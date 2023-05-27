

namespace Domain.Visitors
{
    public class Visitor
    {
        public  string Ip { get; set; }
        public string CurrentLink { get; set; } //لینکی که بازدید کرده است
        public string ReferrerLink { get; set; }  //لینکی که کاربر از آنجا آمده است
        public string Method { get; set; }  //متذی که کاربر ازون بازدید کرده
        public string Protocol { get; set; }  //http یا https
        public string PhysicalPath { get; set; }  // از کدام کنترلر و اکشن بازدید انجام داده 
        public VisitorVersion Browser { get; set; }
        public VisitorVersion OperationSystem { get; set; }
        public Device Device { get; set; }

    }
}
