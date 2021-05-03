using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixHW_Student.Model
{
    class JournalCell: IEquatable<JournalCell>
    {
        public Student Student { get; set; }
        public Mark Mark { get; set; }

        public JournalCell(Student student, Mark mark)
        {
            this.Student = student;
            this.Mark = mark;
        }

        public bool Equals(JournalCell other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Student, other.Student);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((JournalCell) obj);
        }

        public override int GetHashCode()
        {
            return (this.Student != null ? this.Student.GetHashCode() : 0);
        }
    }
}
