using Domain.Abstractions;

namespace Domain.Errors;

public sealed class PlayerError
{
    public static readonly Error NotFound = new("Player.NotFound", "The player was not found");
}
