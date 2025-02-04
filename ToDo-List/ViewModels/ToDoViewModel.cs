using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List.Models;

namespace ToDo_List.ViewModels
{
    public class ToDoViewModel
    {
        public ObservableCollection<ToDoItem> Tasks { get; set; }

        public ToDoViewModel()
        {
            Tasks = new ObservableCollection<ToDoItem>
            {
                new ToDoItem { Title = "Изучить WPF", Description = "Разобраться с XAML", IsCompleted = false },
                new ToDoItem { Title = "Создать ToDo", Description = "Реализовать MVVM", IsCompleted = false },
                new ToDoItem { Title = "Репетиторство", Description = "Провести репетиторство", IsCompleted = false }
            };
        }
    }
}
