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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ShinGrid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShinGrid : Page
    {
        public ShinGrid()
        {
            this.InitializeComponent();
            ShinGridViewModel.Instance.PropertyChanged += Instance_PropertyChanged;
            LoadItems();
        }
        
        private void Instance_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // this fires when the cards in the layout change, meaning the list must be updated.
            CenteredGrid.Children.Clear();
            LoadItems();
        }

        public void LoadItems()
        {
            foreach (PanelInstance _panel in ShinGridViewModel.Instance.PanelInstances)
            {
                Frame frame = new Frame();
                frame.Width = ShinGridViewModel.Instance.ColumnWidth * _panel.ColumnSpan + ShinGridViewModel.Instance.Spacing * (_panel.ColumnSpan - 1);
                frame.Height = ShinGridViewModel.Instance.RowHeight * _panel.RowSpan + ShinGridViewModel.Instance.Spacing * (_panel.RowSpan - 1);
                frame.NavigateToType(_panel.PageType, null, null);
                frame.Tag = _panel;
                frame.CornerRadius = new CornerRadius(ShinGridViewModel.Instance.CornerRadius);
                CenteredGrid.Children.Add(frame);
            }
        }

        public void CalculateArrangement()
        {

        }
    }
}
