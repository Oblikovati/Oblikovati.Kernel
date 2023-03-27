using Silk.NET.Vulkan;

namespace Oblikovati.Domain.Renderer.Vulkan;

public struct SwapChainSupportDetails
{
    public SurfaceCapabilitiesKHR Capabilities;
    public SurfaceFormatKHR[] Formats;
    public PresentModeKHR[] PresentModes;
}