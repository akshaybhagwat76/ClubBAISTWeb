using System;

namespace CLUBBaistWeb.Helper
{
    public class BookStandingTeeTimeReservationVM
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RequestedTime { get; set; }
        public string DayOfWeek { get; set; }
        public int MemberNumber1 { get; set; }  
        public string MemberName1 { get; set; }
        public int MemberNumber2 { get; set; }
        public string MemberName2 { get; set; }
        public int MemberNumber3 { get; set; }
        public string MemberName3 { get; set; }
    }
}