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
    public partial class Auteurs : System.Web.UI.Page
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
            grdAuteurs.DataSource = AuteurService.GetAuteurs();
            grdAuteurs.DataBind();
        }
        protected void lnkAddAuteur_Click(object sender, EventArgs e)
        {
            hidID.Value = "";
            panMain.CssClass = "inactive";
            panMain.Enabled = false;
            panNewEdit.Visible = true;

            lblHeader.Text = "Een nieuwe auteur toevoegen";
            txtNaam.Text = "";
            txtNaam.Focus();
        }

        protected void lnkEditAuteur_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            hidID.Value = lnk.CommandArgument;
            Auteur auteur = AuteurService.FindAuteur(lnk.CommandArgument);
            if (auteur != null)
            {
                panMain.CssClass = "inactive";
                panMain.Enabled = false;
                panNewEdit.Visible = true;

                lblHeader.Text = "Een auteur wijzigen";
                txtNaam.Text = auteur.Naam;
                txtNaam.Focus();
            }
        }

        protected void lnkDeleteAuteur_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            Auteur auteur = AuteurService.FindAuteur(lnk.CommandArgument);
            AuteurService.Delete(auteur);
            BuildGrid();
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            Auteur auteur;
            if (hidID.Value == "")
            {
                auteur = new Auteur();
            }
            else
            {
                auteur = AuteurService.FindAuteur(hidID.Value);
            }
            auteur.Naam = txtNaam.Text;
            if (hidID.Value == "")
            {
                AuteurService.Add(auteur);
            }
            else
            {
                AuteurService.Update(auteur);
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