using System.ComponentModel.DataAnnotations;

namespace ProOffice.BookingAPI.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(1,100)]
        public int Quantity { get; set; }
    }
}
