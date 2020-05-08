using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace Homework5_Tic_Tac_Toe
{
    class Game
    {
        private bool gameover = false;

        public void NewGame(GameBoard game, Grid uxGrid, TextBlock uxTurn, Image img)
        {
            for (int i = 0; i < uxGrid.Children.Count; ++i)
            {
                game.playcount = 1;
                Array.Clear(game.board, 0, game.board.Length);
                Button button = (Button)uxGrid.Children[i];
                button.Content = "";
                uxTurn.Text = "";
                gameover = false;
            }
        }

        public void GameStart(Button button, GameBoard game, TextBlock uxTurn, Image img)
        {
            if (gameover == false)
            {
                string player = string.Empty;
                int[] gamePosition = new int[2];

                uxTurn.Text = PlayerFeedBack.Player1_Turn;

                int i = 0;

                foreach (string s in button.Tag.ToString().Split(","))
                {
                    gamePosition[i] = int.Parse(s);
                    ++i;
                }

                if (game.board[gamePosition[0], gamePosition[1]] == null)
                {
                    if (IsOdd(game.playcount))
                    {
                        player = Players.player1;
                        uxTurn.Text = PlayerFeedBack.Player2_Turn;
                    }
                    else
                    {
                        player = Players.player2;
                    }

                    game.board[gamePosition[0], gamePosition[1]] = player;

                    PlayerMove(button, player);
                    if (Winner(player, game, uxTurn, img))
                    {
                        gameover = true;
                        if (player == "X")
                        {
                            uxTurn.Text = PlayerFeedBack.Player1_Win;
                        }
                        else
                        {
                            uxTurn.Text = PlayerFeedBack.Player2_Win;
                        }
                        MessageBox.Show(PlayerFeedBack.gameOver);
                    }
                    ++game.playcount;
                }
                else
                {
                    MessageBox.Show(PlayerFeedBack.positionFilled);
                }
            }
        }

        private void PlayerMove(Button button, string player)
        {
            button.FontSize = 75;
            button.Content = player;
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        private bool Winner(string player, GameBoard game, TextBlock uxTurn, Image img)
        {
            Winning_Key winkey = new Winning_Key();

            List<string> winner = new List<string>();

            bool isWinner = false;

            if (game.playcount >= 5)
            {
                foreach (string position in game.board)
                {
                    if (position == player)
                    {
                        winner.Add(position);
                    }
                    else
                    {
                        winner.Add(null);
                    }
                }

                List<int> challenge = new List<int>();

                for (int i = 0; i < game.board.Length; ++i)
                {
                    bool gameover = false;
                    if (winner[i] != null)
                    {
                        try
                        {
                            challenge.Add(i);
                        }
                        catch { }

                        if (challenge.Count >= 3)
                        {
                            foreach (var key in winkey.wincombo)
                            {
                                if (string.Join(",", challenge).Contains(string.Join(",", key.Value)))
                                {
                                    uxTurn.Text = "";
                                    MessageBox.Show(PlayerFeedBack.Win);
                                    gameover = true;
                                    isWinner = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (gameover)
                    {
                        break;
                    }
                }
            }
            return isWinner;
        }
    }
}
