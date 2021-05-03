using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixHW_Student.Model
{
    class Student
    {
        private string _firstName;
        private string _lastName;
        private string _group;

        public uint Id { get; set; }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = string.IsNullOrEmpty(value) 
                ? throw new Exception("Student name couldn't be empty.") 
                : value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = string.IsNullOrEmpty(value)
                ? throw new Exception("Student surname couldn't be empty.")
                : value;
        }

        public string Group
        {
            get => _group;
            set => _group = string.IsNullOrEmpty(value)
                ? throw new Exception("Student group couldn't be empty.")
                : value;
        }

        //public Student()
        //{
        //    this.Id = 0;
        //    this.FirstName = "Unknown";
        //    this.LastName = "Unknown";
        //    this.Group = "Unknown";
        //}

        public Student(string firstName, string lastName, string group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Group = group;
        }

        public string GetFullName()
        {
            return LastName + " " + FirstName;
        }
    }
}
