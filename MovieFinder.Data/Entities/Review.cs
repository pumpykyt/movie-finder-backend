namespace MovieFinder.Data.Entities;

public class Review
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsPositive { get; set; }
    public string UserId { get; set; }
    public string MovieId { get; set; }
    public virtual User User { get; set; }
    public virtual Movie Movie { get; set; }
}