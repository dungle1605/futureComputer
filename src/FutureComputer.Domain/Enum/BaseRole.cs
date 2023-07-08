using System;
using System.ComponentModel;
using SysEnum = System.Enum;

namespace FutureComputer.Domain.Enum;

public enum BaseRole
{
    [Description("Admin")]
    Admin = 1,
    [Description("User")]
    User = 2
}

public static class EnumExtensionMethods
{
    public static string GetEnumDescription(this SysEnum enumValue)
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

        var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
    }
}