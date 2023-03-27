namespace Oblikovati.Addin.Tutorials;

public class CIPState
{
    protected Dictionary<string, string> _attributes;
    protected string _subType;

    public CIPState(string subtype, Dictionary<string, string> attributes)
    {
        this._subType = subtype;
        this._attributes = attributes;
    }

    public Dictionary<string, string> Attributes => this._attributes;

    public string SubType
    {
        get => this._subType;
        set => this._subType = value;
    }

    public string GetStateCIPString()
    {
        string stateCipString = "subtype='" + this._subType.ToString() + "'";
        if (this._attributes != null)
        {
            foreach (string key in this._attributes.Keys)
                stateCipString = stateCipString + " " + key + "='" + this._attributes[key] + "'";
        }
        return stateCipString;
    }
}