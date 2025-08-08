using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Infra.Infra.ValueObjects;

public partial class Phone: IValidatableObject
{
  public string Number { get; private set; }
  public string AreaCode { get; private set; }
  public string CountryCode { get; private set; } = "+55";

  public Phone(string number, string areaCode, string countryCode){
    Number = number;
    AreaCode = areaCode;
    CountryCode = countryCode;
  }

  public static implicit operator string(Phone phone) => $"{phone.CountryCode}{phone.AreaCode}{phone.Number}";
  public override string ToString() => $"{CountryCode}{(string.IsNullOrEmpty(AreaCode) ? "" : $" ({AreaCode}) ")}{(Number.Length == 9 ? Number[..5] :Number[..4])}-{Number[^4..]}".Trim();
  
  public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
  {
    if(string.IsNullOrEmpty(Number)) yield return new ValidationResult("Number cannot be empty");
    if(!string.IsNullOrEmpty(AreaCode) && !AreaCodeRegex().IsMatch(AreaCode)) yield return new ValidationResult("Invalid area code");
    if(!string.IsNullOrEmpty(CountryCode) && !CountryCodeRegex().IsMatch(CountryCode)) yield return new ValidationResult("Invalid country code");
    if(!PhoneRegex().IsMatch(Number)) yield return new ValidationResult("Invalid phone number");
  }

  [GeneratedRegex(@"^[0-9]{8,9}$")]
  public static partial Regex PhoneRegex();

  [GeneratedRegex(@"^[0-9]{2}$")]
  public static partial Regex AreaCodeRegex();

  [GeneratedRegex(@"^\+[1-9]{2}$")]
  public static partial Regex CountryCodeRegex();
  
  [GeneratedRegex(@"^(?:\+?(\+\d{2}))?(?:(\d{2}))?(\d{8,9})$")]
  public static partial Regex CompletePhone();
  
  public static bool IsValidAreaCode(string areaCode) => 
    areaCode.Length == 2 && 
    new List<string>{"11", "12", "13", "14", "15", "16", "17", "18", "19", "21", "22", "24", "27", "28", "31", "32", "33", "34", "35", "37", "38", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "53", "54", "55", "61", "62", "63", "64", "65", "66", "67", "68", "69", "71", "73", "74", "75", "77", "79", "81", "82", "83", "84", "85", "86", "87", "88", "89", "91", "92", "93", "94", "95", "96", "97", "98", "99"}.Contains(areaCode);   
}