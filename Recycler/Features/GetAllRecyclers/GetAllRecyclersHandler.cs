



using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class GetAllRecyclersHandler
{
    private readonly AppDbContext _db;

    public GetAllRecyclersHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IResult> HandleAsync()
    {
        var recyclers = await _db.Recyclers
            .AsNoTracking()
            .Select(r => new RecyclerResponse(r.Id, r.Ci, r.Name, r.Gender))
            .ToListAsync();

        return Results.Ok(recyclers);
    }
    
}