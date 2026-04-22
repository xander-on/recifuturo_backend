public abstract class Base
{
    public Guid Id { get; protected set; } = Guid.NewGuid();

    public DateTime CreatedAt { get; set; }   
    public DateTime UpdatedAt { get; set; } 

    public bool IsActive { get; protected set; } = true;

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}