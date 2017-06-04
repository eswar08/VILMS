using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VILMS_CM;
using VILMS_DA;

namespace VILMS_BI
{
    public class BusinessLogOnWindow
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessLogOnWindow()
        {
            o_loginDataValidation = new LoginUserDatavalidation();
        }
        #endregion

        #region Variables
        /// <summary>
        /// LoginUserDatavalidation Class
        /// </summary>
        public LoginUserDatavalidation o_loginDataValidation;
        Dictionary<int, string> distitle = new Dictionary<int, string>();
        #endregion

        #region Methods
        public bool IsValidUser(string user, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(user))
                    return false;
                if (string.IsNullOrEmpty(password))
                    return false;
                return o_loginDataValidation.CheckUser(user, password);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Course> GetCourselist()
        {
            List<Course> CourseList = new List<Course>();
            try
            {
                DataSet ds = o_loginDataValidation.GetCourselist();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Course objCourse = new Course
                        {
                            CourseID = dr["CourseID"] == DBNull.Value ? 0 : Convert.ToInt16(dr["CourseID"].ToString()),
                            CourseName = dr["CourseName"] == DBNull.Value ? "N/A" : dr["CourseName"].ToString(),
                            CourseDescription = dr["CourseDescription"] == DBNull.Value ? "N/A" : dr["CourseDescription"].ToString()
                        };
                        CourseList.Add(objCourse);
                    }
                    return CourseList;
                }
                return CourseList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Lesson> GetLessionlist(string CourseID)
        {
            List<Lesson> LessonsList = new List<Lesson>();
            try
            {
                DataSet ds = o_loginDataValidation.GetLessionlist(CourseID);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Lesson objLesson = new Lesson
                        {
                            CourseID = dr["CourseID"] == DBNull.Value ? 0 : Convert.ToInt16(dr["CourseID"].ToString()),
                            LessonID = dr["LessonID"] == DBNull.Value ? 0 : Convert.ToInt16(dr["LessonID"].ToString()),
                            Name = dr["Name"] == DBNull.Value ? "N/A" : dr["Name"].ToString()
                        };
                        LessonsList.Add(objLesson);
                    }
                    return LessonsList;
                }
                return LessonsList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Topics> GetTopiclist(string CourseID, string LessonID)
        {
            List<Topics> Topiclist = new List<Topics>();
            try
            {
                DataSet ds = o_loginDataValidation.GetTopiclist(CourseID, LessonID);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Topics objTopics = new Topics
                        {
                            TopicID = dr["TopicID"] == DBNull.Value ? 0 : Convert.ToInt16(dr["TopicID"].ToString()),
                            LessonID = dr["LessonID"] == DBNull.Value ? 0 : Convert.ToInt16(dr["LessonID"].ToString()),
                            CourseID = dr["CourseID"] == DBNull.Value ? 0 : Convert.ToInt16(dr["CourseID"].ToString()),
                            Name = dr["Name"] == DBNull.Value ? "N/A" : dr["Name"].ToString(),
                            Content = dr["Content"] == DBNull.Value ? "N/A" : dr["Content"].ToString()
                        };
                        Topiclist.Add(objTopics);
                    }
                    return Topiclist;
                }
                return Topiclist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Questions> GetQuestionlist(string CourseID, string LessonID, string TopicID)
        {
            List<Questions> Questionlist = new List<Questions>();
            try
            {
                DataSet ds = o_loginDataValidation.GetQuestionlist(CourseID, LessonID, TopicID);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Questions objQuestions = new Questions
                        {
                            QuestionID = dr["QuestionID"] == DBNull.Value ? 0 : Convert.ToInt16(dr["QuestionID"].ToString()),
                            TopicID = dr["TopicID"] == DBNull.Value ? 0 : Convert.ToInt16(dr["TopicID"].ToString()),
                            LessonID = dr["LessonID"] == DBNull.Value ? 0 : Convert.ToInt16(dr["LessonID"].ToString()),
                            CourseID = dr["CourseID"] == DBNull.Value ? 0 : Convert.ToInt16(dr["CourseID"].ToString()),
                            QuestionType = dr["QuestionType"] == DBNull.Value ? "N/A" : dr["QuestionType"].ToString(),
                            Attempts = dr["Attempts"] == DBNull.Value ? 0 : Convert.ToInt16(dr["Attempts"].ToString()),
                            QuestionTypeParameter = dr["QuestionTypeParameter"] == DBNull.Value ? "N/A" : dr["QuestionTypeParameter"].ToString(),
                            Instruction = dr["Instruction"] == DBNull.Value ? "N/A" : dr["Instruction"].ToString(),
                            Question = dr["Question"] == DBNull.Value ? "N/A" : dr["Question"].ToString(),
                            OptionToQuestion = dr["OptionToQuestion"] == DBNull.Value ? "N/A" : dr["OptionToQuestion"].ToString(),
                            Answer = dr["Answer"] == DBNull.Value ? "N/A" : dr["Answer"].ToString(),
                            Hint = dr["Hint"] == DBNull.Value ? "N/A" : dr["Hint"].ToString(),
                            FeedBackCorrectAnswer = dr["FeedBackCorrectAnswer"] == DBNull.Value ? "N/A" : dr["FeedBackCorrectAnswer"].ToString(),
                            FeedBackWrongAnswer = dr["FeedBackWrongAnswer"] == DBNull.Value ? "N/A" : dr["FeedBackWrongAnswer"].ToString()
                        };
                        Questionlist.Add(objQuestions);
                    }
                    return Questionlist;
                }
                return Questionlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Dictionary<int, string> LoadTitles()
        {
            distitle.Add(1, "Select Courses-LMS Client");
            distitle.Add(2, "Select Lessons-LMS Client");
            distitle.Add(3, "Select Topics-LMS Client");
            return distitle;
        }
        #endregion
    }
}
