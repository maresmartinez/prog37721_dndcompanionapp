<%@ Page Title="" Language="C#" MasterPageFile="~/DnD.Master" AutoEventWireup="true" CodeBehind="SeeAllCharacters.aspx.cs" Inherits="DnDWebApp.Users.Characters.SeeAllCharacters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Ref: taken from http://dnd.wizards.com/ -->
    <img src="http://dnd.wizards.com/sites/default/files/media/styles/news_banner_header/public/images/news/Adventurers_Header.jpg?itok=coCp626m" class="img-fluid" alt="D&D Header">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-5">Your Characters</h1>
    <p class="lead">These are the characters you have created.</p>

    <div id="NewCharacter" runat="server" class="alert alert-success" role="alert" visible="false">
        Your new character has been added to your collection!
    </div>
    <div id="NoCharacters" runat="server" class="alert alert-info" role="alert" visible="false">
        You have no characters to display.
    </div>

    <div class="form-group">
        <asp:Label ID="LblCharacter" runat="server" Text="Choose Character to Display"></asp:Label>
        <asp:DropDownList ID="DDCharacters" runat="server" CssClass="custom-select" AutoPostBack="true" OnSelectedIndexChanged="DDCharacters_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <div id="CharacterDetails" runat="server" class="card" visible="false">
        <div class="card-header">
            <asp:Label ID="LblCharacterName" runat="server" Text="Character"></asp:Label>
        </div>
        <div class="card-body">
            <h5>Stats</h5>
            <asp:BulletedList ID="BLStats" runat="server"></asp:BulletedList>
            
            <h5>Race</h5>
            <p id="RaceDesc" runat="server"></p>
            <h6>Languages</h6>
            <asp:BulletedList ID="BLLanguages" runat="server"></asp:BulletedList>

            <h5>Class</h5>
            <p id="ClassDesc" runat="server"></p>
            <h6>Features</h6>
            <asp:BulletedList ID="BLFeatures" runat="server"></asp:BulletedList>
            <h6>Hit Dice</h6>
            <p id="HitDice" runat="server"></p>
            <h6>Skills</h6>
            <asp:BulletedList ID="BLSkills" runat="server"></asp:BulletedList>

            <h5>Background</h5>
            <p id="BackgroundDesc" runat="server"></p>
            <h6>Personality</h6>
            <asp:BulletedList ID="BLPersonality" runat="server"></asp:BulletedList>
            <h6>Ideals</h6>
            <asp:BulletedList ID="BLIdeals" runat="server"></asp:BulletedList>
            <h6>Bonds</h6>
            <asp:BulletedList ID="BLBonds" runat="server"></asp:BulletedList>
            <h6>Flaws</h6>
            <asp:BulletedList ID="BLFlaws" runat="server"></asp:BulletedList>

            <h5>Physical Characteristics</h5>
            <p id="PhysicalDesc" runat="server"></p>

            <h5>Additional Notes</h5>
            <p id="AdditionalNotes" runat="server"></p>
        </div>
    </div>
</asp:Content>
