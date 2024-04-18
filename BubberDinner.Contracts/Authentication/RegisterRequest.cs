namespace BubberDinner.Contracts.Authentication
{
    public record RegisterRequest
    (
        string firstName,
        string lastName,
        string Email,
        string Password
    );
}