using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Application.Options;

public class Sketch3DOptions : ISketch3DOptions
{
    public Sketch3DOptions()
    {

    }

    public bool AutoBendWithLineCreation { get; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}