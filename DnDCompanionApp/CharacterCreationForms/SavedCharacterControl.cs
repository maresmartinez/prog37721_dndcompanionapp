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
    public partial class SavedCharacterControl : UserControl {

        Character character;

        public SavedCharacterControl(CharacterCreationLib.Character character) {
            InitializeComponent();
            this.character = character;
        }

        private void SavedCharacterControl_Load(object sender, EventArgs e) {
            lblName.Text = character.Name;
        }

        private void picCharacter_Click(object sender, EventArgs e) {
            // TODO: change name of picturebox

            // When clicked, pass character to output page
            SavedCharacterPreviewForm form = new SavedCharacterPreviewForm();
            form.Show();
        }
    }
}
