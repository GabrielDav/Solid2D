using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Solid2D.Editor.Controls.ControlPanels
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Solid2D.Editor.Controls.ControlPanels"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Solid2D.Editor.Controls.ControlPanels;assembly=Solid2D.Editor.Controls.ControlPanels"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:DockablePanel/>
    ///
    /// </summary>
    public enum PanelDockStatus { Top, Fill, Bottom }

    public enum PanelDockSide { Left, Right }
    public class DockablePanel : ContentControl
    {
        private ContextMenu _dockMenu;

        #region DependencyProperties

        static DockablePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockablePanel), new FrameworkPropertyMetadata(typeof(DockablePanel)));
        }

        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
            "Caption",
            typeof(string),
            typeof(DockablePanel));

        public string Caption
        {
            get
            {
                return (string)GetValue(CaptionProperty);
            }
            set
            {
                SetValue(CaptionProperty, value);
            }
        }

        public static readonly DependencyProperty DockStatusProperty = DependencyProperty.Register(
            "DockStatus",
            typeof(PanelDockStatus),
            typeof(DockablePanel));

        public PanelDockStatus DockStatus
        {
            get
            {
                return (PanelDockStatus)GetValue(DockStatusProperty);
            }
            set
            {
                if ((PanelDockStatus)GetValue(DockStatusProperty) == value)
                    return;
                SetValue(DockStatusProperty, value);
                if (DockStatusChanged != null)
                    DockStatusChanged(this, new EventArgs());
            }
        }

        public static readonly DependencyProperty DockSideProperty = DependencyProperty.Register(
            "DockSide",
            typeof(PanelDockSide),
            typeof(DockablePanel));

        public PanelDockSide DockSide
        {
            get
            {
                return (PanelDockSide)GetValue(DockSideProperty);
            }
            set
            {
                if ((PanelDockSide)GetValue(DockSideProperty) == value)
                    return;
                
                SetValue(DockSideProperty, value);
                if (DockSideChanged != null)
                    DockSideChanged(this, new EventArgs());
            }
        }

        #endregion

        public event EventHandler DockSideChanged;

        public event EventHandler DockStatusChanged;

        public DockablePanel()
        {
            
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _dockMenu = GetTemplateChild("DockContextMenu").ToContextMenu();
            _dockMenu.Opened += DockMenuOnOpened;
        }

        private void DockMenuOnOpened(object sender, RoutedEventArgs routedEventArgs)
        {

        }


        private void PinClick(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
