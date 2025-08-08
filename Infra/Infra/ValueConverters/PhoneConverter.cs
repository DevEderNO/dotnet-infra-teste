using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Phone = Infra.Infra.ValueObjects.Phone;

namespace Infra.Infra.ValueConverters;

public class PhoneConverter
{
    public static ValueConverter<Phone, string> Converter =>
        new(
            phone => phone,
            phone => new Phone(phone.Length <= 9 ? phone :
                phone.Length == 10 || phone.Length == 11 ? phone.Substring(2) :
                phone.Length == 12 ? phone :
                phone.Length == 13 || phone.Length == 14 ? phone.Substring(5) : phone,
                phone.Length < 8 ? "" :
                phone.Length == 8 || phone.Length == 9 ? "" :
                phone.Length == 10 ? Phone.IsValidAreaCode(phone.Substring(0, 2)) ? phone.Substring(0, 2) : "" :
                phone.Length == 11 ? Phone.IsValidAreaCode(phone.Substring(0, 2)) ? phone.Substring(0, 2) : "" :
                phone.Length == 13 || phone.Length == 14 ? Phone.IsValidAreaCode(phone.Substring(3, 2)) ? phone.Substring(3, 2) : "" : "",
                phone.Length < 8 ? "" :
                phone.Length == 8 || phone.Length == 9 ? "" :
                phone.Length == 10 ? "" :
                phone.Length == 11 ? "" :
                phone.Length == 13 || phone.Length == 14 ? phone.Substring(0, 3) : "")
        );
}