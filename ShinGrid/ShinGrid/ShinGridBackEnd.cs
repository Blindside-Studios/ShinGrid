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

    public class PublicViewModel: INotifyPropertyChanged
    {
        private static PublicViewModel _instance;
        public static PublicViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PublicViewModel();
                }
                return _instance;
            }
        }

        public int ColumnWidth { get; set; } = 300;

        public int RowHeight { get; set; } = 300;

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
    }
}
