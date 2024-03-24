using System;

namespace ToDoList.DataModel
{
    public class ToDoItem
    {
        public string item { get; set; } = String.Empty;
        public bool IsChecked { get; set; }
    }
}
