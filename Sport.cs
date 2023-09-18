namespace task4;

public partial class Sport
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public int MinYear { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
