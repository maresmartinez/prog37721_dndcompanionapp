<%@ Page Title="" Language="C#" MasterPageFile="~/DnD.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="CreateNewCampaign.aspx.cs" Inherits="DnDWebApp.Users.Campaigns.CreateNewCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-5">Create a New Campaign</h1>
    <p class="lead">Create a new D&D campaign with other users.</p>

    <h5>Campaign Information</h5>
    <div class="form-group">
        <asp:Label ID="LblName" runat="server" Text="Campaign Name"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqCampaignName" runat="server" ControlToValidate="TxtName" Display="Dynamic" ErrorMessage="(Name must have a value)" ForeColor="#D44A34" ValidationGroup="GenerateCampaign"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TxtName" runat="server" CssClass="form-control" ValidationGroup="GenerateCampaign"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="LblDescription" runat="server" Text="Campaign Description"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqCampaignDescription" runat="server" ControlToValidate="TxtDescription" Display="Dynamic" ErrorMessage="(Description must have a value)" ForeColor="#D44A34" ValidationGroup="GenerateCampaign"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TxtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" ValidationGroup="GenerateCampaign"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="LblDungeonMaster" runat="server" Text="Dungeon Master"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqDungeonMaster" runat="server" ControlToValidate="DDDMUsers" Display="Dynamic" ErrorMessage="(Dungeon Master must have a value)" ForeColor="#D44A34" ValidationGroup="GenerateCampaign"></asp:RequiredFieldValidator>
        <asp:DropDownList ID="DDDMUsers" runat="server" CssClass="form-control" ValidationGroup="GenerateCampaign"></asp:DropDownList>
    </div>

    <h5>Campaign Characters</h5>
    <p>Add party members by selecting a User, and choosing which of their characters to add. The characters you have
         added will appear in the list below.</p>
    <div class="form-row">
        <div class="form-group col-md-6">
            <asp:Label ID="LblCampaignUsers" runat="server" Text="User"></asp:Label>
            <asp:DropDownList ID="DDCampaignUsers" AutoPostBack="true" OnSelectedIndexChanged="DDCampaignUsers_SelectedIndexChanged" runat="server" CssClass="form-control" ValidationGroup="AddCharacterToParty"></asp:DropDownList>
        </div>
        <div class="form-group col-md-6">
            <asp:Label ID="LblCampaignCharacters" runat="server" Text="Character"></asp:Label>
            <asp:DropDownList ID="DDCampaignCharacters" runat="server" CssClass="form-control" ValidationGroup="AddCharacterToParty"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group">
        <asp:Button ID="BtnAddMember" runat="server" CssClass="btn btn-dark btn-block" BackColor="#d44a34"
            BorderColor="#d44a34" Text="Add Character to Campaign" OnClick="BtnAddMember_Click" ValidationGroup="AddCharacterToParty" />
        <asp:Label ID="LblInvalidCharacter" ForeColor="#d44a34" runat="server" Text=""></asp:Label>
    </div>

    <div class="form-group">
        <asp:Label ID="LblPartyMembers" runat="server" Text="Party Members"></asp:Label>
        <asp:CustomValidator ID="ReqTwoPartyMembers" runat="server" ControlToValidate="LBPartyMembers" 
            Display="Dynamic" ValidateEmptyText="True" ForeColor="#d44a34"
            ErrorMessage="(Campaigns must have at least two party members)" 
            ClientValidationFunction="ListBoxValid" ValidationGroup="GenerateCampaign"></asp:CustomValidator>
        <asp:ListBox ID="LBPartyMembers" runat="server" CssClass="form-control" ValidationGroup="GenerateCampaign"></asp:ListBox>
    </div>
    <div class="form-group">
        <asp:Button ID="BtnRemoveCharacter" runat="server" OnClick="BtnRemoveCharacter_Click" CssClass="btn btn-dark btn-sm" Text="Remove Character from Party" />
        <asp:Label ID="LblCannotRemove" ForeColor="#d44a34" runat="server" Text=""></asp:Label>
    </div>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#D44A34" ValidationGroup="GenerateCampaign" />

    <asp:Button ID="BtnGenerate" OnClick="BtnGenerate_Click" runat="server" Text="Generate Campaign"
        CssClass="btn btn-dark btn-lg btn-block" BorderColor="#d44a34" BackColor="#d44a34" ValidationGroup="GenerateCampaign" />
    <asp:Label ID="LblErrorGenerate" ForeColor="#d44a34" runat="server" Text=""></asp:Label>

    <!-- Generated campaign -->
    <div id="NewCampaign" runat="server" visible="false">
        <hr />
        <h2>Your New Campaign</h2>
        <div class="card">
            <div class="card-header text-white bg-dark mb-3">
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
        <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save Character" CssClass="btn btn-dark btn-lg"  BorderColor="#d44a34" BackColor="#d44a34" />
        <asp:Button ID="BtnDiscard" runat="server" OnClick="BtnDiscard_Click" Text="Discard Character" CssClass="btn btn-dark btn-lg"  />
    </div>
    <script type="text/javascript">

        /**
         * Ensures that the controltovalidate has at least two options included
         * @param sender
         * @param args
         */
        function ListBoxValid(sender, args) {
            var ctlDropDown = document.getElementById(sender.controltovalidate);
            args.IsValid = ctlDropDown.options.length >= 2;
        }
    </script>
</asp:Content>
