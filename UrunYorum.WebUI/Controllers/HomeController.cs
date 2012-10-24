using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYorum.Data.Engine.Repositories;
using UrunYorum.Core;
using UrunYorum.Data.Contractor;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Management;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Data.Entity;
using UrunYorum.Data.Engine;
using Microsoft.Practices.Unity;

namespace UrunYorum.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        [Dependency]
        public UserDataService UserDataService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Initialize()
        {
            try
            {
                Database.SetInitializer(new UrunYorumDbInitializer());
                UserDataService.Find(u => true);

                InitAspNetMembership();
            }
            catch (Exception exc)
            {
                ViewBag.HasError = true;
                ViewBag.ErrorMessage = exc.Message;
            }

            return View();
        }

        private void InitAspNetMembership()
        {
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings[SystemConstants.ConnectionStringName];
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder() { ConnectionString = connectionString.ConnectionString };

            try
            {
                SqlServices.Install(connectionStringBuilder.DataSource, connectionStringBuilder.InitialCatalog, SqlFeatures.Membership);
            }
            catch (Exception exc)
            {
                bool rethrow = ExceptionPolicy.HandleException(exc, SystemConstants.ExceptionLogPolicyName);
                if (rethrow)
                    throw;
            }
        }
    }
}
