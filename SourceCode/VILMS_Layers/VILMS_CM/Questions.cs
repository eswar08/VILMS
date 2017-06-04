using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VILMS_CM
{
    public class Questions
    {
        private int m_QuestionID;
        private int m_TopicID;
        private int m_LessonID;
        private int m_CourseID;
        private string m_QuestionType = string.Empty;
        private int m_Attempts;
        private string m_QuestionTypeParameter = string.Empty;
        private string m_Instruction = string.Empty;
        private string m_Question = string.Empty;
        private string m_OptionToQuestion = string.Empty;
        private string m_Answer = string.Empty;
        private string m_Hint = string.Empty;
        private string m_FeedBackCorrectAnswer = string.Empty;
        private string m_FeedBackWrongAnswer = string.Empty;

        public int QuestionID
        {
            get
            {
                return m_QuestionID;
            }
            set
            {
                m_QuestionID = value;
            }
        }

        public int TopicID
        {
            get
            {
                return m_TopicID;
            }
            set
            {
                m_TopicID = value;
            }
        }

        public int LessonID
        {
            get
            {
                return m_LessonID;
            }
            set
            {
                m_LessonID = value;
            }
        }

        public int CourseID
        {
            get
            {
                return m_CourseID;
            }
            set
            {
                m_CourseID = value;
            }
        }

        public string QuestionType
        {
            get
            {
                return m_QuestionType;
            }
            set
            {
                m_QuestionType = value;
            }
        }

        public int Attempts
        {
            get
            {
                return m_Attempts;
            }
            set
            {
                m_Attempts = value;
            }
        }

        public string QuestionTypeParameter
        {
            get
            {
                return m_QuestionTypeParameter;
            }
            set
            {
                m_QuestionTypeParameter = value;
            }
        }

        public string Instruction
        {
            get
            {
                return m_Instruction;
            }
            set
            {
                m_Instruction = value;
            }
        }

        public string Question
        {
            get
            {
                return m_Question;
            }
            set
            {
                m_Question = value;
            }
        }

        public string OptionToQuestion
        {
            get
            {
                return m_OptionToQuestion;
            }
            set
            {
                m_OptionToQuestion = value;
            }
        }

        public string Answer
        {
            get
            {
                return m_Answer;
            }
            set
            {
                m_Answer = value;
            }
        }

        public string Hint
        {
            get
            {
                return m_Hint;
            }
            set
            {
                m_Hint = value;
            }
        }

        public string FeedBackCorrectAnswer
        {
            get
            {
                return m_FeedBackCorrectAnswer;
            }
            set
            {
                m_FeedBackCorrectAnswer = value;
            }
        }

        public string FeedBackWrongAnswer
        {
            get
            {
                return m_FeedBackWrongAnswer;
            }
            set
            {
                m_FeedBackWrongAnswer = value;
            }
        }
    }
}