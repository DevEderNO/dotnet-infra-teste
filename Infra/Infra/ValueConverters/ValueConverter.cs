using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.ValueConverters;

public static class ValueConverter
{
  public static ValueConverter<T, string> Converter<T>(Func<string, T> construtor, Func<T, string> extrator)
    => new (
        v => extrator(v),
        v => construtor(v)
    );
}
