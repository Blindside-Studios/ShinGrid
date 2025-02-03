using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ShinGrid;
using ShinGrid_TestPanel.ExampleWidgets;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ShinGrid_TestPanel
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            ShinGridViewModel.Instance.ColumnWidth = 300;
            ShinGridViewModel.Instance.RowHeight = 300;
            ShinGridViewModel.Instance.CornerRadius = 8;
            ShinGridViewModel.Instance.PanelInstances = new List<PanelInstance>()
            {
                new PanelInstance { PageType = typeof(BluePage), Index = 0 },
                new PanelInstance { PageType = typeof(RedPage), ColumnSpan = 2, Index = 1 },
                new PanelInstance { PageType = typeof(GreenPage), Index = 2 },
                new PanelInstance { PageType = typeof(PurplePage), Index = 3 },
                new PanelInstance { PageType = typeof(BrownPage), ColumnSpan = 2, Index = 4 },
                new PanelInstance { PageType = typeof(YellowPage), Index = 5 },
            };
            ShinGridFrame.NavigateToType(typeof(ShinGrid.ShinGrid), null, null);
        }
    }
}
