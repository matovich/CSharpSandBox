using System.Diagnostics;
using System.Linq;

namespace SandBox
{
    public class RunningAssemblyFinder
    {
        public bool IsRunning(string assyName)
        {
            Process[] proc = Process.GetProcessesByName(assyName);
            return proc.Any();
        }

        public int GetId(string assyName)
        {
            Process[] proc = Process.GetProcessesByName(assyName);
            return proc[0].Id;
        }
    }
}