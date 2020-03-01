using System;
namespace CLUBBaistWeb.Helper
{
    public class BookTeeTimeReservation
    {
        public string Date { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public string AMorPM { get; set; }
        public DateTime ViewTeeTimeBox { get; set; }
        public int NumberOfPlayers { get; set; }

        public int NumberOfCarts { get; set; }

        public string MemberName2 { get; set; }
        public string MemberName3 { get; set; }
        public string MemberName4 { get; set; }
        public string PhoneNumber { get; set; }
    }
}