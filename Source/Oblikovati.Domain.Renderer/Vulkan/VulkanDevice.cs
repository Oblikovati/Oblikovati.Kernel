using Silk.NET.Core.Native;
using Silk.NET.Core;
using Silk.NET.Vulkan;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Silk.NET.Vulkan.Extensions.EXT;
using Silk.NET.Vulkan.Extensions.KHR;
using Silk.NET.Windowing;
using System.Text;

namespace Oblikovati.Domain.Renderer.Vulkan;

public unsafe class VulkanDevice
{
    private readonly IWindow _window;
    private readonly Vk vk;
    private Instance _vulkanInstance;
    public Instance Instance => _vulkanInstance;
    private PhysicalDevice _physicalDevice;
    public PhysicalDevice PhysicalDevice => _physicalDevice;
    private Device _device;
    public Device Device => _device;
    private KhrSurface? _khrSurfaceApi;
    public KhrSurface? KhrSurfaceApi => _khrSurfaceApi;
    private SurfaceKHR _khrSurface;
    public SurfaceKHR Surface => _khrSurface;

    private uint graphicsFamilyIndex = 0;
    private ExtDebugUtils? debugUtils;
    private DebugUtilsMessengerEXT debugMessenger;
    public SampleCountFlags MsaaSamples { get; private set; } = SampleCountFlags.Count1Bit;
    private Queue _graphicsQueue;
    public Queue GraphicsQueue => _graphicsQueue;
    private Queue _presentQueue;
    public Queue PresentQueue => _presentQueue;

    public bool AreValidationLayersEnabled { get; }

    private readonly string[] validationLayers = new[]
    {
        "VK_LAYER_KHRONOS_validation"
    };

    private readonly string[] deviceExtensions = new[]
    {
        KhrSwapchain.ExtensionName
    };
    public VulkanDevice(Vk vulkanApi, IWindow window, bool validationEnabled = false)
    {
        vk = vulkanApi;
        _window = window;
        AreValidationLayersEnabled= validationEnabled;
    }

    public void Initialize()
    {
        CreateInstance();
        SetupDebugMessenger();
        CreateSurface();
        PickPhysicalDevice();
        CreateLogicalDevice();
    }

    void CreateSurface()
    {
        if (!vk!.TryGetInstanceExtension<KhrSurface>(_vulkanInstance, out _khrSurfaceApi))
        {
            throw new NotSupportedException("KHR_surface extension not found.");
        }

        _khrSurface = _window!.VkSurface!.Create<AllocationCallbacks>(_vulkanInstance.ToHandle(), null).ToSurface();
    }

    private bool CheckValidationLayerSupport()
    {
        uint layerCount = 0;
        vk!.EnumerateInstanceLayerProperties(ref layerCount, null);
        var availableLayers = new LayerProperties[layerCount];
        fixed (LayerProperties* availableLayersPtr = availableLayers)
        {
            vk!.EnumerateInstanceLayerProperties(ref layerCount, availableLayersPtr);
        }

        var availableLayerNames = availableLayers.Select(layer => Marshal.PtrToStringAnsi((IntPtr)layer.LayerName)).ToHashSet();

        return validationLayers.All(availableLayerNames.Contains);
    }

