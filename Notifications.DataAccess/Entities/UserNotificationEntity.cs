using System;
using System.Collections.Generic;
using System.Text;
using Notifications.Common.Models.Enums;

namespace Notifications.DataAccess.Entities {
   public class UserNotificationEntity {
      public Guid Id { get; set; }
      public int UserId { get; set; }
      public EventType EventType { get; set; }
      public string Body { get; set; }
      public string Title { get; set; }
   }
}
