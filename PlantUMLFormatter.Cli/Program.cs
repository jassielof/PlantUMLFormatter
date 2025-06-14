using Spectre.Console.Cli;
using PlantUMLFormatter.Cli.Commands.Format;



var app = new CommandApp<FormatCommand>();

app.Configure(conf =>
{
  conf.AddBranch<FormatSettings>("format", format =>
  {
    format.AddCommand<FormatCommand>("plantuml");
    format.AddExample("format", "Input file or directory.");
  });
});

return await app.RunAsync(args);
