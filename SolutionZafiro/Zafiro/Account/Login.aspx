<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Account/SiteLogin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Core.Account.Login" Async="true" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <form runat="server">
        <div class="form-group">
            <label class="sr-only" for="form-username">Username</label>            
            <asp:TextBox ID="txtusuario" runat="server"  class="form-username form-control"  placeholder="Username..." ></asp:TextBox>
        </div>
        <div class="form-group">
            <label class="sr-only" for="form-password">Password</label>
            <asp:TextBox ID="txtclave" runat="server"  class="form-username form-control"  placeholder="Username..." TextMode="Password" ></asp:TextBox>
        </div>
        <asp:Button ID="btnIniciar" runat="server" Text="Iniciar" class="btn" />
    </form>
</asp:Content>
