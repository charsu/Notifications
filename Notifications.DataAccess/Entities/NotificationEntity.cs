using System;
using Notifications.Common.Models;
using Notifications.DataAccess.Entities.Enums;

namespace Notifications.DataAccess.Entities {
   public class NotificationEntity {
      public Guid Id { get; set; }
      public EventType EventType { get; set; }
      public DateTime AppointmentDateTime { get; set; }
      public string FirstName { get; set; }
      public string OrganisationName { get; set; }
      public string Reason { get; set; }
   }
}
