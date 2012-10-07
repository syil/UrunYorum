using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrunYorum.Base.Interfaces
{
    public interface IConfigurationManager
    {
        object GetConfigValue(string configKey);
    }
}
