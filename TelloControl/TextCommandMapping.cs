using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace TelloControl;

public static class TextCommandMapping
{
    private static Dictionary<string, string> _commandDictionary = new Dictionary<string, string>();
    private static Dictionary<string, CommandData[]> _commandMapping = new Dictionary<string, CommandData[]>();


    static void Read()
    {
        _commandDictionary.Clear();
        _commandMapping.Clear();

        using (var reader = new StreamReader("Dictionary.csv"))
        {
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null
            }))
            {
                foreach (var record in csv.GetRecords<DictionaryData>())
                {
                    _commandDictionary.Add(record.Text.ToLower().Trim(), record.VoiceCommand.ToLower().Trim());
                }
            }
        }

        using (var reader = new StreamReader("CommandMapping.csv"))
        {
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                HeaderValidated = null
            }))
            {
                foreach (var record in csv.GetRecords<CommandData>().GroupBy(x => x.VoiceCommand))
                {
                    _commandMapping.Add(record.Key, record.Select(x => x).ToArray());
                }
            }
        }
    }

    public static string GetCommandClass(string text)
    {
        if (_commandDictionary.Count == 0)
            Read();

        _commandDictionary.TryGetValue(text.Trim().ToLower(), out string? result);
        return result ?? "-";
    }

    public static List<CommandData> GetCommand(string command)
    {
        if (_commandMapping.Count == 0)
            Read();

        _commandMapping.TryGetValue(command.Trim().ToLower(), out CommandData[]? result);
        return result?.ToList() ?? new List<CommandData>();
    }
}

public class DictionaryData
{
    public string Text { get; set; }
    public string VoiceCommand { get; set; }
}

public class CommandData
{
    public string VoiceCommand { get; set; }
    public double Time { get; set; }
    public string RCCommand { get; set; }
    public long? ticks { get; set; }
    public int? delayFromPreviousMS { get; set; }
    public byte[] commandBytes => Encoding.UTF8.GetBytes(RCCommand);
}

