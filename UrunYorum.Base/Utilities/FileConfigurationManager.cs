using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace UrunYorum.Base.Utilities
{
    public class FileConfigurationManager : Interfaces.IConfigurationManager
    {
        public FileConfigurationManager()
        {

        }

        public object GetConfigValue(string configKey)
        {
            return ConfigurationManager.AppSettings.Get(configKey);
        }
    }
}
