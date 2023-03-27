using Oblikovati.Domain.Core;

namespace Oblikovati.Addin.Tutorials;

public class CIPWaypoint
{
    protected string _waypointName = "";
    protected CIPState _state;

    public string Waypoint
    {
        get => this._waypointName;
        set => this._waypointName = value;
    }

    public CIPState State
    {
        get => this._state;
        set => this._state = value;
    }

    public CIPWaypoint()
    {
    }

    public CIPWaypoint(string waypointName, CIPState state)
    {
        this._waypointName = waypointName;
        if (state.Attributes == null || state.Attributes.Count <= 0)
            return;
        this._state = state;
    }

    public void SendCIP(IApplication inventorApp)
    {
        string WaypointData;
        if (this._state == null)
            WaypointData = "<CIPWaypoint type ='" + this._waypointName.ToString() + "' />";
        else
            WaypointData = "<CIPWaypoint type ='" + this._waypointName.ToString() + "' " + this._state.GetStateCIPString() + "/>";
        inventorApp.WriteCIPWaypoint(WaypointData);
    }
}