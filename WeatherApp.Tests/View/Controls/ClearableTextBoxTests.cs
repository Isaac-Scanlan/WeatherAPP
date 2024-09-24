using WeatherApp.View.Controls;

namespace WeatherApp.Tests.View.Controls;

[CollectionDefinition("WpfTestCollection", DisableParallelization = true)]
public class ClearableTextBoxTests
{
    [StaFact]
    public void ClearableTextBox_ShouldInitializeClearCommand()
    {
        // Arrange & Act
        ClearableTextBox? clearableTextBox = new();

        // Assert
        Assert.NotNull(clearableTextBox.ClearCommand);
    }

    [StaFact]
    public void ClearCommand_ShouldClearText_WhenExecuted()
    {
        // Arrange
        string content = "Test Text";
        ClearableTextBox? clearableTextBox = new()
        {
            Text = content
        };

        // Act
        clearableTextBox.ClearCommand.Execute(null);

        // Assert
        Assert.Equal(string.Empty, clearableTextBox.Text);
    }

}
