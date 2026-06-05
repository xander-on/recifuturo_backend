



using FluentValidation;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class CreateRecyclerHandler
{
    private readonly AppDbContext _db;
    private readonly IValidator<CreateRecyclerRequest> _validator;
    public CreateRecyclerHandler(AppDbContext db, IValidator<CreateRecyclerRequest> validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<CreateRecyclerResponse> HandleAsync(CreateRecyclerRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if(!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cleanName = request.Name.Trim().ToUpper();
        var exists = await _db.Recyclers.AnyAsync(x => x.Name.ToUpper() == cleanName);

        if (exists)
            throw new ConflictException($"El reciclador '{cleanName}' ya existe.");

        var recycler = Recycler.Create(request.Ci, request.Name, request.Gender);

        await _db.Recyclers.AddAsync(recycler);
        await _db.SaveChangesAsync();

        return new CreateRecyclerResponse(recycler.Id, recycler.Ci, recycler.Name, recycler.Gender);
    }
}