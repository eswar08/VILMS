using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VILMS_UI_Win
{
    public partial class FrmDialogBox : Form
    {
        #region Constructor
        public FrmDialogBox(string message)
        {
            InitializeComponent();
            Message = message;
        }
        #endregion

        #region Variables
        private string Message = string.Empty;
        #endregion

        #region Events
        private void DialogBox_Load_1(object sender, EventArgs e)
        {
            txtMessage.Text = Message;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
