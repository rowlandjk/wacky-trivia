using System.Linq;
using System.Windows.Input;
using WackyTrivia.Abstracts;
using Xamarin.Forms;

namespace WackyTrivia.ViewModel
{
    /*  ViewModel for Game execution - displays questions and answers modally on the same view
     *  Author: Jesse Rowland
     */

    class GameViewModel : BaseViewModel
    {
        //string to hold the Question string, or Correct/Incorrect once an answer is given
        private string _questionQuery;
        //boolean that sets the view layout for a question when true
        private bool _questionLayout;
        //boolean that sets the view layout for an answer response when true
        private bool _answerLayout;
        //property to store the question item from the database
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

        /*  Each answer on the view has an Item id, Item string (name), and a command attached to the item
         *  Todo: Refactor into list of structures with <int, string, Command>
         */
        public int Answer1Id { get; set; }
        public string Answer1String { get; set; }
        public ICommand Answer1Command { get; set; }
        public int Answer2Id { get; set; }
        public string Answer2String { get; set; }
        public ICommand Answer2Command { get; set; }
        public int Answer3Id { get; set; }
        public string Answer3String { get; set; }
        public ICommand Answer3Command { get; set; }
        public int Answer4Id { get; set; }
        public string Answer4String { get; set; }
        public ICommand Answer4Command { get; set; }

        //Command to exit the game back to the MainPage
        public ICommand ExitGameCommand { get; set; }
        //Command to continue to the next question
        public ICommand ContinueCommand { get; set; }

        public GameViewModel()
        {
            /*  Get all items from the database
            *   Todo: Obviously not efficient - when items are sourced outside the local db,
            *   implement lazy loading
            */
            var itemList = App.Database.GetItems().ToList();

            //bind the items to the view
            Answer1Id = itemList[4].Id;
            Answer1String = itemList[4].Name;
            Answer2Id = itemList[2].Id;
            Answer2String = itemList[2].Name;
            Answer3Id = itemList[1].Id;
            Answer3String = itemList[1].Name;
            Answer4Id = itemList[3].Id;
            Answer4String = itemList[3].Name;

            //bind the question to the view
            QuestionItem = itemList[0].Name;
            QuestionQuery = "Which of the below is closer in value?";
            QuestionLayout = true;
            AnswerLayout = false;

            //bind button commands to the view
            Answer1Command = new Command(Answer1);
            Answer2Command = new Command(Answer2);
            Answer3Command = new Command(Answer3);
            Answer4Command = new Command(Answer4);
            ExitGameCommand = new Command(ExitGame);
            ContinueCommand = new Command(Continue);
        }

        /*  Answer commands 1-4 have preset answers currently
         *  Todo: Create method to evaluate item value, that determines answer correctness
         */
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

        //Push next question
        public void Continue()
        {
            var game = new GameViewModel();
            Navigation.Push(ViewFactory.CreatePage(game));
        }

        //flip the layout boolean variables to switch page layout
        public void LayoutSwitch()
        {
            QuestionLayout = !QuestionLayout;
            AnswerLayout = !AnswerLayout;
        }
    }
}
