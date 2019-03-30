<%@ Page Title="" Language="C#" MasterPageFile="~/DnD.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="DnDWebApp.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-5">Register for an account</h1>
    <p>Create an account for the D&D Companion App.</p>

    <div class="form-group">
        <asp:Label ID="LblUsername" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="LblFullName" runat="server" Text="Full Name"></asp:Label>
        <asp:TextBox ID="TxtFullName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="LblPasswordRepeat" runat="server" Text="Confirm Password"></asp:Label>
        <asp:TextBox ID="TxtPasswordRepeat" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:Button ID="BtnCreateAccount" runat="server" Text="Create Account" CssClass="btn btn-dark" OnClick="BtnCreateAccount_Click" />

</asp:Content>
