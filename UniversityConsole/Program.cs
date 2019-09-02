using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLib;

namespace UniversityConsole
{
    class Program
    {
        public enum TeacherRank { Docent = 20, Lecturer = 15, Assistant = 5 };
        static void Main(string[] args)
        {

            //read list of students for the file and save in the static collection
            try
            {   // вынес бы это в переменую filePath, обычно выносят в конфигурационый файл еще
                foreach (string studentName in File.ReadLines("..\\..\\..\\" +
                    "StudentsList.txt"))
                {
                    Student tempStudent = new Student(studentName);
                    UniversityPeopleStorage.AddStudent(tempStudent);
                }
                Console.WriteLine("Student list was read from file");

                // create several teachers and save them in the static collection           
                Teacher drSheldon = new Teacher("Dr. Sheldon", (int)TeacherRank.Docent);
                Teacher drHouse = new Teacher("House M.D.", (int)TeacherRank.Assistant);

                UniversityPeopleStorage.AddTeacher(drSheldon);
                UniversityPeopleStorage.AddTeacher(drHouse);

                // create several groups
                Group physicsCourse = new Group(10, drSheldon);
                Group medicineCourse = new Group(12, drHouse);


                UniversityPeopleStorage.AddGroup(physicsCourse);
                UniversityPeopleStorage.AddGroup(medicineCourse);

                // assign students to the group
                foreach (var curStudent in UniversityPeopleStorage.GetStudentList())
                {
                    if (physicsCourse.AddStudent(curStudent))
                    {
                      
                        // make physics group
                        Console.WriteLine($"To the {drSheldon.LastName,-15} group student {curStudent.LastName,-15} was added");
                        continue;
                    }
                    if (medicineCourse.AddStudent(curStudent))
                    {
                        // make medicine group
                        Console.WriteLine($"To the {drHouse.LastName,-15} group student {curStudent.LastName,-15} was added");
                        continue;
                    }

                }

                // write data about student in the group in the separate file
                // старайся одну операцию использовать в одной строке сейчас пока читаемо но если будет FuncA(FuncB(C)) или FuncA(FuncB(FuncC(D)) уже стремно тебе выпадет ошибка и ты будешь гадать где это у тебя в этом лайне код сломался в внутреней функции или что то не правильно с текущим лайном - нечитаемо и плохоя для дебага
                foreach (var curGroup in UniversityPeopleStorage.GetGroupList())
                {
                    foreach (var curStudent in curGroup.GetGroupStudentList())
                    {
                        // вынести в groupFileName стараемся хард код строк для сеттингов не юзать 
                        using (StreamWriter w = File.AppendText(curGroup.GroupNumber.ToString() + "group.txt" +
                            ""))
                        {
                            w.WriteLine(curStudent.LastName);
                        }
                    }
                }
                Console.WriteLine("Students lists were written to the files");

                // write unassignet student name to the file
                // вот обычно var используют когда тебе явно понятно что вернет тебе правая часть ты нигде не использовал там где можно было просто var написать, а вот в линку решил заюзать хотя тут с первого взгляда явно не указано и не понятно что вернет запрос 
                var unUssignedStudent = from curStudent in UniversityPeopleStorage.GetStudentList() where curStudent.GroupNumber == -1 select curStudent.LastName;
                foreach (var curStudentName in unUssignedStudent)
                {
                    using (StreamWriter w = File.AppendText("student_withoutGroup.txt"))
                    {
                        w.WriteLine(curStudentName);
                    }
                }
                Console.WriteLine("Unussigned students were written to the file");

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File StudentsList.txt didn't found");
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong data to create student list");

            }

            Console.ReadKey();

        }
    }
}
