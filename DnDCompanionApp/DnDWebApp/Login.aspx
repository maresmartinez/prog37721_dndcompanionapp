<%@ Page Title="" Language="C#" MasterPageFile="~/DnD.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DnDWebApp.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-5">Login</h1>
    <p>If you do not have an account, <a href="./CreateAccount.aspx">register here</a>.</p>

    <div class="form-group">
        <asp:Label ID="LblUsername" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:Button ID="BtnAuthenticate" runat="server" Text="Sign In" CssClass="btn btn-dark" OnClick="BtnAuthenticate_Click" BorderColor="#d44a34" BackColor="#d44a34" />
</asp:Content>
