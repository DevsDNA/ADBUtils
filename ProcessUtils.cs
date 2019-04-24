using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbUtils
{
    public static class ProcessUtils
    {
        public static Process StartProcess(string arguments)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = "adb.exe";
            psi.Arguments = arguments;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;            
            var p = new Process();
            p.StartInfo = psi;

            p.Start();
            return p;
        }
    }
}
