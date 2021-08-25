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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BuildFilters();
                BuildGrid();
                panNewEdit.Visible = false;
            }
        }
        private void BuildGrid()
        {
            Auteur auteur = null;
            Uitgever uitgever = null;
            if (cmbFilterAuteur.SelectedIndex != 0) auteur = AuteurService.FindAuteur(cmbFilterAuteur.SelectedValue);
            if (cmbFilterUitgever.SelectedIndex != 0) uitgever = UitgeverService.FindUitgever(cmbFilterUitgever.SelectedValue);

            grdBoeken.DataSource = BoekService.GetBoeken(auteur, uitgever);
            grdBoeken.DataBind();
        }
        private void BuildFilters()
        {
            cmbFilterAuteur.DataValueField = "id";
            cmbFilterAuteur.DataTextField = "naam";
            cmbFilterUitgever.DataValueField = "id";
            cmbFilterUitgever.DataTextField = "naam";

            cmbSelectAuteur.DataValueField = "id";
            cmbSelectAuteur.DataTextField = "naam";
            cmbSelectUitgever.DataValueField = "id";
            cmbSelectUitgever.DataTextField = "naam";

            cmbFilterAuteur.DataSource = AuteurService.GetAuteurs();
            cmbFilterAuteur.DataBind();
            cmbFilterUitgever.DataSource = UitgeverService.GetUitgevers();
            cmbFilterUitgever.DataBind();

            cmbSelectAuteur.DataSource = AuteurService.GetAuteurs();
            cmbSelectAuteur.DataBind();
            cmbSelectUitgever.DataSource = UitgeverService.GetUitgevers();
            cmbSelectUitgever.DataBind();

            cmbFilterAuteur.Items.Insert(0, "Alle auteurs");
            cmbFilterUitgever.Items.Insert(0, "Alle uitgevers");

            cmbFilterAuteur.SelectedIndex = 0;
            cmbFilterUitgever.SelectedIndex = 0;
            spanUitgeverFilter.Attributes.Add("class", "input-group-text");
            spanAuteurFilter.Attributes.Add("class", "input-group-text");

        }
        protected void lnkClearFilterUitgever_Click(object sender, EventArgs e)
        {
            cmbFilterUitgever.SelectedIndex = 0;
            spanUitgeverFilter.Attributes.Add("class", "input-group-text");
            BuildGrid();
        }

        protected void lnkClearFilterAuteur_Click(object sender, EventArgs e)
        {
            cmbFilterAuteur.SelectedIndex = 0;
            spanAuteurFilter.Attributes.Add("class", "input-group-text");
            BuildGrid();
        }
        protected void cmbFilterAuteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterAuteur.SelectedIndex == 0)
                spanAuteurFilter.Attributes.Add("class", "input-group-text");
            else
                spanAuteurFilter.Attributes.Add("class", "input-group-text bg-success text-light");
            BuildGrid();
        }

        protected void cmbFilterUitgever_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterUitgever.SelectedIndex == 0)
                spanUitgeverFilter.Attributes.Add("class", "input-group-text");
            else
                spanUitgeverFilter.Attributes.Add("class", "input-group-text bg-success text-light");
            BuildGrid();
        }

        protected void lnkAddBoek_Click(object sender, EventArgs e)
        {
            hidID.Value = "";
            panMain.CssClass = "inactive";
            panMain.Enabled = false;
            panNewEdit.Visible = true;

            lblHeader.Text = "Een nieuw boek toevoegen";
            txtTitel.Text = "";
            txtJaar.Text = DateTime.Now.Year.ToString();

            txtTitel.Focus();
        }

        protected void lnkEditBoek_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            hidID.Value = lnk.CommandArgument;
            Boek boek = BoekService.FindBoek(lnk.CommandArgument);
            if(boek != null)
            {
                panMain.CssClass = "inactive";
                panMain.Enabled = false;
                panNewEdit.Visible = true;

                lblHeader.Text = "Een boek wijzigen";
                txtTitel.Text = boek.Titel;
                cmbSelectAuteur.SelectedValue = boek.AuteurId;
                cmbSelectUitgever.SelectedValue = boek.UitgeverId;
                txtJaar.Text = boek.Jaar.ToString();
                txtTitel.Focus();

            }
        }

        protected void lnkDeleteBoek_Click(object sender, EventArgs e)
        {
            // we zoeken het boek dat we willen wissen
            LinkButton lnk = (LinkButton)sender;
            Boek boek = BoekService.FindBoek(lnk.CommandArgument);
            // we verwijderen de persoon uit de List
            BoekService.Delete(boek);
            // we vullen de GridView terug met de nieuwe situatie 
            BuildGrid();
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            Boek boek;
            if (hidID.Value == "")
            {
                // is hidID.Value == "" dan gaat het om een nieuw boek
                boek = new Boek();
            }
            else
            {
                // anders is het een bestaand boek dat we moeten opzoeken
                boek = BoekService.FindBoek(hidID.Value);
            }
            boek.Titel = txtTitel.Text;
            boek.AuteurId = cmbSelectAuteur.SelectedValue;
            boek.UitgeverId = cmbSelectUitgever.SelectedValue;
            int.TryParse(txtJaar.Text, out int jaar);
            boek.Jaar = jaar;
            if (hidID.Value == "")
            {
                BoekService.Add(boek);
            }
            else
            {
                BoekService.Update(boek);
            }
            // we vullen de GridView terug met de nieuwe situatie 
            BuildGrid();
            // we zetten visueel weer alles in orde
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