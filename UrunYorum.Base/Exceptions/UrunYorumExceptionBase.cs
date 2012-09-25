using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrunYorum.Base.Exceptions
{
    public class UrunYorumExceptionBase : Exception
    {
        public UrunYorumExceptionBase(string message)
            : base(message)
        {

        }

        public virtual string GetLogMessageString()
        {
            return ToString();
        }

        public virtual void LogException()
        {
            
        }
    }
}
