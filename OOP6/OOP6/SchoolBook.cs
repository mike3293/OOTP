namespace OOP_5_6
{
    public class SchoolBook : Book
    {
            public SchoolBook(string title, Author author, Publisher publisher, string genre, int grade) :base(title, author, publisher, genre)
            {
                Grade = grade;
            }

            public int Grade { get; set; }

        
    }
}
