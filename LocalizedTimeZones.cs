using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeZoneTest;

public class LocalizedTimeZones
{
    public required string IanaId { get; set; }
    public required string DisplayNameRu { get; set; }

    // Кэшируемое свойство — можно не хранить
    [NotMapped]
    public TimeZoneInfo TimeZoneInfo => TimeZoneInfo.FindSystemTimeZoneById(IanaId);

    [NotMapped]
    public TimeSpan CurrentOffset => TimeZoneInfo.GetUtcOffset(DateTime.UtcNow);
}
