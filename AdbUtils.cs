using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AdbUtils
{
    public class AdbUtils : IAdbUtils
    {
        public async Task<List<AndroidDevice>> ListingDevices()
        {
            var devices = new List<AndroidDevice>();

            var p = ProcessUtils.StartProcess("devices");
            try
            {                
                var outPut = await p.StandardOutput.ReadToEndAsync();
                var content = outPut.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                content.RemoveAt(0); //Remove List of Devices line...
                devices = content.Select(x => x.Split('\t')[0]).Select(x => new AndroidDevice() { Id = x }).ToList();

                outPut.Split();
            }
            catch(Exception e)
            {
                Log.Error(e);
            }
            
                                
            return devices;
        }

        public async Task<string> LaunchCommandToShell(AndroidDevice device, string commandParameter)
        {
            var p = ProcessUtils.StartProcess($"-s {device.Id} shell {commandParameter}");
            return await p.StandardOutput.ReadToEndAsync();
        }

        public async Task<string> GetUIDevice(AndroidDevice device)
        {
            await LaunchCommandToShell(device, "uiautomator dump");
            return await LaunchCommandToShell(device, "cat /sdcard/window_dump.xml");
        }
                
        public async Task<bool> NavigateToWeb(AndroidDevice device, string url)
        {
            var output = await LaunchCommandToShell(device, $"am start -a android.intent.action.VIEW -d '{url}'");
            return output.Contains("Starting: Intent");
        }

        public async Task<bool> Tap(AndroidDevice device, int x, int y)
        {
            var output = await LaunchCommandToShell(device, $"input tap {x} {y}");
            return string.IsNullOrEmpty(output);
        }

        public Task<bool> Tap(AndroidDevice device, UINode node) => Tap(device, node.Bounds.X, node.Bounds.Y);

        public async Task<bool> Push(AndroidDevice device, string fileToPush, string devicePath)
        {
            var output = await LaunchCommandToShell(device, $"push {fileToPush} {devicePath}");
            return output.Contains("file pushed");
        }

        public async Task<bool> InsertText(AndroidDevice device, string text)
        {
            var output = await LaunchCommandToShell(device, $@"input keyboard text ""{text}""");
            return string.IsNullOrEmpty(output);
        }

        public async Task<bool> InsertText(AndroidDevice device, UINode node, string text)
        {
            var ok = await Tap(device, node);
            if(ok)
            {
                return await InsertText(device, text);
            }
            else
            {
                return false;
            }
        }
    }
}
