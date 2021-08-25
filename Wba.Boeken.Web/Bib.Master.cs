using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wba.Boeken.Web
{
    public partial class Bib : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mnuBoeken.Attributes["class"] = "nav-item";
            mnuAuteurs.Attributes["class"] = "nav-item";
            mnuUitgevers.Attributes["class"] = "nav-item";

            string pageName = this.Page.Request.FilePath.ToUpper();
            if (pageName == "/DEFAULT.ASPX")
            {
                mnuBoeken.Attributes["class"] = "nav-item active";
            }
            else if (pageName == "/AUTEURS.ASPX")
            {
                mnuAuteurs.Attributes["class"] = "nav-item active";
            }
            else if (pageName == "/UITGEVERS.ASPX")
            {
                mnuUitgevers.Attributes["class"] = "nav-item active";
            }
        }
    }
}