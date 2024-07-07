using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication4.Contracts;
using WebApplication4.DataAccess;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NotesDBContext _dbContext;
        public NotesController(NotesDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAsync([FromQuery] GetNotesRequest request, CancellationToken ct)
        {
            var notesQuery = _dbContext.notes
                .Where(n => string.IsNullOrEmpty(request.Search) ||
                    n.Name.ToLower().Contains(request.Search.ToLower()));

            Expression<Func<Note, object>> selectorKey = request.SortItem?.ToLower() switch
            {
                "date" => note => note.CreatedDate,
                "name" => note => note.Name,
                _ => note => note.Id,
            };

            notesQuery = request.SortOrder == "desc" 
                ? notesQuery.OrderByDescending(selectorKey) 
                : notesQuery.OrderBy(selectorKey);

            var noteDtos = await notesQuery
                .Select(n => new NoteDto(n.Id, n.Name, n.Description, n.CreatedDate))
                .ToListAsync(ct);

            return Ok(new GetNotesResponse(noteDtos));
        }

        [HttpGet("All")]
        public async Task<IActionResult> getAllAsync()
        {
            return Ok(_dbContext.notes);
        }

        [HttpPost]
        public async Task<IActionResult> createNoteAsync([FromBody] CreateNoteRequest request, CancellationToken ct)
        {
            var note = new Note(request.Name, request.Description);
            await _dbContext.notes.AddAsync(note, ct);
            await _dbContext.SaveChangesAsync(ct);

            return Ok();
        }

    }
}
