using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VILMS_CM
{
    public class Topics
    {
        private int m_TopicID;
        private int m_LessonID;
        private int m_CourseID;
        private string m_Name = string.Empty;
        private string m_Content = string.Empty;

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

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public string Content
        {
            get
            {
                return m_Content;
            }
            set
            {
                m_Content = value;
            }
        }
    }
}
