using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Notifications.Common.Interfaces;
using Notifications.Common.Models;
using Notifications.Web.Hubs;

namespace Notifications.Web.Core {
   public class NotificationBroadcastService : INotificationBroadcast {
      private readonly IHubContext<SignalRNotifications> _hubContext;

      public NotificationBroadcastService(IHubContext<SignalRNotifications> hubContext) {
         _hubContext = hubContext;
      }

      public void BroadcastNotification(int userid, UserNotification userNotification) {
         _hubContext.Clients.All.SendAsync("BroadcastNotification", userid, userNotification);
      }
   }
}
