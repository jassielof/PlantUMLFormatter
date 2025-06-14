namespace PlantUMLFormatter.Cli.Commands.Format;

using System.ComponentModel;
using Spectre.Console.Cli;

public class FormatSettings : CommandSettings
{
  [CommandArgument(0, "[INPUT]")]
  [Description("Input file or directory to format.")]
  public string Input { get; set; } = "";
  [CommandOption("-o|--output <OUTPUT>")]
  [Description("Optional output file or directory.")]
  public string Output { get; set; } = "";

}
