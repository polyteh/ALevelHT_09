using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib
{
    /// <summary>
    /// class for Teacher description
    /// </summary>
    public class Teacher :UniversityPeople
    {
 
        /// <summary>
        /// Teache ctr
        /// </summary>
        /// <param name="_lastName">last name of the teacher</param>
        /// <param name="_numberOfStudents">maximum number of students in the group</param>
        public Teacher(string _lastName, int _MmaxNumberOfStudents)
        {
            LastName = _lastName;
            MaxNumberofStudents = _MmaxNumberOfStudents;
            // group by default
            GroupNumber = -1;

        }
       
        // properties
        public override string LastName
        { get; set; }
        public  int GroupNumber
        { get; internal set; }

        public int MaxNumberofStudents
        { get; }


        // methods
        public override string ToString()
        {
            return String.Format("{0,20}",LastName);
        }
    }

}

