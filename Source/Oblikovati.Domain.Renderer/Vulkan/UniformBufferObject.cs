using Silk.NET.Maths;

namespace Oblikovati.Domain.Renderer.Vulkan;

public struct UniformBufferObject
{
    public Matrix4X4<float> Model;
    public Matrix4X4<float> View;
    public Matrix4X4<float> Projection;
}
