using HelpDesk.Client.ViewModels;

namespace HelpDesk.Client.Interfaces
{
	public interface IDeviceService
	{
		Task<List<DevicesViewModel>> GetDevices();
	}
}
