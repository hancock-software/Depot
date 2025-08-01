namespace Depot.Auth.Features.Users.ChangePassword;

using System.Text.Json.Serialization;
using ErrorOr;
using Mestra.Abstractions;

public class ChangePasswordCommand : IRequest<ErrorOr<ChangePasswordResponse>>
{
    [JsonPropertyName("old_password")]
    public string OldPassword { get; set; } = null!;

    [JsonPropertyName("new_password")]
    public string NewPassword { get; set; } = null!;
}