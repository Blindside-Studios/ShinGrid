using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            this.Loaded += ShinGrid_Loaded;
            ShinGridViewModel.Instance.PropertyChanged += Instance_PropertyChanged;
        }

        private void ShinGrid_Loaded(object sender, RoutedEventArgs e)
        {
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
                frame.HorizontalAlignment = HorizontalAlignment.Left;
                frame.VerticalAlignment = VerticalAlignment.Top;
                CenteredGrid.Children.Add(frame);
            }
            CalculateArrangement();
            foreach (Frame frame in CenteredGrid.Children)
            {
                // only do this once the initial placement has been done to avoid an awkward entrance animation!
                frame.TranslationTransition = new Vector3Transition();
            }
        }

        private int _lastColumnCount = 0;
        public void CalculateArrangement()
        {
            double availableSpace = (RootGrid.ActualWidth + ShinGridViewModel.Instance.Spacing) / (ShinGridViewModel.Instance.ColumnWidth + ShinGridViewModel.Instance.Spacing);
            int availableColumns = Convert.ToInt32(Math.Floor(availableSpace));

            float centeredGridWidth = availableColumns * (ShinGridViewModel.Instance.ColumnWidth + ShinGridViewModel.Instance.Spacing) - ShinGridViewModel.Instance.Spacing;
            float centeredGridTranslation = ((float)RootGrid.ActualWidth - centeredGridWidth) / 2;
            CenteredGrid.Translation = new System.Numerics.Vector3(centeredGridTranslation, 0, 0);

            if (availableColumns == _lastColumnCount)
            {
                return; // do not update the layout if it's not necessary
            }

            var sortedFrames = new List<Frame>();
            foreach (Frame frame in CenteredGrid.Children) sortedFrames.Add(frame);
            sortedFrames.Sort((Frame a, Frame b) =>
            {
                var panelA = (PanelInstance)a.Tag;
                var panelB = (PanelInstance)b.Tag;
                return panelA.Index.CompareTo(panelB.Index);
            });

            int _filledColumns = 0;
            int verticalTranslation = 0;
            HashSet<int> _prematurelyPickedCardIndices = new();

            int ColumnWidth = ShinGridViewModel.Instance.ColumnWidth;
            int Spacing = ShinGridViewModel.Instance.Spacing;

            foreach (Frame frame in sortedFrames)
            {
                PanelInstance panel = frame.Tag as PanelInstance;
                if (_prematurelyPickedCardIndices.Contains(panel.Index))
                    continue;

                float newXTranslation = _filledColumns * (ColumnWidth + Spacing);

                if (panel.ColumnSpan <= availableColumns - _filledColumns)
                {
                    _filledColumns += panel.ColumnSpan;
                    frame.Translation = new System.Numerics.Vector3(newXTranslation, verticalTranslation, 0);
                }
                else
                {
                    int remainingSpace = availableColumns - _filledColumns;
                    while (remainingSpace > 0)
                    {
                        bool foundFit = false;
                        foreach (Frame subFrame in sortedFrames)
                        {
                            PanelInstance subPanel = subFrame.Tag as PanelInstance;
                            if (subPanel.Index > panel.Index && !_prematurelyPickedCardIndices.Contains(subPanel.Index) && subPanel.ColumnSpan <= remainingSpace)
                            {
                                subFrame.Translation = new System.Numerics.Vector3(newXTranslation, verticalTranslation, 0);
                                _prematurelyPickedCardIndices.Add(subPanel.Index);
                                _filledColumns += subPanel.ColumnSpan;
                                newXTranslation += subPanel.ColumnSpan * (ColumnWidth + Spacing);
                                remainingSpace -= subPanel.ColumnSpan;
                                foundFit = true;
                                break;
                            }
                        }
                        if (!foundFit) break;
                    }
                    verticalTranslation += ShinGridViewModel.Instance.RowHeight + Spacing;
                    frame.Translation = new System.Numerics.Vector3(0, verticalTranslation, 0);
                    _filledColumns = panel.ColumnSpan;
                }
            }
        }

        private void RootGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CalculateArrangement();
        }
    }
}
