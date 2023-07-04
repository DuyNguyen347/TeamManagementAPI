namespace TeamManagementAPI.ViewModels
{
    public class TeamVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdLeague { get; set; }
        public int IdStadium { get; set; }
        public string? NameStadium { get; set; }
        public string? NameLeague { get; set; }


    }
}
