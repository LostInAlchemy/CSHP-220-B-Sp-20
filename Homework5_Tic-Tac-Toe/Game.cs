using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace Homework5_Tic_Tac_Toe
{
    class Game
    {
        public void GameStart(GameBoard gameBoard, string player, Button button)
        {
            int playerposition = BoardPostion(button);
            List<int> playerMovesUpdate = null;

            if (player == Constants.player1)
            {
                playerMovesUpdate = gameBoard.Player1Moves;
            }
            else if (player == Constants.player2)
            {
                playerMovesUpdate = gameBoard.Player2Moves;
            }

            foreach (int position in gameBoard.AvaibleMoves)
            {
                if (gameBoard.AvaibleMoves.Remove(playerposition))
                {
                    playerMovesUpdate.Add(playerposition);
                    ++gameBoard.Playcount;
                    break;
                }
            }
        }

        private bool OccupiedPosition(GameBoard gameBoard, Button button)
        {
            bool positionFilled = false;

            if (!gameBoard.AvaibleMoves.Contains(BoardPostion(button)))
            {
                MessageBox.Show(PlayerFeedBack.positionFilled);
                positionFilled = true;
            }
            return positionFilled;
        }

        public string PlayerTurn(GameBoard gameBoard, Button button)
        {
            string player = Constants.nonPlayer;

            if (!OccupiedPosition(gameBoard, button))
            {
                if (!IsOdd(gameBoard.Playcount))
                {
                    player = Constants.player1;
                }
                else
                {
                    player = Constants.player2;
                }

                GameStart(gameBoard, player, button);
            }

            return player;
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public int BoardPostion(Button button)
        {
            int[] gamePosition = new int[2];
            int i = 0;

            foreach (string s in button.Tag.ToString().Split(","))
            {
                gamePosition[i] = int.Parse(s);
                ++i;
            }

            int position = Convert.ToInt32("" + gamePosition[0] + gamePosition[1]);
            return position;
        }

        public bool Winner(GameBoard gameBoard, string player)//, Image img)
        {
            Winning_Key winkey = new Winning_Key();
            bool isWinner = false;

            List<int> EvalPlayerMoves = null;

            if (player == Constants.player1)
            {
                EvalPlayerMoves = gameBoard.Player1Moves;
            }
            else if (player == Constants.player2)
            {
                EvalPlayerMoves = gameBoard.Player2Moves;
            }

            foreach (var key in winkey.Wincombo)
            {
               if (WinningKeySearch.ContainsSequence(EvalPlayerMoves, key.Value))
                {
                    isWinner = true;
                    break;
                }
            }

            return isWinner;
        }

        private string PlayerPlaySet(GameBoard gameBoard, string player)
        {
            string playerPlaySet = "";

            if (player == Constants.player1)
            {
                playerPlaySet = string.Join(",", gameBoard.Player1Moves);
            }

            else if (player == Constants.player2)
            {
                playerPlaySet = string.Join(",", gameBoard.Player2Moves);
            }

            return playerPlaySet;
        }

        public bool Stalemate(GameBoard gameBoard)
        {
            bool stalemate = false;

            if (gameBoard.Playcount == Constants.MaxPlayCount)
            {
                stalemate = true;
                //var image = new BitmapImage();
                //image.BeginInit();
                //image.UriSource = new Uri(Resources.stalemateanim.gif);
                //image.EndInit();
                //ImageBehavior.SetAnimatedSource(img, image);
                //ImageBehavior.SetAutoStart(img, false);
                //ImageBehavior.SetRepeatBehavior(img, new RepeatBehavior(TimeSpan.FromSeconds(10)));
                //isWinner = true;
                //break;
            }
            return stalemate;
        }
    }
}
