using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDoList.DataModel;
using ToDoList.Services;
using ReactiveUI;
using System;
using System.Timers;

namespace ToDoList.ViewModels
{
    public class ToDoListViewModel : ViewModelBase
    {
        private Timer timer;
        private ToDoListService service = new ToDoListService();

        public ToDoListViewModel()
        {
            timer = new Timer(2000);

            timer.Elapsed += Tick;

            timer.Enabled = true;

            update();
        }

        private async void Tick(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: starting a new callback.");
            update();
        }

        private async void update()
        {
            var allItems = await service.GetItems();
            this.ListItems = new ObservableCollection<ToDoItem>(allItems);

        }

        private ObservableCollection<ToDoItem> _listItems = new ObservableCollection<ToDoItem>();
        public ObservableCollection<ToDoItem> ListItems
        {
            get => _listItems;
            set => this.RaiseAndSetIfChanged(ref _listItems, value);
        }

    }
}
