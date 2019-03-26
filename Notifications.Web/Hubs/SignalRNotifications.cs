using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Notifications.Web.Hubs {
   public class SignalRNotifications : Hub {
      public async Task SendNotifications(string user, string message) {
         await Clients.All.SendAsync("ReceiveNotification", user, message);
      }
   }
}
