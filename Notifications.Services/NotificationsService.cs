using System;
using System.Collections.Generic;
using System.Linq;
using Notifications.Common.Interfaces;
using Notifications.Common.Models;

namespace Notifications.Services {
   public class NotificationsService : INotificationsService {
      private readonly INotificationsAccess _notificationsAccess;
      private readonly IUserNotificationService _userNotificationService;
      private readonly INotificationBroadcast _notificationBroadcast;

      public NotificationsService(INotificationsAccess notificationsAccess,
         IUserNotificationService userNotificationService,
         INotificationBroadcast notificationBroadcast
         ) {

         _notificationsAccess = notificationsAccess;
         _userNotificationService = userNotificationService;
         _notificationBroadcast = notificationBroadcast;
      }

      public IReadOnlyCollection<NotificationModel> GetAllNotifications()
         => _notificationsAccess.GetAllNotifications().ToList();

      public NotificationModel AddNotification(NotificationModel notificationModel) {
         // store it as it is 
         _notificationsAccess.AddNotification(notificationModel);

         // try to save the user's copy 
         var usrNotification = _userNotificationService.AddNotification(notificationModel);

         // try to broadcast it to the user
         _notificationBroadcast.BroadcastNotification(usrNotification.UserId, usrNotification);

         return notificationModel;
      }
   }
}
