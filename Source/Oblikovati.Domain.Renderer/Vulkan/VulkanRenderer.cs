using Silk.NET.Vulkan.Extensions.EXT;
using Silk.NET.Vulkan.Extensions.KHR;
using Silk.NET.Vulkan;
using Silk.NET.Windowing;
using Semaphore = Silk.NET.Vulkan.Semaphore;
using Buffer = Silk.NET.Vulkan.Buffer;
using Silk.NET.Core.Native;
using System.Runtime.CompilerServices;
using Silk.NET.Assimp;
using Silk.NET.Maths;
using Oblikovati.Domain.Windowing;
using Silk.NET.Input;
using System.Diagnostics;
using Silk.NET.OpenAL;

namespace Oblikovati.Domain.Renderer.Vulkan;


public unsafe class VulkanRenderer : IDisposable
{
    const int MAX_FRAMES_IN_FLIGHT = 2;
    private readonly VulkanDevice _vulkanDevice;
    private VulkanSwapChain? _vulkanSwapChain;
    private readonly IWindow _window;
    private readonly Vk _vulkanApi;

    public VulkanRenderer(IWindow window)
    {
        _window = window;
        _vulkanApi = Vk.GetApi();
        
        _vulkanDevice = new VulkanDevice(_vulkanApi, _window, Debugger.IsAttached);

        _window.Resize += _window_Resize;
        _window.Render += DrawFrame;
    }

    private void _window_Resize(Vector2D<int> obj)
    {
        frameBufferResized = true;
        RecreateSwapChain();
        _window.DoRender();
    }

    public void Initialize()
    {
        _vulkanDevice.Initialize();

        _vulkanSwapChain = new VulkanSwapChain(
            _vulkanApi, 
            _vulkanDevice.Instance, 
            _vulkanDevice.PhysicalDevice, 
            _vulkanDevice.Device,
            _vulkanDevice.KhrSurfaceApi!,
            _vulkanDevice.Surface);

        _vulkanSwapChain.Initialize();

        _vulkanSwapChain.CreateSwapChain(
            (uint)_window.FramebufferSize.X, 
            (uint)_window.FramebufferSize.Y, 
            true, 
            false);
        CreateCommandPool();
        CreateCommandBuffers();
        CreateSyncObjects();
        CreateColorResources();
        CreateDepthResources();
        CreateRenderPass();
        CreateDescriptorSetLayout();
        CreateGraphicsPipeline(
            System.IO.File.ReadAllBytes("shaders/vert.spv"),
            System.IO.File.ReadAllBytes("shaders/frag.spv"));
        
        
        CreateFramebuffers();
        CreateTextureImage("Assets/viking_room.png");
        CreateTextureImageView();
        CreateTextureSampler();
        LoadModel("Assets/viking_room.obj");
        CreateVertexBuffer();
        CreateIndexBuffer();
        CreateUniformBuffers();
        CreateDescriptorPool();
        CreateDescriptorSets();
        
        
        InitImGui();
    }
    private void CreateCommandPool()
    {
        var queueFamiliyIndicies = _vulkanDevice.FindQueueFamilies();

        CommandPoolCreateInfo poolInfo = new()
        {
            SType = StructureType.CommandPoolCreateInfo,
            QueueFamilyIndex = queueFamiliyIndicies.GraphicsFamily!.Value,
        };

        if (_vulkanApi!.CreateCommandPool(_vulkanDevice.Device, 
            poolInfo, null, out commandPool) != Result.Success)
        {
            throw new Exception("failed to create command pool!");
        }
    }
    private void InitImGui()
    {
        //_imGui = new ImGuiController(
        //            _vulkanApi,
        //            _window,
        //            _window.CreateInput(),
        //            _vulkanDevice.PhysicalDevice,
        //            graphicsFamilyIndex,
        //            swapChainImages.Length,
        //            _vulkanSwapChain.SwapChainImageFormat,
        //            null
        //        );
    }
    public void DrawFrame(double delta)
    {
        // Make sure ImGui is up-to-date before rendering
        //_imGui.Update((float)delta);

        // This is where you'll tell ImGui what to draw.
        // For now, we'll just show their built-in demo window.
       // ImGuiNET.ImGui.ShowDemoWindow();

        _vulkanApi!.WaitForFences(_vulkanDevice.Device, 1, inFlightFences![currentFrame], true, ulong.MaxValue);

        uint imageIndex = _vulkanSwapChain.AquireNextImageIndex(imageAvailableSemaphores![currentFrame]);

       // var result = _vulkanSwapChain.!.AcquireNextImage(_vulkanDevice.Device, swapChain, ulong.MaxValue, imageAvailableSemaphores![currentFrame], default, ref imageIndex);

        //if (result == Result.ErrorOutOfDateKhr)
        //{
        //    RecreateSwapChain();
        //    return;
        //}
        //else if (result != Result.Success && result != Result.SuboptimalKhr)
        //{
        //    throw new Exception("failed to acquire swap chain image!");
        //}

        UpdateUniformBuffer(imageIndex);

        if (imagesInFlight![imageIndex].Handle != default)
        {
            _vulkanApi!.WaitForFences(_vulkanDevice.Device, 1, imagesInFlight[imageIndex], true, ulong.MaxValue);
        }
        imagesInFlight[imageIndex] = inFlightFences[currentFrame];


        CommandBufferBeginInfo beginInfo = new()
        {
            SType = StructureType.CommandBufferBeginInfo,
            Flags = CommandBufferUsageFlags.OneTimeSubmitBit
        };

        if (_vulkanApi!.BeginCommandBuffer(commandBuffers[imageIndex], beginInfo) != Result.Success)
        {
            throw new Exception("failed to begin recording command buffer!");
        }

        RenderPassBeginInfo renderPassInfo = new()
        {
            SType = StructureType.RenderPassBeginInfo,
            RenderPass = renderPass,
            Framebuffer = swapChainFramebuffers[imageIndex],
            RenderArea =
            {
                Offset = { X = 0, Y = 0 },
                Extent = _vulkanSwapChain.SwapChainExtent,
            }
        };

        var clearValues = new ClearValue[]
        {
            new()
            {
                Color = new (){ Float32_0 = 0.01F, Float32_1 = 0.01F, Float32_2 = 0.01F, Float32_3 = 1 },
            },
            new()
            {
                DepthStencil = new () { Depth = 1, Stencil = 0 }
            }
        };


        fixed (ClearValue* clearValuesPtr = clearValues)
        {
            renderPassInfo.ClearValueCount = (uint)clearValues.Length;
            renderPassInfo.PClearValues = clearValuesPtr;

            _vulkanApi!.CmdBeginRenderPass(commandBuffers[imageIndex], &renderPassInfo, SubpassContents.Inline);
        }

        _vulkanApi!.CmdBindPipeline(commandBuffers[imageIndex], PipelineBindPoint.Graphics, graphicsPipeline);

        var vertexBuffers = new Buffer[] { vertexBuffer };
        var offsets = new ulong[] { 0 };

        fixed (ulong* offsetsPtr = offsets)
        fixed (Buffer* vertexBuffersPtr = vertexBuffers)
        {
            _vulkanApi!.CmdBindVertexBuffers(commandBuffers[imageIndex], 0, 1, vertexBuffersPtr, offsetsPtr);
        }

        _vulkanApi!.CmdBindIndexBuffer(commandBuffers[imageIndex], indexBuffer, 0, IndexType.Uint32);

        _vulkanApi!.CmdBindDescriptorSets(commandBuffers[imageIndex], PipelineBindPoint.Graphics, pipelineLayout, 0, 1, descriptorSets![imageIndex], 0, null);

        _vulkanApi!.CmdDrawIndexed(commandBuffers[imageIndex], (uint)indices!.Length, 1, 0, 0, 0);

        _vulkanApi!.CmdEndRenderPass(commandBuffers[imageIndex]);

        // Render ImGui
       // _imGui.Render(commandBuffers[imageIndex], swapChainFramebuffers[imageIndex], _vulkanSwapChain.SwapChainExtent);

        if (_vulkanApi!.EndCommandBuffer(commandBuffers[imageIndex]) != Result.Success)
        {
            throw new Exception("failed to record command buffer!");
        }

        SubmitInfo submitInfo = new()
        {
            SType = StructureType.SubmitInfo,
        };

        var waitSemaphores = stackalloc[] { imageAvailableSemaphores[currentFrame] };
        var waitStages = stackalloc[] { 
            PipelineStageFlags.PipelineStageColorAttachmentOutputBit };

        var buffer = commandBuffers![imageIndex];

        submitInfo = submitInfo with
        {
            WaitSemaphoreCount = 1,
            PWaitSemaphores = waitSemaphores,
            PWaitDstStageMask = waitStages,
            CommandBufferCount = 1,
            PCommandBuffers = &buffer
        };

        var signalSemaphores = stackalloc[] { renderFinishedSemaphores![currentFrame] };
        submitInfo = submitInfo with
        {
            SignalSemaphoreCount = 1,
            PSignalSemaphores = signalSemaphores,
        };
        
        _vulkanApi!.ResetFences(_vulkanDevice.Device, 1, inFlightFences[currentFrame]);

        if (_vulkanApi!.QueueSubmit(_vulkanDevice.GraphicsQueue, 1, submitInfo, inFlightFences[currentFrame]) != Result.Success)
        {
            throw new Exception("failed to submit draw command buffer!");
        }

        var swapChains = stackalloc[] { _vulkanSwapChain.SwapChain };

        PresentInfoKHR presentInfo = new()
        {
            SType = StructureType.PresentInfoKhr,

            WaitSemaphoreCount = 1,
            PWaitSemaphores = signalSemaphores,

            SwapchainCount = 1,
            PSwapchains = swapChains,

            PImageIndices = &imageIndex
        };

        var result = _vulkanSwapChain.KhrSwapchain?.QueuePresent(_vulkanDevice.PresentQueue, presentInfo);

        if (result == Result.ErrorOutOfDateKhr || result == Result.SuboptimalKhr || frameBufferResized)
        {
            frameBufferResized = false;
            RecreateSwapChain();
        }
        else if (result != Result.Success)
        {
            throw new Exception("failed to present swap chain image!");
        }

        currentFrame = (currentFrame + 1) % MAX_FRAMES_IN_FLIGHT;

    }
    public void Shutdown()
    {
        _vulkanApi!.DeviceWaitIdle(_vulkanDevice.Device);

        _imGui.Dispose();

       // CleanUpSwapChain();

        _vulkanApi!.DestroySampler(_vulkanDevice.Device, textureSampler, null);
        _vulkanApi!.DestroyImageView(_vulkanDevice.Device, textureImageView, null);

        _vulkanApi!.DestroyImage(_vulkanDevice.Device, textureImage, null);
        _vulkanApi!.FreeMemory(_vulkanDevice.Device, textureImageMemory, null);

        _vulkanApi!.DestroyDescriptorSetLayout(_vulkanDevice.Device, descriptorSetLayout, null);

        _vulkanApi!.DestroyBuffer(_vulkanDevice.Device, indexBuffer, null);
        _vulkanApi!.FreeMemory(_vulkanDevice.Device, indexBufferMemory, null);

        _vulkanApi!.DestroyBuffer(_vulkanDevice.Device, vertexBuffer, null);
        _vulkanApi!.FreeMemory(_vulkanDevice.Device, vertexBufferMemory, null);

        for (int i = 0; i < MAX_FRAMES_IN_FLIGHT; i++)
        {
            _vulkanApi!.DestroySemaphore(_vulkanDevice.Device, renderFinishedSemaphores![i], null);
            _vulkanApi!.DestroySemaphore(_vulkanDevice.Device, imageAvailableSemaphores![i], null);
            _vulkanApi!.DestroyFence(_vulkanDevice.Device, inFlightFences![i], null);
        }

        _vulkanApi!.DestroyCommandPool(_vulkanDevice.Device, commandPool, null);

        _vulkanApi!.DestroyDevice(_vulkanDevice.Device, null);

        //if (AreValidationLayersEnabled)
        //{
        //    debugUtils!.DestroyDebugUtilsMessenger(_vulkanInstance, debugMessenger, null);
        //}

       // khrSurface!.DestroySurface(_vulkanInstance, surface, null);
       // _vulkanApi!.DestroyInstance(_vulkanInstance, null);
        _vulkanApi!.Dispose();
    }
    //Private Methods --------------------------------------------------
    private void UpdateUniformBuffer(uint currentImage)
    {
        //Silk Window has timing information so we are skipping the time code.
        var time = (float)_window!.Time;

        UniformBufferObject ubo = new()
        {
            Model = Matrix4X4<float>.Identity * Matrix4X4.CreateFromAxisAngle(new Vector3D<float>(0, 0, 1), time * Scalar.DegreesToRadians(90.0f)),
            View = Matrix4X4.CreateLookAt(new Vector3D<float>(2, 2, 2), new Vector3D<float>(0, 0, 0), new Vector3D<float>(0, 0, 1)),
            Projection = Matrix4X4.CreatePerspectiveFieldOfView(Scalar.DegreesToRadians(45.0f), _vulkanSwapChain.SwapChainExtent.Width / _vulkanSwapChain.SwapChainExtent.Height, 0.1f, 10.0f),
        };
        ubo.Projection.M22 *= -1;


        void* data;
        _vulkanApi!.MapMemory(_vulkanDevice.Device, uniformBuffersMemory![currentImage], 0, (ulong)Unsafe.SizeOf<UniformBufferObject>(), 0, &data);
        new Span<UniformBufferObject>(data, 1)[0] = ubo;
        _vulkanApi!.UnmapMemory(_vulkanDevice.Device, uniformBuffersMemory![currentImage]);

    }

