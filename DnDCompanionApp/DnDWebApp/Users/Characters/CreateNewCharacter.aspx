<%@ Page Title="" Language="C#" MasterPageFile="~/DnD.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="CreateNewCharacter.aspx.cs" Inherits="DnDWebApp.Users.Characters.CreateNewCharacter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        tr td label {
            margin-left: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-5">Create a New Character</h1>
    <p class="lead">Create a new D&D character for your account.</p>

    <div class="form-group">
        <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <h5>Character Build</h5>

    <h6>Race</h6>
    <div class="form-group">
        <asp:Label ID="LblRace" runat="server" Text="Choose a Race"></asp:Label>
        <asp:DropDownList ID="DDRace" OnSelectedIndexChanged="DDRace_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="card" style="margin-bottom: 20px;">
        <div class="card-header">
            <asp:Label ID="LblRaceName" runat="server" Text="Race"></asp:Label>
        </div>
        <div class="card-body">
            <p id="RaceDesc" runat="server"></p>
            <h6>Languages</h6>
            <asp:BulletedList ID="BLLanguages" runat="server"></asp:BulletedList>
        </div>
    </div>

    <h6>Class</h6>
    <div class="form-group">
        <asp:Label ID="LblClass" runat="server" Text="Choose a Class"></asp:Label>
        <asp:DropDownList ID="DDClass" AutoPostBack="true" OnSelectedIndexChanged="DDClass_SelectedIndexChanged" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="card" style="margin-bottom: 20px;">
        <div class="card-header">
            <asp:Label ID="LblClassName" runat="server" Text="Class"></asp:Label>
        </div>
        <div class="card-body">
            <p id="ClassDesc" runat="server"></p>
            <h6>Features</h6>
            <asp:BulletedList ID="BLFeatures" runat="server"></asp:BulletedList>
            <h6>Hit Dice</h6>
            <p id="HitDice" runat="server"></p>
            <h6>Skills</h6>
            <asp:BulletedList ID="BLSkills" runat="server"></asp:BulletedList>
        </div>
    </div>

    <h6>Background</h6>
    <div class="form-group">
        <asp:Label ID="LblBackground" runat="server" Text="Choose a Background"></asp:Label>
        <asp:DropDownList ID="DDBackground" AutoPostBack="true" OnSelectedIndexChanged="DDBackground_SelectedIndexChanged" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="card" style="margin-bottom: 20px;">
        <div class="card-header">
            <asp:Label ID="LblBackgroundName" runat="server" Text="Background"></asp:Label>
        </div>
        <div class="card-body">
            <p id="BackgroundDesc" runat="server"></p>
            <div class="form-group">
                <asp:Label ID="LblPersonality" runat="server" Text="Personality Traits (Choose Two)"></asp:Label>
                <asp:CustomValidator ClientValidationFunction="CountPersonality" ID="ReqTwoPersonality" runat="server" ForeColor="#d44a34" 
                    ErrorMessage="(Personality must have exactly two items selected)"></asp:CustomValidator>
                <asp:CheckBoxList ID="ChkLPersonality" CssClass="form-check" runat="server"></asp:CheckBoxList>
            </div>
            <div class="form-group">
                <asp:Label ID="LblIdeals" runat="server" Text="Ideals (Choose Two)"></asp:Label>
                <asp:CustomValidator ClientValidationFunction="CountIdeals" ID="ReqTwoIdeals" runat="server" ForeColor="#d44a34" 
                    ErrorMessage="(Ideals must have exactly two items selected)"></asp:CustomValidator>
                <asp:CheckBoxList ID="ChkLIdeals" CssClass="form-check" runat="server"></asp:CheckBoxList>
            </div>
            <div class="form-group">
                <asp:Label ID="LblBonds" runat="server" Text="Bonds (Choose Two)"></asp:Label>
                <asp:CustomValidator ClientValidationFunction="CountBonds" ID="ReqTwoBonds" runat="server" ForeColor="#d44a34" 
                    ErrorMessage="(Bonds must have exactly two items selected)"></asp:CustomValidator>
                <asp:CheckBoxList ID="ChkLBonds" CssClass="form-check" runat="server"></asp:CheckBoxList>
            </div>
            <div class="form-group">
                <asp:Label ID="LblFlaws" runat="server" Text="Flaws (Choose Two)"></asp:Label>
                <asp:CustomValidator ClientValidationFunction="CountFlaws" ID="ReqTwoFlaws" runat="server" ForeColor="#d44a34" 
                    ErrorMessage="(Flaws must have exactly two items selected)"></asp:CustomValidator>
                <asp:CheckBoxList ID="ChkLFlaws" CssClass="form-check" runat="server"></asp:CheckBoxList>
            </div>
        </div>
    </div>

    <h5>Ability Scores and Modifiers</h5>
    <div class="form-group">
        <asp:Button ID="BtnRollStats" runat="server" Text="Re-Roll Stats" CssClass="btn btn-dark" OnClick="BtnRollStats_Click" BorderColor="#d44a34" BackColor="#d44a34" />
    </div>
    <table class="table table-striped">
        <thead>
            <tr>
                <th scope="col"></th>
                <th scope="col">Ability Score</th>
                <th scope="col">Modifier</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Strength</td>
                <td id="Str" runat="server"></td>
                <td id="StrMod" runat="server"></td>
            </tr>
            <tr>
                <td>Dexterity</td>
                <td id="Dex" runat="server"></td>
                <td id="DexMod" runat="server"></td>
            </tr>
            <tr>
                <td>Constitution</td>
                <td id="Con" runat="server"></td>
                <td id="ConMod" runat="server"></td>
            </tr>
            <tr>
                <td>Wisdom</td>
                <td id="Wis" runat="server"></td>
                <td id="WisMod" runat="server"></td>
            </tr>
            <tr>
                <td>Intelligence</td>
                <td id="Intel" runat="server"></td>
                <td id="IntMod" runat="server"></td>
            </tr>
            <tr>
                <td>Charisma</td>
                <td id="Chr" runat="server"></td>
                <td id="ChrMod" runat="server"></td>
            </tr>
        </tbody>
    </table>

    <h5>Physical Characteristics</h5>
    <div class="form-row">
        <div class="form-group col-md-4">
            <asp:Label ID="LblHair" runat="server" Text="Hair"></asp:Label>
            <asp:TextBox ID="TxtHair" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group col-md-4">
            <asp:Label ID="LblEyes" runat="server" Text="Eyes"></asp:Label>
            <asp:TextBox ID="TxtEyes" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-4">
            <asp:Label ID="LblSkin" runat="server" Text="Skin"></asp:Label>
            <asp:TextBox ID="TxtSkin" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <h5>Notes</h5>
    <div class="form-group">
        <asp:Label ID="LblAdditionalNotes" runat="server" Text="Additional Notes"></asp:Label>
        <asp:TextBox ID="TxtAdditionalNotes" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
    </div>

    <asp:Button ID="BtnGenerate" OnClick="BtnGenerate_Click" runat="server" Text="Generate Character" CssClass="btn btn-dark btn-lg btn-block" BorderColor="#d44a34" BackColor="#d44a34" />

    <div id="CharacterDetails" runat="server" visible="false">
        <hr />
        <h2>Your New Character</h2>
        <div class="card" style="margin-bottom: 15px;">
            <div class="card-header text-white bg-dark mb-3">
                <asp:Label ID="LblCharacterName" runat="server" Text="Character"></asp:Label>
            </div>
            <div class="card-body">
                <h5>Stats</h5>
                <asp:BulletedList ID="BLStats" runat="server"></asp:BulletedList>

                <h5>Race</h5>
                <p id="P1" runat="server"></p>
                <h6>Languages</h6>
                <asp:BulletedList ID="BLNewCharLang" runat="server"></asp:BulletedList>

                <h5>Class</h5>
                <p id="P2" runat="server"></p>
                <h6>Features</h6>
                <asp:BulletedList ID="BLNewCharFeats" runat="server"></asp:BulletedList>
                <h6>Hit Dice</h6>
                <p id="P3" runat="server"></p>
                <h6>Skills</h6>
                <asp:BulletedList ID="BLNewCharSkills" runat="server"></asp:BulletedList>

                <h5>Background</h5>
                <p id="P4" runat="server"></p>
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
        <asp:Button ID="BtnSave" OnClick="BtnSave_Click" runat="server" Text="Save Character" CssClass="btn btn-dark btn-lg"  BorderColor="#d44a34" BackColor="#d44a34" />
        <asp:Button ID="BtnDiscard" runat="server" Text="Discard Character" CssClass="btn btn-dark btn-lg" OnClick="BtnDiscard_Click" />
    </div>

    <script type="text/javascript">

        // Ref for validators: 
        // https://www.aspsnippets.com/Articles/Validate-ASPNet-CheckBoxList-at-least-one-CheckBox-checked-using-Custom-Validator.aspx

        /**
         * Returns true if the there are exactly 2 personality items checked
         * @param sender
         * @param args
         */
        function CountPersonality(sender, args) {
            var checkBoxList = document.getElementById("<%=ChkLPersonality.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;

            var numChecked = 0;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    numChecked++;
                }
            }

            if (numChecked === 2) {
                isValid = true;
            }

            args.IsValid = isValid;
        }

        /**
         * Returns true if the there are exactly 2 ideal items checked
         * @param sender
         * @param args
         */
        function CountIdeals(sender, args) {
            var checkBoxList = document.getElementById("<%=ChkLIdeals.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;

            var numChecked = 0;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    numChecked++;
                }
            }

            if (numChecked === 2) {
                isValid = true;
            }

            args.IsValid = isValid;
        }

        /**
         * Returns true if the there are exactly 2 bond items checked
         * @param sender
         * @param args
         */
        function CountBonds(sender, args) {
            var checkBoxList = document.getElementById("<%=ChkLBonds.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;

            var numChecked = 0;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    numChecked++;
                }
            }

            if (numChecked === 2) {
                isValid = true;
            }

            args.IsValid = isValid;
        }

        /**
         * Returns true if the there are exactly 2 flaw items checked
         * @param sender
         * @param args
         */
        function CountFlaws(sender, args) {
            var checkBoxList = document.getElementById("<%=ChkLFlaws.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;

            var numChecked = 0;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    numChecked++;
                }
            }

            if (numChecked === 2) {
                isValid = true;
            }

            args.IsValid = isValid;
        }
    </script>
</asp:Content>
