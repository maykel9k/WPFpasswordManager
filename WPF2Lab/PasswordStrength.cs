using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF2Lab
{
    public enum PasswordStrength
    {
        Invalid,
        VeryWeak,
        Weak,
        Average,
        Strong,
        VeryStrong
    }

    public static class PasswordStrengthUtils
    {
        public static PasswordStrength CalculatePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return PasswordStrength.Invalid;

            bool hasLowercase = false;
            bool hasUppercase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (var c in password)
            {
                if (char.IsDigit(c))
                    hasDigit = true;
                else if (char.IsLower(c))
                    hasLowercase = true;
                else if (char.IsUpper(c))
                    hasUppercase = true;
                else
                    hasSpecialChar = true;
            }

            int score = password.Length;
            if (hasLowercase) score += 2;
            if (hasUppercase) score += 2;
            if (hasDigit) score += 2;
            if (hasSpecialChar) score += 2;

            if (score < 10)
                return PasswordStrength.VeryWeak;
            if (score < 15)
                return PasswordStrength.Weak;
            if (score < 20)
                return PasswordStrength.Average;
            if (score < 25)
                return PasswordStrength.Strong;

            return PasswordStrength.VeryStrong;
        }
    }

    public class PasswordStrengthToColorConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PasswordStrength ret = PasswordStrengthUtils.CalculatePasswordStrength((string)value);
            switch (ret)
            {
                case PasswordStrength.VeryWeak:
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#f54842"));
                case PasswordStrength.Weak:
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#f57542"));
                case PasswordStrength.Average:
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#f5da42"));
                case PasswordStrength.Strong:
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#7bf542"));
                case PasswordStrength.VeryStrong:
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#237529"));
                default:
                    return null;
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PasswordStrengthToValueBarConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PasswordStrength ret = PasswordStrengthUtils.CalculatePasswordStrength((string)value);
            switch (ret)
            {
                case PasswordStrength.VeryWeak:
                    return 20;
                case PasswordStrength.Weak:
                    return 40;
                case PasswordStrength.Average:
                    return 60;
                case PasswordStrength.Strong:
                    return 80;
                case PasswordStrength.VeryStrong:
                    return 100;
                default:
                    return null;
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PasswordStrengthToEnumConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return PasswordStrengthUtils.CalculatePasswordStrength((string)value).ToString();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
