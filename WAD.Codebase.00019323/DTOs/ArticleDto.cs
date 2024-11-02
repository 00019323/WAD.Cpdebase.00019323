namespace WAD.Codebase._00019323.DTOs
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public int NewspaperId { get; set; }
        public string NewspaperName { get; set; }
    }
}
