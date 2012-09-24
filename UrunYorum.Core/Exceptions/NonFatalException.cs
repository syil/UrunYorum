using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrunYorum.Core.Exceptions
{
    public class NonFatalException : UrunYorumExceptionBase
    {
        public string UserMessage { get; set; }
        public string LogMessage { get; set; }

        public NonFatalException(string message)
            : base(message)
        {
            UserMessage = LogMessage = message;
        }

        public NonFatalException(string userMessage, string logMessage)
            : base(logMessage)
        {
            UserMessage = userMessage;
            LogMessage = logMessage;
        }
    }
}
