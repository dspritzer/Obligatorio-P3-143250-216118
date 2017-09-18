using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Dominio;
using Persistencia;
using System.Configuration;

namespace Presentacion
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            ActiveRecord<Proveedor>.StringConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;
            ActiveRecord<Servicio>.StringConexion = ConfigurationManager.ConnectionStrings["miConDaniel"].ConnectionString;

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}