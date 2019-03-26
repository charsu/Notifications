using System;
using System.Collections.Generic;
using System.Text;

namespace Notifications.Common.Models.NotificationData {
   public class CanceledNotificationData : INotificationData {
      public DateTime AppointmentDateTime { get; set; }
      public string FirstName { get; set; }
      public string OrganisationName { get; set; }
      public string Reason { get; set; }
   }
}
