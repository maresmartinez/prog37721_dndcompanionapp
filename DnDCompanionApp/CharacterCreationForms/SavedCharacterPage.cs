using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreationLib;

namespace CharacterCreationForms {
    public partial class SavedCharacterPage : UserControl {
        public SavedCharacterPage() {
            InitializeComponent();
        }

        private void SavedCharacterPage_Load(object sender, EventArgs e) {

            /*
             TODO: instead of creating characters objects here, it would
                query the database and retrieve the saved characters
                of a user
             */

            // Create Characters
            CharacterCreationLib.Character character1 = new Character();
            character1.Name = "Character 1";
            CharacterCreationLib.Character character2 = new Character();
            character2.Name = "Character 2";
            CharacterCreationLib.Character character3 = new Character();
            character3.Name = "Character 3";
            CharacterCreationLib.Character character4 = new Character();
            character4.Name = "Character 4";

            // Create character controls for each character
            SavedCharacterControl cc1 = new SavedCharacterControl(character1);
            SavedCharacterControl cc2 = new SavedCharacterControl(character2);
            SavedCharacterControl cc3 = new SavedCharacterControl(character3);
            SavedCharacterControl cc4 = new SavedCharacterControl(character4);

            // Add character controls to flow layout panel
            flowSavedCharacters.Controls.Add(cc1);
            flowSavedCharacters.Controls.Add(cc2);
            flowSavedCharacters.Controls.Add(cc3);
            flowSavedCharacters.Controls.Add(cc4);
        }
    }
}
