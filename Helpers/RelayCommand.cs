using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.Helpers;


/// <summary>
/// A command that relays its execution to the provided delegates (both synchronous and asynchronous).
/// Implements the <see cref="ICommand"/> interface for use in XAML or MVVM patterns.
/// </summary>
public class RelayCommand : ICommand
{
    private readonly Func<Task>? _executeAsync;
    private readonly Action? _execute;
    private readonly Func<bool>? _canExecute;

    /// <summary>
    /// Occurs when changes occur that affect whether or not the command can execute.
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="RelayCommand"/> class for synchronous actions.
    /// </summary>
    /// <param name="execute">The synchronous action to execute when the command is invoked.</param>
    /// <param name="canExecute">The execution status logic, as a <see cref="Func{Boolean}"/>. Optional.</param>
    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RelayCommand"/> class for asynchronous actions.
    /// </summary>
    /// <param name="executeAsync">The asynchronous function to execute when the command is invoked.</param>
    /// <param name="canExecute">The execution status logic, as a <see cref="Func{Boolean}"/>. Optional.</param>
    public RelayCommand(Func<Task> executeAsync, Func<bool>? canExecute = null)
    {
        _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        _canExecute = canExecute;
    }

    /// <summary>
    /// Determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">Data used by the command. Not used in this implementation.</param>
    /// <returns><c>true</c> if this command can be executed; otherwise, <c>false</c>.</returns>
    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute();
    }

    /// <summary>
    /// Executes the command's action synchronously or asynchronously, depending on the delegate provided.
    /// </summary>
    /// <param name="parameter">Data used by the command. Not used in this implementation.</param>
    public async void Execute(object? parameter)
    {
        if (_execute != null)
        {
            _execute();
        }
        else if (_executeAsync != null)
        {
            await _executeAsync();
        }
    }

    /// <summary>
    /// Raises the <see cref="CanExecuteChanged"/> event to notify that the execution status has changed.
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

