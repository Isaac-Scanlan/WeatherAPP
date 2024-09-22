using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.Helpers;

/// <summary>
/// A command that relays its execution logic to the provided delegates.
/// Implements the <see cref="ICommand"/> interface for use in XAML or MVVM patterns.
/// </summary>
public class RelayCommand : ICommand
{
    private readonly Func<Task> _execute;
    private readonly Func<bool>? _canExecute;

    /// <summary>
    /// Occurs when changes occur that affect whether or not the command can execute.
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="RelayCommand"/> class.
    /// </summary>
    /// <param name="execute">The execution logic, as a <see cref="Func{Task}"/>.</param>
    /// <param name="canExecute">The execution status logic, as a <see cref="Func{Boolean}"/>. Optional.</param>
    public RelayCommand(Func<Task> execute, Func<bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    /// <summary>
    /// Defines the method that determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">Data used by the command. This parameter is not used.</param>
    /// <returns><c>true</c> if this command can be executed; otherwise, <c>false</c>.</returns>
    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute();
    }

    /// <summary>
    /// Defines the method to be called when the command is invoked.
    /// </summary>
    /// <param name="parameter">Data used by the command. This parameter is not used.</param>
    public async void Execute(object? parameter)
    {
        await _execute();
    }

    /// <summary>
    /// Raises the <see cref="CanExecuteChanged"/> event to notify that the execution status has changed.
    /// </summary>
    public void RaiseCanExecuteChnged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
