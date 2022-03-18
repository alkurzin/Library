namespace Library.Domain.Records
{
    public class Record
    {
        public int RecordId { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }

        public Record()
        {
        }

        public Record(int readerId, int bookId)
        {
            ReaderId = readerId;
            BookId = bookId;
        }

        public void Update(int readerId, int bookId)
        {
            ReaderId = readerId;
            BookId = bookId;
        }
    }
}
