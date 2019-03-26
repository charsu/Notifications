using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Notifications.Common.Interfaces;
using Notifications.Common.Models;
using Notifications.DataAccess.Entities;

namespace Notifications.DataAccess.Access {
   public class UserNotificationService : IUserNotificationService {
      private readonly NotificationsDbContext _dbContext;

      public UserNotificationService(NotificationsDbContext dbContext) {
         _dbContext = dbContext;
      }

      public IReadOnlyCollection<UserNotification> NotificationsForUser(int userId)
         => _dbContext.Set<UserNotificationEntity>()
               .Where(x => x.UserId == userId)
               .Select(e => Map<UserNotificationEntity, UserNotification>(e))
               .ToList()
               .AsReadOnly();

      public UserNotification AddNotification(NotificationModel notificationModel) {
         // todo add coherent error handling 
         var notificationType = notificationModel.Type;
         var template = _dbContext.Set<TemplateEntity>().FirstOrDefault(x => x.EventType == notificationType);
         if (template != null) {
            var entity = new UserNotificationEntity() {
               Body = FillTemplate(notificationModel.Data as JObject, template.Body),
               Title = FillTemplate(notificationModel.Data as JObject, template.Title),
               EventType = notificationModel.Type,
               UserId = notificationModel.UserId
            };

            _dbContext.Set<UserNotificationEntity>().Add(entity);
            _dbContext.SaveChanges();

            return Map<UserNotificationEntity, UserNotification>(entity);
         }

         //something is wrong ?!?
         throw new Exception("Unhandled case ...");
      }

      /// <summary>
      /// raw model mapping ( to use a more adv framewrok like automapper)
      /// </summary>
      /// <typeparam name="TIn"></typeparam>
      /// <typeparam name="TOut"></typeparam>
      /// <param name="input"></param>
      /// <returns></returns>
      internal TOut Map<TIn, TOut>(TIn input) where TOut : class {
         if (typeof(TIn) == typeof(UserNotificationEntity) && typeof(TOut) == typeof(UserNotification)) {
            var entity = input as UserNotificationEntity;
            return new UserNotification() {
               Body = entity.Body,
               EventType = entity.EventType,
               Id = entity.Id,
               Title = entity.Title,
               UserId = entity.UserId
            } as TOut;
         }

         return default(TOut);
      }

      internal string FillTemplate(JObject input, string template) {
         var templatedText = template;

         foreach (JProperty property in input.Properties()) {
            var value = property.Value?.ToString() ?? string.Empty;
            templatedText = templatedText.Replace($"{{{property.Name}}}", value);
         }

         return templatedText;
      }

      internal string FillTemplate(object input, string template) {
         if (input == null || string.IsNullOrEmpty(template))
            return null;

         // todo : 
         // - we need to cache the type reflection in order to inrease performance 
         // - we need to use StringBuilder to optimize memory fragmentation
         var templatedText = template;
         var type = input.GetType();
         foreach (var prop in type.GetProperties()) {
            var value = prop.GetValue(input)?.ToString() ?? string.Empty;
            templatedText = templatedText.Replace($"{{{prop.Name}}}", value);
         }

         return templatedText;
      }
   }
}
