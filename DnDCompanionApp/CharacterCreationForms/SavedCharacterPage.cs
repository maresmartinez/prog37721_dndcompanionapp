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

        List<Character> savedCharacters;

        public SavedCharacterPage(List<Character> savedCharacters) {
            InitializeComponent();
            this.savedCharacters = savedCharacters;
        }

        private void SavedCharacterPage_Load(object sender, EventArgs e) {
            // Create character controls for each character
            foreach (Character character in savedCharacters) {
                flowSavedCharacters.Controls.Add(new SavedCharacterControl(character));
            }
        }
    }
}
