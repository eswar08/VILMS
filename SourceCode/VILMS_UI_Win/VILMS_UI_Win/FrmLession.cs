using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VILMS_BI;
using VILMS_CM;

namespace VILMS_UI_Win
{
    public partial class frmLessions : Form
    {
        #region Constructor
        public frmLessions()
        {
            InitializeComponent();
        }

        public frmLessions(string lCourseID, string lLessionID = "0")
        {
            InitializeComponent();
            CourseID = lCourseID;
            LessionID = lLessionID;
        }
        #endregion

        #region Variables
        private BusinessLogOnWindow o_loginWindow = new BusinessLogOnWindow();
        List<Lesson> LessionsLiist = new List<Lesson>();
        Dictionary<int, string> distitle = new Dictionary<int, string>();
        string CourseID = string.Empty;
        string LessionID = "0";
        #endregion

        #region Methods
        private bool LoadLession(string CourseID)
        {
            if (LessionsLiist.Count == 0)
                LessionsLiist = o_loginWindow.GetLessionlist(CourseID);
            if (LessionsLiist.Count > 0)
            {
                lstLessions.DataSource = null;
                lstLessions.DataSource = new BindingSource(LessionsLiist, null);
                lstLessions.DisplayMember = "Name";
                lstLessions.ValueMember = "LessonID";
                lstLessions.Focus();
                if (LessionID == "0")
                    lstLessions.SelectedIndex = 0;
                else
                    lstLessions.SelectedValue = int.Parse(LessionID);
                lstLessions.Select();
                return true;
            }
            return false;
        }
        #endregion

        #region Events
        private void Lessions_Load(object sender, EventArgs e)
        {
            distitle = o_loginWindow.LoadTitles();
            LoadLession(CourseID);
            grpLessions.Text = distitle[2];
        }

        private void lstLessions_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int key = (int)lstLessions.SelectedValue;
                    FrmTopic objFrmTopic = new FrmTopic(CourseID, key.ToString());
                    this.Hide();
                    objFrmTopic.ShowDialog();
                }
                else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
                {
                    FrmCourses objCourses = new FrmCourses(CourseID);
                    this.Hide();
                    objCourses.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void frmLessions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                FrmCourses objCourses = new FrmCourses(CourseID);
                this.Hide();
                objCourses.ShowDialog();
            }
        }
        #endregion
    }
}