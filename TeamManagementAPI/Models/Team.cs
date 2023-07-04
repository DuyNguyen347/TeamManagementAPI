using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManagementAPI.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public bool isDeleted { get; set; }
        public int IdLeague { get; set; }
        [ForeignKey("IdLeague")]
        public League? League { get; set; }
        public int IdStadium { get; set; }
        [ForeignKey("IdStadium")]
        public Stadium? Stadium { get; set; }
        public ICollection<Player>? Players { get; set; }
    }
}
