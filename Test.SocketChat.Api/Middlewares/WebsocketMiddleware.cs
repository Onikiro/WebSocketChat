using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Test.SocketChat.Core;

namespace Test.SocketChat.Api.Middlewares
{
    public class WebsocketMiddleware : IMiddleware
    {
        private readonly ChatHub _chatHub;

        public WebsocketMiddleware(ChatHub chatHub)
        {
            _chatHub = chatHub;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                await next.Invoke(context);
                return;
            }

            var ct = context.RequestAborted;
            using var currentSocket = await context.WebSockets.AcceptWebSocketAsync();

            var nickname = context.Request.Query["nickname"].ToString();
            var status = context.Request.Query["status"].ToString();

            if (!await _chatHub.TryHandleConnect(nickname, status, currentSocket, ct))
            {
                return;
            }

            while (!currentSocket.CloseStatus.HasValue)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }

                await _chatHub.HandleMessage(nickname, WebSocketMessageType.Text, ct);
            }

            await currentSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, currentSocket.CloseStatusDescription, ct);

            await _chatHub.HandleDisconnect(nickname, ct);
        }
    }
}