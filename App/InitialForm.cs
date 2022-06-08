using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class InitialForm : Form
    {
        RolService rolService = new RolService();
        public InitialForm()
        {
            InitializeComponent();
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {
            var r = rolService.GetAll();
        }
    }
}
