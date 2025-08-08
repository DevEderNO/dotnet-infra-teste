using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Infra.Infra.JsonConverters;
using Infra.Infra.ValueObjects;

namespace Infra.Domain.People;

public class People
{
  [Key]
  public Guid Id { get; private set; }
  [Required, MaxLength(200)]
  public string Name { get; private set; }
  [Required, JsonConverter(typeof(EmailJsonConverter))]
  public Email Email { get; private set; }
  [Required, JsonConverter(typeof(PhoneJsonConverter))]
  public Phone Phone { get; private set; }

  public People(string name, Email email, Phone phone){
    Id = Guid.NewGuid();
    Name = name;
    Email = email;
    Phone = phone;
  }
}
