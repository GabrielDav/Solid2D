using System.Windows;

namespace Solid2D.Editor.Controls.ControlPanels
{
    public interface IDockableControl
    {
        DockablePanel ContainerPanel { get; set; }

        Visibility Visibility { get; set; }
    }
}
