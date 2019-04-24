using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdbUtils
{
    public interface IAdbUtils
    {
        Task<List<AndroidDevice>> ListingDevices();

        Task<string> LaunchCommandToShell(AndroidDevice device, string commandParameter);

        Task<string> GetUIDevice(AndroidDevice device);

        Task<bool> NavigateToWeb(AndroidDevice device, string url);

        Task<bool> Tap(AndroidDevice device, int x, int y);

        Task<bool> Tap(AndroidDevice device, UINode node);

        Task<bool> Push(AndroidDevice device, string fileToPush, string devicePath);

        Task<bool> InsertText(AndroidDevice device, string text);

        Task<bool> InsertText(AndroidDevice device, UINode node, string text);
    }
}