namespace Domin.IRepositories.Dtos.Comment
{
    public class CommentAddDto
    {
        public string userId { get; set; }
        public int productId { get; set; }
        public string title { get; set; }
        public string describtion { get; set; }
    }
}
