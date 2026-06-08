
public record GetAllRecyclerResponse();



public record RecyclerResponse(
    Guid Id, 
    string? Ci,
    string Name, 
    Gender Gender
);