<%@ Page Title="" Language="C#" MasterPageFile="~/DnD.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="EncyclopaediaOverview.aspx.cs" Inherits="DnDWebApp.Tools.EncyclopaediaOverview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-5">Encyclopaedia</h1>
    <p class="lead">Learn more about the D&D lore.</p>

    <div class="container">
        <div class="row">
            <div id="links" runat="server" class="col-md-2">
                <a href="EncyclopaediaOverview.aspx?encyclopaediaReq=backgroundTypes" class="text-dark">Backgrounds</a>
                <br />
                <a href="EncyclopaediaOverview.aspx?encyclopaediaReq=classes" class="text-dark">Classes</a>
                <br />
                <a href="EncyclopaediaOverview.aspx?encyclopaediaReq=races" class="text-dark">Races</a>
                <br />
                <a href="EncyclopaediaOverview.aspx?encyclopaediaReq=spells" class="text-dark">Spells</a>
            </div>

            <div class="col-md-10">
                <div class="card">
                    <div runat="server" id="name" class="card-header">
                        Encyclopaedia
                    </div>
                    <div class="card-body">

                        <div runat="server" id="description">
                            Welcome to the D&D Encyclopaedia. In this section, you can learn about D&D lore by selecting the 
                            different pages in the navigation bar. The information about each item will be displayed here.
                        </div>
                        <div runat="server" id="descriptor2">
                        </div>
                        <div runat="server" id="descriptor3">
                        </div>
                        <div runat="server" id="descriptor4">
                        </div>
                        <div runat="server" id="descriptor5">
                        </div>
                        <div runat="server" id="descriptor6">
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
