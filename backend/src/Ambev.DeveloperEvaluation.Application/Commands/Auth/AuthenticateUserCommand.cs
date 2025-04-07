using Ambev.DeveloperEvaluation.Application.DTOs.Auth.Response;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Commands.Auth;

/// <summary>
/// Command for authenticating a user in the system.
/// Implements IRequest for mediator pattern handling.
/// </summary>
public class AuthenticateUserCommand : IRequest<AuthenticateUserResponseDto>
{
    /// <summary>
    /// Gets or sets the email address for authentication.
    /// Used as the primary identifier for the user.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password for authentication.
    /// Will be verified against the stored hashed password.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
