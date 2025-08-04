using System.Globalization;
using TimeZoneTest;

var timeZones = TimeZoneInfo.GetSystemTimeZones();

await GetTextOutput();

void GetConsoleOutput()
{
    foreach (var tz in timeZones)
    {
        string ianaId = tz.Id; // на Linux — это IANA ID
        var offset = tz.GetUtcOffset(DateTime.UtcNow);
        string offsetFormatted = $"UTC{(offset >= TimeSpan.Zero ? "+" : "-")}{offset:hh\\:mm}";

        System.Console.WriteLine("=====" + tz.DisplayName + "=======");
        foreach (var tzProp in tz.GetType().GetProperties())
        {
            Console.WriteLine($"{tzProp.Name} = {tzProp.GetValue(tz)}");
        }
    }

}

async Task GetTextOutput()
{
    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru-RU");
    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("ru-RU");

    var list = new List<string>();

    foreach (var tz in TimeZoneInfo.GetSystemTimeZones())
    {
        list.Add($"{tz.Id} => {tz.DisplayName}");
    }

    await File.WriteAllLinesAsync("timezones.txt", list);
}

