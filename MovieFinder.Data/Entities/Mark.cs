namespace MovieFinder.Data.Entities;

public class Mark
{
    public string Id { get; set; }
    public int Value { get; set; }
    public string UserId { get; set; }
    public string MovieId { get; set; }
    public virtual User User { get; set; }
    public virtual Movie Movie { get; set; }
}