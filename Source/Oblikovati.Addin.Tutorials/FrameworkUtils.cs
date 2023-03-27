using System.Globalization;
using System.Security.Principal;
using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

public class FrameworkUtils
  {
    public static string GetUserName()
    {
      string userName = "";
      try
      {
        WindowsIdentity current = WindowsIdentity.GetCurrent();
        if (current != null)
          userName = current.Name;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
      return userName;
    }

    public static string GetProductCode(IApplication invApp)
    {
      ProductEditionEnum productEdition = invApp.SoftwareVersion.ProductEdition;
      string productCode = "INVNTOR";
      switch (productEdition)
      {
        case ProductEditionEnum.kProductEditionOblikovatiLT:
          productCode = "INVLT";
          break;
        case ProductEditionEnum.kProductEditionOblikovatiProfessional:
          productCode = "INVPROSA";
          break;
        case ProductEditionEnum.kProductEditionOblikovatiOEM:
          productCode = "INVOEM";
          break;
        case ProductEditionEnum.kProductEditionOblikovatiRO:
          productCode = "INVRO";
          break;
      }
      return productCode;
    }

    public static string GetLanguage(IApplication invApp, bool threeLetter = true)
    {
      string language = "ENU";
      try
      {
        CultureInfo cultureInfo = new CultureInfo(invApp.Locale);
        language = !threeLetter ? cultureInfo.Name : cultureInfo.ThreeLetterWindowsLanguageName;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
      return language;
    }

    public static string InventorRoamingFolder(IApplication invApp)
    {
      string str = invApp.SoftwareVersion.DisplayVersion;
      if (str.Length > 4)
        str = str.Remove(4);
      string path2 = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Oblikovati\\{0} {1}", (object) invApp.SoftwareVersion.ProductName, (object) str);
      return System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), path2);
    }
  }