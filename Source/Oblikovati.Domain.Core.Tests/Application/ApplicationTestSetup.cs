using System;
using Oblikovati.Domain.Contracts.Application;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace Oblikovati.Domain.Core.Tests.Application;

public static class ApplicationTestSetup
{
    private static IApplication app;
    public static IApplication ThisApplication()
    {
        //if(app is not A)
        //    app = new Core.Application.Application();
        return app;
    }

    public static void SetupAppium()
    {
        var x = new AppiumOptions();
        x.AddAdditionalCapability("app", @"C:\Windows\System32\notepad.exe");
        x.AddAdditionalCapability("appArguments", @"MyTestFile.txt");
        x.AddAdditionalCapability("appWorkingDir", @"C:\MyTestFolder\");
        var NotepadSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), x);

        NotepadSession.FindElementByClassName("Edit").SendKeys("This is some text");
    }
}