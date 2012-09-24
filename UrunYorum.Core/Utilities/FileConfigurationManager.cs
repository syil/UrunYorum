using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Core.Base;
using System.Configuration;

namespace UrunYorum.Core.Utilities
{
    public class FileConfigurationManager : IConfigurationManager
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