    private void RecreateSwapChain()
    {
        Vector2D<int> framebufferSize = _window!.FramebufferSize;

        while (framebufferSize.X == 0 || framebufferSize.Y == 0)
        {
            framebufferSize = _window.FramebufferSize;
            _window.DoEvents();
        }

        _vulkanApi!.DeviceWaitIdle(_vulkanDevice.Device);

        //CleanUpSwapChain();

        CreateRenderPass();
        CreateGraphicsPipeline(
            System.IO.File.ReadAllBytes("shaders/vert.spv"),
            System.IO.File.ReadAllBytes("shaders/frag.spv"));
      //  CreateColorResources();
       // CreateDepthResources();
        CreateFramebuffers();
        CreateUniformBuffers();
        CreateDescriptorPool();
        CreateDescriptorSets();
        CreateCommandBuffers();

        imagesInFlight = new Fence[_vulkanSwapChain!.ImageCount];
    }

    private Format FindSupportedFormat(IEnumerable<Format> candidates, ImageTiling tiling, FormatFeatureFlags features)
    {
        foreach (var format in candidates)
        {
            _vulkanApi!.GetPhysicalDeviceFormatProperties(_vulkanDevice.PhysicalDevice, format, out var props);

            if (tiling == ImageTiling.Linear && (props.LinearTilingFeatures & features) == features)
            {
                return format;
            }
            else if (tiling == ImageTiling.Optimal && (props.OptimalTilingFeatures & features) == features)
            {
                return format;
            }
        }

        throw new Exception("failed to find supported format!");
    }

    private Format FindDepthFormat()
    {
        return FindSupportedFormat(new[] { Format.D32Sfloat, Format.D32SfloatS8Uint, Format.D24UnormS8Uint }, ImageTiling.Optimal, FormatFeatureFlags.FormatFeatureDepthStencilAttachmentBit);
    }

