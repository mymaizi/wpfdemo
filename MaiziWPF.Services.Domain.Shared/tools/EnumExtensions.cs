using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace MaiziWPF.Services.Domain.Shared
{
    public static class EnumExtensions
    {
        // 获取枚举的描述特性
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }

        // 将枚举转换为列表
        public static T[] GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }

        // 检查枚举值是否有效
        public static bool IsValid<T>(this T value) where T : Enum
        {
            return Enum.IsDefined(typeof(T), value);
        }

        // 获取枚举的整数值
        public static int GetIntValue<T>(this T value) where T : Enum
        {
            return Convert.ToInt32(value);
        }

        // 获取枚举的字符串
        public static String GetStringValue<T>(this T value) where T : Enum
        {
            return Convert.ToInt32(value)+"";
        }

        // 获取枚举的所有描述
        public static string[] GetAllDescriptions<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => e.GetDescription())
                .ToArray();
        }
    }
}
