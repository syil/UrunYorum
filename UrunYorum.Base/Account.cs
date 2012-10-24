using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrunYorum.Base
{
    public abstract class AccountInfoBase
    {
        public string Key { get; set; }
        public string RealName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
