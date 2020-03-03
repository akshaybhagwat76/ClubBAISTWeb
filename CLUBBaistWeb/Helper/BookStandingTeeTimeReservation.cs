using System;
namespace CLUBBaistWeb.Helper
{
    /// <summary>
    /// Author : Akshay Bhagwat
    /// SKype Id : akshaybhagwat76@hotmail.com
    /// Gmail : akshaybhagwat76@gmail.com
    /// Freelancer : https://www.freelancer.com/u/akshaybhagwat76
    /// COntact : +91-7383328380
    /// </summary>
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