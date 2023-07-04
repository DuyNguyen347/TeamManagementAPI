using System.ComponentModel.DataAnnotations;

namespace TeamManagementAPI.Models
{
    public class League
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int NumberOfTeams { get; set; }
        public ICollection<Team>? Teams { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; } = DateTime.Now;
        public bool isDeleted { get; set; } = false;
    }
}