using System.Text.Json;
using System.Text.Json.Serialization;
using Phone = Infra.Infra.ValueObjects.Phone;

namespace Infra.Infra.JsonConverters;

public class PhoneJsonConverter : JsonConverter<Phone>
{
  public override Phone? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var phone = reader.GetString();
    if(phone is null) return null;
    return new Phone(phone.Length switch
      {
        <= 9 => phone,
        10 or 11 => phone[2..],
        12 => phone,
        13 or 14 => phone[5..],
        _ => phone
      },
      phone.Length switch
      {
        < 8 => "",
        8 or 9 => "",
        10 => Phone.IsValidAreaCode(phone[..2]) ? phone[..2] : "",
        11 => Phone.IsValidAreaCode(phone[..2]) ? phone[..2] : "",
        13 or 14 => Phone.IsValidAreaCode(phone[3..5]) ? phone[3..5] : "",
        _ => ""
      },
      phone.Length switch
      {
        < 8 => "",
        8 or 9 => "",
        10 => "",
        11 => "",
        13 or 14 => phone[..3],
        _ => "",
      });
  }

  public override void Write(Utf8JsonWriter writer, Phone value, JsonSerializerOptions options)
  {
    writer.WriteStringValue(value.ToString());
  }
}
