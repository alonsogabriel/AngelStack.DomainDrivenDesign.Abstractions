using DomainDrivenDesign.Abstractions.Attributes;
using DomainDrivenDesign.Abstractions.Validations;
using System.Reflection;

namespace DomainDrivenDesign.Abstractions.ValueObjects;

public abstract record ValidatableStringValue : StringValue
{
    public ValidatableStringValue(string value) : base(value) { }

    protected override void Validate()
    {
        if (ValidateFromOptions(out var errors)) return;

        var errorDetails = string.Join(", ", errors);
        throw new Exception($"Validation contain errors: [{errorDetails}]");
    }

    protected bool ValidateFromOptions(out IEnumerable<StringValidationError> errors)
    {
        var attribute = this.GetType().GetCustomAttribute<StringValidation>();

        var options = new StringValidationOptions(
            attribute?.Required ?? true,
            attribute?.MinLength ?? 0,
            attribute?.MaxLength,
            attribute?.Pattern);

        var validator = new StringValidator(options);

        return validator.Validate(Value, out errors);
    }
}