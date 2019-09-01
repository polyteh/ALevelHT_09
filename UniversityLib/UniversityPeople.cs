using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib
{
    /// <summary>
    /// abstract class for all people in the university
    /// </summary>
    public abstract class UniversityPeople
    {
        /// <summary>
        /// Last name of the person
        /// </summary>
        public abstract string LastName
            {get;set;}

    }
}
