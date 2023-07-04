using System.ComponentModel.DataAnnotations;

namespace TeamManagementAPI.Models
{
    public class Stadium
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string? Location { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public bool isDeleted { get; set; }
        public int NumberOfSeats { get; set; }
    }
}