    private void PopulateDebugMessengerCreateInfo(ref DebugUtilsMessengerCreateInfoEXT createInfo)
    {
        createInfo.SType = StructureType.DebugUtilsMessengerCreateInfoExt;
        createInfo.MessageSeverity = DebugUtilsMessageSeverityFlagsEXT.DebugUtilsMessageSeverityVerboseBitExt |
                                     DebugUtilsMessageSeverityFlagsEXT.DebugUtilsMessageSeverityWarningBitExt |
                                     DebugUtilsMessageSeverityFlagsEXT.DebugUtilsMessageSeverityErrorBitExt;

        createInfo.MessageType = DebugUtilsMessageTypeFlagsEXT.DebugUtilsMessageTypeGeneralBitExt |
                                 DebugUtilsMessageTypeFlagsEXT.DebugUtilsMessageTypePerformanceBitExt |
                                 DebugUtilsMessageTypeFlagsEXT.DebugUtilsMessageTypeValidationBitExt;

        createInfo.PfnUserCallback = (DebugUtilsMessengerCallbackFunctionEXT)DebugCallback;
    }
    private SampleCountFlags GetMaxUsableSampleCount()
    {
        vk!.GetPhysicalDeviceProperties(_physicalDevice, out var physicalDeviceProperties);

        var counts = physicalDeviceProperties.Limits.FramebufferColorSampleCounts & physicalDeviceProperties.Limits.FramebufferDepthSampleCounts;

        return counts switch
        {
            var c when (c & SampleCountFlags.SampleCount64Bit) != 0 => SampleCountFlags.SampleCount64Bit,
            var c when (c & SampleCountFlags.SampleCount32Bit) != 0 => SampleCountFlags.SampleCount32Bit,
            var c when (c & SampleCountFlags.SampleCount16Bit) != 0 => SampleCountFlags.SampleCount16Bit,
            var c when (c & SampleCountFlags.SampleCount8Bit) != 0 => SampleCountFlags.SampleCount8Bit,
            var c when (c & SampleCountFlags.SampleCount4Bit) != 0 => SampleCountFlags.SampleCount4Bit,
            var c when (c & SampleCountFlags.SampleCount2Bit) != 0 => SampleCountFlags.SampleCount2Bit,
            _ => SampleCountFlags.SampleCount1Bit
        };
    }
    public static string InsertNewLine(string s, int len)
    {
        StringBuilder sb = new StringBuilder(s.Length + (int)(s.Length / len) + 1);
        int start = 0;
        for (start = 0; start < s.Length - len; start += len)
        {
            sb.Append(s.Substring(start, len));
            sb.Append(Environment.NewLine);
        }
        sb.Append(s.Substring(start));
        return sb.ToString();
    }
    private uint DebugCallback(DebugUtilsMessageSeverityFlagsEXT messageSeverity, DebugUtilsMessageTypeFlagsEXT messageTypes, DebugUtilsMessengerCallbackDataEXT* pCallbackData, void* pUserData)
    {
        var message = Marshal.PtrToStringAnsi((nint)pCallbackData->PMessage);
        if(message.Contains("("))
        {
            var splitted = message.Split('(');
            splitted[0] = InsertNewLine(splitted[0], 100);
            message = splitted[0] + "\n" + splitted[1].Replace(')', '\n');
        }
        
        if ((messageSeverity & DebugUtilsMessageSeverityFlagsEXT.ErrorBitExt) >0)
            Serilog.Log.Error(message);
        if ((messageSeverity & DebugUtilsMessageSeverityFlagsEXT.VerboseBitExt) > 0)
            Serilog.Log.Verbose(message);
        if ((messageSeverity & DebugUtilsMessageSeverityFlagsEXT.InfoBitExt) > 0)
            Serilog.Log.Information(message);
        if ((messageSeverity & DebugUtilsMessageSeverityFlagsEXT.WarningBitExt) > 0)
            Serilog.Log.Warning(message);

        return Vk.False;
    }


    void CreateInstance()
    {

        if (AreValidationLayersEnabled && !CheckValidationLayerSupport())
        {
            throw new Exception("validation layers requested, but not available!");
        }

        ApplicationInfo appInfo = new()
        {
            SType = StructureType.ApplicationInfo,
            PApplicationName = (byte*)Marshal.StringToHGlobalAnsi("Hello Triangle"),
            ApplicationVersion = new Version32(1, 0, 0),
            PEngineName = (byte*)Marshal.StringToHGlobalAnsi("No Engine"),
            EngineVersion = new Version32(1, 0, 0),
            ApiVersion = Vk.Version12
        };

        InstanceCreateInfo createInfo = new()
        {
            SType = StructureType.InstanceCreateInfo,
            PApplicationInfo = &appInfo
        };

        var extensions = GetRequiredExtensions();
        createInfo.EnabledExtensionCount = (uint)extensions.Length;
        createInfo.PpEnabledExtensionNames = (byte**)SilkMarshal.StringArrayToPtr(extensions); ;

        if (AreValidationLayersEnabled)
        {
            createInfo.EnabledLayerCount = (uint)validationLayers.Length;
            createInfo.PpEnabledLayerNames = (byte**)SilkMarshal.StringArrayToPtr(validationLayers);

            DebugUtilsMessengerCreateInfoEXT debugCreateInfo = new();
            PopulateDebugMessengerCreateInfo(ref debugCreateInfo);
            createInfo.PNext = &debugCreateInfo;
        }
        else
        {
            createInfo.EnabledLayerCount = 0;
            createInfo.PNext = null;
        }

        if (vk.CreateInstance(createInfo, null, out _vulkanInstance) != Result.Success)
        {
            throw new Exception("failed to create instance!");
        }

        Marshal.FreeHGlobal((IntPtr)appInfo.PApplicationName);
        Marshal.FreeHGlobal((IntPtr)appInfo.PEngineName);
        SilkMarshal.Free((nint)createInfo.PpEnabledExtensionNames);

        if (AreValidationLayersEnabled)
        {
            SilkMarshal.Free((nint)createInfo.PpEnabledLayerNames);
        }
    }

