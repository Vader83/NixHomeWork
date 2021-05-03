using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NixHW_Student.Model
{
    class Mark
    {
        private string _subject;
        private uint _markValue;

        public uint Id { get; set; }
        
        public uint StudentId { get; set; }

        public string Subject
        {
            get => _subject;
            set => _subject = string.IsNullOrEmpty(value)
                ? throw new Exception("Mark must reference to subject.")
                : value;
        }
        
        public uint MarkValue
        {
            get => _markValue;
            set => _markValue = value > 100
                ? throw new Exception("Mark value must be between 0 and 100")
                : value;
        }

        //public Mark()
        //{
        //    this.Id = 0;
        //    this.StudentId = 0;
        //    this.Subject = "Undefined";
        //    this.MarkValue = 0;
        //}

        public Mark(uint studentId, string subject, uint markValue)
        {
            this.Subject = subject;
            this.MarkValue = markValue;
            this.StudentId = studentId;
        }
    }
}
