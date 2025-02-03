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
            PublicViewModel.Instance.ColumnWidth = 300;
            PublicViewModel.Instance.RowHeight = 300;
            PublicViewModel.Instance.PanelInstances = new List<PanelInstance>()
            {
                new PanelInstance { PageType = typeof(BluePage) },
                new PanelInstance { PageType = typeof(RedPage), ColumnSpan = 2 },
                new PanelInstance { PageType = typeof(GreenPage) },
                new PanelInstance { PageType = typeof(PurplePage) },
                new PanelInstance { PageType = typeof(BrownPage), ColumnSpan = 2 },
                new PanelInstance { PageType = typeof(YellowPage) },
            };
            ShinGridFrame.NavigateToType(typeof(ShinGrid.ShinGrid), null, null);
        }
    }
}
