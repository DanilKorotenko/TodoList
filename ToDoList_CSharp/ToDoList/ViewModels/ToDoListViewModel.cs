using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using ToDoList.DataModel;
using ToDoList.Services;
using ReactiveUI;
using System;
using System.Timers;

namespace ToDoList.ViewModels
{
    public class ToDoListViewModel : ViewModelBase, ToDoListService.Delegate
    {
        // private Timer? timer = null;
        private ToDoListService service = new ToDoListService();

        public ToDoListViewModel()
        {
            // timer = new Timer(2000);
            // timer.Elapsed += Tick;
            // timer.Enabled = true;
// TODO: subscribe to text box event.
            updateAsync();
        }

        private void Tick(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: starting a new callback.");
            updateAsync();
        }

        void ToDoListService.Delegate.update()
        {
            updateAsync();
        }

        private async void updateAsync()
        {
            var allItems = await service.GetItems();
            this.ListItems = new ObservableCollection<ToDoItem>(allItems);
        }

        public void PropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != null)
            {
                Console.WriteLine($"property changed sender: {sender}");

            }
            Console.WriteLine("property changed");
        }

/// <summary>
/// Properties///////////////////////////////////////////////////////////////////////////////////////
/// </summary>
        private ObservableCollection<ToDoItem> _listItems = new ObservableCollection<ToDoItem>();
        public ObservableCollection<ToDoItem> ListItems
        {
            get => _listItems;
            set => this.RaiseAndSetIfChanged(ref _listItems, value);
        }

    }
}
