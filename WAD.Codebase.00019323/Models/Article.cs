namespace WAD.Codebase._00019323.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }

        // Foreign key
        public int NewspaperId { get; set; }
        // Navigation property
        public Newspaper Newspaper { get; set; }
    }
}
