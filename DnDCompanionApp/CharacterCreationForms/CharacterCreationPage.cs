using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreationForms {
    public partial class CharacterCreationPage : UserControl {
        public CharacterCreationPage() {
            InitializeComponent();
        }

        private void CharacterCreationPage_Load(object sender, EventArgs e) {
            // Retrieve all Classes
            // Retrieve all Races
            // Retrieve all backgrounds
            
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            // TODO: Form validation

            // Generate stats and modifiers

            // Generate character

            // Go to Character Output Page
            CharacterPreviewForm form = new CharacterPreviewForm();
            form.Show();
        }
    }
}
