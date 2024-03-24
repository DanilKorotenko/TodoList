using System;

namespace ToDoList.DataModel
{
    public class ToDoItem
    {
        public int id { get; set; } = 0;
        public string item { get; set; } = String.Empty;
        public bool IsChecked { get; set; }
    }
}
