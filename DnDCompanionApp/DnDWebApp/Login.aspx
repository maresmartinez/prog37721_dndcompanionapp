<%@ Page Title="" Language="C#" MasterPageFile="~/DnD.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Login.aspx.cs" Inherits="DnDWebApp.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-5">Login</h1>
    <p>If you do not have an account, <a href="./CreateAccount.aspx">register here</a>.</p>

    <div id="Registered" runat="server" class="alert alert-success" role="alert" visible="false">
        Registration Succcessful! You may now login.
    </div>

    <asp:Label ID="LblFail" runat="server" ForeColor="#983625"></asp:Label>
    
    <div class="form-group">
        <asp:Label ID="LblUsername" runat="server" Text="Username"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqUsername" runat="server" ControlToValidate="TxtUsername" Display="Dynamic"
            ErrorMessage="(Username must have a value)" ForeColor="#D44A34" ValidationGroup="Login"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" ValidationGroup="SignIn"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqPassword" runat="server" ControlToValidate="TxtPassword" Display="Dynamic"
            ErrorMessage="(Password must have a value)" ForeColor="#D44A34" ValidationGroup="Login"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control" ValidationGroup="SignIn"></asp:TextBox>
    </div>

    <asp:Button ID="BtnAuthenticate" runat="server" Text="Sign In" CssClass="btn btn-dark" OnClick="BtnAuthenticate_Click"
        BorderColor="#d44a34" BackColor="#d44a34" ValidationGroup="SignIn" />
</asp:Content>
