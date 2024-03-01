using Microsoft.ML.Data;

namespace CommandClassification;

public class TextData
{
    [LoadColumn(0)]
    public string Text { get; set; }
    [LoadColumn(1)]
    public string Category { get; set; }
}