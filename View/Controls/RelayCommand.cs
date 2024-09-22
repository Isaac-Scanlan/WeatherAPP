using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.View.Controls;

/// <summary>
/// A command that relays its execution to a delegate passed in via the constructor.
/// Implements the <see cref="ICommand"/> interface.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="RelayCommand"/> class.
/// </remarks>
/// <param name="execute">The action to execute when the command is invoked.</param>
public class RelayCommand(Action execute) : ICommand
{
    private readonly Action _execute = execute ?? throw new ArgumentNullException(nameof(execute));

    /// <summary>
    /// Occurs when changes occur that affect whether or not the command should execute.
    /// This event is required by the <see cref="ICommand"/> interface but is not used in this implementation.
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Determines whether the command can execute in its current state.
    /// Always returns <c>true</c> in this implementation.
    /// </summary>
    /// <param name="parameter">Data used by the command. Not used in this implementation.</param>
    /// <returns>Always returns <c>true</c>.</returns>
    public bool CanExecute(object? parameter) => true;

    /// <summary>
    /// Executes the command's action.
    /// </summary>
    /// <param name="parameter">Data used by the command. Not used in this implementation.</param>
    public void Execute(object? parameter)
    {
        _execute();
    }
}

