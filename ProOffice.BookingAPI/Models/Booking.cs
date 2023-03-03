using System.ComponentModel.DataAnnotations;

namespace ProOffice.BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity { get; set; }
        public int ResourceId { get; set; }
    }
}
