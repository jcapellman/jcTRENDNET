using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jcTRENDNET.Viewmodels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace jcTRENDNET.Views
{
    public partial class LiveCameraPage : Page {
        private LiveViewModel viewModel {
            get { return (LiveViewModel)DataContext; }
        }

        public LiveCameraPage()
        {
            
            DataContext = new LiveViewModel();

            viewModel.LoadData();
        }
        
      
    }
}
