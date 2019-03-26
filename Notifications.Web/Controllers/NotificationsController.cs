using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notifications.Common.Interfaces;
using Notifications.Common.Models;

namespace NotificationsWeb.Controllers {

   [Route("api/[controller]")]
   [ApiController]
   public class NotificationsController : ControllerBase {
      private readonly INotificationsService _notificationsService;
      private readonly IUserNotificationService _userNotificationservice;

      public NotificationsController(INotificationsService notificationsService, IUserNotificationService userNotificationService) {
         _notificationsService = notificationsService;
         _userNotificationservice = userNotificationService;
      }

      [Route("")]
      [HttpGet]
      public IReadOnlyCollection<NotificationModel> Get() {
         return _notificationsService.GetAllNotifications();
      }

      [Route("{userId}")]
      [HttpGet]
      public IReadOnlyCollection<UserNotification> GetFroUser(int userId) {
         return _userNotificationservice.NotificationsForUser(userId);
      }

      [Route(""), HttpPost]
      public NotificationModel PostNotification(NotificationModel notificationModel) {
         return _notificationsService.AddNotification(notificationModel);
      }
   }
}
