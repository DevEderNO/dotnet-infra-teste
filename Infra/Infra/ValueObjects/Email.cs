using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Infra.Infra.ValueObjects;

public partial class Email: IValidatableObject
{
   public string Address { get; private set; }

   public Email(string address){
    Address = address;
   }

   public override string ToString() => Address;

   [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
   public static partial Regex EmailRegex();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Address)) yield return new ValidationResult("Email cannot be empty");
        if (!EmailRegex().IsMatch(Address)) yield return new ValidationResult("Invalid email");
    }
}
