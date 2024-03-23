using ToDoList.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Nito.AsyncEx;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
             ToDoList = new ToDoListViewModel();
        }

        // public MainWindowViewModel()
        // {
        //     InitializationNotifier = NotifyTaskCompletion.Create(InitializeAsync());
        // }

        // public INotifyTaskCompletion InitializationNotifier { get; private set; }

        // private async Task InitializeAsync()
        // {
        //     var service = new ToDoListService();
        //     var allItems = await service.GetItems();
        //     await Task.Delay(1000);

        //     ToDoList = new ToDoListViewModel(allItems);
        // }


        public ToDoListViewModel ToDoList { get; }
    }
}
