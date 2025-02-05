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
            ShinGridViewModel.Instance.ColumnWidth = 150;
            ShinGridViewModel.Instance.RowHeight = 150;
            ShinGridViewModel.Instance.CornerRadius = 8;
            ShinGridViewModel.Instance.PanelInstances = new List<PanelInstance>()
            {
                new PanelInstance { PageType = typeof(PurplePage), Index = 0 },
                new PanelInstance { PageType = typeof(GreenPage), Index = 1, ColumnSpan = 2 },
                new PanelInstance { PageType = typeof(BluePage), Index = 2 },
                new PanelInstance { PageType = typeof(YellowPage), Index = 3 },
                new PanelInstance { PageType = typeof(RedPage), Index = 4, ColumnSpan = 2 },
                new PanelInstance { PageType = typeof(BrownPage), Index = 5 },

                new PanelInstance { PageType = typeof(YellowPage), Index = 6, ColumnSpan = 2 },
                new PanelInstance { PageType = typeof(PurplePage), Index = 7 },
                new PanelInstance { PageType = typeof(RedPage), Index = 8, ColumnSpan = 3 },
                new PanelInstance { PageType = typeof(BluePage), Index = 9 },
                new PanelInstance { PageType = typeof(GreenPage), Index = 10 },
                new PanelInstance { PageType = typeof(BrownPage), Index = 11, ColumnSpan = 2 },

                new PanelInstance { PageType = typeof(BluePage), Index = 12 },
                new PanelInstance { PageType = typeof(RedPage), Index = 13, ColumnSpan = 2 },
                new PanelInstance { PageType = typeof(YellowPage), Index = 14 },
                new PanelInstance { PageType = typeof(GreenPage), Index = 15, ColumnSpan = 3 },
                new PanelInstance { PageType = typeof(PurplePage), Index = 16 },
                new PanelInstance { PageType = typeof(BrownPage), Index = 17 },

                new PanelInstance { PageType = typeof(GreenPage), Index = 18, ColumnSpan = 2 },
                new PanelInstance { PageType = typeof(YellowPage), Index = 19 },
                new PanelInstance { PageType = typeof(RedPage), Index = 20, ColumnSpan = 3 },
                new PanelInstance { PageType = typeof(BrownPage), Index = 21 },
                new PanelInstance { PageType = typeof(BluePage), Index = 22, ColumnSpan = 2 },
                new PanelInstance { PageType = typeof(PurplePage), Index = 23 },

                new PanelInstance { PageType = typeof(RedPage), Index = 24 },
                new PanelInstance { PageType = typeof(BrownPage), Index = 25, ColumnSpan = 2 },
                new PanelInstance { PageType = typeof(YellowPage), Index = 26 },
                new PanelInstance { PageType = typeof(BluePage), Index = 27 },
                new PanelInstance { PageType = typeof(GreenPage), Index = 28, ColumnSpan = 2 },
                new PanelInstance { PageType = typeof(PurplePage), Index = 29 },

                new PanelInstance { PageType = typeof(YellowPage), Index = 30, ColumnSpan = 2 },
                new PanelInstance { PageType = typeof(RedPage), Index = 31 },
                new PanelInstance { PageType = typeof(BluePage), Index = 32, ColumnSpan = 3}
            };

            ShinGridFrame.NavigateToType(typeof(ShinGrid.ShinGrid), null, null);
        }
    }
}
