using System.Linq;
using EnvDTE;
using EnvDTE100;
using EnvDTE90a;

namespace StartDebug
{
    internal class DteHelper
    {
        private readonly dynamic _dte = System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.15.0");

        public void Attache(int pid)
        {
            Debugger d = (Debugger5)_dte.Debugger;
            
            var debugProcess =(Process4) d.LocalProcesses.OfType<Process>().First(process => process.ProcessID == pid);
            debugProcess.Attach2("Managed");
        }
    }
}
