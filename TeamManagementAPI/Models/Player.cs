using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManagementAPI.Models
{
    public enum Position
    {
        GK,CB,RB,LB,CDM,CAM,LW,RW,CF,ST
    }
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Position Position { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public bool isDeleted { get; set; }
        public int Id_Team { get; set; }
        [ForeignKey("Id_Team")]
        public Team? Team { get; set; }
    }
}