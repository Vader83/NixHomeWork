
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixHW_Student.Model
{

    static class StudentJournal
    {
        private static uint _currentStudentId;
        private static uint _currentMarkId;

        private static List<Student> _students;
        private static List<Mark> _marks;

        static StudentJournal()
        {
            _students = new List<Student>();
            _currentStudentId = (uint)_students.Count;

            _marks = new List<Mark>();
            _currentMarkId = (uint) _marks.Count;
        }

        public static void AddStudent(Student student)
        {
            student.Id = ++_currentStudentId;
            _students.Add(student);
        }

        public static void AddMark(Mark mark)
        {
            if (!_students.Exists(stud => stud.Id == mark.StudentId))
                throw new Exception("There is no student with such id.");

            mark.Id = ++_currentMarkId;
            _marks.Add(mark);
        }

        private static double GetStudentAvgMark(Student student)
        {
            double markSum = 0;
            double markCount = -1;

            var query = _students.Join(_marks, stud => student.Id, mark => mark.StudentId, (stud, mark) => mark);
            markSum = (double)query.Sum(mark => mark.MarkValue);
            markCount = (double)query.Count();

            return markSum / markCount;
        }

        public static double GetAvgMark()
        {
            double markSum = 0;
            double markCount = -1;

            markSum = (double)_marks.Sum(mk => mk.MarkValue);
            markCount = (double)_marks.Count();

            return markSum / markCount;
        }
        
        private static List<JournalCell> GetBadStudents()
        {
            var query = (from student in _students
                                        join mark in _marks on student.Id equals mark.StudentId
                                        where mark.MarkValue < 60
                                        select new JournalCell(student, mark)).ToList();

            //var query = (from student in _students
            //    join mark in _marks
            //        on student.Id equals mark.StudentId
            //    where mark.MarkValue < 60
            //    select new JournalCell(student, mark)).Distinct().ToList();

            return query;
        }

        public static void PrintBadStudents()
        {
            var badList = GetBadStudents();
            Console.WriteLine("Bad students:");
            foreach (var cell in badList)
            {
                Console.WriteLine($"Student: {cell.Student.GetFullName()}, Subject: {cell.Mark.Subject}, Mark: {cell.Mark.MarkValue}.");
            }
        }

        public static void PrintJournal()
        {
            if (_students.Count == 0)
            {
                Console.WriteLine("There is no records in journal");
                return;
            }
            foreach (var student in _students)
            {
                Console.WriteLine($"Student: {student.GetFullName()}, Average mark: {GetStudentAvgMark(student)}");
            }
        }

    }
}
