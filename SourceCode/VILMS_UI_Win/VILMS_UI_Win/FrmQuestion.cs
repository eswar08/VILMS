using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using VILMS_BI;
using VILMS_CM;

namespace VILMS_UI_Win
{
    public partial class FrmQuestion : Form
    {
        #region Constructor
        public FrmQuestion()
        {
            InitializeComponent();
        }

        public FrmQuestion(Topics lobjTopics)
        {
            InitializeComponent();
            objTopics = lobjTopics;
            CourseID = lobjTopics.CourseID.ToString();
            LessonID = lobjTopics.LessonID.ToString();
            TopicID = lobjTopics.TopicID.ToString();
        }
        #endregion

        #region Variables
        private BusinessLogOnWindow o_loginWindow = new BusinessLogOnWindow();
        List<Questions> QuestionsLiist = new List<Questions>();
        Topics objTopics = null;
        string CourseID = string.Empty;
        string LessonID = string.Empty;
        string TopicID = string.Empty;
        int index = 0;
        int charindex = 0;
        string Typekey = "";
        string Spacekey = "";
        string wrongkey = "";
        string Typedkey = "";
        string Correctkey = "";
        string speak = string.Empty;
        string Answer = string.Empty;
        char[] Answerlist = null;
        StringBuilder Alltext = null;
        int numberoflines = 0;
        int attempts = 0;
        string FeedBackCorrectAnswer = string.Empty;
        SpeechSynthesizer speaker = null;

        #endregion

        #region Methods
        private bool LoadQuestion(string lCourseID, string lLessionID, string lTopicID)
        {
            if (QuestionsLiist.Count == 0)
                QuestionsLiist = o_loginWindow.GetQuestionlist(lCourseID, lLessionID, lTopicID);
            if (QuestionsLiist.Count > 0)
                return true;
            return false;
        }

        private void Assigntext(int index)
        {
            try
            {
                Alltext = new StringBuilder();
                Alltext.Append(QuestionsLiist[index].Instruction);
                Alltext.Append(Environment.NewLine);
                Alltext.Append(Environment.NewLine);
                Alltext.Append(QuestionsLiist[index].Question);
                Alltext.Append(Environment.NewLine);
                txtquestion.Text = Alltext.ToString();
                speak = Typekey + QuestionsLiist[index].Answer;
                Answer = QuestionsLiist[index].Answer;
                FeedBackCorrectAnswer = QuestionsLiist[index].FeedBackCorrectAnswer;
                attempts = Convert.ToInt16(QuestionsLiist[index].Attempts);
                int i = 0;
                Answerlist = new char[attempts * (Answer.Length + 1)];
                for (int j = 0; j < attempts; j++)
                {
                    foreach (char c in Answer)
                    {
                        Answerlist[i] = c;
                        i += 1;
                    }
                    Answerlist[i] = ' ';
                    i += 1;
                }
                charindex = 0;
                txtAnswer.TextChanged -= txtAnswer_TextChanged;
                txtAnswer.Text = string.Empty;
                txtAnswer.TextChanged += txtAnswer_TextChanged;
                numberoflines = txtquestion.Lines.Count();
                txtquestion.Focus();
                speaker.Speak(speak);
            }
            catch (Exception ex)
            {

            }
        }

        private void FrmLoadTopic()
        {
            FrmTopic objFrmTopic = new FrmTopic(objTopics);
            this.Hide();
            objFrmTopic.ShowDialog();
        }

        private void LoadKeys()
        {
            Typekey = ConfigurationManager.AppSettings["Typekey"];
            Spacekey = ConfigurationManager.AppSettings["Spacekey"];
            wrongkey = ConfigurationManager.AppSettings["wrongkey"];
            Typedkey = ConfigurationManager.AppSettings["Typedkey"];
            Correctkey = ConfigurationManager.AppSettings["Correctkey"];
        }
        #endregion

        #region Events
        private void DlgTopic_Load(object sender, EventArgs e)
        {
            speaker = new SpeechSynthesizer();
            speaker.Rate = -2;
            LoadKeys();
            LoadQuestion(CourseID, LessonID, TopicID);
            Assigntext(index);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                index += 1;

                if (QuestionsLiist.Count > index)
                    Assigntext(index);
                else
                {
                    FrmLoadTopic();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (index >= 0)
                {
                    index -= 1;
                    if (index == -1)
                        index = 0;
                    Assigntext(index);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void FrmQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Back)
                    FrmLoadTopic();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtquestion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Tab)
                    txtAnswer.Focus();
                else if (e.KeyCode == Keys.Escape)
                    FrmLoadTopic();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtoption_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Tab)
                    txtAnswer.Focus();
                else if (e.KeyCode == Keys.Up)
                {
                    e.Handled = true;
                    txtquestion.Focus();
                }
                else if (e.KeyCode == Keys.Escape)
                    FrmLoadTopic();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F3)
                    txtquestion.Focus();
                else if (e.KeyCode == Keys.Escape)
                    FrmLoadTopic();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtAnswer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string compstring = txtAnswer.Text.Substring(txtAnswer.Text.Length - 1, 1);
                if (compstring == Answerlist[charindex].ToString())
                {
                    charindex += 1;
                    if (Answerlist.Count() > charindex)
                    {
                        if (Answerlist[charindex].ToString() == " ")
                            speak = Correctkey + Typekey + Spacekey;
                        else
                            speak = Correctkey + Typekey + Answerlist[charindex].ToString();
                        speaker.Speak(speak);
                    }
                    else
                        if (QuestionsLiist.Count > index)
                        {
                            speaker.Speak(FeedBackCorrectAnswer);
                            index += 1;
                            if (index == QuestionsLiist.Count)
                                FrmLoadTopic();
                            else
                                Assigntext(index);
                        }
                }
                else
                {
                    if (Answerlist[charindex].ToString() == " ")
                        speak = wrongkey + Typekey + Spacekey;
                    else
                        speak = wrongkey + Typekey + Answerlist[charindex].ToString();
                    speaker.Speak(speak);
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}