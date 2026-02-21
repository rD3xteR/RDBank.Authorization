namespace Core.Dal.Models;

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public decimal Balance { get; set; }
    public string? Number { get; set; }

    public Guid UserId { get; set; }
    public UserProfile? UserInfo { get; set; }
}
