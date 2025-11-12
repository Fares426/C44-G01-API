namespace E_commerce.ServiceAbstraction.Common;

public partial class Error
{
    public string Code { get; }
    public string Description { get; }
    public ErrorType Type { get; }
    public Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    public static Error Failure(string code = "General.Failure", string description = "A failure error has occured")
        => new(code, description, ErrorType.Failure);
    public static Error Validation(string code = "General.Validation", string description = "A Validation error has occured")
    => new(code, description, ErrorType.Validation);
    public static Error NotFound(string code = "General.NotFound", string description = "A 'Not Found' has occured")
        => new(code, description, ErrorType.NotFound);
    public static Error Conflict(string code = "General.Conflict", string description = "A Conflict error has occured")
        => new(code, description, ErrorType.Conflict);
    public static Error Unauthorized(string code = "General.Unauthorized", string description = "An Unauthorized error has occured")
        => new(code, description, ErrorType.Unauthorized);
}