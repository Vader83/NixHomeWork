using System;
using NixHW_Student.Model;

namespace NixHW_Student
{
	class Program
	{
		static void Main()
		{
			StudentJournal.AddStudent(new Student("Ivan", "Ivanov", "CE-4-6"));
			StudentJournal.AddStudent(new Student("Peter", "Petrov", "AP-1-1"));
			StudentJournal.AddStudent(new Student("Vasiliy", "Vasiliev", "AP-1-1"));
			StudentJournal.AddStudent(new Student("Dmitri", "Dmitriev", "CE-4-6"));
			StudentJournal.AddStudent(new Student("Sidor", "Sidorov", "CE-4-5"));

			StudentJournal.AddMark(new Mark(1, "High Math",60u));
			StudentJournal.AddMark(new Mark(2, "High Math",85u));
			StudentJournal.AddMark(new Mark(3, "High Math",70u));
			StudentJournal.AddMark(new Mark(4, "High Math",90u));
			StudentJournal.AddMark(new Mark(5, "High Math", 56u));
			StudentJournal.AddMark(new Mark(1, "High Math", 80u));
			StudentJournal.AddMark(new Mark(1, "High Math", 85u));
			StudentJournal.AddMark(new Mark(2, "High Math", 85u));
			StudentJournal.AddMark(new Mark(2, "High Math", 85u));
			StudentJournal.AddMark(new Mark(3, "High Math", 65u));
			StudentJournal.AddMark(new Mark(4, "High Math", 90u));
			StudentJournal.AddMark(new Mark(5, "High Math", 55u));
			StudentJournal.AddMark(new Mark(3, "High Math", 69u));
			StudentJournal.AddMark(new Mark(5, "High Math", 60u));
			StudentJournal.AddMark(new Mark(4, "High Math", 95u));

			Console.WriteLine("============================================");
			Console.WriteLine($"Student average Mark: {StudentJournal.GetAvgMark()}");
			Console.WriteLine("============================================");
			StudentJournal.PrintBadStudents();
			Console.WriteLine("============================================");
			StudentJournal.PrintJournal();
		}
	}
}
