namespace TeamManagementAPI.ViewModels
{
    public enum Position
    {
        GK, CB, RB, LB, CDM, CAM, LW, RW, CF, ST
    }
    public class PlayerVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public Position Position { get; set; }
        public string? NameTeam { get; set; }
    }
}
