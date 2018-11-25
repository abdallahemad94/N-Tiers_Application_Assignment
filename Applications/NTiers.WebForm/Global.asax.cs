using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace NTiers.WebForm
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery-3.3.1.js",
                    DebugPath = "~/scripts/jquery-3.3.1.js",
                    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.3.1.js",
                    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.3.1.js"
                });
        }
    }
}