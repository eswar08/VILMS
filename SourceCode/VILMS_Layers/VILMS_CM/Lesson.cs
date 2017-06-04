using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VILMS_CM
{
    public class Lesson
    {
        private int m_CourseID;
        private int m_LessonID;
        private string m_Name = string.Empty;

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
    }
}
