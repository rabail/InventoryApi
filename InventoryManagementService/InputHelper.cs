using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace InventoryManagementService
{
    public class InputHelper : IInputHelper
    {
        private string apiPath = "http://localhost:3000/inventory/";

        private async Task<string> ReadInput()
        {
            string input = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage reader = await client.GetAsync(apiPath))
                    {
                        input = await reader.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return input;
        }

        public async Task<InventoryModel> GetInputAsString()
        {
            InventoryModel inv = JsonConvert.DeserializeObject<InventoryModel>(await ReadInput());
            return inv;
        }
    }
}
