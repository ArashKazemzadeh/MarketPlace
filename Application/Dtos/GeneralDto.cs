namespace Application.Dtos
{
    public class GeneralDto
    {
        public string message { get; set; }
    }
    public class GeneralDto<T>
    {
        public string? message { get; set; }
        public T Data { get; set; }
    }
}
