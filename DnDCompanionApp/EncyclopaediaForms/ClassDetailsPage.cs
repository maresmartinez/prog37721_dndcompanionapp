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

namespace EncyclopaediaForms {
    public partial class ClassDetailsPage : Form {

        Class charClass;

        public ClassDetailsPage(Class charClass) {
            InitializeComponent();
            this.charClass = charClass;
        }
    }
}
