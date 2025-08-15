using AngelStack.Common.Strings;
using System.Reflection;

namespace AngelStack.DomainDrivenDesign.Abstractions;

public abstract record StringValueValidatable : StringValue
{
    public StringValueValidatable(string value) : base(value) { }

    protected override void Validate()
    {
        if (ValidateFromOptions(out var errors)) return;

        var errorDetails = string.Join(", ", errors);
        throw new Exception($"Validation contain errors: [{errorDetails}]");
    }

    protected bool ValidateFromOptions(out IEnumerable<StringValidationError> errors)
    {
        bool required = GetType().GetCustomAttribute<Required>()?.Value ?? false;
        int minLength = GetType().GetCustomAttribute<MinLength>()?.Value ?? 0;
        int? maxLength = GetType().GetCustomAttribute<MaxLength>()?.Value;
        string? pattern = GetType().GetCustomAttribute<RegularExpression>()?.Value;

        var options = new StringValidationOptions(required, minLength, maxLength, pattern);

        var validator = new StringValidator(options);

        return validator.Validate(Value, out errors);
    }
}