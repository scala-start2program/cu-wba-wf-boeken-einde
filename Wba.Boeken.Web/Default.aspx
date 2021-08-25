<%@ Page Title="" Language="C#" MasterPageFile="~/Bib.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Wba.Boeken.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterContent" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <div class="jumbotron">
        <h1>Boeken</h1>
    </div>
    <asp:Panel ID="panMain" runat="server">
        <div class="container">
            <div class="row" style="margin-bottom: 10px;">
                <table>
                    <tr>
                        <td style="padding-right: 20px;">
                            <asp:LinkButton ID="lnkAddBoek" runat="server" CssClass="btn btn-primary" OnClick="lnkAddBoek_Click">Nieuw boek</asp:LinkButton>
                        </td>
                        <td style="padding-right: 5px;">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" runat="server" id="spanAuteurFilter">Auteurfilter :</span>
                                </div>

                                <asp:DropDownList ID="cmbFilterAuteur" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbFilterAuteur_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                <div class="input-group-append">
                                    <asp:LinkButton ID="lnkClearFilterAuteur" OnClick="lnkClearFilterAuteur_Click" runat="server" CssClass="btn btn-sm btn-light">
                                        <i class="far fa-window-close" style="font-size:20pt;"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>

                        </td>
                        <td>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" runat="server" id="spanUitgeverFilter">Uitgeverfilter :</span>
                                </div>
                                <asp:DropDownList ID="cmbFilterUitgever" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbFilterUitgever_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                <div class="input-group-append">
                                    <asp:LinkButton ID="lnkClearFilterUitgever" OnClick="lnkClearFilterUitgever_Click" runat="server" CssClass="btn btn-sm btn-light">
                                        <i class="far fa-window-close" style="font-size:20pt;"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="row">
                <div class="table-responsive">
                    <asp:GridView ID="grdBoeken" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblTitel" runat="server" Text='<%# Eval("titel") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Naam
                                </HeaderTemplate>
                                <HeaderStyle CssClass="bg-dark text-light" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblAuteursNaam" runat="server" Text='<%# Eval("auteursnaam") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Auteur
                                </HeaderTemplate>
                                <HeaderStyle CssClass="bg-dark text-light" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblUitgeversNaam" runat="server" Text='<%# Eval("uitgeversnaam") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Uitgever
                                </HeaderTemplate>
                                <HeaderStyle CssClass="bg-dark text-light" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblJaar" runat="server" Text='<%# Eval("Jaar") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Jaar uitgifte
                                </HeaderTemplate>
                                <HeaderStyle CssClass="bg-dark text-light" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEditBoek" runat="server"
                                        CommandArgument='<%# Eval("ID") %>'
                                        CssClass="btn btn-sm btn-warning"
                                        ToolTip="Wijzig dit boek"
                                        OnClick="lnkEditBoek_Click">
                                        <i class="fas fa-pencil-alt"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle CssClass="bg-dark text-light" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDeleteBoek" runat="server"
                                        CommandArgument='<%# Eval("ID") %>'
                                        CssClass="btn btn-sm btn-danger"
                                        ToolTip="Verwijder dit boek"
                                        OnClick="lnkDeleteBoek_Click"
                                        OnClientClick="return confirm('Ben je zeker dat dit boek mag verwijderd worden?');">
                                        <i class="fas fa-trash"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle CssClass="bg-dark text-light" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panNewEdit" runat="server" CssClass="popup">
        <div class="card ">
            <div class="card-header bg-dark text-light">
                <h2>
                    <asp:Label ID="lblHeader" runat="server" Text="Boek toevoegen"></asp:Label></h2>
            </div>
            <div class="card-body">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text" style="width: 150px;">Titel : </span>
                    </div>
                    <asp:TextBox ID="txtTitel" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text" style="width: 150px;">Auteur : </span>
                    </div>
                    <asp:DropDownList ID="cmbSelectAuteur" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text" style="width: 150px;">Geboortedatum : </span>
                    </div>
                    <asp:DropDownList ID="cmbSelectUitgever" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text" style="width: 150px;">Jaar uitgifte : </span>
                    </div>
                    <asp:TextBox ID="txtJaar" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtJaar"
                        Type="Integer"
                        MinimumValue="0"
                        MaximumValue="2050"
                        ErrorMessage="Selecteer een geldig uitgiftejaar"></asp:RangeValidator>
                </div>
            </div>
            <div class="card-footer bg-light">
                <div class="btn-group">
                    <asp:LinkButton ID="lnkSave" runat="server"
                        CssClass="btn btn-success" OnClick="lnkSave_Click">
                            <i class="far fa-save" ></i>
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
