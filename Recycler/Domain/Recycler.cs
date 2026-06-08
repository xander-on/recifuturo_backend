


using System.Globalization;

public class Recycler : Base
{
    public string? Ci { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Gender Gender { get; private set; }


    private Recycler() { }

    private Recycler(Guid id, string? ci, string name, Gender gender)
    {
        Id = id;
        Ci = ci;
        Name = name;
        Gender = gender;
    }


    public static Recycler Create(string? ci, string name, Gender gender)
    {
        return new Recycler(
            Guid.NewGuid(),
            ci,
            name,
            gender
        );
    }


    public void Update(string? ci, string? name, Gender? gender)
    {   
        if(ci is not null)
            Ci = ci;

        if(name is not null)
            Name = CultureInfo.CurrentCulture.TextInfo.ToUpper(name);

        if(gender is not null)
            Gender = gender.Value;
    }
}