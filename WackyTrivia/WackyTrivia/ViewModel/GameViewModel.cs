using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WackyTrivia.Abstracts;
using Xamarin.Forms;

namespace WackyTrivia.ViewModel
{
    class GameViewModel : BaseViewModel
    {
        public ICommand Answer1Command { get; set; }
        public ICommand Answer2Command { get; set; }
        public ICommand Answer3Command { get; set; }
        public ICommand Answer4Command { get; set; }

        public GameViewModel()
        {
            Answer1Command = new Command(Answer1);
            Answer2Command = new Command(Answer2);
            Answer3Command = new Command(Answer3);
            Answer4Command = new Command(Answer4);
        }

        public void Answer1()
        {
        }

        public void Answer2()
        {
        }

        public void Answer3()
        {
        }

        public void Answer4()
        {
        }
    }
}
