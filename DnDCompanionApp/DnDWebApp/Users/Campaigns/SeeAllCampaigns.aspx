<%@ Page Title="" Language="C#" MasterPageFile="~/DnD.Master" AutoEventWireup="true" CodeBehind="SeeAllCampaigns.aspx.cs" Inherits="DnDWebApp.Users.Campaigns.SeeAllCampaigns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Ref: taken from http://dnd.wizards.com/ -->
    <img src="http://geekandsundry.com/wp-content/uploads/2016/08/Article_LightDarkUnderdark_Header.jpg" class="img-fluid" alt="D&D Header">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-5">Your Campaigns</h1>
    <p class="lead">These are the campaigns that you are a part of.</p>

    <div id="NewCampaign" runat="server" class="alert alert-success" role="alert" visible="false">
        Your new campaign has been added to your collection!
    </div>
    <div id="NoCampaigns" runat="server" class="alert alert-info" role="alert" visible="false">
        You have no campaigns to display.
    </div>

    <div class="form-group">
        <asp:Label ID="LblCampaigns" runat="server" Text="Choose Campaign to Display"></asp:Label>
        <asp:DropDownList ID="DDCampaigns" runat="server" CssClass="custom-select" AutoPostBack="true" OnSelectedIndexChanged="DDCampaigns_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <div id="CampaignDetails" runat="server" class="card" visible="false">
        <div class="card-header">
            <asp:Label ID="LblCampaignName" runat="server" Text="Campaign"></asp:Label>
        </div>
        <div class="card-body">
            <h5>Description</h5>
            <p id="CampaignDescription" runat="server"></p>
            <h5>Dungeon Master</h5>
            <p id="DMName" runat="server"></p>
            <h5>Party Members</h5>
            <asp:Label ID="LblPartyMember" runat="server" Text="Choose Character to Display"></asp:Label>
            <asp:DropDownList ID="DDPartyMembers" runat="server" CssClass="form-control" AutoPostBack="true"
                OnSelectedIndexChanged="DDPartyMembers_SelectedIndexChanged">
            </asp:DropDownList>
            <div class="card">
                <div class="card-body">
                    <h6>Character User</h6>
                    <p id="CharacterUser" runat="server"></p>

                    <h6>Race</h6>
                    <p id="RaceDesc" runat="server"></p>
                    <p>Languages</p>
                    <asp:BulletedList ID="BLLanguages" runat="server"></asp:BulletedList>

                    <h6>Class</h6>
                    <p id="ClassDesc" runat="server"></p>
                    <p>Features</p>
                    <asp:BulletedList ID="BLFeatures" runat="server"></asp:BulletedList>
                    <p>Hit Dice</p>
                    <p id="HitDice" runat="server"></p>
                    <p>Skills</p>
                    <asp:BulletedList ID="BLSkills" runat="server"></asp:BulletedList>

                    <h6>Background</h6>
                    <p id="BackgroundDesc" runat="server"></p>

                    <h6>Physical Characteristics</h6>
                    <p id="PhysicalDesc" runat="server"></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
