using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WackyTrivia.Abstracts;
using Xamarin.Forms;

namespace WackyTrivia.ViewModel
{
    class StatsPageViewModel : BaseViewModel
    {
        public ICommand ExitStatsCommand { get; set; }

        public StatsPageViewModel()
        {
            ExitStatsCommand = new Command(ExitStats);
        }

        public void ExitStats()
        {
            Navigation.Pop();
        }
    }
}
