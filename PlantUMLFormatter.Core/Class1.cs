using System.Text.RegularExpressions;

namespace PlantUMLFormatter.Core;

public class PlantUmlBlock(int startLine, int endLine, string content)
{
  public int StartLine { get; } = startLine;
  public int EndLine { get; } = endLine;
  public string Content { get; } = content;
}

public static class PlantUmlBlockExtractor
{
  private static readonly Regex BlockRegex = new Regex(
    @"(^|\r?\n)[ \t]*@startuml.*?(?:(\r?\n.*?)*?)@enduml[ \t]*(\r?\n|$)",
    RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase
  );

  public static List<PlantUmlBlock> ExtractBlocks(string content)
  {
    var matches = BlockRegex.Matches(content);
    var blocks = new List<PlantUmlBlock>();

    foreach (Match match in matches)
    {
      var text = match.Value;
      var startLine = content[..match.Index].Split('\n').Length;
      var endLine = startLine + text.Split('\n').Length - 1;
      blocks.Add(new PlantUmlBlock(startLine, endLine, text));
    }

    return blocks;
  }
}
