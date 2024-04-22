<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="GestionArriendos.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container ">

        <div class="form-group">
            <asp:Label ID="lbl1" runat="server" CssClass="control-label" Text="Nombre"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lbl2" runat="server" CssClass="control-label" Text="Dirección"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <div class="radio">
                <label>
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Soy Arrendatario" CssClass="radio-inline" />
                </label>
            </div>
            <div class="radio">
                <label>
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Soy Arrendador" CssClass="radio-inline" />
                </label>
            </div>
        </div>

        <asp:Button ID="Btn1" runat="server" class="btn-registro" CssClass="btn btn-primary" Text="Registrarse" />

    </div>

</asp:Content>

