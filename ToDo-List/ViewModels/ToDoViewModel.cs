using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDo_List.Models;

namespace ToDo_List.ViewModels
{
    public class ToDoViewModel
    {
        public ObservableCollection<ToDoItem> Tasks { get; set; }

        public string NewTaskTitle { get; set; }
        public string NewTaskDescription { get; set; }

        public ICommand AddTaskCommand { get; }

        public ToDoViewModel()
        {
            Tasks = new ObservableCollection<ToDoItem>
            {
                new ToDoItem { Title = "Изучить WPF", Description = "Разобраться с XAML", IsCompleted = false },
                new ToDoItem { Title = "Создать ToDo", Description = "Реализовать MVVM", IsCompleted = false },
                new ToDoItem { Title = "Репетиторство", Description = "Провести репетиторство", IsCompleted = false }
            };

            AddTaskCommand = new RelayCommand(AddTask);
        }

        private void AddTask(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTitle))
            {
                Tasks.Add(new ToDoItem { Title = NewTaskTitle, Description = NewTaskDescription, IsCompleted = false });

                // Очищаем поля ввода
                NewTaskTitle = string.Empty;
                NewTaskDescription = string.Empty;
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);
    }
}
