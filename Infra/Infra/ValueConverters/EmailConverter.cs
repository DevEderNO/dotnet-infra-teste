using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Email = Infra.Infra.ValueObjects.Email;

namespace Infra.Infra.ValueConverters;

public class EmailConverter
{
  public static ValueConverter<Email, string> Converter => 
    new(
      email => email.Address,
      address => new Email(address)
    );
}
