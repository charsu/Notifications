using System;
using System.Collections.Generic;
using System.Text;
using Notifications.Common.Models;

namespace Notifications.Common.Interfaces {
   public interface INotificationBroadcast {
      void BroadcastNotification(int userid, UserNotification userNotification);
   }
}
