using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using BaseballStatsApi.Infrastructure.Exceptions;

namespace BaseballStatsApi.Infrastructure.ValueObjects;

public partial record EmailAddress
{
    
    [GeneratedRegex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex EmailRegEx();
    public string Value { get; }

    public EmailAddress(string emailAddress)
    {
        if (!IsValidEmail(emailAddress))
        {
            throw new InvalidEmailException();
        }
        Value = emailAddress;
    }

    private static bool IsValidEmail(string email)
    {
        var regEx = EmailRegEx();
        return regEx.IsMatch(email);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }

    public virtual bool Equals(EmailAddress? other)
    {
        if (other == null) return false;
        return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
    }

    public override string ToString()
    {
        return Value;
    }

}