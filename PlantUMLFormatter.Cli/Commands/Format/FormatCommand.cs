using PlantUMLFormatter.Core;
using Spectre.Console.Cli;
namespace PlantUMLFormatter.Cli.Commands.Format;

public class FormatCommand : AsyncCommand<FormatSettings>
{
  public override async Task<int> ExecuteAsync(CommandContext context, FormatSettings settings)
  {
    if (string.IsNullOrWhiteSpace(settings.Input))
    {
      Console.WriteLine("No input file or directory specified.");
      return 1;
    }

    if (!File.Exists(settings.Input))
    {
      Console.WriteLine($"Input file '{settings.Input}' does not exist.");
      return 1;
    }

    var content = await File.ReadAllTextAsync(settings.Input);
    var blocks = PlantUmlBlockExtractor.ExtractBlocks(content);

    Console.WriteLine($"Found {blocks.Count} diagram block(s).");
    for (int i = 0; i < blocks.Count; i++)
    {
      Console.WriteLine($"Block {i + 1}: lines {blocks[i].StartLine}-{blocks[i].EndLine}");
    }

    // Next: Format each block and write output (in Phase 2)
    return 0;
  }

}
