using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Renderer.Vulkan;
using Silk.NET.Windowing;
using System.Numerics;

namespace Oblikovati.Domain.Renderer;

public class Renderer : IRenderer
{
    private readonly IWindow _window;
    private readonly VulkanRenderer _vulkanRenderer;
    public Renderer(IWindow window)
    {
        _window = window;
        _vulkanRenderer = new VulkanRenderer(window);
    }

    public void AcknowledgeParsedGlobalMacros(IEnumerable<string> macros, IShader shader)
    {
        throw new NotImplementedException();
    }

    public void BeginFrame()
    {
        throw new NotImplementedException();
    }

    public void BeginRenderPass(IRenderCommandBuffer renderCommandBuffer, IRenderPass renderPass, bool explicitClear = false)
    {
        throw new NotImplementedException();
    }

    public void ClearImage(IRenderCommandBuffer renderCommandBuffer, IImage2D image)
    {
        throw new NotImplementedException();
    }

    public Tuple<ITextureCube, ITextureCube> CreateEnvironmentMap(string filepath)
    {
        throw new NotImplementedException();
    }

    public ITextureCube CreatePreethamSky(float turbidity, float azimuth, float inclination)
    {
        throw new NotImplementedException();
    }

    public void DispatchComputeShader(IRenderCommandBuffer renderCommandBuffer, IPipelineCompute computePipeline, IUniformBufferSet uniformBufferSet, IStorageBufferSet storageBufferSet, IMaterial material, Vector3 workGroups, object additionalUniforms = null)
    {
        throw new NotImplementedException();
    }

    public void EndFrame()
    {
        throw new NotImplementedException();
    }

    public void EndRenderPass(IRenderCommandBuffer renderCommandBuffer)
    {
        throw new NotImplementedException();
    }

    public ITextureCube GetBlackCubeTexture()
    {
        throw new NotImplementedException();
    }

    public ITexture2D GetBlackTexture()
    {
        throw new NotImplementedException();
    }

    public ITexture2D GetBRDFLutTexture()
    {
        throw new NotImplementedException();
    }

    public RendererConfig GetConfig()
    {
        throw new NotImplementedException();
    }

    public uint GetCurrentFrameIndex()
    {
        throw new NotImplementedException();
    }

    public IRenderEnvironment GetEmptyEnvironment()
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, string> GetGlobalShaderMacros()
    {
        throw new NotImplementedException();
    }

    public ITexture2D GetHilbertLut()
    {
        throw new NotImplementedException();
    }

    public IRenderCommandQueue GetRenderResourceReleaseQueue(uint index)
    {
        throw new NotImplementedException();
    }

    public IShaderLibrary GetShaderLibrary()
    {
        throw new NotImplementedException();
    }

    public ITexture2D GetWhiteTexture()
    {
        throw new NotImplementedException();
    }

    public void Init()
    {
        _vulkanRenderer.Initialize();
    }

    public void LightCulling(IRenderCommandBuffer renderCommandBuffer, IPipelineCompute computePipeline, IUniformBufferSet uniformBufferSet, IStorageBufferSet storageBufferSet, IMaterial material, Vector3 workGroups)
    {
        throw new NotImplementedException();
    }

    public void OnShaderReloaded(long hash)
    {
        throw new NotImplementedException();
    }

    public void RegisterShaderDependency(IShader shader, IPipelineCompute computePipeline)
    {
        throw new NotImplementedException();
    }

    public void RegisterShaderDependency(IShader shader, IPipeline pipeline)
    {
        throw new NotImplementedException();
    }

    public void RegisterShaderDependency(IShader shader, IMaterial material)
    {
        throw new NotImplementedException();
    }

    public void RenderGeometry(IRenderCommandBuffer renderCommandBuffer, IPipeline pipeline, IUniformBufferSet uniformBufferSet, IStorageBufferSet storageBufferSet, IMaterial material, IVertexBuffer vertexBuffer, IIndexBuffer indexBuffer, Matrix4x4 transform, uint indexCount = 0)
    {
        throw new NotImplementedException();
    }

    public void RenderMeshWithMaterial(IRenderCommandBuffer renderCommandBuffer, IPipeline pipeline, IUniformBufferSet uniformBufferSet, IStorageBufferSet storageBufferSet, IMesh mesh, uint submeshIndex, IVertexBuffer transformBuffer, uint transformOffset, uint instanceCount, IMaterial material, object additionalUniforms = null)
    {
        throw new NotImplementedException();
    }

