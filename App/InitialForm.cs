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
        PermissionService permissionService= new PermissionService();   
        UserService userService = new UserService();
        public InitialForm()
        {
            InitializeComponent();
            InitialState();
        }

        private void InitialState()
        {
            foreach (ToolStripMenuItem tsmi in menu.Items)
            {
                tsmi.Visible = false;
            }

            archivoToolStripMenuItem.Visible = true;
            loginToolStripMenuItem.Visible = true;
            logoutToolStripMenuItem.Visible = true;
            abrirToolStripMenuItem.Visible = false;
            cerrarToolStripMenuItem.Visible = false;
            salirToolStripMenuItem.Visible = false;
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {

            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            var user = userService.GetByLogon(LoginForm.logon);

            if (user != null)
            {
                var r = rolService.GetRol(user.Rol.RolId);

                //recorro los items del menu y si el usuario tiene el permiso lo muestro, caso contrario lo oculto
                foreach (ToolStripMenuItem tsmi in menu.Items)
                {
                    if(permissionService.Validate(int.Parse(tsmi.Tag.ToString()), r.Permission))
                    {
                        tsmi.Visible=true;
                        //Me fijo los submenu
                        foreach(var p in tsmi.DropDownItems)
                        {
                            if(p is ToolStripMenuItem)
                            {
                                ((ToolStripMenuItem)p).Visible = permissionService.Validate(int.Parse(((ToolStripMenuItem)p).Tag.ToString()), r.Permission);
                            }
                        }
                    }
                    else tsmi.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("No existe el usuario");
                InitialState();

            }
            
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            var user = userService.GetByLogon(LoginForm.logon);

            if (user != null)
            {
                var r = rolService.GetRol(user.Rol.RolId);

                //recorro los items del menu y si el usuario tiene el permiso lo muestro, caso contrario lo oculto
                foreach (ToolStripMenuItem tsmi in menu.Items)
                {
                    if (permissionService.Validate(int.Parse(tsmi.Tag.ToString()), r.Permission))
                    {
                        tsmi.Visible = true;
                        //Me fijo los submenu
                        foreach (var p in tsmi.DropDownItems)
                        {
                            if (p is ToolStripMenuItem)
                            {
                                ((ToolStripMenuItem)p).Visible = permissionService.Validate(int.Parse(((ToolStripMenuItem)p).Tag.ToString()), r.Permission);
                            }
                        }
                    }
                    else tsmi.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("No existe el usuario");
                InitialState();

            }
        }
    }
}