    void CreateRenderPass()
    {
        AttachmentDescription colorAttachment = new()
        {
            Format = _vulkanSwapChain!.SwapChainImageFormat,
            Samples = _vulkanDevice.MsaaSamples,
            LoadOp = AttachmentLoadOp.Clear,
            StoreOp = AttachmentStoreOp.Store,
            StencilLoadOp = AttachmentLoadOp.DontCare,
            InitialLayout = ImageLayout.Undefined,
            FinalLayout = ImageLayout.ColorAttachmentOptimal,
        };

        AttachmentDescription depthAttachment = new()
        {
            Format = FindDepthFormat(),
            Samples = _vulkanDevice.MsaaSamples,
            LoadOp = AttachmentLoadOp.Clear,
            StoreOp = AttachmentStoreOp.DontCare,
            StencilLoadOp = AttachmentLoadOp.DontCare,
            StencilStoreOp = AttachmentStoreOp.DontCare,
            InitialLayout = ImageLayout.Undefined,
            FinalLayout = ImageLayout.DepthStencilAttachmentOptimal,
        };

        AttachmentDescription colorAttachmentResolve = new()
        {
            Format = _vulkanSwapChain.SwapChainImageFormat,
            Samples = SampleCountFlags.Count1Bit,
            LoadOp = AttachmentLoadOp.DontCare,
            StoreOp = AttachmentStoreOp.Store,
            StencilLoadOp = AttachmentLoadOp.DontCare,
            StencilStoreOp = AttachmentStoreOp.DontCare,
            InitialLayout = ImageLayout.Undefined,
            FinalLayout = ImageLayout.PresentSrcKhr,
        };

        AttachmentReference colorAttachmentRef = new()
        {
            Attachment = 0,
            Layout = ImageLayout.ColorAttachmentOptimal,
        };

        AttachmentReference depthAttachmentRef = new()
        {
            Attachment = 1,
            Layout = ImageLayout.DepthStencilAttachmentOptimal,
        };

        AttachmentReference colorAttachmentResolveRef = new()
        {
            Attachment = 2,
            Layout = ImageLayout.ColorAttachmentOptimal,
        };

        SubpassDescription subpass = new()
        {
            PipelineBindPoint = PipelineBindPoint.Graphics,
            ColorAttachmentCount = 1,
            PColorAttachments = &colorAttachmentRef,
            PDepthStencilAttachment = &depthAttachmentRef,
            PResolveAttachments = &colorAttachmentResolveRef,
        };

        SubpassDependency dependency = new()
        {
            SrcSubpass = Vk.SubpassExternal,
            DstSubpass = 0,
            SrcStageMask = PipelineStageFlags.PipelineStageColorAttachmentOutputBit | PipelineStageFlags.PipelineStageEarlyFragmentTestsBit,
            SrcAccessMask = 0,
            DstStageMask = PipelineStageFlags.PipelineStageColorAttachmentOutputBit | PipelineStageFlags.PipelineStageEarlyFragmentTestsBit,
            DstAccessMask = AccessFlags.AccessColorAttachmentWriteBit | AccessFlags.AccessDepthStencilAttachmentWriteBit
        };

        var attachments = new[] { colorAttachment, depthAttachment, colorAttachmentResolve };

        fixed (AttachmentDescription* attachmentsPtr = attachments)
        {
            RenderPassCreateInfo renderPassInfo = new()
            {
                SType = StructureType.RenderPassCreateInfo,
                AttachmentCount = (uint)attachments.Length,
                PAttachments = attachmentsPtr,
                SubpassCount = 1,
                PSubpasses = &subpass,
                DependencyCount = 1,
                PDependencies = &dependency,
            };

            if (_vulkanApi!.CreateRenderPass(_vulkanDevice.Device, renderPassInfo, null, out renderPass) != Result.Success)
            {
                throw new Exception("failed to create render pass!");
            }
        }
    }

    private void CreateDescriptorSetLayout()
    {
        DescriptorSetLayoutBinding uboLayoutBinding = new()
        {
            Binding = 0,
            DescriptorCount = 1,
            DescriptorType = DescriptorType.UniformBuffer,
            PImmutableSamplers = null,
            StageFlags = ShaderStageFlags.ShaderStageVertexBit,
        };

        DescriptorSetLayoutBinding samplerLayoutBinding = new()
        {
            Binding = 1,
            DescriptorCount = 1,
            DescriptorType = DescriptorType.CombinedImageSampler,
            PImmutableSamplers = null,
            StageFlags = ShaderStageFlags.ShaderStageFragmentBit,
        };

        var bindings = new DescriptorSetLayoutBinding[] { uboLayoutBinding, samplerLayoutBinding };

        fixed (DescriptorSetLayoutBinding* bindingsPtr = bindings)
        fixed (DescriptorSetLayout* descriptorSetLayoutPtr = &descriptorSetLayout)
        {
            DescriptorSetLayoutCreateInfo layoutInfo = new()
            {
                SType = StructureType.DescriptorSetLayoutCreateInfo,
                BindingCount = (uint)bindings.Length,
                PBindings = bindingsPtr,
            };

            if (_vulkanApi!.CreateDescriptorSetLayout(_vulkanDevice.Device, layoutInfo, null, descriptorSetLayoutPtr) != Result.Success)
            {
                throw new Exception("failed to create descriptor set layout!");
            }
        }
    }

    private ShaderModule CreateShaderModule(byte[] code)
    {
        ShaderModuleCreateInfo createInfo = new()
        {
            SType = StructureType.ShaderModuleCreateInfo,
            CodeSize = (nuint)code.Length,
        };

        ShaderModule shaderModule;

        fixed (byte* codePtr = code)
        {
            createInfo.PCode = (uint*)codePtr;

            if (_vulkanApi!.CreateShaderModule(_vulkanDevice.Device, createInfo, null, out shaderModule) != Result.Success)
            {
                throw new Exception();
            }
        }

        return shaderModule;

    }

