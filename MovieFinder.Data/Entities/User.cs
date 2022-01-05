namespace MovieFinder.Data.Entities;

public class User
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string? ImagePath { get; set; }
    public DateTime Created { get; set; }
    public string RoleId { get; set; }
    public virtual Role Role { get; set; }
    public virtual ICollection<Mark> Marks { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}