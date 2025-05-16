using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace SharedKernel.Extensions;

public static class EnumExtension
{
    public static string ToDescription(this Enum value)
    {
        var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
        var descriptionAttribute =
            enumMember == null
                ? default
                : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
        return
            descriptionAttribute == null
                ? value.ToString()
                : descriptionAttribute.Description;
    }

    public static TEnum ToEnum<TEnum>(this string value)
        where TEnum : Enum
    {
        var query = from field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static)
                    let attr = field.GetCustomAttribute<EnumMemberAttribute>()
                    where attr != null && attr.Value != null
                    select (field.Name, attr.Value);

        var enumValue = query.FirstOrDefault(x => x.Value == value).Name;
        return (TEnum)Enum.Parse(typeof(TEnum), enumValue);
    }
}