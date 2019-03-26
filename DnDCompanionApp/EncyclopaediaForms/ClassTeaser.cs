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

namespace EncyclopaediaForms {
    public partial class ClassTeaser : UserControl {
        Class charClass;

        public ClassTeaser(Class charClass) {
            InitializeComponent();
            this.charClass = charClass;
        }

        private void ClassTeaser_Load(object sender, EventArgs e) {
            lblName.Text = charClass.Name;
            if (charClass.Description.Length > 100) {
                lblDescription.Text = charClass.Description.Substring(0, 100) + "...";
            } else {
                lblDescription.Text = charClass.Description;
            }
        }

        private void btnSeeMore_Click(object sender, EventArgs e) {
            ClassDetailsPage classDetails = new ClassDetailsPage(charClass);
            classDetails.ShowDialog();
        }
    }
}
