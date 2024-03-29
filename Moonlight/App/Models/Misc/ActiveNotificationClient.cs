﻿using System.Net.WebSockets;
using System.Text;
using FirePortal.App.Database.Entities.Notification;

namespace FirePortal.App.Models.Misc;

public class ActiveNotificationClient
{
    public WebSocket WebSocket { get; set; }
    public NotificationClient Client { get; set; }
    
    public async Task SendAction(string action)
    {
        await WebSocket.SendAsync(
            Encoding.UTF8.GetBytes(action),
            WebSocketMessageType.Text,
            WebSocketMessageFlags.EndOfMessage, CancellationToken.None);
    }
}