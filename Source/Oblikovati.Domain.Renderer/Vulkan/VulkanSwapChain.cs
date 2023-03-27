using Silk.NET.Vulkan.Extensions.KHR;
using Silk.NET.Vulkan;

namespace Oblikovati.Domain.Renderer.Vulkan;

public unsafe class VulkanSwapChain
{
    private readonly Vk _vulkanApi;
    private readonly Instance _vulkanInstance;
    private readonly PhysicalDevice _physicalDevice;
    private readonly Device _device;
    private readonly SurfaceKHR _surface;
    private readonly KhrSurface _khrSurfaceApi;
    private KhrSwapchain? _khrSwapChain;
    public KhrSwapchain? KhrSwapchain => _khrSwapChain;
    public Extent2D SwapChainExtent { get; private set; }

    public SwapChainBuffer[]? SwapChainBuffers { get; private set; }
    private SwapchainKHR? _swapChain;
    public SwapchainKHR SwapChain => (SwapchainKHR) _swapChain!;
    public Format SwapChainImageFormat { get; private set; }
    public uint ImageCount { get; private set; }

    public VulkanSwapChain(Vk vulkanApi,
                            Instance vulkanInstance, 
                            PhysicalDevice physicalDevice,
                            Device device,
                            KhrSurface khrSurfaceApi,
                            SurfaceKHR surface)
    {
        _vulkanApi = vulkanApi;
        _vulkanInstance = vulkanInstance;
        _physicalDevice = physicalDevice;
        _device = device;
        _khrSurfaceApi = khrSurfaceApi;
        _surface = surface;
    }
    public struct SwapChainBuffer
    {
        public Image Image;
        public ImageView View;
        public SwapChainBuffer()
        {
            Image = new Image();
            View = new ImageView();
        }
    }

    public void Initialize()
    {

    }
    
