namespace PlantUMLFormatter.Tests.Class;

public class ClassTest
{
  [Theory]
  [InlineData("Class.pu")]
  public void ProducesExpectedOutput(string input)
  {
    var samplesPath = Path.Combine("Class", input);
    var expected = Path.Combine("Expected", input);
    string content = File.ReadAllText(samplesPath);
    string expectedContent = File.ReadAllText(expected);


    string formatted = PlantUMLFormatter.Core.Formatter.Format(content);

    Assert.Equal(expectedContent, formatted);
  }
}
