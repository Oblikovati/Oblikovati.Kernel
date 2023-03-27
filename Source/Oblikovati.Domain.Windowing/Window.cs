using Oblikovati.Domain.Contracts.Windowing;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using static Oblikovati.Domain.Contracts.Windowing.IWindowEvents;

namespace Oblikovati.Domain.Windowing;

public class Window : IWindowEvents
{
    public int Width { get; set; }
    public int Height { get; set; }
    public string Title { get; init; } = "";
    public Window(string title, int width = 0, int height = 0)
    {
        Title= title;
        Width = width;
        Height = height;
    }
    
    public void Init()
    {
        var options = WindowOptions.DefaultVulkan with
        {
            IsEventDriven = false,
            
            Title = Title,

        };

        if (Width == 0 || Height == 0)
            options.WindowState = WindowState.Maximized;
        else
            options.Size = new Vector2D<int>(Width, Height);

        SilkWindow = Silk.NET.Windowing.Window.Create(options);
        SilkWindow.Initialize();

        if (SilkWindow.VkSurface is null)
        {
            throw new Exception("Windowing platform doesn't support Vulkan.");
        }

        SilkWindow.Resize += FramebufferResizeCallback;
    }

    public EventHandler<WindowResizedEventArgs> WindowResized { get; }

    private void FramebufferResizeCallback(Vector2D<int> size)
    {
        WindowResized?.Invoke(this, new WindowResizedEventArgs(size.X, size.Y));
        SilkWindow?.DoRender();
    }

    public void Dispose()
    {
        SilkWindow?.Dispose();
    }

    public IWindow? SilkWindow { get; private set; }
}