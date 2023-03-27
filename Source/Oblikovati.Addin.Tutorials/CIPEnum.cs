namespace Oblikovati.Addin.Tutorials;

public sealed class CIPEnum
  {
    private readonly string name;
    public static readonly CIPEnum WAYPOINT_UNSET = new CIPEnum("WGTUNSET");
    public static readonly CIPEnum WAYPOINT_STARTUP = new CIPEnum("WGTStartup");
    public static readonly CIPEnum WAYPOINT_START_TUTORIAL = new CIPEnum("WGTStartTutorial");
    public static readonly CIPEnum WAYPOINT_DOWNLOAD_TUTORIAL = new CIPEnum("WGTDownloadTutorial");
    public static readonly CIPEnum WAYPOINT_TASK_ADDED = new CIPEnum("WGTTaskAdded");
    public static readonly CIPEnum WAYPOINT_TASK_EDITED = new CIPEnum("WGTTaskEdited");
    public static readonly CIPEnum WAYPOINT_TASK_DELETED = new CIPEnum("WGTTaskDeleted");
    public static readonly CIPEnum WAYPOINT_TUTORIAL_CREATED = new CIPEnum("WGTTutorialCreated");
    public static readonly CIPEnum WAYPOINT_TUTORIAL_RESTARTED = new CIPEnum("WGTTutorialRestarted");
    public static readonly CIPEnum WAYPOINT_VIDEO_UPLOADED = new CIPEnum("WGTVideoUploaded");
    public static readonly CIPEnum WAYPOINT_IMAGE_UPLOADED = new CIPEnum("WGTImageUploaded");
    public static readonly CIPEnum WAYPOINT_SENDTO_NEXTTASK = new CIPEnum("WGTSendToNextTask");
    public static readonly CIPEnum STATE_TUTORIAL = new CIPEnum("SGTTutorial");
    public static readonly CIPEnum STATE_TASK = new CIPEnum("SGTTask");

    private CIPEnum(string name) => this.name = name;

    public override string ToString() => this.name;

    public static string GetWaypoint(string wpString)
    {
      if (wpString == "StartTutorial")
        return CIPEnum.WAYPOINT_START_TUTORIAL.ToString();
      if (wpString == "DownloadTutorial")
        return CIPEnum.WAYPOINT_DOWNLOAD_TUTORIAL.ToString();
      if (wpString == "TaskAdded")
        return CIPEnum.WAYPOINT_TASK_ADDED.ToString();
      if (wpString == "TaskEdited")
        return CIPEnum.WAYPOINT_TASK_EDITED.ToString();
      if (wpString == "TaskDeleted")
        return CIPEnum.WAYPOINT_TASK_DELETED.ToString();
      if (wpString == "TutorialCreated")
        return CIPEnum.WAYPOINT_TUTORIAL_CREATED.ToString();
      if (wpString == "TutorialRestarted")
        return CIPEnum.WAYPOINT_TUTORIAL_RESTARTED.ToString();
      if (wpString == "VideoUploaded")
        return CIPEnum.WAYPOINT_VIDEO_UPLOADED.ToString();
      if (wpString == "ImageUploaded")
        return CIPEnum.WAYPOINT_IMAGE_UPLOADED.ToString();
      return wpString == "CreateForward" ? CIPEnum.WAYPOINT_SENDTO_NEXTTASK.ToString() : CIPEnum.WAYPOINT_UNSET.ToString();
    }

    public static string GetSubType(string typeString)
    {
      if (typeString == "tutorial")
        return CIPEnum.STATE_TUTORIAL.ToString();
      return typeString == "task" ? CIPEnum.STATE_TASK.ToString() : (string) null;
    }
  }