using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Notifications.Common.Interfaces;
using Notifications.Common.Models;
using Notifications.Common.Models.NotificationData;
using Notifications.DataAccess.Entities;

namespace Notifications.DataAccess.Access {
   public class NotificationsAccess : INotificationsAccess {
      private readonly NotificationsDbContext _dbContext;

      public NotificationsAccess(NotificationsDbContext dbContext) {
         _dbContext = dbContext;
      }

      public IEnumerable<NotificationModel> GetAllNotifications() {
         return _dbContext.Notifications.Select(x => new NotificationModel() {
            Id = x.Id,
         });
      }

      public NotificationModel AddNotification(NotificationModel notificationModel) {
         //todo : add a better way of converting the dtos -> entities (autommaper)

         if (notificationModel.Type == Common.Models.Enums.EventType.AppointmentCancelled) {
            var canceledNotificationdata = (notificationModel.Data as JObject).ToObject<CanceledNotificationData>();
            var entity = new NotificationEntity() {
               EventType = notificationModel.Type,
               FirstName = canceledNotificationdata.FirstName,
               AppointmentDateTime = canceledNotificationdata.AppointmentDateTime,
               OrganisationName = canceledNotificationdata.OrganisationName,
               Reason = canceledNotificationdata.Reason,
               CreationTime = DateTime.Now
            };

            _dbContext.Notifications.Add(entity);
            _dbContext.SaveChanges();

            notificationModel.Id = entity.Id;
            return notificationModel;
         }

         // we failed to find all suitable data inside the model , then throw an error 
         // todo : add a better error handling with base class and domain errors ... 
         throw new ArgumentException($"Invalid input provided", nameof(NotificationModel));
      }
   }
}
