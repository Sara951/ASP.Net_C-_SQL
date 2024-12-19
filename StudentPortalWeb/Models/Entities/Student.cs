namespace StudentPortalWeb.Models.Entities
{
    // Ensure that the correct namespaces are being used
    using System;

    public class Student
    {
        public Guid Id { get; set; } //global uniq identifer GUID
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Subscribed { get; set; }
    }
}
