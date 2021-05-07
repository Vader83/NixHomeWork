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

        private static readonly List<Student> _students;
        private static readonly List<Mark> _marks;

        static StudentJournal()
        {
            _students = new List<Student>();
            _currentStudentId = (uint)_students.Count;

            _marks = new List<Mark>();
            _currentMarkId = (uint) _marks.Count;
        }

        public static void AddStudent(Student newStudent)
        {
	        if (_students.Contains(newStudent))
		        throw new Exception("This student already exists.");

	        newStudent.Id = ++_currentStudentId;
            _students.Add(newStudent);
        }

        public static void AddMark(Mark mark)
        {
            if (!_students.Exists(student => student.Id == mark.StudentId))
                throw new Exception("There is no student with such id.");

            mark.Id = ++_currentMarkId;
            _marks.Add(mark);
        }

        public static double GetStudentAvgMark(Student student)
        {
	        if (!_students.Exists(stud => stud.Id == student.Id))
		        throw new Exception("There is no student with such id.");

            var query = _students.Join(_marks, stud => student.Id, mark => mark.StudentId, (stud, mark) => mark);
            if (query.Any())
                return query.Average(mark => mark.MarkValue);
            throw new Exception("This student doesn't have any mark.");
        }

        public static double GetAvgMark()
        {
			if (_marks.Count > 0)
				return (double)_marks.Average(mk => mk.MarkValue);
			throw new Exception("There is no mark in journal.");
        }

        public static List<Student> GetStudents()
        {
	        return _students;
        }

        public static List<Mark> GetMarks()
        {
	        return _marks;
        }

        public static IEnumerable<JournalCell> GetBadStudents()
        {
	        IEnumerable<JournalCell> query = _students
		        .Join(_marks, student => student.Id, mark => mark.StudentId, (student, mark) => new JournalCell(student, mark))
		        .Where(cell => cell.Mark.MarkValue < 60);

	        return query;
        }
    }
}
