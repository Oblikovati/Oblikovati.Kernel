using Oblikovati.Domain.Contracts;
using Oblikovati.Domain.Contracts.Enums;

namespace Oblikovati.Domain.Core.Application;

public class ErrorManager : IErrorManager
{
    public ErrorManager()
    {
        
        
    }
    
    
    public string AllMessages { get; set; }
    public bool HasErrors { get; set; }
    public bool HasWarnings { get; set; }
    public bool IsMessageSectionActive { get; set; }
    public string LastMessage { get; set; }
    public void AddMessage(string Message, bool Error, object Reserved)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public ButtonTypeEnum Show(string Title, bool AllowAccept, bool AllowEdit)
    {
        throw new NotImplementedException();
    }

    public IMessageSection StartMessageSection()
    {
        throw new NotImplementedException();
    }
}