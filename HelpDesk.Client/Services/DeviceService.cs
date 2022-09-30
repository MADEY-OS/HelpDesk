using HelpDesk.Client.Interfaces;
using HelpDesk.Client.ViewModels;
using System.Net.Http.Json;

namespace HelpDesk.Client.Services
{
	public class DeviceService : IDeviceService
	{
		private readonly HttpClient _httpClient;

		public DeviceService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<DevicesViewModel>> GetDevices()
		{
			return await _httpClient.GetFromJsonAsync<List<DevicesViewModel>>("api/device");
		}

	}
}
