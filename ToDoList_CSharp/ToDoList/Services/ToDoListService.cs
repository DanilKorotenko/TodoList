using System.Collections.Generic;
using ToDoList.DataModel;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Text.Json;

namespace ToDoList.Services
{
    public class ToDoListService
    {
        public interface Delegate
        {
            public void update();

        }

        private static readonly HttpClient client = new HttpClient();

/// Public methods ////////////////////////////////////////////////////////////////////////////

        public async Task<IEnumerable<ToDoItem>> GetItems()
        {
            ToDoItem[] result = new ToDoItem[0];
            try
            {
                using HttpResponseMessage response = await client.PostAsync("http://localhost:8080/getAllItems", null);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                ToDoItem[]? items = 
                    JsonSerializer.Deserialize<ToDoItem[]>(responseBody);

                if (items != null)
                {
                    result = items;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            result = pushToArray(result, new ToDoItem());

            return result;
        }

/// Private methods ////////////////////////////////////////////////////////////////////////////

        private ToDoItem[] pushToArray(ToDoItem[] arr, ToDoItem item)
        {
            ToDoItem[] result = new ToDoItem[arr.Length + 1];
            int i =0;
            for (; i< arr.Length; i++)
            {
                result[i] = arr[i];
            }
            result[i] = item;
            return result;
        }
    }
}
