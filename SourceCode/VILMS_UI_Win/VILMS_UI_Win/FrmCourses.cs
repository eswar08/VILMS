using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VILMS_BI;
using VILMS_CM;

namespace VILMS_UI_Win
{
    public partial class FrmCourses : Form
    {
        #region Constructor
        public FrmCourses()
        {
            InitializeComponent();
        }

        public FrmCourses(string lcourseID)
        {
            InitializeComponent();
            courseID = lcourseID;
        }
        #endregion

        #region Variables
        private BusinessLogOnWindow o_loginWindow = new BusinessLogOnWindow();
        List<Course> CourseLiist = new List<Course>();
        Dictionary<int, string> distitle = new Dictionary<int, string>();
        string courseID = "0";
        #endregion

        #region Methods
        private bool LoadCourse()
        {
            if (CourseLiist.Count == 0)
                CourseLiist = o_loginWindow.GetCourselist();
            if (CourseLiist.Count > 0)
            {
                lstCourses.DataSource = null;
                lstCourses.DataSource = new BindingSource(CourseLiist, null);
                lstCourses.DisplayMember = "CourseName";
                lstCourses.ValueMember = "CourseID";
                lstCourses.Focus();
                if (courseID == "0")
                    lstCourses.SelectedIndex = 0;
                else
                    lstCourses.SelectedValue = int.Parse(courseID);
                lstCourses.Select();
                return true;
            }
            return false;
        }

        private void LoadMessage(string Title, string Message)
        {
            FrmDialogBox dlgbox = new FrmDialogBox(Message);
            dlgbox.Text = Title;
            dlgbox.ShowDialog();
        }

        private void DisplayDiscription(int Id)
        {
            if (CourseLiist.Count == 0)
                CourseLiist = o_loginWindow.GetCourselist();
            List<Course> selCorse = CourseLiist.Where(x => x.CourseID == Id).ToList();
            LoadMessage(distitle[0], selCorse[0].CourseDescription);
        }
        #endregion

        #region Events
        private void Courses_Load(object sender, EventArgs e)
        {
            distitle = o_loginWindow.LoadTitles();
            LoadCourse();
            grpCourse.Text = distitle[1];
        }

        private void lstCourses_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int key = (int)lstCourses.SelectedValue;
                    frmLessions objfrmLessions = new frmLessions(key.ToString());
                    this.Hide();
                    objfrmLessions.ShowDialog();
                }
                else if (e.KeyCode == Keys.F1)
                {
                    int key = (int)lstCourses.SelectedValue;
                    DisplayDiscription(key);
                }
                else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
                {
                    FrmLogin objFrmLogin = new FrmLogin();
                    this.Hide();
                    objFrmLogin.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void FrmCourses_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
                {
                    FrmLogin objFrmLogin = new FrmLogin();
                    this.Hide();
                    objFrmLogin.ShowDialog();
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
