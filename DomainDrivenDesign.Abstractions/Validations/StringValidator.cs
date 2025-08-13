using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DomainDrivenDesign.Abstractions.Validations;

public enum StringValidationError
{
    Required,
    TooShort,
    TooLong,
    InvalidFormat,
}

public record StringValidationOptions(
    bool Required = true,
    int MinLength = 0,
    int? MaxLength = null,
    [StringSyntax(StringSyntaxAttribute.Regex)] string? Pattern = null);

public class StringValidator
{
    private readonly Regex? _regex;

    public StringValidator(StringValidationOptions options)
    {
        Options = options;
        if (options.Pattern != null)
        {
            _regex = new(options.Pattern, RegexOptions.Compiled);
        }
    }
    public StringValidationOptions Options { get; }

    public virtual bool Validate(string? value, out IEnumerable<StringValidationError> errors)
    {
        List<StringValidationError> errorList = [];

        if (Options.Required && string.IsNullOrWhiteSpace(value))
        {
            errorList.Add(StringValidationError.Required);
        }
        if (string.IsNullOrEmpty(value) == false)
        {
            if (value.Length < Options.MinLength)
            {
                errorList.Add(StringValidationError.TooShort);
            }
            if (value.Length > Options.MaxLength)
            {
                errorList.Add(StringValidationError.TooLong);
            }
            if (_regex is not null && _regex.IsMatch(value) == false)
            {
                errorList.Add(StringValidationError.InvalidFormat);
            }
        }

        errors = errorList;
        return errorList.Count == 0;
    }
}