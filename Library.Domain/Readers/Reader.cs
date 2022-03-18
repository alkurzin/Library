using System;

namespace Library.Domain.Readers
{
    public class Reader
    {
        public int ReaderId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public Reader()
        {
        }

        public Reader(string fullName, DateTime birthDate)
        {
            FullName = fullName;
            BirthDate = birthDate;
        }

        public void Update(string fullName, DateTime birthDate)
        {
            FullName = fullName;
            BirthDate = birthDate;
        }
    }
}
