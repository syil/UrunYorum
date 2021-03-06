﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Base.Utilities;

namespace UrunYorum.Base.Exceptions
{
    public class RouteMapCannotResolvedException : NonFatalException
    {
        public string RequestedSlug { get; set; }
        public string RequestedType { get; set; }

        public RouteMapCannotResolvedException()
            : base(ResourceManager.GetString("Exceptions.DefaultMessages.RouteMapCannotResolved"))
        {
            
        }

        public RouteMapCannotResolvedException(string message)
            : base(message)
        {

        }

        public RouteMapCannotResolvedException(string userMessage, string logMessage)
            : base(userMessage, logMessage)
        {

        }
    }
}
