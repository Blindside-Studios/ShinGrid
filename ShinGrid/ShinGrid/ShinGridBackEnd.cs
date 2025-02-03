using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ShinGrid
{
    public class ShinGridBackEnd
    {
    }

    public class ShinGridViewModel: INotifyPropertyChanged
    {
        private static ShinGridViewModel _instance;
        public static ShinGridViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ShinGridViewModel();
                }
                return _instance;
            }
        }

        public int ColumnWidth { get; set; } = 300;

        public int RowHeight { get; set; } = 300;

        public int Spacing { get; set; } = 10;

        public int CornerRadius { get; set; } = 0;

        public List<PanelInstance> PanelInstances
        {
            get => _panelInstances;
            set
            {
                if (_panelInstances != value)
                {
                    _panelInstances = value;
                    OnPropertyChanged(nameof(PanelInstances));
                }
            }
        }
        private List<PanelInstance> _panelInstances;

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PanelInstance
    {
        public Type PageType { get; set; }
        public int ColumnSpan { get; set; } = 1;
        public int RowSpan { get; set; } = 1;
        public int Index { get; set; }
    }
}
