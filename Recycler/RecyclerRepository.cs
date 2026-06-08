


using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;



public class RecyclerRepository
{
    private readonly AppDbContext _db;

    public RecyclerRepository(AppDbContext db) => _db = db;

    public async Task<bool> NameExistsAsync(string name, Guid? excludeId = null) =>
        await _db.Recyclers.AnyAsync(x =>
            x.Name.ToUpper() == name.Trim().ToUpper() && x.Id != excludeId);


    public async Task<bool> CiExistsAsync(string ci, Guid? excludeId = null) =>
        await _db.Recyclers.AnyAsync(x =>
            x.Ci == ci && x.Id != excludeId);
}