    void CreateGraphicsPipeline(byte[]? vertShaderCode, byte[]? fragShaderCode)
    {
        var vertShaderModule = CreateShaderModule(vertShaderCode);
        var fragShaderModule = CreateShaderModule(fragShaderCode);

        PipelineShaderStageCreateInfo vertShaderStageInfo = new()
        {
            SType = StructureType.PipelineShaderStageCreateInfo,
            Stage = ShaderStageFlags.ShaderStageVertexBit,
            Module = vertShaderModule,
            PName = (byte*)SilkMarshal.StringToPtr("main")
        };

        PipelineShaderStageCreateInfo fragShaderStageInfo = new()
        {
            SType = StructureType.PipelineShaderStageCreateInfo,
            Stage = ShaderStageFlags.ShaderStageFragmentBit,
            Module = fragShaderModule,
            PName = (byte*)SilkMarshal.StringToPtr("main")
        };

        var shaderStages = stackalloc[]
        {
            vertShaderStageInfo,
            fragShaderStageInfo
        };

        var bindingDescription = Vertex.GetBindingDescription();
        var attributeDescriptions = Vertex.GetAttributeDescriptions();

        fixed (VertexInputAttributeDescription* attributeDescriptionsPtr = attributeDescriptions)
        fixed (DescriptorSetLayout* descriptorSetLayoutPtr = &descriptorSetLayout)
        {

            PipelineVertexInputStateCreateInfo vertexInputInfo = new()
            {
                SType = StructureType.PipelineVertexInputStateCreateInfo,
                VertexBindingDescriptionCount = 1,
                VertexAttributeDescriptionCount = (uint)attributeDescriptions.Length,
                PVertexBindingDescriptions = &bindingDescription,
                PVertexAttributeDescriptions = attributeDescriptionsPtr,
            };

            PipelineInputAssemblyStateCreateInfo inputAssembly = new()
            {
                SType = StructureType.PipelineInputAssemblyStateCreateInfo,
                Topology = PrimitiveTopology.TriangleList,
                PrimitiveRestartEnable = false,
            };

            Viewport viewport = new()
            {
                X = 0,
                Y = 0,
                Width = _vulkanSwapChain.SwapChainExtent.Width,
                Height = _vulkanSwapChain.SwapChainExtent.Height,
                MinDepth = 0,
                MaxDepth = 1,
            };

            Rect2D scissor = new()
            {
                Offset = { X = 0, Y = 0 },
                Extent = _vulkanSwapChain.SwapChainExtent,
            };

            PipelineViewportStateCreateInfo viewportState = new()
            {
                SType = StructureType.PipelineViewportStateCreateInfo,
                ViewportCount = 1,
                PViewports = &viewport,
                ScissorCount = 1,
                PScissors = &scissor,
            };

            PipelineRasterizationStateCreateInfo rasterizer = new()
            {
                SType = StructureType.PipelineRasterizationStateCreateInfo,
                DepthClampEnable = false,
                RasterizerDiscardEnable = false,
                PolygonMode = PolygonMode.Fill,
                LineWidth = 1,
                CullMode = CullModeFlags.CullModeBackBit,
                FrontFace = FrontFace.CounterClockwise,
                DepthBiasEnable = false,
            };

            PipelineMultisampleStateCreateInfo multisampling = new()
            {
                SType = StructureType.PipelineMultisampleStateCreateInfo,
                SampleShadingEnable = false,
                RasterizationSamples = _vulkanDevice.MsaaSamples,
            };

            PipelineDepthStencilStateCreateInfo depthStencil = new()
            {
                SType = StructureType.PipelineDepthStencilStateCreateInfo,
                DepthTestEnable = true,
                DepthWriteEnable = true,
                DepthCompareOp = CompareOp.Less,
                DepthBoundsTestEnable = false,
                StencilTestEnable = false,
            };

            var colorBlendAttachment = new PipelineColorBlendAttachmentState
            {
                ColorWriteMask = ColorComponentFlags.RBit |
                                 ColorComponentFlags.GBit |
                                 ColorComponentFlags.BBit |
                                 ColorComponentFlags.ABit,
                BlendEnable = Vk.False
            };

            var colorBlending = new PipelineColorBlendStateCreateInfo
            {
                SType = StructureType.PipelineColorBlendStateCreateInfo,
                LogicOpEnable = Vk.False,
                LogicOp = LogicOp.Copy,
                AttachmentCount = 1,
                PAttachments = &colorBlendAttachment
            };

            colorBlending.BlendConstants[0] = 0.0f;
            colorBlending.BlendConstants[1] = 0.0f;
            colorBlending.BlendConstants[2] = 0.0f;
            colorBlending.BlendConstants[3] = 0.0f;


            PipelineLayoutCreateInfo pipelineLayoutInfo = new()
            {
                SType = StructureType.PipelineLayoutCreateInfo,
                PushConstantRangeCount = 0,
                SetLayoutCount = 1,
                PSetLayouts = descriptorSetLayoutPtr
            };

            if (_vulkanApi!.CreatePipelineLayout(_vulkanDevice.Device, pipelineLayoutInfo, null, out pipelineLayout) != Result.Success)
            {
                throw new Exception("failed to create pipeline layout!");
            }

            GraphicsPipelineCreateInfo pipelineInfo = new()
            {
                SType = StructureType.GraphicsPipelineCreateInfo,
                StageCount = 2,
                PStages = shaderStages,
                PVertexInputState = &vertexInputInfo,
                PInputAssemblyState = &inputAssembly,
                PViewportState = &viewportState,
                PRasterizationState = &rasterizer,
                PMultisampleState = &multisampling,
                PDepthStencilState = &depthStencil,
                PColorBlendState = &colorBlending,
                Layout = pipelineLayout,
                RenderPass = renderPass,
                Subpass = 0,
                BasePipelineHandle = default
            };

            if (_vulkanApi!.CreateGraphicsPipelines(_vulkanDevice.Device, default, 1, pipelineInfo, null, out graphicsPipeline) != Result.Success)
            {
                throw new Exception("failed to create graphics pipeline!");
            }
        }

        _vulkanApi!.DestroyShaderModule(_vulkanDevice.Device, fragShaderModule, null);
        _vulkanApi!.DestroyShaderModule(_vulkanDevice.Device, vertShaderModule, null);

        SilkMarshal.Free((nint)vertShaderStageInfo.PName);
        SilkMarshal.Free((nint)fragShaderStageInfo.PName);
    }

    //private void CreateCommandPool()
    //{
    //    var queueFamiliyIndicies = FindQueueFamilies(_vulkanDevice.PhysicalDevice);

    //    CommandPoolCreateInfo poolInfo = new()
    //    {
    //        SType = StructureType.CommandPoolCreateInfo,
    //        QueueFamilyIndex = queueFamiliyIndicies.GraphicsFamily!.Value,
    //        Flags = CommandPoolCreateFlags.ResetCommandBufferBit
    //    };

    //    if (_vulkanApi!.CreateCommandPool(_vulkanDevice.Device, poolInfo, null, out commandPool) != Result.Success)
    //    {
    //        throw new Exception("failed to create command pool!");
    //    }
    //}

    private uint FindMemoryType(uint typeFilter, MemoryPropertyFlags properties)
    {
        PhysicalDeviceMemoryProperties memProperties;
        _vulkanApi!.GetPhysicalDeviceMemoryProperties(_vulkanDevice.PhysicalDevice, out memProperties);

        for (int i = 0; i < memProperties.MemoryTypeCount; i++)
        {
            if ((typeFilter & 1 << i) != 0 && (memProperties.MemoryTypes[i].PropertyFlags & properties) == properties)
            {
                return (uint)i;
            }
        }

        throw new Exception("failed to find suitable memory type!");
    }

    private ImageView CreateImageView(Image image, Format format, ImageAspectFlags aspectFlags, uint mipLevels)
    {
        ImageViewCreateInfo createInfo = new()
        {
            SType = StructureType.ImageViewCreateInfo,
            Image = image,
            ViewType = ImageViewType.Type2D,
            Format = format,
            //Components =
            //    {
            //        R = ComponentSwizzle.Identity,
            //        G = ComponentSwizzle.Identity,
            //        B = ComponentSwizzle.Identity,
            //        A = ComponentSwizzle.Identity,
            //    },
            SubresourceRange =
                {
                    AspectMask = aspectFlags,
                    BaseMipLevel = 0,
                    LevelCount = mipLevels,
                    BaseArrayLayer = 0,
                    LayerCount = 1,
                }

        };

        ImageView imageView = default;

        if (_vulkanApi!.CreateImageView(_vulkanDevice.Device, createInfo, null, out imageView) != Result.Success)
        {
            throw new Exception("failed to create image views!");
        }

        return imageView;
    }
    private void CreateColorResources()
    {
        Format colorFormat = _vulkanSwapChain!.SwapChainImageFormat;

        CreateImage(_vulkanSwapChain!.SwapChainExtent.Width,
            _vulkanSwapChain!.SwapChainExtent.Height,
            1, _vulkanDevice.MsaaSamples,
            colorFormat,
            ImageTiling.Optimal, 
            ImageUsageFlags.TransientAttachmentBit | ImageUsageFlags.ColorAttachmentBit, 
            MemoryPropertyFlags.DeviceLocalBit,
            ref colorImage, 
            ref colorImageMemory);

        colorImageView = CreateImageView(colorImage, colorFormat, ImageAspectFlags.ColorBit, 1);
    }

    private void CreateDepthResources()
    {
        Format depthFormat = FindDepthFormat();

        CreateImage(_vulkanSwapChain!.SwapChainExtent.Width,
            _vulkanSwapChain!.SwapChainExtent.Height, 1, 
            _vulkanDevice.MsaaSamples, depthFormat, 
            ImageTiling.Optimal, 
            ImageUsageFlags.DepthStencilAttachmentBit, 
            MemoryPropertyFlags.DeviceLocalBit,
            ref depthImage,
            ref depthImageMemory);

        depthImageView = CreateImageView(depthImage, depthFormat, ImageAspectFlags.DepthBit, 1);
    }

