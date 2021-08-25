<%@ Page Title="" Language="C#" MasterPageFile="~/Bib.Master" AutoEventWireup="true" CodeBehind="Auteurs.aspx.cs" Inherits="Wba.Boeken.Web.Auteurs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterContent" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <div class="jumbotron">
        <h1>Auteurs</h1>
    </div>
    <asp:Panel ID="panMain" runat="server">
        <div class="container">
            <div class="row" style="margin-bottom: 10px;">
                <asp:LinkButton ID="lnkAddAuteur" runat="server" CssClass="btn btn-primary" OnClick="lnkAddAuteur_Click">Nieuwe auteur</asp:LinkButton>
            </div>
            <div class="row">
                <div class="table-responsive">
                    <asp:GridView ID="grdAuteurs" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                        <columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblNaam" runat="server" Text='<%# Eval("naam") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Naam
                                </HeaderTemplate>
                                <HeaderStyle CssClass="bg-dark text-light" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditAuteur" runat="server"
                                        CommandArgument='<%# Eval("ID") %>'
                                        CssClass="btn btn-sm btn-warning"
                                        ToolTip="Wijzig deze auteur"
                                        OnClick="lnkEditAuteur_Click">
                                        <i class="fas fa-pencil-alt"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle CssClass="bg-dark text-light" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDeleteAuteur" runat="server"
                                        CommandArgument='<%# Eval("ID") %>'
                                        CssClass="btn btn-sm btn-danger"
                                        ToolTip="Verwijder deze auteur"
                                        OnClick="lnkDeleteAuteur_Click"
                                        OnClientClick="return confirm('Ben je zeker dat deze auteur mag verwijderd worden?');">
                                        <i class="fas fa-trash"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle CssClass="bg-dark text-light" />
                            </asp:TemplateField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panNewEdit" runat="server" CssClass="popup">
        <div class="card ">
            <div class="card-header bg-dark text-light">
                <h2>
                    <asp:Label ID="lblHeader" runat="server" Text="Auteur toevoegen"></asp:Label></h2>
            </div>
            <div class="card-body">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text" style="width: 150px;">Naam : </span>
                    </div>
                    <asp:TextBox ID="txtNaam" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="card-footer bg-light">
                <div class="btn-group">
                    <asp:LinkButton ID="lnkSave" runat="server"
                        CssClass="btn btn-success" OnClick="lnkSave_Click">
                        <i class="far fa-save"></i>
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkCancel" runat="server"
                        CssClass="btn btn-danger" OnClick="lnkCancel_Click">
                        <i class="fas fa-undo"></i>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