    public void RenderQuad(IRenderCommandBuffer renderCommandBuffer, IPipeline pipeline, IUniformBufferSet uniformBufferSet, IStorageBufferSet storageBufferSet, IMaterial material, Matrix4x4 transform)
    {
        throw new NotImplementedException();
    }

    public void RenderStaticMesh(IRenderCommandBuffer renderCommandBuffer, IPipeline pipeline, IUniformBufferSet uniformBufferSet, IStorageBufferSet storageBufferSet, IStaticMesh mesh, uint submeshIndex, IMaterialTable materialTable, IVertexBuffer transformBuffer, uint transformOffset, uint instanceCount)
    {
        throw new NotImplementedException();
    }

    public void RenderStaticMeshWithMaterial(IRenderCommandBuffer renderCommandBuffer, IPipeline pipeline, IUniformBufferSet uniformBufferSet, IStorageBufferSet storageBufferSet, IStaticMesh mesh, uint submeshIndex, IVertexBuffer transformBuffer, uint transformOffset, uint instanceCount, IMaterial material, object additionalUniforms = null)
    {
        throw new NotImplementedException();
    }

    public void RenderSubmesh(IRenderCommandBuffer renderCommandBuffer, IPipeline pipeline, IUniformBufferSet uniformBufferSet, IStorageBufferSet storageBufferSet, IMesh mesh, uint submeshIndex, IMaterialTable materialTable, Matrix4x4 transform)
    {
        throw new NotImplementedException();
    }

    public void RenderSubmeshInstanced(IRenderCommandBuffer renderCommandBuffer, IPipeline pipeline, IUniformBufferSet uniformBufferSet, IStorageBufferSet storageBufferSet, IMesh mesh, uint submeshIndex, IMaterialTable materialTable, IVertexBuffer transformBuffer, uint transformOffset, uint instanceCount)
    {
        throw new NotImplementedException();
    }

    public void RT_BeginGPUPerfMarker(IRenderCommandBuffer renderCommandBuffer, string label, Vector4 markerColor = default)
    {
        throw new NotImplementedException();
    }

    public void RT_EndGPUPerfMarker(IRenderCommandBuffer renderCommandBuffer)
    {
        throw new NotImplementedException();
    }

    public void RT_InsertGPUPerfMarker(IRenderCommandBuffer renderCommandBuffer, string label, Vector4 markerColor = default)
    {
        throw new NotImplementedException();
    }

    public void SetConfig(RendererConfig config)
    {
        throw new NotImplementedException();
    }

    public void SetGlobalMacroInShaders(string name, string value = "")
    {
        throw new NotImplementedException();
    }

    public void SetMacroInShader(IShader shader, string name, string value = "")
    {
        throw new NotImplementedException();
    }

    public void SetSceneEnvironment(ISceneRenderer sceneRenderer, IRenderEnvironment environment, IImage2D shadow)
    {
        throw new NotImplementedException();
    }

    public void Shutdown()
    {
        _vulkanRenderer.Shutdown();
    }

    public void Submit()
    {
        throw new NotImplementedException();
    }

    public void SubmitFullscreenQuad(IRenderCommandBuffer renderCommandBuffer, IPipeline pipeline, IUniformBufferSet uniformBufferSet, IMaterial material)
    {
        throw new NotImplementedException();
    }

    public void SubmitFullscreenQuad(IRenderCommandBuffer renderCommandBuffer, IPipeline pipeline, IUniformBufferSet uniformBufferSet, IStorageBufferSet storageBufferSet, IMaterial material)
    {
        throw new NotImplementedException();
    }

    public void SubmitFullscreenQuadWithOverrides(IRenderCommandBuffer renderCommandBuffer, IPipeline pipeline, IUniformBufferSet uniformBufferSet, IMaterial material, object vertexShaderOverrides, object fragmentShaderOverrides)
    {
        throw new NotImplementedException();
    }

    public void SubmitQuad(IRenderCommandBuffer renderCommandBuffer, IMaterial material, Matrix4x4 transform = default)
    {
        throw new NotImplementedException();
    }

    public void SubmitResourceFree()
    {
        throw new NotImplementedException();
    }

    public bool UpdateDirtyShaders()
    {
        throw new NotImplementedException();
    }

    public void WaitAndRender()
    {
        throw new NotImplementedException();
    }
}