    void SetupDebugMessenger()
    {
        if (!AreValidationLayersEnabled) return;

        if (!vk!.TryGetInstanceExtension(_vulkanInstance, out debugUtils)) return;

        DebugUtilsMessengerCreateInfoEXT createInfo = new();
        PopulateDebugMessengerCreateInfo(ref createInfo);

        if (debugUtils!.CreateDebugUtilsMessenger(_vulkanInstance, in createInfo, null, out debugMessenger) != Result.Success)
        {
            throw new Exception("failed to set up debug messenger!");
        }
    }
    private bool IsDeviceSuitable(PhysicalDevice device)
    {
        var indices = FindQueueFamilies(device);

        bool extensionsSupported = CheckDeviceExtensionsSupport(device);

        bool swapChainAdequate = false;
        if (extensionsSupported)
        {
            var swapChainSupport = QuerySwapChainSupport(device);
            swapChainAdequate = swapChainSupport.Formats.Any() && swapChainSupport.PresentModes.Any();
        }

        PhysicalDeviceFeatures supportedFeatures;
        vk!.GetPhysicalDeviceFeatures(device, out supportedFeatures);

        return indices.IsComplete() && extensionsSupported && swapChainAdequate && supportedFeatures.SamplerAnisotropy;
    }

    private bool CheckDeviceExtensionsSupport(PhysicalDevice device)
    {
        uint extentionsCount = 0;
        vk!.EnumerateDeviceExtensionProperties(device, (byte*)null, ref extentionsCount, null);

        var availableExtensions = new ExtensionProperties[extentionsCount];
        fixed (ExtensionProperties* availableExtensionsPtr = availableExtensions)
        {
            vk!.EnumerateDeviceExtensionProperties(device, (byte*)null, ref extentionsCount, availableExtensionsPtr);
        }

        var availableExtensionNames = availableExtensions.Select(extension => Marshal.PtrToStringAnsi((IntPtr)extension.ExtensionName)).ToHashSet();

        return deviceExtensions.All(availableExtensionNames.Contains);

    }

    private SwapChainSupportDetails QuerySwapChainSupport(PhysicalDevice physicalDevice)
    {
        var details = new SwapChainSupportDetails();

        _khrSurfaceApi!.GetPhysicalDeviceSurfaceCapabilities(physicalDevice, _khrSurface, out details.Capabilities);

        uint formatCount = 0;
        _khrSurfaceApi.GetPhysicalDeviceSurfaceFormats(physicalDevice, _khrSurface, ref formatCount, null);

        if (formatCount != 0)
        {
            details.Formats = new SurfaceFormatKHR[formatCount];
            fixed (SurfaceFormatKHR* formatsPtr = details.Formats)
            {
                _khrSurfaceApi.GetPhysicalDeviceSurfaceFormats(physicalDevice, _khrSurface, ref formatCount, formatsPtr);
            }
        }
        else
        {
            details.Formats = Array.Empty<SurfaceFormatKHR>();
        }

        uint presentModeCount = 0;
        _khrSurfaceApi.GetPhysicalDeviceSurfacePresentModes(physicalDevice, _khrSurface, ref presentModeCount, null);

        if (presentModeCount != 0)
        {
            details.PresentModes = new PresentModeKHR[presentModeCount];
            fixed (PresentModeKHR* formatsPtr = details.PresentModes)
            {
                _khrSurfaceApi.GetPhysicalDeviceSurfacePresentModes(physicalDevice, _khrSurface, ref presentModeCount, formatsPtr);
            }

        }
        else
        {
            details.PresentModes = Array.Empty<PresentModeKHR>();
        }

        return details;
    }

    void PickPhysicalDevice()
    {
        uint devicedCount = 0;
        vk!.EnumeratePhysicalDevices(_vulkanInstance, ref devicedCount, null);

        if (devicedCount == 0)
        {
            throw new Exception("failed to find GPUs with Vulkan support!");
        }

        var devices = new PhysicalDevice[devicedCount];
        fixed (PhysicalDevice* devicesPtr = devices)
        {
            vk!.EnumeratePhysicalDevices(_vulkanInstance, ref devicedCount, devicesPtr);
        }

        foreach (var device in devices)
        {
            if (IsDeviceSuitable(device))
            {
                _physicalDevice = device;
                MsaaSamples = GetMaxUsableSampleCount();
                break;
            }
        }

        if (_physicalDevice.Handle == 0)
        {
            throw new Exception("failed to find a suitable GPU!");
        }
    }