    private void CreateImage(uint width, uint height, uint mipLevels, SampleCountFlags numSamples, Format format, ImageTiling tiling, ImageUsageFlags usage, MemoryPropertyFlags properties, ref Image image, ref DeviceMemory imageMemory)
    {
        ImageCreateInfo imageInfo = new()
        {
            SType = StructureType.ImageCreateInfo,
            ImageType = ImageType.ImageType2D,
            Extent =
            {
                Width = width,
                Height = height,
                Depth = 1,
            },
            MipLevels = mipLevels,
            ArrayLayers = 1,
            Format = format,
            Tiling = tiling,
            InitialLayout = ImageLayout.Undefined,
            Usage = usage,
            Samples = numSamples,
            SharingMode = SharingMode.Exclusive,
        };

        fixed (Image* imagePtr = &image)
        {
            if (_vulkanApi!.CreateImage(_vulkanDevice.Device, imageInfo, null, imagePtr) != Result.Success)
            {
                throw new Exception("failed to create image!");
            }
        }

        MemoryRequirements memRequirements;
        _vulkanApi!.GetImageMemoryRequirements(_vulkanDevice.Device, image, out memRequirements);

        MemoryAllocateInfo allocInfo = new()
        {
            SType = StructureType.MemoryAllocateInfo,
            AllocationSize = memRequirements.Size,
            MemoryTypeIndex = FindMemoryType(memRequirements.MemoryTypeBits, properties),
        };

        fixed (DeviceMemory* imageMemoryPtr = &imageMemory)
        {
            if (_vulkanApi!.AllocateMemory(_vulkanDevice.Device, allocInfo, null, imageMemoryPtr) != Result.Success)
            {
                throw new Exception("failed to allocate image memory!");
            }
        }

        _vulkanApi!.BindImageMemory(_vulkanDevice.Device, image, imageMemory, 0);
    }

    //private void CreateColorResources()
    //{
    //    Format colorFormat = _vulkanSwapChain.SwapChainImageFormat;

    //    CreateImage(_vulkanSwapChain.SwapChainExtent.Width, _vulkanSwapChain.SwapChainExtent.Height, 1, _vulkanDevice.MsaaSamples, colorFormat, ImageTiling.Optimal, ImageUsageFlags.ImageUsageTransientAttachmentBit | ImageUsageFlags.ImageUsageColorAttachmentBit, MemoryPropertyFlags.MemoryPropertyDeviceLocalBit, ref colorImage, ref colorImageMemory);
    //    colorImageView = CreateImageView(colorImage, colorFormat, ImageAspectFlags.ImageAspectColorBit, 1);
    //}

    //private void CreateDepthResources()
    //{
    //    Format depthFormat = FindDepthFormat();

    //    CreateImage(_vulkanSwapChain.SwapChainExtent.Width, _vulkanSwapChain.SwapChainExtent.Height, 1, _vulkanDevice.MsaaSamples, depthFormat, ImageTiling.Optimal, ImageUsageFlags.ImageUsageDepthStencilAttachmentBit, MemoryPropertyFlags.MemoryPropertyDeviceLocalBit, ref depthImage, ref depthImageMemory);
    //    depthImageView = CreateImageView(depthImage, depthFormat, ImageAspectFlags.ImageAspectDepthBit, 1);
    //}

    private void CreateFramebuffers()
    {
        swapChainFramebuffers = new Framebuffer[_vulkanSwapChain!.ImageCount];

        for (int i = 0; i < _vulkanSwapChain!.ImageCount; i++)
        {
            var attachments = new[] { colorImageView, depthImageView, _vulkanSwapChain!.SwapChainBuffers![i].View };

            fixed (ImageView* attachmentsPtr = attachments)
            {
                FramebufferCreateInfo framebufferInfo = new()
                {
                    SType = StructureType.FramebufferCreateInfo,
                    RenderPass = renderPass,
                    AttachmentCount = (uint)attachments.Length,
                    PAttachments = attachmentsPtr,
                    Width = _vulkanSwapChain.SwapChainExtent.Width,
                    Height = _vulkanSwapChain.SwapChainExtent.Height,
                    Layers = 1,
                };

                if (_vulkanApi!.CreateFramebuffer(_vulkanDevice.Device, framebufferInfo, null, out swapChainFramebuffers[i]) != Result.Success)
                {
                    throw new Exception("failed to create framebuffer!");
                }
            }
        }
    }

    private void CreateBuffer(ulong size, BufferUsageFlags usage, MemoryPropertyFlags properties, ref Buffer buffer, ref DeviceMemory bufferMemory)
    {
        BufferCreateInfo bufferInfo = new()
        {
            SType = StructureType.BufferCreateInfo,
            Size = size,
            Usage = usage,
            SharingMode = SharingMode.Exclusive,
        };

        fixed (Buffer* bufferPtr = &buffer)
        {
            if (_vulkanApi!.CreateBuffer(_vulkanDevice.Device, bufferInfo, null, bufferPtr) != Result.Success)
            {
                throw new Exception("failed to create vertex buffer!");
            }
        }

        MemoryRequirements memRequirements = new();
        _vulkanApi!.GetBufferMemoryRequirements(_vulkanDevice.Device, buffer, out memRequirements);

        MemoryAllocateInfo allocateInfo = new()
        {
            SType = StructureType.MemoryAllocateInfo,
            AllocationSize = memRequirements.Size,
            MemoryTypeIndex = FindMemoryType(memRequirements.MemoryTypeBits, properties),
        };

        fixed (DeviceMemory* bufferMemoryPtr = &bufferMemory)
        {
            if (_vulkanApi!.AllocateMemory(_vulkanDevice.Device, allocateInfo, null, bufferMemoryPtr) != Result.Success)
            {
                throw new Exception("failed to allocate vertex buffer memory!");
            }
        }

        _vulkanApi!.BindBufferMemory(_vulkanDevice.Device, buffer, bufferMemory, 0);
    }

    private CommandBuffer BeginSingleTimeCommands()
    {
        CommandBufferAllocateInfo allocateInfo = new()
        {
            SType = StructureType.CommandBufferAllocateInfo,
            Level = CommandBufferLevel.Primary,
            CommandPool = commandPool,
            CommandBufferCount = 1,
        };

        CommandBuffer commandBuffer = default;
        _vulkanApi!.AllocateCommandBuffers(_vulkanDevice.Device, allocateInfo, out commandBuffer);

        CommandBufferBeginInfo beginInfo = new()
        {
            SType = StructureType.CommandBufferBeginInfo,
            Flags = CommandBufferUsageFlags.CommandBufferUsageOneTimeSubmitBit,
        };

        _vulkanApi!.BeginCommandBuffer(commandBuffer, beginInfo);

        return commandBuffer;
    }


    private void EndSingleTimeCommands(CommandBuffer commandBuffer)
    {
        _vulkanApi!.EndCommandBuffer(commandBuffer);

        SubmitInfo submitInfo = new()
        {
            SType = StructureType.SubmitInfo,
            CommandBufferCount = 1,
            PCommandBuffers = &commandBuffer,
        };

        _vulkanApi!.QueueSubmit(_vulkanDevice.GraphicsQueue, 1, submitInfo, default);
        _vulkanApi!.QueueWaitIdle(_vulkanDevice.GraphicsQueue);

        _vulkanApi!.FreeCommandBuffers(_vulkanDevice.Device, commandPool, 1, commandBuffer);
    }

