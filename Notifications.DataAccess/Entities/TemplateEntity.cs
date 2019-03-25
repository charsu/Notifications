using System;
using System.Collections.Generic;
using System.Text;
using Notifications.DataAccess.Entities.Enums;

namespace Notifications.DataAccess.Entities {
   public class TemplateEntity {
      public Guid Id { get; set; }
      public EventType EventType { get; set; }
      public string Body { get; set; }
      public string Title { get; set; }
   }
}
