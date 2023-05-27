namespace Domain.Visitors
{
    /// <summary>
    /// دستگاهی که کاربر استفده می کند
    /// </summary>
    public class Device
    {
        public string Brand { get; set; }
        public string Family { get; set; }
        public string Model { get; set; }
        public bool IsSpider { get; set; }  //کاربر ربات است یا خیر

    }
}
