using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Solid2D.Editor.Controls.ControlPanels;

namespace Solid2D.Editor.Controls
{
    [TemplatePart(Name = "RootGrid", Type = typeof(Grid))]
    /// <summary>
    /// Interaction logic for SidePanel.xaml
    /// </summary>
    public partial class SidePanel : UserControl
    {
        protected class TabButton
        {
            public TabButton(IDockableControl dockableControl, Button button)
            {
                DockableControl = dockableControl;
                Button = button;
            }

            public IDockableControl DockableControl { get; set; }

            public Button Button { get; set; }
        }

        public static readonly DependencyProperty DockSideProperty = DependencyProperty.Register(
            "DockSide",
            typeof(PanelDockSide),
            typeof(SidePanel), new PropertyMetadata(PanelDockSide.Right));

        protected bool _resolvingTabs;

        protected List<TabButton> _tabButtons;

        protected List<IDockableControl> _tabs;

        public PanelDockSide DockSide
        {
            get
            {
                return (PanelDockSide)GetValue(DockSideProperty);
            }
            set
            {
                if (((PanelDockSide)GetValue(DockSideProperty)) == value)
                    return;
                SetValue(DockSideProperty, value);
                OnDockSideChanged(this, new EventArgs());
            }
        }

        public IDockableControl TopPanel { get; protected set; }

        public IDockableControl BottomPanel { get; protected set; }

        public IDockableControl FilledPanel { get; protected set; }

        public SidePanel()
        {
            _tabs = new List<IDockableControl>();
            _tabButtons = new List<TabButton>();
            InitializeComponent();
        }

        protected virtual void OnDockSideChanged(object sender, EventArgs eventArgs)
        {
            foreach (var tabButton in _tabButtons)
            {
                tabButton.Button.HorizontalAlignment = HorizontalContentAlignment;
            }

            if (DockSide == PanelDockSide.Left)
            {
                MainGrid.ColumnDefinitions[0].Width = new GridLength(30);
                MainGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
                Grid.SetColumn(TabsGrid, 1);
                Grid.SetColumn(ButtonsPanel, 0);
            }
            else
            {
                MainGrid.ColumnDefinitions[1].Width = new GridLength(30);
                MainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                Grid.SetColumn(TabsGrid, 0);
                Grid.SetColumn(ButtonsPanel, 1);
            }
        }

        protected virtual void OnSidePanelLoaded(object sender, RoutedEventArgs e)
        {
            foreach (var tab in ButtonsPanel.Children.OfType<IDockableControl>())
            {
                AddTab(tab);
            }
            if (DockSide != PanelDockSide.Right)
                OnDockSideChanged(this, new EventArgs());
        }

        protected virtual void AddTabButton(Button button, IDockableControl tab)
        {
            ButtonsPanel.Children.Add(button);
            button.HorizontalContentAlignment = DockSide == PanelDockSide.Right
                                                 ? HorizontalAlignment.Right
                                                 : HorizontalAlignment.Left;
            _tabButtons.Add(new TabButton(tab, button));
        }

        public virtual void AddTab(IDockableControl tab)
        {
            _tabs.Add(tab);
            var btn = new Button { Content = tab.ContainerPanel.Caption };
            AddTabButton(btn, tab);
            tab.ContainerPanel.DockStatusChanged += OnContainerPanelOnDockStatusChanged;
            ResolveTabs();
        }

        protected virtual void ResolveTabs()
        {
            if (_tabs.Count < 1)
                return;
            _resolvingTabs = true;

            for (var i = _tabs.Count-1; i >= 0; i--)
            {
                if (_tabs[i].Visibility != Visibility.Visible)
                    continue;
                if (FilledPanel != null)
                    _tabs[i].Visibility = Visibility.Collapsed;
                if (_tabs[i].ContainerPanel.DockStatus == PanelDockStatus.Fill)
                    FilledPanel = _tabs[i];
                else if (_tabs[i].ContainerPanel.DockStatus == PanelDockStatus.Top)
                {
                    if (TopPanel == null)
                        TopPanel = _tabs[i];
                    else if (BottomPanel == null)
                    {
                        _tabs[i].ContainerPanel.DockStatus = PanelDockStatus.Bottom;
                        BottomPanel = _tabs[i];
                    }
                    else
                        _tabs[i].Visibility = Visibility.Collapsed;
                }
                else if (_tabs[i].ContainerPanel.DockStatus == PanelDockStatus.Bottom)
                {
                    if (BottomPanel == null)
                        BottomPanel = _tabs[i];
                    else if (TopPanel == null)
                    {
                        _tabs[i].ContainerPanel.DockStatus = PanelDockStatus.Top;
                        TopPanel = _tabs[i];
                    }
                    else
                    {
                        _tabs[i].ContainerPanel.Visibility = Visibility.Collapsed;
                    }

                }
            }
            _resolvingTabs = false;
        }


        

        protected virtual void OnContainerPanelOnDockStatusChanged(object sender, EventArgs eventArgs)
        {
            if (_resolvingTabs)
                return;
        }
    }
}
