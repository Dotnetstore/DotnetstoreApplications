using LuhnNet;
using System.Text.RegularExpressions;

namespace Dotnetstore.Core.Structs;

public partial struct SwedishSocialSecurityNumber : IEquatable<SwedishSocialSecurityNumber>
{
    private const string YearHundredOpt = @"(19|20)?"; // 19 or 20 only (optional)
    private const string YearDecade = @"(\d{2})"; // any two digits
    private const string Month = @"(0[1-9]|10|11|12)"; // 01 to 12
    private const string Day = @"(0[1-9]|1\d|2\d|30|31)"; // 01 to 31
    private const string SeparatorAndLastFourOpt = @"([-\+]?)(\d{4})?"; // optional - or + followed by any four digits (optional)

    private const string RegExForValidation = $"^{YearHundredOpt}{YearDecade}{Month}{Day}{SeparatorAndLastFourOpt}$";

    private static readonly Regex personNoRegex = SsnRegex();

    private readonly string _rawSwedishSocialSecurityNumber;
    private readonly string _swedishSocialSecurityNumber;
    private readonly bool _isValid;
    private readonly bool _isPlus100YearsOld;

    public SwedishSocialSecurityNumber(string swedishSocialSecurityNumber)
    {
        _rawSwedishSocialSecurityNumber = swedishSocialSecurityNumber;

        var matches = personNoRegex.Matches(swedishSocialSecurityNumber);
        var normalizedYYMMDDXXXC = string.Empty;
        _isPlus100YearsOld = false;

        foreach (var match in matches.Cast<Match>())
        {
            if (!match.Success) continue;

            normalizedYYMMDDXXXC = $"{match.Groups[2].Value}{match.Groups[3].Value}{match.Groups[4].Value}{match.Groups[6].Value}";
            if (match.Groups[5].Success)
            {
                _isPlus100YearsOld = match.Groups[5].Value == "+";
            }
            break;
        }

        if (normalizedYYMMDDXXXC.Length > 6)
        {
            _isValid = personNoRegex.IsMatch(swedishSocialSecurityNumber) && Luhn.IsValid(normalizedYYMMDDXXXC);
        }
        else
        {
            _isValid = personNoRegex.IsMatch(swedishSocialSecurityNumber);
        }

        _swedishSocialSecurityNumber = string.IsNullOrEmpty(normalizedYYMMDDXXXC) ? _rawSwedishSocialSecurityNumber : normalizedYYMMDDXXXC;
    }

    public string Number => _swedishSocialSecurityNumber;

    public bool IsPlus100YearsOld => _isPlus100YearsOld;

    public bool IsValid => _isValid;

    public bool IsMale => !IsFemale;

    public bool IsFemale
    {
        get
        {
            var genderCharacter = _swedishSocialSecurityNumber.Substring(_swedishSocialSecurityNumber.Length - 2, 1);
            return int.Parse(genderCharacter) % 2 == 0;
        }
    }

    public override string ToString()
    { return Number; }

    public bool Equals(SwedishSocialSecurityNumber other)
    {
        return Equals(other._swedishSocialSecurityNumber, _swedishSocialSecurityNumber);
    }

    public override bool Equals(object? obj)
    {
        return obj is SwedishSocialSecurityNumber number && Equals(number);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var result = _rawSwedishSocialSecurityNumber != null ? _rawSwedishSocialSecurityNumber.GetHashCode() : 0;
            result = result * 397 ^ (_swedishSocialSecurityNumber != null ? _swedishSocialSecurityNumber.GetHashCode() : 0);
            result = result * 397 ^ _isValid.GetHashCode();
            return result;
        }
    }

    public static bool operator ==(SwedishSocialSecurityNumber left, SwedishSocialSecurityNumber right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(SwedishSocialSecurityNumber left, SwedishSocialSecurityNumber right)
    {
        return !left.Equals(right);
    }

    [GeneratedRegex("^(19|20)?(\\d{2})(0[1-9]|10|11|12)(0[1-9]|1\\d|2\\d|30|31)([-\\+]?)(\\d{4})?$", RegexOptions.Compiled)]
    private static partial Regex SsnRegex();
}