using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VILMS_CM
{
    public class Course
    {
        private int m_CourseID;
        private string m_CourseName = string.Empty;
        private string m_CourseDescription = string.Empty;

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

        public string CourseName
        {
            get
            {
                return m_CourseName;
            }
            set
            {
                m_CourseName = value;
            }
        }

        public string CourseDescription
        {
            get
            {
                return m_CourseDescription;
            }
            set
            {
                m_CourseDescription = value;
            }
        }
    }
}