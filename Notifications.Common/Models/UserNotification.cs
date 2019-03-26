using System;
using System.Collections.Generic;
using System.Text;
using Notifications.Common.Models.Enums;

namespace Notifications.Common.Models {
   public class UserNotification {
      public Guid Id { get; set; }
      public int UserId { get; set; }
      public EventType EventType { get; set; }
      public string Body { get; set; }
      public string Title { get; set; }
   }
}
