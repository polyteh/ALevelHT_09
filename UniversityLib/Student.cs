using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib
{
    /// <summary>
    /// class for Student description
    /// </summary>
    public class Student: UniversityPeople
    {
        /// <summary>
        /// student ctr
        /// </summary>
        /// <param name="_lastName">last name of the student</param>
        public Student(string _lastName)
        {
            this.LastName = _lastName;
            // group by default
            this.GroupNumber = -1;

        }
        /// <summary>
        /// Last name of the student
        /// </summary>
        public override string LastName
        { get; set; }

        /// <summary>
        /// student study in this group
        /// </summary>
        //I don't like setter here
        public  int GroupNumber
        { get; internal set; }
        public override string ToString()
        {
            return this.LastName;
        }
    }
}
