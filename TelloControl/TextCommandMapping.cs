using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace TelloControl;

public static class TextCommandMapping
{
    private static Dictionary<string, string> _commandDictionary = new Dictionary<string, string>();

    static void Read()
    {
        _commandDictionary.Clear();
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
                    _commandDictionary.Add(record.Text.ToLower().Trim(), record.Category.ToLower().Trim());
                }
            }
        }
    }

    public static string GetCommand(string text)
    {
        if (_commandDictionary.Count == 0)
            Read();
        
        _commandDictionary.TryGetValue(text.Trim().ToLower(), out string? result);
        return result ?? "-";
    }
}

public class DictionaryData
{
    public string Text { get; set; }
    public string Category { get; set; }
}