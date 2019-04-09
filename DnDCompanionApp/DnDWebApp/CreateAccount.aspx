<%@ Page Title="" Language="C#" MasterPageFile="~/DnD.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="DnDWebApp.CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-5">Register for an account</h1>
    <p>Create an account for the D&D Companion App.</p>

    <div class="form-group">
        <asp:Label ID="LblUsername" runat="server" Text="Username"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqUsername" runat="server" ControlToValidate="TxtUsername" Display="Dynamic" ErrorMessage="(Username must have a value)"
            ForeColor="#D44A34" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="LblFullName" runat="server" Text="Full Name"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqFullName" runat="server" ControlToValidate="TxtFullName" Display="Dynamic" ErrorMessage="(Full Name must have a value)"
            ForeColor="#D44A34" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TxtFullName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqPassword" runat="server" ControlToValidate="TxtPassword" Display="Dynamic" ErrorMessage="(Password must have a value)"
            ForeColor="#D44A34" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CmpPasswords" runat="server" ControlToCompare="TxtPasswordRepeat" ControlToValidate="TxtPassword" Display="Dynamic"
            ErrorMessage="(Passwords must match)" ForeColor="#D44A34" ValidationGroup="CreateAccount"></asp:CompareValidator>
        <asp:RegularExpressionValidator ID="RegexPassword" runat="server" ControlToValidate="TxtPassword" Display="Dynamic"
            ErrorMessage="(Password must have at least 6 characters)" ForeColor="#D44A34" ValidationExpression="^.{6,}$"
            ValidationGroup="CreateAccount"></asp:RegularExpressionValidator>
        <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="LblPasswordRepeat" runat="server" Text="Confirm Password"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqConfirmPassword" runat="server" ControlToValidate="TxtPasswordRepeat" Display="Dynamic"
            ErrorMessage="(Confirm password must have a value)" ForeColor="#D44A34" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TxtPasswordRepeat" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:Button ID="BtnCreateAccount" runat="server" Text="Create Account" CssClass="btn btn-dark" OnClick="BtnCreateAccount_Click" ValidationGroup="CreateAccount" />
    <asp:Label ID="LblError" runat="server" ForeColor="#D44A34" Text=""></asp:Label>

</asp:Content>
