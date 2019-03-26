﻿using System;
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

      public NotificationsController(INotificationsService notificationsService) {
         this._notificationsService = notificationsService;
      }

      [Route("")]
      [HttpGet]
      public IReadOnlyCollection<NotificationModel> Get() {
         return _notificationsService.GetAllNotifications();
      }

      [Route(""), HttpPost]
      public NotificationModel PostNotification(NotificationModel notificationModel) {
         return _notificationsService.AddNotification(notificationModel);
      }
   }
}