    private void TransitionImageLayout(Image image, Format format, ImageLayout oldLayout, ImageLayout newLayout, uint mipLevels)
    {
        CommandBuffer commandBuffer = BeginSingleTimeCommands();

        ImageMemoryBarrier barrier = new()
        {
            SType = StructureType.ImageMemoryBarrier,
            OldLayout = oldLayout,
            NewLayout = newLayout,
            SrcQueueFamilyIndex = Vk.QueueFamilyIgnored,
            DstQueueFamilyIndex = Vk.QueueFamilyIgnored,
            Image = image,
            SubresourceRange =
            {
                AspectMask = ImageAspectFlags.ImageAspectColorBit,
                BaseMipLevel = 0,
                LevelCount = mipLevels,
                BaseArrayLayer = 0,
                LayerCount = 1,
            }
        };

        PipelineStageFlags sourceStage;
        PipelineStageFlags destinationStage;

        if (oldLayout == ImageLayout.Undefined && newLayout == ImageLayout.TransferDstOptimal)
        {
            barrier.SrcAccessMask = 0;
            barrier.DstAccessMask = AccessFlags.AccessTransferWriteBit;

            sourceStage = PipelineStageFlags.PipelineStageTopOfPipeBit;
            destinationStage = PipelineStageFlags.PipelineStageTransferBit;
        }
        else if (oldLayout == ImageLayout.TransferDstOptimal && newLayout == ImageLayout.ShaderReadOnlyOptimal)
        {
            barrier.SrcAccessMask = AccessFlags.AccessTransferWriteBit;
            barrier.DstAccessMask = AccessFlags.AccessShaderReadBit;

            sourceStage = PipelineStageFlags.PipelineStageTransferBit;
            destinationStage = PipelineStageFlags.PipelineStageFragmentShaderBit;
        }
        else
        {
            throw new Exception("unsupported layout transition!");
        }

        _vulkanApi!.CmdPipelineBarrier(commandBuffer, sourceStage, destinationStage, 0, 0, null, 0, null, 1, barrier);

        EndSingleTimeCommands(commandBuffer);

    }

    private void CopyBufferToImage(Buffer buffer, Image image, uint width, uint height)
    {
        CommandBuffer commandBuffer = BeginSingleTimeCommands();

        BufferImageCopy region = new()
        {
            BufferOffset = 0,
            BufferRowLength = 0,
            BufferImageHeight = 0,
            ImageSubresource =
            {
                AspectMask = ImageAspectFlags.ImageAspectColorBit,
                MipLevel = 0,
                BaseArrayLayer = 0,
                LayerCount = 1,
            },
            ImageOffset = new Offset3D(0, 0, 0),
            ImageExtent = new Extent3D(width, height, 1),

        };

        _vulkanApi!.CmdCopyBufferToImage(commandBuffer, buffer, image, ImageLayout.TransferDstOptimal, 1, region);

        EndSingleTimeCommands(commandBuffer);
    }

    private void GenerateMipMaps(Image image, Format imageFormat, uint width, uint height, uint mipLevels)
    {
        _vulkanApi!.GetPhysicalDeviceFormatProperties(_vulkanDevice.PhysicalDevice, imageFormat, out var formatProperties);

        if ((formatProperties.OptimalTilingFeatures & FormatFeatureFlags.FormatFeatureSampledImageFilterLinearBit) == 0)
        {
            throw new Exception("texture image format does not support linear blitting!");
        }

        var commandBuffer = BeginSingleTimeCommands();

        ImageMemoryBarrier barrier = new()
        {
            SType = StructureType.ImageMemoryBarrier,
            Image = image,
            SrcQueueFamilyIndex = Vk.QueueFamilyIgnored,
            DstQueueFamilyIndex = Vk.QueueFamilyIgnored,
            SubresourceRange =
            {
                AspectMask = ImageAspectFlags.ImageAspectColorBit,
                BaseArrayLayer = 0,
                LayerCount = 1,
                LevelCount = 1,
            }
        };

        var mipWidth = width;
        var mipHeight = height;

        for (uint i = 1; i < mipLevels; i++)
        {
            barrier.SubresourceRange.BaseMipLevel = i - 1;
            barrier.OldLayout = ImageLayout.TransferDstOptimal;
            barrier.NewLayout = ImageLayout.TransferSrcOptimal;
            barrier.SrcAccessMask = AccessFlags.AccessTransferWriteBit;
            barrier.DstAccessMask = AccessFlags.AccessTransferReadBit;

            _vulkanApi!.CmdPipelineBarrier(commandBuffer, PipelineStageFlags.PipelineStageTransferBit, PipelineStageFlags.PipelineStageTransferBit, 0,
                0, null,
                0, null,
                1, barrier);

            ImageBlit blit = new()
            {
                SrcOffsets =
                {
                    Element0 = new Offset3D(0,0,0),
                    Element1 = new Offset3D((int)mipWidth, (int)mipHeight, 1),
                },
                SrcSubresource =
                {
                    AspectMask = ImageAspectFlags.ImageAspectColorBit,
                    MipLevel = i - 1,
                    BaseArrayLayer = 0,
                    LayerCount = 1,
                },
                DstOffsets =
                {
                    Element0 = new Offset3D(0,0,0),
                    Element1 = new Offset3D((int)(mipWidth > 1 ? mipWidth / 2 : 1), (int)(mipHeight > 1 ? mipHeight / 2 : 1),1),
                },
                DstSubresource =
                {
                    AspectMask = ImageAspectFlags.ImageAspectColorBit,
                    MipLevel = i,
                    BaseArrayLayer = 0,
                    LayerCount = 1,
                },

            };

            _vulkanApi!.CmdBlitImage(commandBuffer,
                image, ImageLayout.TransferSrcOptimal,
                image, ImageLayout.TransferDstOptimal,
                1, blit,
                Filter.Linear);

            barrier.OldLayout = ImageLayout.TransferSrcOptimal;
            barrier.NewLayout = ImageLayout.ShaderReadOnlyOptimal;
            barrier.SrcAccessMask = AccessFlags.AccessTransferReadBit;
            barrier.DstAccessMask = AccessFlags.AccessShaderReadBit;

            _vulkanApi!.CmdPipelineBarrier(commandBuffer, PipelineStageFlags.PipelineStageTransferBit, PipelineStageFlags.PipelineStageFragmentShaderBit, 0,
                0, null,
                0, null,
                1, barrier);

            if (mipWidth > 1) mipWidth /= 2;
            if (mipHeight > 1) mipHeight /= 2;
        }

        barrier.SubresourceRange.BaseMipLevel = mipLevels - 1;
        barrier.OldLayout = ImageLayout.TransferDstOptimal;
        barrier.NewLayout = ImageLayout.ShaderReadOnlyOptimal;
        barrier.SrcAccessMask = AccessFlags.AccessTransferWriteBit;
        barrier.DstAccessMask = AccessFlags.AccessShaderReadBit;

        _vulkanApi!.CmdPipelineBarrier(commandBuffer, PipelineStageFlags.PipelineStageTransferBit, PipelineStageFlags.PipelineStageFragmentShaderBit, 0,
            0, null,
            0, null,
            1, barrier);

        EndSingleTimeCommands(commandBuffer);
    }

    void CreateTextureImage(string imagePath)
    {
        using var img = SixLabors.ImageSharp.Image.Load<SixLabors.ImageSharp.PixelFormats.Rgba32>(imagePath);

        ulong imageSize = (ulong)(img.Width * img.Height * img.PixelType.BitsPerPixel / 8);
        mipLevels = (uint)(System.Math.Floor(System.Math.Log2(System.Math.Max(img.Width, img.Height))) + 1);

        Buffer stagingBuffer = default;
        DeviceMemory stagingBufferMemory = default;
        CreateBuffer(imageSize, BufferUsageFlags.BufferUsageTransferSrcBit, MemoryPropertyFlags.MemoryPropertyHostVisibleBit | MemoryPropertyFlags.MemoryPropertyHostCoherentBit, ref stagingBuffer, ref stagingBufferMemory);

        void* data;
        _vulkanApi!.MapMemory(_vulkanDevice.Device, stagingBufferMemory, 0, imageSize, 0, &data);
        img.CopyPixelDataTo(new Span<byte>(data, (int)imageSize));
        _vulkanApi!.UnmapMemory(_vulkanDevice.Device, stagingBufferMemory);

        CreateImage((uint)img.Width, (uint)img.Height, mipLevels, SampleCountFlags.SampleCount1Bit, Format.R8G8B8A8Srgb, ImageTiling.Optimal, ImageUsageFlags.ImageUsageTransferSrcBit | ImageUsageFlags.ImageUsageTransferDstBit | ImageUsageFlags.ImageUsageSampledBit, MemoryPropertyFlags.MemoryPropertyDeviceLocalBit, ref textureImage, ref textureImageMemory);

        TransitionImageLayout(textureImage, Format.R8G8B8A8Srgb, ImageLayout.Undefined, ImageLayout.TransferDstOptimal, mipLevels);
        CopyBufferToImage(stagingBuffer, textureImage, (uint)img.Width, (uint)img.Height);
        //Transitioned to VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL while generating mipmaps

        _vulkanApi!.DestroyBuffer(_vulkanDevice.Device, stagingBuffer, null);
        _vulkanApi!.FreeMemory(_vulkanDevice.Device, stagingBufferMemory, null);

        GenerateMipMaps(textureImage, Format.R8G8B8A8Srgb, (uint)img.Width, (uint)img.Height, mipLevels);
    }

