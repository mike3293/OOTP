namespace OOP_5_6_7
{
    public partial class Press
    {
        public Press(string title, Author author, Publisher publisher)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
        }

        public double Cost { get; set; }
        public double Year { get; set; }


        public override string ToString()
        {
            return "Title: " + Title + ", Author: " + Author.Name + ", Publisher: " + Publisher.PubName;
        }
    }
}
