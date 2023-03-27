using System.Runtime.InteropServices;

namespace Oblikovati.Addin.Tutorials;

 public class Job : IDisposable
  {
    private IntPtr m_handle;
    private bool m_disposed;

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr CreateJobObject(object a, string lpName);

    [DllImport("kernel32.dll")]
    private static extern bool SetInformationJobObject(
      IntPtr hJob,
      JobObjectInfoType infoType,
      IntPtr lpJobObjectInfo,
      uint cbJobObjectInfoLength);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool AssignProcessToJobObject(IntPtr job, IntPtr process);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool CloseHandle(IntPtr hHandle);

    public Job()
    {
      this.m_handle = Job.CreateJobObject((object) null, (string) null);
      JOBOBJECT_BASIC_LIMIT_INFORMATION limitInformation = new JOBOBJECT_BASIC_LIMIT_INFORMATION();
      limitInformation.LimitFlags = (short) 8192;
      JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure = new JOBOBJECT_EXTENDED_LIMIT_INFORMATION();
      structure.BasicLimitInformation = limitInformation;
      int num1 = Marshal.SizeOf(typeof (JOBOBJECT_EXTENDED_LIMIT_INFORMATION));
      IntPtr num2 = Marshal.AllocHGlobal(num1);
      Marshal.StructureToPtr<JOBOBJECT_EXTENDED_LIMIT_INFORMATION>(structure, num2, false);
      if (!Job.SetInformationJobObject(this.m_handle, JobObjectInfoType.ExtendedLimitInformation, num2, (uint) num1))
        throw new Exception(string.Format("Unable to set information.  Error: {0}", (object) Marshal.GetLastWin32Error()));
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    private void Dispose(bool disposing)
    {
      if (this.m_disposed)
        return;
      int num = disposing ? 1 : 0;
      this.Close();
      this.m_disposed = true;
    }

    public void Close()
    {
      Job.CloseHandle(this.m_handle);
      this.m_handle = IntPtr.Zero;
    }

    public bool AddProcess(IntPtr handle)
    {
      if (Job.AssignProcessToJobObject(this.m_handle, handle))
        return true;
      Marshal.GetLastWin32Error();
      return false;
    }
  }