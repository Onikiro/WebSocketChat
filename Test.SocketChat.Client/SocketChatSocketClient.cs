using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test.SocketChat.Client
{
    public class SocketChatSocketClient : IDisposable
    {
        public event Action<string> OnMessageReceived;

        private const string WebSocketConnectionUrl = "wss://localhost:5001/ws";
        private ClientWebSocket _webSocket;
        private Task _handleSocketTask;

        public bool TryConnect(string nickname, string status)
        {
            var uri = new Uri(WebSocketConnectionUrl + $"?nickname={nickname}&status={status}");
            try
            {
                _webSocket = new ClientWebSocket();
                _webSocket.ConnectAsync(uri, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            _handleSocketTask = Task.Run(HandleSocket);
            _handleSocketTask.ConfigureAwait(false);

            return true;
        }

        public void Disconnect(string nickname)
        {
            _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, $"Client {nickname} disconnected", CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            _webSocket.Dispose();
        }

        public void SendMessage(string message)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            var buffer = new byte[Encoding.UTF8.GetByteCount(message)];
            Encoding.UTF8.GetBytes(message, 0, message.Length, buffer, 0);
            var bufferSegment = new ArraySegment<byte>(buffer, 0, buffer.Length);

            _ = _webSocket.SendAsync(bufferSegment, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task HandleSocket()
        {
            while (_webSocket.State == WebSocketState.Open)
            {
                var bytesReceived = new ArraySegment<byte>(new byte[1024 * 4]);
                var result = await _webSocket.ReceiveAsync(bytesReceived, CancellationToken.None);
                if (bytesReceived.All(b => b == 0))
                {
                    continue;
                }

                var response = Encoding.UTF8.GetString(bytesReceived.Array ?? Array.Empty<byte>(), 0, result.Count);
                if (!string.IsNullOrEmpty(response) && !string.IsNullOrWhiteSpace(response))
                {
                    OnMessageReceived?.Invoke(response);
                }
            }
        }

        public void Dispose()
        {
            _webSocket?.Dispose();
        }
    }
}