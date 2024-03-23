using System.Collections.Generic;
using ToDoList.DataModel;

using System.Net.Http;

namespace ToDoList.Services
{
    public class ToDoListService
    {
        private static readonly HttpClient client = new HttpClient();



        public IEnumerable<ToDoItem> GetItems()
        {
            ToDoItem[] result = new ToDoItem[3];
            // try
            // {
            //     using HttpResponseMessage response = await client.PostAsync("http://localhost:8080/getAllItems", null);
            //     response.EnsureSuccessStatusCode();
            //     string responseBody = await response.Content.ReadAsStringAsync();
            //     // Above three lines can be replaced with new helper method below
            //     // string responseBody = await client.GetStringAsync(uri);

            //     Console.WriteLine(responseBody);
            // }
            // catch (HttpRequestException e)
            // {
            //     Console.WriteLine("\nException Caught!");
            //     Console.WriteLine("Message :{0} ", e.Message);
            // }

            result[0] = new ToDoItem { Description = "Walk the dog" };
            result[1] = new ToDoItem { Description = "Buy some milk" };
            result[2] = new ToDoItem { Description = "Learn Avalonia", IsChecked = true };

            return result;
        }
    }
}
