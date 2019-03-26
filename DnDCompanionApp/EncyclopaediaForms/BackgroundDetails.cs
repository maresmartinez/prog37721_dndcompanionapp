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
    public partial class BackgroundDetails : Form {

        Background background;

        public BackgroundDetails(Background background) {
            InitializeComponent();
            this.background = background;
        }
    }
}
