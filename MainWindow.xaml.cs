using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region VariableData
        private static bool turn;
        private static int roundsCounter = 0;
        private static int X_wins = 0;
        private static int O_wins = 0;
        private static int TiesNumber = 0;
        #endregion

        #region ConstansData
        private const int minimalAmountOfRounds = 5;//Minimum number of moves for a win
        private const string O_SYMBOL = "O";
        private const string X_SYMBOL = "X";
        #endregion

        private List<Button> gameFields;
        public MainWindow()
        {
            InitializeComponent();
            
            gameFields = new List<Button>() { Field1, Field2, Field3, Field4, Field5, Field6, Field7, Field8, Field9 };
            foreach (Button x in gameFields) { x.Content = ""; }
        }

        #region FunctionsToField
        private void field_Click(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;
            if (turn)
            {
                pressedButton.Content = X_SYMBOL;
                pressedButton.Foreground = new SolidColorBrush(Colors.Red);
                whoseTurnLabel.Content = O_SYMBOL;
                whoseTurnLabel.Foreground = new SolidColorBrush(Colors.Blue);

            }
            else
            {
                pressedButton.Content = O_SYMBOL;
                pressedButton.Foreground = new SolidColorBrush(Colors.Blue);
                whoseTurnLabel.Content = X_SYMBOL;
                whoseTurnLabel.Foreground = new SolidColorBrush(Colors.Red);
            }

            turn = !turn;
            roundsCounter++;
            pressedButton.IsEnabled = false;

            if (roundsCounter >= minimalAmountOfRounds)
            {
                if (roundsCounter == 9 && !checkFields())
                {
                    MessageBox.Show("The game ended with tie");addTies();
                    Window_Loaded();
                }
                else if (checkFields())
                {
                    if (turn) { MessageBox.Show("Winner is O"); addOWins(); }
                    else { MessageBox.Show("Winner is X"); addXWins(); }
                    Window_Loaded();
                }
            }

        }

        private bool checkFields()
        {
            //Horizontal wins
            if (Field1.Content.Equals(Field2.Content) && Field2.Content.Equals(Field3.Content) && !Field1.Content.Equals("")) { return true; }
            else if (Field4.Content.Equals(Field5.Content) && Field5.Content.Equals(Field6.Content) && !Field4.Content.Equals("")) { return true; }
            else if (Field7.Content.Equals(Field8.Content) && Field8.Content.Equals(Field9.Content) && !Field7.Content.Equals("")) { return true; }
            //Vertical wins
            else if (Field1.Content.Equals(Field4.Content) && Field4.Content.Equals(Field7.Content) && !Field1.Content.Equals("")) { return true; }
            else if (Field2.Content.Equals(Field5.Content) && Field5.Content.Equals(Field8.Content) && !Field2.Content.Equals("")) { return true; }
            else if (Field3.Content.Equals(Field6.Content) && Field6.Content.Equals(Field9.Content) && !Field3.Content.Equals("")) { return true; }
            //Diagonal wins
            else if (Field3.Content.Equals(Field5.Content) && Field5.Content.Equals(Field7.Content) && !Field3.Content.Equals("")) { return true; }
            else if (Field1.Content.Equals(Field5.Content) && Field5.Content.Equals(Field9.Content) && !Field1.Content.Equals("")) { return true; }

            return false;
        }
        #endregion

        #region WindowLoadedFunctions
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var button in gameFields)
            {
                button.IsEnabled = true;
                button.Content = "";
                button.Foreground = new SolidColorBrush(Colors.Black);
            }
            roundsCounter = 0;
            if (getRandomNumber() == 1)
            {
                turn = true;
                whoseTurnLabel.Content = X_SYMBOL;
                whoseTurnLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                turn = false;
                whoseTurnLabel.Content = O_SYMBOL;
                whoseTurnLabel.Foreground = new SolidColorBrush(Colors.Blue);
            }
        }
        private void Window_Loaded()
        {
            foreach (var button in gameFields)
            {
                button.IsEnabled = true;
                button.Content = "";
                button.Foreground = new SolidColorBrush(Colors.Black);
            }
            roundsCounter = 0;
            if (getRandomNumber() == 1)
            {
                turn = true;
                whoseTurnLabel.Content = X_SYMBOL;
                whoseTurnLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                turn = false;
                whoseTurnLabel.Content = O_SYMBOL;
                whoseTurnLabel.Foreground = new SolidColorBrush(Colors.Blue);
            }
        }
        #endregion

        #region PointsFunctions
        private void addXWins()
        {
            X_wins++;
            XWins.PointsContent = X_wins.ToString();
        }
        private void addOWins()
        {
            O_wins++;
            OWins.PointsContent = O_wins.ToString();
        }
        private void addTies()
        {
            TiesNumber++;
            Ties.PointsContent = TiesNumber.ToString();
        }
        #endregion

        #region OtherFunctions
        private static int getRandomNumber()
        {
            Random rand = new Random();
            return rand.Next(2);
        }
        private void resetPointsButton_Click(object sender, RoutedEventArgs e)
        {
            O_wins = 0; X_wins = 0; TiesNumber = 0;
            XWins.PointsContent = X_wins.ToString();
            OWins.PointsContent = O_wins.ToString();
            Ties.PointsContent = TiesNumber.ToString();
        }
        #endregion
    }
}
