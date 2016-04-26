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
        private string _questionQuery;
        private bool _questionLayout;
        private bool _answerLayout;
        public string QuestionItem { get; set; }

        public bool AnswerLayout
        {
            get { return _answerLayout; }
            set
            {
                _answerLayout = value;
                OnPropertyChanged();
            }
        }

        public bool QuestionLayout
        {
            get { return _questionLayout; }
            set
            {
                _questionLayout = value;
                OnPropertyChanged();
            }
        }

        public string QuestionQuery
        {
            get { return _questionQuery; }
            set
            {
                _questionQuery = value;
                OnPropertyChanged();
            }
        }

        public ICommand Answer1Command { get; set; }
        public ICommand Answer2Command { get; set; }
        public ICommand Answer3Command { get; set; }
        public ICommand Answer4Command { get; set; }
        public ICommand ExitGameCommand { get; set; }
        public ICommand ContinueCommand { get; set; }

        public GameViewModel()
        {
            QuestionItem = "Question Here";
            QuestionQuery = "Which of the below is closer in value?";
            QuestionLayout = true;
            AnswerLayout = false;

            Answer1Command = new Command(Answer1);
            Answer2Command = new Command(Answer2);
            Answer3Command = new Command(Answer3);
            Answer4Command = new Command(Answer4);
            ExitGameCommand = new Command(ExitGame);
            ContinueCommand = new Command(Continue);
        }

        public void Answer1()
        {
            QuestionQuery = "Correct!";
            LayoutSwitch();
        }

        public void Answer2()
        {
            QuestionQuery = "Incorrect...";
            LayoutSwitch();
        }

        public void Answer3()
        {
            QuestionQuery = "Incorrect...";
            LayoutSwitch();
        }

        public void Answer4()
        {
            QuestionQuery = "Incorrect...";
            LayoutSwitch();
        }

        public void ExitGame()
        {
            Navigation.PopToRoot();
        }

        public void Continue()
        {
            var game = new GameViewModel();
            Navigation.Push(ViewFactory.CreatePage(game));
        }

        public void LayoutSwitch()
        {
            QuestionLayout = !QuestionLayout;
            AnswerLayout = !AnswerLayout;
        }
    }
}
