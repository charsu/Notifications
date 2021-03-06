﻿using System;
using System.Collections.Generic;
using System.Text;
using Notifications.Common.Models.Enums;

namespace Notifications.Common.Models {
   public class NotificationModel {
      public Guid? Id { get; set; }
      public int UserId { get; set; }
      public EventType Type { get; set; }
      public object Data { get; set; }
   }
}
