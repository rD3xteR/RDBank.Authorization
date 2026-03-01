namespace Core.Dal.Models;

public class UserProfile
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthday { get; set; }
    public string Phone { get; set; }

    public string PassportNumber { get; set; }
    public string RegistrationAddress { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
