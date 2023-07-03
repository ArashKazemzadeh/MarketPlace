using ConsoleApp1.Models;


namespace Domin.IRepositories.Dtos.Image
{
    public class ImageUserAddDto
    {
        public virtual int SellerId { get; set; }
        public string? Url { get; set; }
    }
}