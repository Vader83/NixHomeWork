using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixHW_Student.Model
{
    class Student : IEquatable<Student>
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

        public Student(){}

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

        public override bool Equals(object obj)
        {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((Student) obj);
        }

        public bool Equals(Student other)
        {
	        if (ReferenceEquals(null, other)) return false;
	        if (ReferenceEquals(this, other)) return true;
	        return _firstName == other._firstName && _lastName == other._lastName && _group == other._group;
        }

        public override int GetHashCode()
        {
	        unchecked
	        {
		        var hashCode = (_firstName != null ? _firstName.GetHashCode() : 0);
		        hashCode = (hashCode * 397) ^ (_lastName != null ? _lastName.GetHashCode() : 0);
		        hashCode = (hashCode * 397) ^ (_group != null ? _group.GetHashCode() : 0);
		        hashCode = (hashCode * 397) ^ (int) Id;
		        return hashCode;
	        }
        }
    }
}
