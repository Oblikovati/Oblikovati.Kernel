using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Application;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Documents.PartDocuments;

public class PartDocument : Document, IPartDocument
{
    public PartDocument(IApplicationBase parent) 
        : base(parent)
    {
        if (parent is IApplication app)
        {
            EnvironmentManager = new PartEnvironmentManager(this);
        }
            
    }

    public bool SketchActive { get; set; }
    public IPartComponentDefinition ComponentDefinition { get; set; }
    public IMaterials Materials { get; set; }
    public IRenderStyle ActiveRenderStyle { get; set; }
    public IModelingSettings ModelingSettings { get; set; }
    public ISketchSettings SketchSettings { get; set; }
    public ISketch3DSettings Sketch3DSettings { get; set; }
    public IDisabledCommandList DisabledCommandList { get; set; }
    public IEnvironmentManager EnvironmentManager { get; set; }
    public ILightingStyle ActiveLightingStyle { get; set; }
    public ILightingStyles LightingStyles { get; set; }
    public bool IsSubstitutePart { get; set; }
    public ReferenceStatusEnum SubstitutePartStatus { get; set; }
    public IObjectVisibility ObjectVisibility { get; set; }
    public IPartComponentDefinitions ComponentDefinitions { get; set; }
    public IDisplaySettings DisplaySettings { get; set; }
    public IAssets Assets { get; set; }
    public IAssetsEnumerator AppearanceAssets { get; set; }
    public IAssetsEnumerator MaterialAssets { get; set; }
    public IAssetsEnumerator PhysicalAssets { get; set; }
    public IAsset ActiveAppearance { get; set; }
    public IAsset ActiveMaterial { get; set; }
    public AppearanceSourceTypeEnum AppearanceSourceType { get; set; }
    public bool IsEmbeddedDocument { get; set; }
    public IDocument EmbeddingDocument { get; set; }
    public IFlatPatternSettings FlatPatternSettings { get; set; }
    public string ActiveAnnotationsStandard { get; set; }
    public ITextStylesEnumerator TextStyles { get; set; }
    public string AssociativeForeignFilename { get; set; }
    public bool UpdateSubstitutePart(bool IgnoreErrors)
    {
        throw new NotImplementedException();
    }

    public void GetSelectedObject(IGenericObject Selection, out ObjectTypeEnum ObjectType, out INameValueMap AdditionalData,
        out IComponentOccurrence ContainingOccurrence, ref object SelectedObject)
    {
        throw new NotImplementedException();
    }

    public void ExecutePromptToChoose3daStyle()
    {
        throw new NotImplementedException();
    }

    public void PutGraphicsLevelsOfDetail(int LevelsOfDetail)
    {
        throw new NotImplementedException();
    }

    public void BatchEdit(string BatchEditParams, out MemberManagerErrorsEnum Error)
    {
        throw new NotImplementedException();
    }
}