

public record UpdateRecyclerRequest(
    Guid? Id, 
    string? Ci, 
    string? Name, 
    Gender? Gender
);



public record UpdateRecyclerResponse(
    Guid Id, 
    string? Ci, 
    string Name, 
    Gender? Gender
);