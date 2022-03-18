using Library.Domain.Books;
using System;
using System.Collections.Generic;

namespace Library.Domain.Readers
{
    public class ReaderInfoDto
    {
        public int ReaderId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<Book> Books { get; set; }

        public ReaderInfoDto(Reader reader, IEnumerable<Book> books)
        {
            ReaderId = reader.ReaderId;
            FullName = reader.FullName;
            BirthDate = reader.BirthDate;
            Books = books;
        }
    }
}