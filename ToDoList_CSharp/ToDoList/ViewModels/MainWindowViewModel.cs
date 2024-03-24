using ToDoList.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
             ToDoList = new ToDoListViewModel();
        }

        public ToDoListViewModel ToDoList { get; }
    }
}
