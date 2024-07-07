namespace notesApp.Models
{
    public class Note
    {
        public Note(string name, string description)
        {
            Name = name;
            Description = description;
            CreatedDate = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