    /// <summary>
    /// Create the swapchain and get its images with given width and height
    /// </summary>
    /// <param name="width">Width of the swapchain (may be adjusted to fit the requirements of the swapchain)</param>
    /// <param name="height">Height of the swapchain (may be adjusted to fit the requirements of the swapchain)</param>
    /// <param name="vsync">Can be used to force vsync-ed rendering (by using VK_PRESENT_MODE_FIFO_KHR as presentation mode)</param>
    /// <param name="fullscreen"></param>
    /// <exception cref="NotSupportedException"></exception>
    /// <exception cref="Exception"></exception>
    public void CreateSwapChain(uint width, uint height, bool vsync = false, bool fullscreen = false)
    {
        var oldSwapChain = _swapChain;
        var swapChainSupport = QuerySwapChainSupport(_physicalDevice);
        var surfaceFormat = ChooseSwapSurfaceFormat(swapChainSupport.Formats);
        var presentMode = ChoosePresentMode(swapChainSupport.PresentModes, vsync);
        var extent = ChooseSwapExtent(swapChainSupport.Capabilities, width, height);

        var desirableNumberOfSwapchainImages = swapChainSupport.Capabilities.MinImageCount + 1;
        if (swapChainSupport.Capabilities.MaxImageCount > 0
            && desirableNumberOfSwapchainImages > swapChainSupport.Capabilities.MaxImageCount)
        {
            desirableNumberOfSwapchainImages = swapChainSupport.Capabilities.MaxImageCount;
        }

        var compositeAlphaFlags = new List<CompositeAlphaFlagsKHR>() {
            CompositeAlphaFlagsKHR.OpaqueBitKhr,
            CompositeAlphaFlagsKHR.PreMultipliedBitKhr,
            CompositeAlphaFlagsKHR.PostMultipliedBitKhr,
            CompositeAlphaFlagsKHR.InheritBitKhr};
        CompositeAlphaFlagsKHR desiredAlpha = CompositeAlphaFlagsKHR.OpaqueBitKhr;

        foreach (var alpha in compositeAlphaFlags)
        {
            if ((int)(swapChainSupport.Capabilities.SupportedCompositeAlpha & alpha) > 0)
            {
                desiredAlpha = alpha;
                break;
            }
        }

        SurfaceTransformFlagsKHR preTransform = swapChainSupport.Capabilities.CurrentTransform;
        if ((int)(swapChainSupport.Capabilities.SupportedTransforms
            & SurfaceTransformFlagsKHR.IdentityBitKhr) > 0)
        {
            preTransform = SurfaceTransformFlagsKHR.IdentityBitKhr;
        }

        SwapchainCreateInfoKHR swapChainCreateInfo = new()
        {
            SType = StructureType.SwapchainCreateInfoKhr,
            Surface = _surface,
            MinImageCount = desirableNumberOfSwapchainImages,
            ImageFormat = surfaceFormat.Format,
            ImageColorSpace = surfaceFormat.ColorSpace,
            ImageExtent = extent,
            ImageArrayLayers = 1,
            ImageUsage = ImageUsageFlags.ColorAttachmentBit,
            PreTransform = preTransform,
            QueueFamilyIndexCount = 0,
            PresentMode = presentMode,            
            Clipped = true,
            CompositeAlpha = desiredAlpha
        };

        if (oldSwapChain is not null)
            swapChainCreateInfo.OldSwapchain = (SwapchainKHR)oldSwapChain!;

        var indices = FindQueueFamilies(_physicalDevice);
        var queueFamilyIndices = stackalloc[] {
            indices.GraphicsFamily!.Value,
            indices.PresentFamily!.Value
        };

        if (indices.GraphicsFamily != indices.PresentFamily)
        {
            swapChainCreateInfo = swapChainCreateInfo with
            {
                ImageSharingMode = SharingMode.Concurrent,
                QueueFamilyIndexCount = 2,
                PQueueFamilyIndices = queueFamilyIndices,
            };
        }
        else
        {
            swapChainCreateInfo.ImageSharingMode = SharingMode.Exclusive;
        }

        // Enable transfer source on swap chain images if supported
        if ((int)(swapChainSupport.Capabilities.SupportedUsageFlags & ImageUsageFlags.TransferSrcBit) > 0)
        {
            swapChainCreateInfo = swapChainCreateInfo with
            {
                ImageUsage = swapChainCreateInfo.ImageUsage | ImageUsageFlags.TransferSrcBit
            };
        }

        // Enable transfer destination on swap chain images if supported
        if ((int)(swapChainSupport.Capabilities.SupportedUsageFlags & ImageUsageFlags.TransferDstBit) > 0)
        {
            swapChainCreateInfo = swapChainCreateInfo with
            {
                ImageUsage = swapChainCreateInfo.ImageUsage | ImageUsageFlags.TransferDstBit
            };
        }

        if (_khrSwapChain is null)
        {
            if (!_vulkanApi!.TryGetDeviceExtension(_vulkanInstance, _device, out _khrSwapChain))
            {
                throw new NotSupportedException("VK_KHR_swapchain extension not found.");
            }
        }
        SwapchainKHR outSwap;
        if (_khrSwapChain!.CreateSwapchain(_device, swapChainCreateInfo, null, out outSwap) != Result.Success)
        {
            throw new Exception("failed to create swap chain!");
        }
        _swapChain = outSwap;

        if (oldSwapChain is not null)
        {
            for (int i = 0; i < ImageCount; i++)
            {
                _vulkanApi?.DestroyImageView(_device, SwapChainBuffers![i].View, null);
            }
            _khrSwapChain.DestroySwapchain(_device, (SwapchainKHR)oldSwapChain, null);
        }
        uint newCount = 0;
        _khrSwapChain.GetSwapchainImages(_device, (SwapchainKHR)_swapChain!, ref newCount, null);
        ImageCount = newCount;

        SwapChainBuffers = new SwapChainBuffer[ImageCount];

        var images = new Image[ImageCount];
        fixed(Image* imgPtr =  images)
        {
            _khrSwapChain.GetSwapchainImages(_device, (SwapchainKHR)_swapChain!, ref newCount, imgPtr);
        }
        
        SwapChainImageFormat = surfaceFormat.Format;
        SwapChainExtent = extent;

        for (int i = 0; i < ImageCount; i++)
        {
            SwapChainBuffers[i].Image = images[i];
            var imageViewCreateInfo = new ImageViewCreateInfo()
            {
                SType = StructureType.ImageViewCreateInfo,
                PNext = null,
                Format = surfaceFormat.Format,
                Components =
                    {
                        R = ComponentSwizzle.Identity,
                        G = ComponentSwizzle.Identity,
                        B = ComponentSwizzle.Identity,
                        A = ComponentSwizzle.Identity,
                    },
                SubresourceRange = new ImageSubresourceRange
                {
                    AspectMask = ImageAspectFlags.ColorBit,
                    BaseMipLevel = 0,
                    LevelCount = 1,
                    BaseArrayLayer = 0,
                    LayerCount = 1,
                },
                ViewType = ImageViewType.Type2D,
                Flags = 0,
                Image = SwapChainBuffers[i].Image
            };


            if (_vulkanApi?.CreateImageView(_device, imageViewCreateInfo, null, out SwapChainBuffers[i].View) != Result.Success)
            {
                throw new Exception("Unable to Create an Image View");
            }
        }

    }
    /// <summary>
    /// Acquires the next image in the swap chain
    /// </summary>
    /// <param name="presentCompleteSemaphore">emaphore that is signaled when the image is ready for use</param>
    /// <returns>The image index</returns>
    /// <exception cref="Exception">When request is not successfull</exception>
    public uint AquireNextImageIndex(Silk.NET.Vulkan.Semaphore presentCompleteSemaphore)
    {
        uint index = 0;
        if (_khrSwapChain?.AcquireNextImage(
            _device,
            (SwapchainKHR)_swapChain!,
            uint.MaxValue,
            presentCompleteSemaphore,
            default,
            ref index) != Result.Success)
        {
            throw new Exception("Unavle to Aquire next image index!");
        }
        return index;
    }

