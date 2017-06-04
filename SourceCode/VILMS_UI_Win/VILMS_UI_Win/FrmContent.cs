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
    public partial class FrmContent : Form
    {
        #region Constructor
        public FrmContent()
        {
            InitializeComponent();
        }

        public FrmContent(Topics lobjTopics)
        {
            InitializeComponent();
            objTopics = lobjTopics;
        }
        #endregion

        #region Variables
        Topics objTopics = null;
        private BusinessLogOnWindow o_loginWindow = new BusinessLogOnWindow();
        List<Questions> QuestionsLiist = new List<Questions>();
        #endregion

        #region Events
        private void FrmContent_Load(object sender, EventArgs e)
        {
            txtContent.Text = objTopics.Content;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            QuestionsLiist = o_loginWindow.GetQuestionlist(objTopics.CourseID.ToString(), objTopics.LessonID.ToString(), objTopics.TopicID.ToString());
            if (QuestionsLiist.Count > 0)
            {
                FrmQuestion objFrmQuestion = new FrmQuestion(objTopics);
                this.Hide();
                objFrmQuestion.ShowDialog();
            }
            else
            {
                FrmTopic objFrmTopic = new FrmTopic(objTopics);
                this.Hide();
                objFrmTopic.ShowDialog();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmTopic objFrmTopic = new FrmTopic(objTopics);
            this.Hide();
            objFrmTopic.ShowDialog();
        }

        private void FrmContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                FrmTopic objFrmTopic = new FrmTopic(objTopics);
                this.Hide();
                objFrmTopic.ShowDialog();
            }
        }

        private void txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                FrmTopic objFrmTopic = new FrmTopic(objTopics);
                this.Hide();
                objFrmTopic.ShowDialog();
            }
            else if (e.KeyCode == Keys.Tab)
                btnStart.Focus();
        }

        private void btnStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                FrmTopic objFrmTopic = new FrmTopic(objTopics);
                this.Hide();
                objFrmTopic.ShowDialog();
            }
        }

        private void btnBack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                FrmTopic objFrmTopic = new FrmTopic(objTopics);
                this.Hide();
                objFrmTopic.ShowDialog();
            }
        }
        #endregion
    }
}