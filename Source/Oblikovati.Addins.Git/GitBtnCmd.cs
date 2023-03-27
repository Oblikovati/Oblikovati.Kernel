using System.Windows.Forms;
using Oblikovati.GeneralTools;

namespace Oblikovati.Addins.Git;

public class GitBtnCmd : Command
{
    public override void StartCommand()
    {
        base.StartCommand();
        MessageBox.Show("Start Command");
    }

    public override void StopCommand()
    {
        base.StopCommand();
        MessageBox.Show("Stop Command");
    }

    public override void ExecuteCommand()
    {
        base.ExecuteCommand();
        MessageBox.Show("Exec Command");
    }
}