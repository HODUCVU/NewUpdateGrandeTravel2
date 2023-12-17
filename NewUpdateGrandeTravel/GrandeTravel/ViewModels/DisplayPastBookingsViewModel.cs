using GrandeTravel.Models;

namespace GrandeTravel.ViewModels
{
    public class DisplayPastBookingsViewModel
    {
        public int total { get; set; }
        public IEnumerable<Booking>? Bookings { get; set; }
        public string? Username { get; set; }
    }
}
