using System.Collections.Generic;

namespace Solid2D.Editor.Controls.ControlPanels
{
    public class ControlPanelsManager
    {

        public ControlPanelsManager(SidePanel leftSidePanel, SidePanel rightSidePanel)
        {
            LeftSidePanel = leftSidePanel;
            RightSidePanel = rightSidePanel;
        }

        public List<IDockableControl> ControlPanels { get; set; }

        public SidePanel LeftSidePanel { get; set; }

        public SidePanel RightSidePanel { get; set; }
    }
}
