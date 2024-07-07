namespace notesApp.Contracts
{
    public record NoteDto(Guid Id, string Name, string Description, DateTime CreatedDate);
}
