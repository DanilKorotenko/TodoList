using System.Collections.Generic;
using ToDoList.DataModel;
using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace ToDoList.Services
{
    public class ToDoListService
    {
        private static readonly HttpClient client = new HttpClient();



        public async Task<IEnumerable<ToDoItem>> GetItems()
        {
            try
            {
                using HttpResponseMessage response = await client.PostAsync("http://localhost:8080/getAllItems", null);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            ToDoItem[] result = new ToDoItem[3];

            result[0] = new ToDoItem { Description = "Walk the dog" };
            result[1] = new ToDoItem { Description = "Buy some milk" };
            result[2] = new ToDoItem { Description = "Learn Avalonia", IsChecked = true };

            Console.WriteLine($"return result: {result}");

            return result;
        }
    }
}
