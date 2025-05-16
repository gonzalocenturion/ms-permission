using FluentValidation;

namespace Permission.Application.Extensions;

public static class RuleExtension
{
    public static IRuleBuilderOptions<T, string> NotNullOrWhiteSpace<T>(
    this IRuleBuilder<T, string> ruleBuilder,
    string fieldName)
    {
        return ruleBuilder
            .NotEmpty()
            .WithMessage($"{fieldName} must not be null, empty or whitespace");
    }

    public static IRuleBuilderOptions<T, TEnum> MustBeDefinedEnum<T, TEnum>(
        this IRuleBuilder<T, TEnum> ruleBuilder,
        string fieldName) where TEnum : struct, Enum
    {
        return ruleBuilder
            .IsInEnum()
            .WithMessage($"{fieldName} is not allowed");
    }
}