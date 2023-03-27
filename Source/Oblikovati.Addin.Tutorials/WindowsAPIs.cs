namespace Oblikovati.Addin.Tutorials;

 public static class WindowsAPIs
  {
    public static bool IsFileExist(string filePath) => File.Exists(filePath);

    public static bool IsDirectoryExist(string directoryPath) => Directory.Exists(directoryPath);

    public static void CreateDirectory(string directoryPath) => Directory.CreateDirectory(directoryPath);

    public static void SetFileAttributes(string filePath, FileAttributes fileAttr) => File.SetAttributes(filePath, fileAttr);

    public static void CopyFile(string sourceFile, string targetFile, bool overwrite) => File.Copy(sourceFile, targetFile, overwrite);

    public static void DirectoryCopy(
      string sourceDirName,
      string destDirName,
      bool copySubDirs,
      bool overwrite = false)
    {
      DirectoryInfo directoryInfo1 = new DirectoryInfo(sourceDirName);
      DirectoryInfo[] directoryInfoArray = directoryInfo1.Exists ? directoryInfo1.GetDirectories() : throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
      if (!Directory.Exists(destDirName))
        Directory.CreateDirectory(destDirName);
      foreach (FileInfo file in directoryInfo1.GetFiles())
      {
        string str = Path.Combine(destDirName, file.Name);
        if (overwrite || !File.Exists(str))
          file.CopyTo(str, overwrite);
      }
      if (!copySubDirs)
        return;
      foreach (DirectoryInfo directoryInfo2 in directoryInfoArray)
      {
        string destDirName1 = Path.Combine(destDirName, directoryInfo2.Name);
        WindowsAPIs.DirectoryCopy(directoryInfo2.FullName, destDirName1, copySubDirs);
      }
    }

    public static void ChangeFileAttributesRecursively(string directory, FileAttributes attributes)
    {
      try
      {
        foreach (string directory1 in Directory.GetDirectories(directory))
          WindowsAPIs.ChangeFileAttributesRecursively(directory1, attributes);
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        return;
      }
      foreach (string file in Directory.GetFiles(directory))
      {
        try
        {
          new FileInfo(file).Attributes = attributes;
        }
        catch (Exception ex)
        {
          string message = ex.Message;
        }
      }
    }

    public static void DeleteDirectory(string directoryPath)
    {
      WindowsAPIs.ChangeFileAttributesRecursively(TutorialsData.TutorialFolder(), FileAttributes.Normal);
      Directory.Delete(directoryPath, true);
    }

    public static string DirectorySearch(string directoryToSearch, string fileToFind)
    {
      try
      {
        foreach (string file in Directory.GetFiles(directoryToSearch))
        {
          if (file.Contains(fileToFind))
            return directoryToSearch;
        }
        foreach (string directory in Directory.GetDirectories(directoryToSearch))
        {
          foreach (string file in Directory.GetFiles(directory))
          {
            if (file.Contains(fileToFind))
              return directory;
          }
          string str = WindowsAPIs.DirectorySearch(directory, fileToFind);
          if (str.Length > 0)
            return str;
        }
        return "";
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        return "";
      }
    }

    public static void ShowErrorMessage(Exception e)
    {
      //int num = (int) MessageBox.Show(e.Message);
    }
  }