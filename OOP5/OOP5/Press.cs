namespace OOP5
{
    internal class Press
    {
        public Press(string title, Author author, Publisher publisher)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
        }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }

        public override string ToString()
        {
            return "Title: " + Title + ", Author: " + Author.Name + ", Publisher: " + Publisher.PubName;
        }
    }
}
