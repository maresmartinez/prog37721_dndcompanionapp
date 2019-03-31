<%@ Page Title="" Language="C#" MasterPageFile="~/DnD.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="DnDWebApp.Users.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-5">Profile</h1>
    <p class="lead">Here are your user details.</p>
    <table class="table table-striped table-bordered col-md-5">
        <tbody>
            <tr>
                <th scope="row">Username</th>
                <td id="Username" runat="server"></td>
            </tr>
            <tr>
                <th scope="row">Full Name</th>
                <td id="FullName" runat="server"></td>
            </tr>
        </tbody>
    </table>
</asp:Content>
