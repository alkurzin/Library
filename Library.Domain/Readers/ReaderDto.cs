using System;

namespace Library.Domain.Readers
{
    public class ReaderDto
    {
        public int ReaderId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}