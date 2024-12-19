namespace StudentPortalWeb.Models.Entities
{
    public class AddStudentViewModel
    {
        public Guid Id { get; set; } //global uniq identifer GUID
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public bool Subscribed { get; set; }

    }
}
