using System;
using System.Collections.Generic;
using System.Text;
using Notifications.Common.Models;

namespace Notifications.Common.Interfaces {
   public interface IUserNotificationService {
      UserNotification AddNotification(NotificationModel notificationModel);
   }
}
