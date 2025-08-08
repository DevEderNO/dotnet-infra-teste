using System.Text.Json;
using System.Text.Json.Serialization;
using Email = Infra.Infra.ValueObjects.Email;

namespace Infra.Infra.JsonConverters;

public class EmailJsonConverter : JsonConverter<Email>
{
  public override Email? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var email = reader.GetString();
    return new Email(email!);
  }

  public override void Write(Utf8JsonWriter writer, Email value, JsonSerializerOptions options)
  {
    writer.WriteStringValue(value.Address);
  }
}
