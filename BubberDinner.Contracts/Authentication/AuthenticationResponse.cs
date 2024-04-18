namespace BubberDinner.Contracts.Authentication
{
    public record AuthenticationResponse
    (
        Guid Id,
        string firstName,
        string lastName,
        string Email,
        string Token
    );
}