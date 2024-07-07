namespace WebApplication4.Contracts
{
    public record NoteDto(Guid Id, string Name, string Description, DateTime CreatedDate);
}