    private string[] GetRequiredExtensions()
    {
        var glfwExtensions = _window!.VkSurface!.GetRequiredExtensions(out var glfwExtensionCount);
        var extensions = SilkMarshal.PtrToStringArray((nint)glfwExtensions, (int)glfwExtensionCount);

        if (AreValidationLayersEnabled)
        {
            return extensions.Append(ExtDebugUtils.ExtensionName).ToArray();
        }

        return extensions;
    }

    public QueueFamilyIndices FindQueueFamilies()
    {
        return FindQueueFamilies(_physicalDevice);
    }
    public QueueFamilyIndices FindQueueFamilies(PhysicalDevice device)
    {
        var indices = new QueueFamilyIndices();

        uint queueFamilityCount = 0;
        vk!.GetPhysicalDeviceQueueFamilyProperties(device, ref queueFamilityCount, null);

        var queueFamilies = new QueueFamilyProperties[queueFamilityCount];
        fixed (QueueFamilyProperties* queueFamiliesPtr = queueFamilies)
        {
            vk!.GetPhysicalDeviceQueueFamilyProperties(device, ref queueFamilityCount, queueFamiliesPtr);
        }


        uint i = 0;
        foreach (var queueFamily in queueFamilies)
        {
            if (queueFamily.QueueFlags.HasFlag(QueueFlags.GraphicsBit))
            {
                indices.GraphicsFamily = i;
            }
            _khrSurfaceApi!.GetPhysicalDeviceSurfaceSupport(device, i, _khrSurface, out var presentSupport);

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

    private void CreateLogicalDevice()
    {
        var indices = FindQueueFamilies();

        var uniqueQueueFamilies = new[] {
            indices.GraphicsFamily!.Value,
            indices.PresentFamily!.Value };

        uniqueQueueFamilies = uniqueQueueFamilies.Distinct().ToArray();

        graphicsFamilyIndex = indices.GraphicsFamily.Value;

        using var mem = GlobalMemory.Allocate(uniqueQueueFamilies.Length * sizeof(DeviceQueueCreateInfo));
        var queueCreateInfos = (DeviceQueueCreateInfo*)Unsafe.AsPointer(ref mem.GetPinnableReference());

        float queuePriority = 1.0f;
        for (int i = 0; i < uniqueQueueFamilies.Length; i++)
        {
            queueCreateInfos[i] = new()
            {
                SType = StructureType.DeviceQueueCreateInfo,
                QueueFamilyIndex = uniqueQueueFamilies[i],
                QueueCount = 1
            };


            queueCreateInfos[i].PQueuePriorities = &queuePriority;
        }

        PhysicalDeviceFeatures deviceFeatures = new()
        {
            SamplerAnisotropy = true,
        };


        DeviceCreateInfo createInfo = new()
        {
            SType = StructureType.DeviceCreateInfo,
            QueueCreateInfoCount = (uint)uniqueQueueFamilies.Length,
            PQueueCreateInfos = queueCreateInfos,

            PEnabledFeatures = &deviceFeatures,

            EnabledExtensionCount = (uint)deviceExtensions.Length,
            PpEnabledExtensionNames = (byte**)SilkMarshal.StringArrayToPtr(deviceExtensions)
        };

        if (AreValidationLayersEnabled)
        {
            createInfo.EnabledLayerCount = (uint)validationLayers.Length;
            createInfo.PpEnabledLayerNames = (byte**)SilkMarshal.StringArrayToPtr(validationLayers);
        }
        else
        {
            createInfo.EnabledLayerCount = 0;
        }

        if (vk!.CreateDevice(_physicalDevice, in createInfo, null, out _device) != Result.Success)
        {
            throw new Exception("failed to create logical device!");
        }

        vk!.GetDeviceQueue(_device, indices.GraphicsFamily!.Value, 0, out _graphicsQueue);
        vk!.GetDeviceQueue(_device, indices.PresentFamily!.Value, 0, out _presentQueue);

        if (AreValidationLayersEnabled)
        {
            SilkMarshal.Free((nint)createInfo.PpEnabledLayerNames);
        }

        SilkMarshal.Free((nint)createInfo.PpEnabledExtensionNames);
    }

}