    private void CreateTextureImageView()
    {
       // textureImageView = CreateImageView(textureImage, Format.R8G8B8A8Srgb, ImageAspectFlags.ImageAspectColorBit, mipLevels);
    }

    private void CreateTextureSampler()
    {
        PhysicalDeviceProperties properties;
        _vulkanApi!.GetPhysicalDeviceProperties(_vulkanDevice.PhysicalDevice, out properties);

        SamplerCreateInfo samplerInfo = new()
        {
            SType = StructureType.SamplerCreateInfo,
            MagFilter = Filter.Linear,
            MinFilter = Filter.Linear,
            AddressModeU = SamplerAddressMode.Repeat,
            AddressModeV = SamplerAddressMode.Repeat,
            AddressModeW = SamplerAddressMode.Repeat,
            AnisotropyEnable = true,
            MaxAnisotropy = properties.Limits.MaxSamplerAnisotropy,
            BorderColor = BorderColor.IntOpaqueBlack,
            UnnormalizedCoordinates = false,
            CompareEnable = false,
            CompareOp = CompareOp.Always,
            MipmapMode = SamplerMipmapMode.Linear,
            MinLod = 0,
            MaxLod = mipLevels,
            MipLodBias = 0,
        };

        fixed (Sampler* textureSamplerPtr = &textureSampler)
        {
            if (_vulkanApi!.CreateSampler(_vulkanDevice.Device, samplerInfo, null, textureSamplerPtr) != Result.Success)
            {
                throw new Exception("failed to create texture sampler!");
            }
        }
    }

    private void LoadModel(string modelPath)
    {
        using var assimp = Assimp.GetApi();
        var scene = assimp.ImportFile(modelPath, (uint)PostProcessPreset
            .TargetRealTimeMaximumQuality);

        var vertexMap = new Dictionary<Vertex, uint>();
        var vertices = new List<Vertex>();
        var indices = new List<uint>();

        VisitSceneNode(scene->MRootNode);

        assimp.ReleaseImport(scene);

        this.vertices = vertices.ToArray();
        this.indices = indices.ToArray();

        void VisitSceneNode(Node* node)
        {
            for (int m = 0; m < node->MNumMeshes; m++)
            {
                var mesh = scene->MMeshes[node->MMeshes[m]];

                for (int f = 0; f < mesh->MNumFaces; f++)
                {
                    var face = mesh->MFaces[f];

                    for (int i = 0; i < face.MNumIndices; i++)
                    {
                        uint index = face.MIndices[i];

                        var position = mesh->MVertices[index];
                        var texture = mesh->MTextureCoords[0][(int)index];

                        Vertex vertex = new Vertex
                        {
                            Position = new Vector3D<float>(position.X, position.Y, position.Z),
                            Color = new Vector3D<float>(1, 1, 1),
                            //Flip Y for OBJ in Vulkan
                            TextureCoordinates = new Vector2D<float>(texture.X, 1.0f - texture.Y)
                        };

                        if (vertexMap.TryGetValue(vertex, out var meshIndex))
                        {
                            indices.Add(meshIndex);
                        }
                        else
                        {
                            indices.Add((uint)vertices.Count);
                            vertexMap[vertex] = (uint)vertices.Count;
                            vertices.Add(vertex);
                        }
                    }
                }
            }

            for (int c = 0; c < node->MNumChildren; c++)
            {
                VisitSceneNode(node->MChildren[c]);
            }
        }
    }

    private void CopyBuffer(Buffer srcBuffer, Buffer dstBuffer, ulong size)
    {
        CommandBuffer commandBuffer = BeginSingleTimeCommands();

        BufferCopy copyRegion = new()
        {
            Size = size,
        };

        _vulkanApi!.CmdCopyBuffer(commandBuffer, srcBuffer, dstBuffer, 1, copyRegion);

        EndSingleTimeCommands(commandBuffer);
    }

    private void CreateVertexBuffer()
    {
        ulong bufferSize = (ulong)(Unsafe.SizeOf<Vertex>() * vertices!.Length);

        Buffer stagingBuffer = default;
        DeviceMemory stagingBufferMemory = default;
        CreateBuffer(bufferSize, BufferUsageFlags.BufferUsageTransferSrcBit, MemoryPropertyFlags.MemoryPropertyHostVisibleBit | MemoryPropertyFlags.MemoryPropertyHostCoherentBit, ref stagingBuffer, ref stagingBufferMemory);

        void* data;
        _vulkanApi!.MapMemory(_vulkanDevice.Device, stagingBufferMemory, 0, bufferSize, 0, &data);
        vertices.AsSpan().CopyTo(new Span<Vertex>(data, vertices.Length));
        _vulkanApi!.UnmapMemory(_vulkanDevice.Device, stagingBufferMemory);

        CreateBuffer(bufferSize, BufferUsageFlags.BufferUsageTransferDstBit | BufferUsageFlags.BufferUsageVertexBufferBit, MemoryPropertyFlags.MemoryPropertyDeviceLocalBit, ref vertexBuffer, ref vertexBufferMemory);

        CopyBuffer(stagingBuffer, vertexBuffer, bufferSize);

        _vulkanApi!.DestroyBuffer(_vulkanDevice.Device, stagingBuffer, null);
        _vulkanApi!.FreeMemory(_vulkanDevice.Device, stagingBufferMemory, null);
    }
    private void CreateIndexBuffer()
    {
        ulong bufferSize = (ulong)(Unsafe.SizeOf<uint>() * indices!.Length);

        Buffer stagingBuffer = default;
        DeviceMemory stagingBufferMemory = default;
        CreateBuffer(bufferSize, BufferUsageFlags.BufferUsageTransferSrcBit, MemoryPropertyFlags.MemoryPropertyHostVisibleBit | MemoryPropertyFlags.MemoryPropertyHostCoherentBit, ref stagingBuffer, ref stagingBufferMemory);

        void* data;
        _vulkanApi!.MapMemory(_vulkanDevice.Device, stagingBufferMemory, 0, bufferSize, 0, &data);
        indices.AsSpan().CopyTo(new Span<uint>(data, indices.Length));
        _vulkanApi!.UnmapMemory(_vulkanDevice.Device, stagingBufferMemory);

        CreateBuffer(bufferSize, BufferUsageFlags.BufferUsageTransferDstBit | BufferUsageFlags.BufferUsageIndexBufferBit, MemoryPropertyFlags.MemoryPropertyDeviceLocalBit, ref indexBuffer, ref indexBufferMemory);

        CopyBuffer(stagingBuffer, indexBuffer, bufferSize);

        _vulkanApi!.DestroyBuffer(_vulkanDevice.Device, stagingBuffer, null);
        _vulkanApi!.FreeMemory(_vulkanDevice.Device, stagingBufferMemory, null);
    }

