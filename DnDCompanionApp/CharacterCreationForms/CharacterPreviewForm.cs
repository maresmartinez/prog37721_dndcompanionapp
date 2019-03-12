using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreationLib;

namespace CharacterCreationForms {
    public partial class CharacterPreviewForm : Form {

        Character character;

        public CharacterPreviewForm(Character character) {
            InitializeComponent();
            this.character = character;
        }

        private void CharacterPreviewForm_Load(object sender, EventArgs e) {
            txtName.Text = character.Name;
            txtRace.Text = character.Race.ToString();
            txtClass.Text = character.CharacterClass.ToString();

            string backgroundDesc = character.CharacterBackground.ToString() + Environment.NewLine;
            backgroundDesc += $"Personality: {Environment.NewLine}";
            foreach (string personalityTrait in character.CharacterBackground.Personality) {
                backgroundDesc += $"- {personalityTrait}{Environment.NewLine}";
            }
            backgroundDesc += $"Ideals: {Environment.NewLine}";
            foreach (string ideal in character.CharacterBackground.Ideals) {
                backgroundDesc += $"- {ideal}{Environment.NewLine}";
            }
            backgroundDesc += $"Bonds: {Environment.NewLine}";
            foreach (string bond in character.CharacterBackground.Bonds) {
                backgroundDesc += $"- {bond}{Environment.NewLine}";
            }
            backgroundDesc += $"Flaws: {Environment.NewLine}";
            foreach (string flaw in character.CharacterBackground.Flaws) {
                backgroundDesc += $"- {flaw}{Environment.NewLine}";
            }
            txtBackground.Text = backgroundDesc;

            txtStrength.Text = character.Strength.ToString();
            txtDexterity.Text = character.Dexterity.ToString();
            txtConstitution.Text = character.Constitution.ToString();
            txtIntelligence.Text = character.Intelligence.ToString();
            txtWisdom.Text = character.Wisdom.ToString();
            txtCharisma.Text = character.Charisma.ToString();

            txtStrMod.Text = character.StrMod.ToString();
            txtDexMod.Text = character.DexMod.ToString();
            txtConMod.Text = character.ConMod.ToString();
            txtIntMod.Text = character.IntMod.ToString();
            txtWisMod.Text = character.WisMod.ToString();
            txtChrMod.Text = character.ChrMod.ToString();

            txtPhysical.Text = $"Hair: {character.Hair}{Environment.NewLine}" +
                $"Eyes: {character.Eyes}{Environment.NewLine}" +
                $"Skin: {character.Skin}";

            txtNotes.Text = character.AdditionalNotes;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnDiscard_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
