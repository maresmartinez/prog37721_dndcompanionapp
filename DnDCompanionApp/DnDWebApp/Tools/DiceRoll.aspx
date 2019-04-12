<%@ Page Title="" Language="C#" MasterPageFile="~/DnD.Master" AutoEventWireup="true" CodeBehind="DiceRoll.aspx.cs" Inherits="DnDWebApp.Tools.DiceRoll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Ref: taken from https://holyxseis.files.wordpress.com/ -->
    <img src="https://holyxseis.files.wordpress.com/2019/01/headerphoto-e1547443927473.jpg?w=736" class="img-fluid" alt="D&D Header">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-5">Dice Roll</h1>
    <p class="lead">Generate your dice rolls.</p>
    <div class="card">
        <div class="card-header">
            <asp:Label ID="LblResultInstructions" runat="server" Text="Your result..."></asp:Label>
        </div>
        <div class="card-body">
            <asp:Label ID="LblResult" runat="server" Text="0" CssClass="display-3"></asp:Label>
        </div>
    </div>
    <br />
    <div class="form-group">
        <asp:Label ID="LblDice" runat="server" Text="Choose Dice to roll"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DDDice" Display="Dynamic" ErrorMessage="(Dice is required)" ForeColor="#D44A34" ValidationGroup="Roll"></asp:RequiredFieldValidator>
        <asp:DropDownList ID="DDDice" runat="server" CssClass="custom-select"></asp:DropDownList>
    </div>
    <div class="form-group">
        <asp:Label ID="LblNumRolls" runat="server" Text="Choose how many times to roll"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqNumRolls" runat="server" ControlToValidate="TxtNumRolls" Display="Dynamic" ErrorMessage="(Number of rolls is required)" ForeColor="#D44A34" ValidationGroup="Roll"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RngNumRolls" runat="server" ControlToValidate="TxtNumRolls" Display="Dynamic" ErrorMessage="(Number of rolls must be positive)" ForeColor="#D44A34" MaximumValue="9999999" MinimumValue="1" ValidationGroup="Roll"></asp:RangeValidator>
        <asp:TextBox ID="TxtNumRolls" runat="server" CssClass="form-control" Text="1" TextMode="Number" ></asp:TextBox>
    </div>
    <asp:Button ID="BtnRoll" runat="server" CssClass="btn btn-dark btn-lg btn-block" Text="Roll Dice" OnClick="BtnRoll_Click" ValidationGroup="Roll" BorderColor="#d44a34" BackColor="#d44a34"  />
</asp:Content>
