namespace Blog.Application.Common.Models.ServiceResult;

public record ServiceError(string Message, int Code)
{
    public static ServiceError DefaultError => new("An exception occured.", 999);

    public static ServiceError ModelStateError(string validationError) => new(validationError, 998);

    public static ServiceError ForbiddenError => new("You are not authorized to call this action.", 998);

    public static ServiceError CustomMessage(string errorMessage) => new(errorMessage, 997);

    public static ServiceError Canceled => new("The request canceled successfully!", 994);

    public static ServiceError NotFound => new("The specified resource was not found.", 990);

    public static ServiceError ValidationFormat => new("Request object format is not true.", 901);

    public static ServiceError Validation => new("One or more validation errors occurred.", 900);

    public static ServiceError SearchAtLeastOneCharacter => new("Search parameter must have at least one character!", 898);

    public static ServiceError ServiceProviderNotFound => new("Service Provider with this name does not exist.", 700);

    public static ServiceError ServiceProvider => new("Service Provider failed to return as expected.", 600);

    public static ServiceError DateTimeFormatError => new("Date format is not true. Date format must be like yyyy-MM-dd (2019-07-19)", 500);

    #region Overrides
    public override int GetHashCode() => Code;
    #endregion
}