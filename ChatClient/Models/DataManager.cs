using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Models
{
    public class DataManager
    {
        private HttpClient httpClient = new HttpClient();
        
        public async Task<List<Dialog>> GetDialogs() 
        {
            await Console.Out.WriteLineAsync(httpClient.GetFromJsonAsync<IEnumerable<Dialog>>("http://localhost:5000/api/Dialogs").ToString());
            return await httpClient.GetFromJsonAsync<List<Dialog>>("http://localhost:5000/api/Dialogs") ??new List<Dialog>();
        }
    }
}
