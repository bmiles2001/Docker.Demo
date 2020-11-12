using Client.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Docker.Demo.Client.Pages
{
    public class BasePage : PageModel
    {
        public BackendInfo BackendInfo { get; set; }
        public FrontendInfo FrontendInfo { get; set; }
        public string ErrorMessage { get; set; }

        // On Page Load, fetch our data
        public async Task OnGetAsync()
        {
            FrontendInfo = GetLocalMachineInfo();
            await GetBackendInfo();
        }

        public FrontendInfo GetLocalMachineInfo()
        {
            return new FrontendInfo
            {
                Hostname = Dns.GetHostName(),
                IPAddress = HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() // could be ipv4 or ipv6
            };
        }

        public async Task GetBackendInfo()
        {
            try
            {
                FrontendInfo = GetLocalMachineInfo();

                using HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://dockerDemo_server/Machine/GetComputerInfo");

                if (response.IsSuccessStatusCode)
                {
                    BackendInfo = await response.Content.ReadAsAsync<BackendInfo>();
                }
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}