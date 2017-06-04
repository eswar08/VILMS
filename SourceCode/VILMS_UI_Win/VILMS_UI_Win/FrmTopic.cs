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
    public partial class FrmTopic : Form
    {
        #region Constructor
        public FrmTopic()
        {
            InitializeComponent();
        }

        public FrmTopic(Topics objTopics)
        {
            InitializeComponent();
            CourseID = objTopics.CourseID.ToString();
            LessionID = objTopics.LessonID.ToString();
            TopicID = objTopics.TopicID.ToString();
        }

        public FrmTopic(string lCourseID, string lLessionID)
        {
            InitializeComponent();
            CourseID = lCourseID;
            LessionID = lLessionID;
        }
        #endregion

        #region Variables
        private BusinessLogOnWindow o_loginWindow = new BusinessLogOnWindow();
        List<Topics> TopicsLiist = new List<Topics>();
        Dictionary<int, string> distitle = new Dictionary<int, string>();
        string CourseID = string.Empty;
        string LessionID = string.Empty;
        string TopicID = "0";
        #endregion

        #region Methods
        private bool LoadTopics(string lCourseID, string lLessionID)
        {
            if (TopicsLiist.Count == 0)
                TopicsLiist = o_loginWindow.GetTopiclist(lCourseID, lLessionID);
            if (TopicsLiist.Count > 0)
            {
                lstTopics.DataSource = null;
                lstTopics.DataSource = new BindingSource(TopicsLiist, null);
                lstTopics.DisplayMember = "Name";
                lstTopics.ValueMember = "TopicID";
                lstTopics.Focus();
                if (TopicID == "0")
                    lstTopics.SelectedIndex = 0;
                else
                    lstTopics.SelectedValue = int.Parse(TopicID);
                lstTopics.Select();
                return true;
            }
            return false;
        }
        #endregion

        #region Events
        private void FrmTopic_Load(object sender, EventArgs e)
        {
            distitle = o_loginWindow.LoadTitles();
            LoadTopics(CourseID, LessionID);
            grpTopics.Text = distitle[3];
        }

        private void lstTopics_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Topics objTopics = (Topics)lstTopics.SelectedItem;
                    FrmContent objFrmContent = new FrmContent(objTopics);
                    this.Hide();
                    objFrmContent.ShowDialog();
                }
                else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
                {
                    frmLessions objLession = new frmLessions(CourseID, LessionID);
                    this.Hide();
                    objLession.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void FrmTopic_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
                {
                    frmLessions objLession = new frmLessions(CourseID, LessionID);
                    this.Hide();
                    objLession.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}