using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VILMS_DA
{
    public class LoginUserDatavalidation
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public LoginUserDatavalidation(string lconstring)
        {
            constring = lconstring;
            o_dbManger = new MysqldbManager(constring);
        }
        #endregion

        #region Variables
        string constring = string.Empty;
        private MysqldbManager o_dbManger = null;
        #endregion

        #region Methods
        public bool CheckUser(string userName, string password, out string UserId)
        {
            try
            {
                UserId = "0";
                object value = o_dbManger.GetSingleValue("SELECT ID FROM m_user WHERE User_name='" + userName + "' AND Password='" + password + "' AND Status='1'");
                if (value != DBNull.Value)
                {
                    UserId = value.ToString();
                    if (Convert.ToInt32(value) >= 1)
                        return true;
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetCourselist()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = o_dbManger.GetDataInDataSet("SELECT CourseID,CourseName,CourseDescription FROM m_course");
                if (ds != null)
                    return ds;
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetLessionlist(string CourseID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = o_dbManger.GetDataInDataSet("SELECT CourseID,LessonID,Name FROM m_lessons WHERE CourseID=" + CourseID);
                if (ds != null)
                    return ds;
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetTopiclist(string CourseID, string LessonID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = o_dbManger.GetDataInDataSet("SELECT TopicID,LessonID,CourseID,Name,Content FROM m_topic WHERE CourseID=" + CourseID + " AND LessonID = " + LessonID);
                if (ds != null)
                    return ds;
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetQuestionlist(string CourseID, string LessonID, string TopicID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = o_dbManger.GetDataInDataSet("SELECT QuestionID,TopicID,LessonID,CourseID,QuestionType,Attempts,QuestionTypeParameter,Instruction,Question," +
                    "OptionToQuestion,Answer,Hint,FeedBackCorrectAnswer,FeedBackWrongAnswer FROM m_question WHERE TopicID=" + TopicID + " AND CourseID=" + CourseID +
                    " AND LessonID = " + LessonID);
                if (ds != null)
                    return ds;
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool InsertUserAnswer(string Query, out int noOfRowsaffected)
        {
            try
            {
                return (o_dbManger.RunQuery(Query, out noOfRowsaffected));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
