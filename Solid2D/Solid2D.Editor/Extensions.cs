using System;
using System.Windows;
using System.Windows.Controls;

namespace Solid2D.Editor
{
    public static class Extensions
    {
        public static Button ToButton(this DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
                throw new ArgumentNullException();
            if (!(dependencyObject is Button))
                throw new InvalidCastException("Dependency object is not Button");
            return (dependencyObject as Button);
        }

        public static ContextMenu ToContextMenu(this DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
                throw new ArgumentNullException();
            if (!(dependencyObject is ContextMenu))
                throw new InvalidCastException("Dependency object is not ContextMenu");
            return (dependencyObject as ContextMenu);
        }
    }
}
