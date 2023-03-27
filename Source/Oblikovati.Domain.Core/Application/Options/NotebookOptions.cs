using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Application.Options;

public class NotebookOptions : INotebookOptions
{
    public NotebookOptions()
    {

    }

    public bool DisplayNoteIcons { get; set; }
    public bool DisplayNoteText { get; set; }
    public bool KeepNotesOnDeletedObjects { get; set; }
    public IColor TextBackgroundColor { get; set; }
    public IColor ArrowColor { get; set; }
    public IColor NoteHighlightColor { get; set; }
}