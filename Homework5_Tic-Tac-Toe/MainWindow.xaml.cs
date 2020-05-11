using System.Windows;
using System.Windows.Controls;

namespace Homework5_Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameBoard gameboard = new GameBoard();
        Game game = new Game();

        public MainWindow()
        {
            InitializeComponent();
            BoardInitialization();
            uxTurn.Text = PlayerFeedBack.Player1_Turn;
        }

        private void BoardInitialization()
        {
            foreach (Button button in uxGrid.Children)
            {
                gameboard.AvaibleMoves.Add(game.BoardPostion(button));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            PlayerMove(button);
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
            BoardInitialization();
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void NewGame()
        {
            for (int i = 0; i < uxGrid.Children.Count; ++i)
            {
                Button button = (Button)uxGrid.Children[i];
                button.Content = Constants.nonPlayer;
                uxTurn.Text = Constants.InfoBar;
            }

            gameboard.Playcount = Constants.StartingPlayCount;
            gameboard.Gameover = false;
            gameboard.AvaibleMoves.Clear();
            gameboard.Player1Moves.Clear();
            gameboard.Player2Moves.Clear();
        }

        private void PlayerMove(Button button)
        {
            if (!gameboard.Gameover)
            {
                string player = game.PlayerTurn(gameboard, button);

                if (!GameOver(button, player))
                {
                    UpdateBoardPosition(button, player);
                }
            }
        }

        private void UpdateBoardPosition(Button button, string player)
        {
            button.FontSize = Constants.ButtonPositionFontSize;
            if (player != string.Empty)
            {
                button.Content = player;
            }

            if (player == Constants.player1)
            {
                uxTurn.Text = PlayerFeedBack.Player2_Turn;
            }

            else if (player == Constants.player2)
            {
                uxTurn.Text = PlayerFeedBack.Player1_Turn;
            }
        }

        private bool GameOver(Button button, string player)
        {
            if (gameboard.Playcount >= Constants.RequiredPlayCount)
            {
                gameboard.Gameover = game.Winner(gameboard, player);
                //bool stalemate = newgame.Stalemate(gameboard);
                bool GameWon = gameboard.Gameover;

                //if (stalemate)
                if (gameboard.Playcount == Constants.MaxPlayCount)
                {
                    UpdateBoardPosition(button, player);
                    uxTurn.Text = PlayerFeedBack.Stalemate;
                    gameboard.Gameover = true;
                    MessageBox.Show(PlayerFeedBack.gameOver);
                    return true;
                }

                if (GameWon)
                {
                    UpdateBoardPosition(button, player);
                    WinnerMSG(player);
                    MessageBox.Show(PlayerFeedBack.gameOver);
                    return GameWon;
                }
            }

            return false;
        }

        private void WinnerMSG(string player)
        {
            if (player == Constants.player1)
            {
                uxTurn.Text = PlayerFeedBack.Player1_Win;
            }
            else if (player == Constants.player2)
            {
                uxTurn.Text = PlayerFeedBack.Player2_Win;
            }

            MessageBox.Show(PlayerFeedBack.Win);
        }
    }
}