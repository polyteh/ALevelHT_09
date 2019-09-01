using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib
{
    public class Group
    {
        private List<Student> studentsInGroup=new List<Student>();
        public Group(int _groupNumber, Teacher _groupTeacher)
        {
            // i dont like this code. How can I do it more perfect?
            this.GroupTeacher = _groupTeacher;
            this.GroupNumber = _groupNumber;
            GroupTeacher.GroupNumber = GroupNumber;
        }

        // properties
        public Teacher GroupTeacher
        { get; set; }
        /// <summary>
        /// Group number can't be changed
        /// </summary>
        public int GroupNumber
        { get;}

        //methods
        /// <summary>
        /// Add new student in the group; return true, if student was add suceffully, otherwise return false
        /// </summary>
        /// <param name="_newStudent"></param>
        /// <returns></returns>
        public bool AddStudent(Student _newStudent)
        {
            // if there is free place in the group, add student in the group and update student properties
            if (studentsInGroup.Count< GroupTeacher.MaxNumberofStudents)
            {
                this.studentsInGroup.Add(_newStudent);
                _newStudent.GroupNumber = GroupNumber;
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// get all students in the current group
        /// </summary>
        /// <returns></returns>
        public Student[] GetGroupStudentList()
        {
            return this.studentsInGroup.ToArray();
        }
    }
}