    private void CreateUniformBuffers()
    {
        ulong bufferSize = (ulong)Unsafe.SizeOf<UniformBufferObject>();

        uniformBuffers = new Buffer[_vulkanSwapChain!.ImageCount];
        uniformBuffersMemory = new DeviceMemory[_vulkanSwapChain!.ImageCount];

        for (int i = 0; i < _vulkanSwapChain!.ImageCount; i++)
        {
            CreateBuffer(bufferSize, BufferUsageFlags.BufferUsageUniformBufferBit, MemoryPropertyFlags.MemoryPropertyHostVisibleBit | MemoryPropertyFlags.MemoryPropertyHostCoherentBit, ref uniformBuffers[i], ref uniformBuffersMemory[i]);
        }

    }

    private void CreateDescriptorPool()
    {
        var poolSizes = new DescriptorPoolSize[]
        {
            new DescriptorPoolSize()
            {
                Type = DescriptorType.UniformBuffer,
                DescriptorCount = (uint)_vulkanSwapChain!.ImageCount,
            },
            new DescriptorPoolSize()
            {
                Type = DescriptorType.CombinedImageSampler,
                DescriptorCount = (uint)_vulkanSwapChain!.ImageCount *2,
            }
        };

        fixed (DescriptorPoolSize* poolSizesPtr = poolSizes)
        fixed (DescriptorPool* descriptorPoolPtr = &descriptorPool)
        {

            DescriptorPoolCreateInfo poolInfo = new()
            {
                SType = StructureType.DescriptorPoolCreateInfo,
                PoolSizeCount = (uint)poolSizes.Length,
                PPoolSizes = poolSizesPtr,
                MaxSets = (uint)_vulkanSwapChain!.ImageCount * 2,
                Flags = DescriptorPoolCreateFlags.FreeDescriptorSetBit
            };

            if (_vulkanApi!.CreateDescriptorPool(_vulkanDevice.Device, poolInfo, null, descriptorPoolPtr) != Result.Success)
            {
                throw new Exception("failed to create descriptor pool!");
            }

        }
    }

    private void CreateDescriptorSets()
    {
        var layouts = new DescriptorSetLayout[_vulkanSwapChain!.ImageCount];
        Array.Fill(layouts, descriptorSetLayout);

        fixed (DescriptorSetLayout* layoutsPtr = layouts)
        {
            DescriptorSetAllocateInfo allocateInfo = new()
            {
                SType = StructureType.DescriptorSetAllocateInfo,
                DescriptorPool = descriptorPool,
                DescriptorSetCount = (uint)_vulkanSwapChain!.ImageCount,
                PSetLayouts = layoutsPtr,
            };

            descriptorSets = new DescriptorSet[_vulkanSwapChain!.ImageCount];
            fixed (DescriptorSet* descriptorSetsPtr = descriptorSets)
            {
                if (_vulkanApi!.AllocateDescriptorSets(_vulkanDevice.Device, allocateInfo, descriptorSetsPtr) != Result.Success)
                {
                    throw new Exception("failed to allocate descriptor sets!");
                }
            }
        }


        for (int i = 0; i < _vulkanSwapChain!.ImageCount; i++)
        {
            DescriptorBufferInfo bufferInfo = new()
            {
                Buffer = uniformBuffers![i],
                Offset = 0,
                Range = (ulong)Unsafe.SizeOf<UniformBufferObject>(),

            };

            DescriptorImageInfo imageInfo = new()
            {
                ImageLayout = ImageLayout.ShaderReadOnlyOptimal,
                ImageView = textureImageView,
                Sampler = textureSampler,
            };

            var descriptorWrites = new WriteDescriptorSet[]
            {
                new()
                {
                    SType = StructureType.WriteDescriptorSet,
                    DstSet = descriptorSets[i],
                    DstBinding = 0,
                    DstArrayElement = 0,
                    DescriptorType = DescriptorType.UniformBuffer,
                    DescriptorCount = 1,
                    PBufferInfo = &bufferInfo,
                },
                new()
                {
                    SType = StructureType.WriteDescriptorSet,
                    DstSet = descriptorSets[i],
                    DstBinding = 1,
                    DstArrayElement = 0,
                    DescriptorType = DescriptorType.CombinedImageSampler,
                    DescriptorCount = 1,
                    PImageInfo = &imageInfo,
                }
            };

            fixed (WriteDescriptorSet* descriptorWritesPtr = descriptorWrites)
            {
                _vulkanApi!.UpdateDescriptorSets(_vulkanDevice.Device, (uint)descriptorWrites.Length, descriptorWritesPtr, 0, null);
            }
        }

    }

    private void CreateCommandBuffers()
    {
        commandBuffers = new CommandBuffer[_vulkanSwapChain!.ImageCount];

        CommandBufferAllocateInfo allocInfo = new()
        {
            SType = StructureType.CommandBufferAllocateInfo,
            CommandPool = commandPool,
            Level = CommandBufferLevel.Primary,
            CommandBufferCount = (uint)commandBuffers.Length,
        };

        fixed (CommandBuffer* commandBuffersPtr = commandBuffers)
        {
            if (_vulkanApi!.AllocateCommandBuffers(_vulkanDevice.Device, allocInfo, commandBuffersPtr) != Result.Success)
            {
                throw new Exception("failed to allocate command buffers!");
            }
        }
    }

    private void CreateSyncObjects()
    {
        imageAvailableSemaphores = new Semaphore[MAX_FRAMES_IN_FLIGHT];
        renderFinishedSemaphores = new Semaphore[MAX_FRAMES_IN_FLIGHT];
        inFlightFences = new Fence[MAX_FRAMES_IN_FLIGHT];
        imagesInFlight = new Fence[_vulkanSwapChain!.ImageCount];

        SemaphoreCreateInfo semaphoreInfo = new()
        {
            SType = StructureType.SemaphoreCreateInfo,
        };

        FenceCreateInfo fenceInfo = new()
        {
            SType = StructureType.FenceCreateInfo,
            Flags = FenceCreateFlags.FenceCreateSignaledBit,
        };

        for (var i = 0; i < MAX_FRAMES_IN_FLIGHT; i++)
        {
            if (_vulkanApi!.CreateSemaphore(_vulkanDevice.Device, semaphoreInfo, null, out imageAvailableSemaphores[i]) != Result.Success ||
                _vulkanApi!.CreateSemaphore(_vulkanDevice.Device, semaphoreInfo, null, out renderFinishedSemaphores[i]) != Result.Success ||
                _vulkanApi!.CreateFence(_vulkanDevice.Device, fenceInfo, null, out inFlightFences[i]) != Result.Success)
            {
                throw new Exception("failed to create synchronization objects for a frame!");
            }
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }


    //Private Variables ------------------------------------------------


    private Framebuffer[]? swapChainFramebuffers;

    private RenderPass renderPass;
    private DescriptorSetLayout descriptorSetLayout;
    private PipelineLayout pipelineLayout;
    private Pipeline graphicsPipeline;

    private CommandPool commandPool;

    private Image colorImage;
    private DeviceMemory colorImageMemory;
    private ImageView colorImageView;

    private Image depthImage;
    private DeviceMemory depthImageMemory;
    private ImageView depthImageView;

    private uint mipLevels;
    private Image textureImage;
    private DeviceMemory textureImageMemory;
    private ImageView textureImageView;
    private Sampler textureSampler;

    private Buffer vertexBuffer;
    private DeviceMemory vertexBufferMemory;
    private Buffer indexBuffer;
    private DeviceMemory indexBufferMemory;

    private Buffer[]? uniformBuffers;
    private DeviceMemory[]? uniformBuffersMemory;

    private DescriptorPool descriptorPool;
    private DescriptorSet[]? descriptorSets;

    private CommandBuffer[]? commandBuffers;

    private Semaphore[]? imageAvailableSemaphores;
    private Semaphore[]? renderFinishedSemaphores;
    private Fence[]? inFlightFences;
    private Fence[]? imagesInFlight;
    private int currentFrame = 0;

    private bool frameBufferResized = false;

    private Vertex[]? vertices;

    private uint[]? indices;
    private ImGuiController _imGui;
}