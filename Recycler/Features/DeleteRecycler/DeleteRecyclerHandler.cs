



using Infrastructure.Persistence;

public class DeleteRecyclerHandler
{
    private readonly AppDbContext _context;

    public DeleteRecyclerHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IResult> HandleAsync(Guid id)
    {
        var recycler = await _context.Recyclers.FindAsync(id);

        if (recycler is null)
            return Results.NotFound(new { error = $"Reciclador con ID {id} no encontrado." });

        if (!recycler.IsActive)
            return Results.BadRequest(new { error = $"Reciclador con ID {id} ya ha sido eliminado." });

        recycler.Deactivate();
        await _context.SaveChangesAsync();

        return Results.Ok(new{id});
    }
}