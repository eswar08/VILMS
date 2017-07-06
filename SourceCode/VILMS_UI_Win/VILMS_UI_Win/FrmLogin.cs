using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VILMS_BI;
using VILMS_CM;

namespace VILMS_UI_Win
{
    public partial class FrmLogin : Form
    {
        #region Constructor
        public FrmLogin()
        {
            InitializeComponent();
            o_loginWindow = new BusinessLogOnWindow();
        }
        #endregion

        #region Variables
        private BusinessLogOnWindow o_loginWindow = null;
        #endregion

        #region Methods
        private void LoadMessage(string Title, string Message)
        {
            FrmDialogBox dlgbox = new FrmDialogBox(Message);
            dlgbox.Text = Title;
            dlgbox.ShowDialog();
        }

        private void CloseScreen(KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "TrailUser";
            txtPassword.Text = "TrailUser";
            txtUsername.Select();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string UserId = "0";
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                LoadMessage("Information", "Please Enter User Name");
                txtUsername.Focus();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                LoadMessage("Information", "Please Enter Password");
                txtPassword.Focus();
            }
            else
            {
                if (o_loginWindow.IsValidUser(txtUsername.Text, txtPassword.Text, out UserId)) //To Check Username Exist Or Not
                {
                    Globals.UserId = UserId;
                    FrmCourses frmCourses = new FrmCourses();
                    this.Hide();
                    frmCourses.ShowDialog();
                    this.Close();
                }
                else
                {
                    LoadMessage("Information", "Invalid User Name or Password");
                    txtUsername.Focus();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            CloseScreen(e);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            CloseScreen(e);
        }

        private void btnlogin_KeyDown(object sender, KeyEventArgs e)
        {
            CloseScreen(e);
        }

        private void btnExit_KeyDown(object sender, KeyEventArgs e)
        {
            CloseScreen(e);
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            CloseScreen(e);
        }
        #endregion
    }
}