    public void QueuePresentation(Queue queue, uint imageIndex, Silk.NET.Vulkan.Semaphore? waitSemaphore = null)
    {
        var swapChains = stackalloc[] { (SwapchainKHR)_swapChain! };

        var presentInfo = new PresentInfoKHR()
        {
            SType = StructureType.PresentInfoKhr,
            PNext = null,
            SwapchainCount = 1,
            PSwapchains = swapChains,
            PImageIndices = &imageIndex
        };

        if (waitSemaphore != null)
        {
            var semaphore = stackalloc[] { (Silk.NET.Vulkan.Semaphore)waitSemaphore };
            presentInfo.WaitSemaphoreCount = 1;
            presentInfo.PWaitSemaphores = semaphore;
        }

        _khrSwapChain?.QueuePresent(queue, presentInfo);
    }

    public void Cleanup()
    {
        if (_swapChain is not null)
        {
            for (int i = 0; i < ImageCount; i++)
            {
            }
        }
    }

    private SwapChainSupportDetails QuerySwapChainSupport(PhysicalDevice physicalDevice)
    {
        var details = new SwapChainSupportDetails();

        _khrSurfaceApi!.GetPhysicalDeviceSurfaceCapabilities(physicalDevice, _surface, out details.Capabilities);

        uint formatCount = 0;
        _khrSurfaceApi.GetPhysicalDeviceSurfaceFormats(physicalDevice, _surface, ref formatCount, null);

        if (formatCount != 0)
        {
            details.Formats = new SurfaceFormatKHR[formatCount];
            fixed (SurfaceFormatKHR* formatsPtr = details.Formats)
            {
                _khrSurfaceApi.GetPhysicalDeviceSurfaceFormats(physicalDevice, _surface, ref formatCount, formatsPtr);
            }
        }
        else
        {
            details.Formats = Array.Empty<SurfaceFormatKHR>();
        }

        uint presentModeCount = 0;
        _khrSurfaceApi.GetPhysicalDeviceSurfacePresentModes(physicalDevice, _surface, ref presentModeCount, null);

        if (presentModeCount != 0)
        {
            details.PresentModes = new PresentModeKHR[presentModeCount];
            fixed (PresentModeKHR* formatsPtr = details.PresentModes)
            {
                _khrSurfaceApi.GetPhysicalDeviceSurfacePresentModes(physicalDevice, _surface, ref presentModeCount, formatsPtr);
            }

        }
        else
        {
            details.PresentModes = Array.Empty<PresentModeKHR>();
        }

        return details;
    }

    private SurfaceFormatKHR ChooseSwapSurfaceFormat(IReadOnlyList<SurfaceFormatKHR> availableFormats)
    {

        foreach (var availableFormat in availableFormats)
        {
            if (availableFormat.Format == Format.B8G8R8A8Unorm 
                && availableFormat.ColorSpace == ColorSpaceKHR.SpaceSrgbNonlinearKhr)
            {
                return availableFormat;
            }
        }

        return availableFormats[0];
    }

    private PresentModeKHR ChoosePresentMode(IReadOnlyList<PresentModeKHR> availablePresentModes, bool vsync)
    {
        if (vsync)
            return PresentModeKHR.FifoKhr;

        foreach (var availablePresentMode in availablePresentModes)
        {
            if (availablePresentMode == PresentModeKHR.MailboxKhr)
            {
                return availablePresentMode;
            }
        }

        return PresentModeKHR.FifoKhr;
    }

    private Extent2D ChooseSwapExtent(SurfaceCapabilitiesKHR capabilities, uint w, uint h)
    {
        if (capabilities.CurrentExtent.Width != uint.MaxValue)
        {
            return capabilities.CurrentExtent;
        }
        else
        {

            Extent2D actualExtent = new Extent2D { 
                Width= w,
                Height= h
            };

            actualExtent.Width = System.Math.Clamp(actualExtent.Width, capabilities.MinImageExtent.Width, capabilities.MaxImageExtent.Width);
            actualExtent.Height = System.Math.Clamp(actualExtent.Height, capabilities.MinImageExtent.Height, capabilities.MaxImageExtent.Height);

            return actualExtent;
        }
    }

    private QueueFamilyIndices FindQueueFamilies(PhysicalDevice device)
    {
        var indices = new QueueFamilyIndices();

        uint queueFamilityCount = 0;
        _vulkanApi!.GetPhysicalDeviceQueueFamilyProperties(device, ref queueFamilityCount, null);

        var queueFamilies = new QueueFamilyProperties[queueFamilityCount];
        fixed (QueueFamilyProperties* queueFamiliesPtr = queueFamilies)
        {
            _vulkanApi!.GetPhysicalDeviceQueueFamilyProperties(device, ref queueFamilityCount, queueFamiliesPtr);
        }


        uint i = 0;
        foreach (var queueFamily in queueFamilies)
        {
            if (queueFamily.QueueFlags.HasFlag(QueueFlags.GraphicsBit))
            {
                indices.GraphicsFamily = i;
            }

            _khrSurfaceApi!.GetPhysicalDeviceSurfaceSupport(device, i, _surface, out var presentSupport);

            if (presentSupport)
            {
                indices.PresentFamily = i;
            }

            if (indices.IsComplete())
            {
                break;
            }

            i++;
        }

        return indices;
    }

}