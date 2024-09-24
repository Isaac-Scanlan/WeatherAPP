using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WeatherApp.Helpers;

namespace WeatherApp.Tests.Helpers;


public class RelayCommandTests
{
    [Fact]
    public void Constructor_WhenSynchronousActionIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        Action? execute = null;

        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(
            () => new RelayCommand(execute!));
    }

    [Fact]
    public void Constructor_WhenAsynchronousActionIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        Func<Task>? executeAsync = null;

        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(
            () => new RelayCommand(executeAsync!));
    }

    [Fact]
    public void CanExecute_WhenCanExecuteIsNull_ShouldReturnTrue()
    {
        // Arrange
        static void execute() { };
        RelayCommand? command = new(execute);

        // Act
        bool result = command.CanExecute(null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanExecute_WhenCanExecuteReturnsFalse_ShouldReturnFalse()
    {
        // Arrange
        static void execute() { };
        static bool canExecute() => false;

        RelayCommand? command = new(execute, canExecute);

        // Act
        bool result = command.CanExecute(null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CanExecute_WhenCanExecuteReturnsTrue_ShouldReturnTrue()
    {
        // Arrange
        static void execute() { };
        static bool canExecute() => true;

        RelayCommand command = new(execute, canExecute);

        // Act
        bool result = command.CanExecute(null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Execute_WhenCalled_ShouldInvokeSynchronousAction()
    {
        // Arrange
        bool wasExecuted = false;
        void execute() => wasExecuted = true;
        var command = new RelayCommand(execute);

        // Act
        command.Execute(null);

        // Assert
        Assert.True(wasExecuted);
    }

    [Fact]
    public async Task Execute_WhenCalled_ShouldInvokeAsynchronousAction()
    {
        bool wasExecuted = false;
        Func<Task> executeAsync = async () =>
        {
            await Task.Delay(4);
            wasExecuted = true;
        };

        var command = new RelayCommand(executeAsync);

        command.Execute(null);

        await Task.Delay(30); // Allow time for async execution
        Assert.True(wasExecuted);

    }

    [Fact]
    public void RaiseCanExecuteChanged_ShouldRaiseCanExecuteChangedEvent()
    {
        // Arrange
        var command = new RelayCommand(() => { });
        bool eventRaised = false;

        void OnCanExecuteChanged(object? sender, EventArgs args)
        {
            eventRaised = true;
        }

        // Subscribe to the CanExecuteChanged event
        command.CanExecuteChanged += OnCanExecuteChanged;

        // Act
        command.RaiseCanExecuteChanged();

        // Assert
        Assert.True(eventRaised);
    }
}
