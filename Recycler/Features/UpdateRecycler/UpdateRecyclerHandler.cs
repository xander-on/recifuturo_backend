




using System.ComponentModel.DataAnnotations;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class UpdateRecyclerHandler
{
    private readonly AppDbContext _db;
    private readonly RecyclerRepository _repository;

    public UpdateRecyclerHandler(AppDbContext db, RecyclerRepository repository)
    {
        _db = db;
        _repository = repository;
    }


    public async Task<IResult> HandleAsync(Guid id, UpdateRecyclerRequest request)
    {
        var recycler = await _db.Recyclers.FindAsync(id);

        if (recycler is null)
            return Results.NotFound(new { error = $"Reciclador con ID {id} no encontrado." });

        if (request.Name is not null)
            if (await _repository.NameExistsAsync(request.Name, id))
                return Results.Conflict(new { error = $"El nombre '{request.Name}' ya está en uso." });

        if (request.Ci is not null)
            if (await _repository.CiExistsAsync(request.Ci, id))
                return Results.Conflict(new { error = $"La CI '{request.Ci}' ya está en uso." });


        recycler.Update(request.Ci, request.Name, request.Gender);
        await _db.SaveChangesAsync();

        return Results.Ok(new UpdateRecyclerResponse(recycler.Id, recycler.Ci, recycler.Name, recycler.Gender));
    }
}