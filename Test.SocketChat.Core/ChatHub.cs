using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test.SocketChat.Core
{
    public class ChatHub
    {
        private readonly ConcurrentDictionary<string, (User user, WebSocket webSocket)> _clients = new ConcurrentDictionary<string, (User user, WebSocket webSocket)>();

        public async Task<bool> TryHandleConnect(string nickname, string status, WebSocket webSocket, CancellationToken ct)
        {
            if (status.Length > 30)
            {
                Debug.Fail($"{nickname}'s status is too long.");
                return false;
            }

            var user = new User(nickname, status);
            if (!_clients.TryAdd(nickname, (user, webSocket)))
            {
                Debug.Fail($"Cannot add client with {nickname} id.");
                return false;
            }

            await SendMessageToAllClients($"{nickname} joined.", WebSocketMessageType.Text, ct);
            return true;
        }

        public async Task HandleDisconnect(string nickname, CancellationToken ct)
        {
            if (!_clients.TryRemove(nickname, out _))
            {
                Debug.Fail($"Client with nickname {nickname} not found.");
            }

            await SendMessageToAllClients($"{nickname} disconnected.", WebSocketMessageType.Text, ct);
        }

        public async Task HandleMessage(string nickname, WebSocketMessageType messageType, CancellationToken ct)
        {
            if (!_clients.ContainsKey(nickname))
            {
                Debug.Fail($"Client with nickname {nickname} not found.");
                return;
            }

            var (user, webSocket) = _clients[nickname];
            await HandleMessage(user.Nickname, user.Status, webSocket, messageType, ct);
        }

        private async Task HandleMessage(string nickname, string status, WebSocket webSocket, WebSocketMessageType messageType, CancellationToken ct)
        {
            var receivedMessage = await ReceiveMessage(webSocket, ct);
            if (string.IsNullOrEmpty(receivedMessage) || string.IsNullOrWhiteSpace(receivedMessage))
            {
                return;
            }

            await SendMessageToAllClients($"[{nickname} ({status})]: {receivedMessage}", messageType, ct);
        }

        private async Task<string> ReceiveMessage(WebSocket webSocket, CancellationToken ct)
        {
            var buffer = new byte[1024 * 4];
            await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), ct);
            return webSocket.CloseStatus.HasValue ? null : Encoding.UTF8.GetString(buffer);
        }

        private async Task SendMessageToAllClients(string message, WebSocketMessageType messageType, CancellationToken ct)
        {
            var buffer = new byte[Encoding.UTF8.GetByteCount(message)];
            Encoding.UTF8.GetBytes(message, 0, message.Length, buffer, 0);
            var bufferSegment = new ArraySegment<byte>(buffer, 0, buffer.Length);
            foreach (var (_, socket) in _clients.Values)
            {
                await socket.SendAsync(bufferSegment, messageType, true, ct);
            }
        }
    }
}