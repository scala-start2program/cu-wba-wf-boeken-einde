using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wba.Boeken.Lib.Entities;
using Wba.Boeken.Lib.Services;

namespace Wba.Boeken.Web
{
    public partial class Uitgevers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BuildGrid();
                panNewEdit.Visible = false;
            }
        }
        private void BuildGrid()
        {
            grdUitgevers.DataSource = UitgeverService.GetUitgevers();
            grdUitgevers.DataBind();
        }
        protected void lnkAddUitgever_Click(object sender, EventArgs e)
        {
            hidID.Value = "";
            panMain.CssClass = "inactive";
            panMain.Enabled = false;
            panNewEdit.Visible = true;

            lblHeader.Text = "Een nieuwe uitgever toevoegen";
            txtNaam.Text = "";
            txtNaam.Focus();
        }
        protected void lnkEditUitgever_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            hidID.Value = lnk.CommandArgument;
            Uitgever uitgever = UitgeverService.FindUitgever(lnk.CommandArgument);
            if (uitgever != null)
            {
                panMain.CssClass = "inactive";
                panMain.Enabled = false;
                panNewEdit.Visible = true;

                lblHeader.Text = "Een uitgever wijzigen";
                txtNaam.Text = uitgever.Naam;
                txtNaam.Focus();
            }
        }
        protected void lnkDeleteUitgever_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            Uitgever uitgever = UitgeverService.FindUitgever(lnk.CommandArgument);
            UitgeverService.Delete(uitgever);
            BuildGrid();
        }
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            Uitgever uitgever;
            if (hidID.Value == "")
            {
                uitgever = new Uitgever();
            }
            else
            {
                uitgever = UitgeverService.FindUitgever(hidID.Value);
            }
            uitgever.Naam = txtNaam.Text;
            if (hidID.Value == "")
            {
                UitgeverService.Add(uitgever);
            }
            else
            {
                UitgeverService.Update(uitgever);
            }
            BuildGrid();
            panNewEdit.Visible = false;
            panMain.CssClass = "active";
            panMain.Enabled = true;
        }
        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            panNewEdit.Visible = false;
            panMain.CssClass = "active";
            panMain.Enabled = true;
        }
    }
}