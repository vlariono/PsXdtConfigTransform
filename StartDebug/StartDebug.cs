using System.Diagnostics;

namespace StartDebug
{
    class StartDebug
    {
        static void Main(string[] args)
        {
            var startedProcess = Process.Start("powershell", "-NoExit -File Start-Debug.ps1");
            var dteHelper = new DteHelper();
            try
            {
                if (startedProcess != null)
                {
                    dteHelper.Attache(startedProcess.Id);
                    startedProcess?.WaitForExit();
                }
            }
            catch
            {
                //startedProcess?.Kill();
            }
        }
    }
}
