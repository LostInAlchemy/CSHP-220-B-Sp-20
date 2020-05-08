using System.Windows;
using System.Windows.Controls;

namespace Homework5_Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameBoard game = new GameBoard();
        Game newgame = new Game();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            newgame.GameStart(button, game, uxTurn, img);
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            newgame.NewGame(game, uxGrid, uxTurn, img);
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


/*
Allow placement only on empty spots.
X goes first, then O
When you get three in a row, you declare a winner.
When a winner is declared, you disable any further development.
The menu has File | New Game and File | Exit.

HINT: Notice the Tag and that you ONLY have the Button_Click event. 
The tag gives you the row and column. The tag is also an object 
but as you can see it is actually a string 
(unbox it or call ToString). Then you can parse the string into 
row and column. 

Remember the Button_Click event has an object sender parameter.
That sender object is a Button, so cast it to a Button and 
get the Tag object.
*/












