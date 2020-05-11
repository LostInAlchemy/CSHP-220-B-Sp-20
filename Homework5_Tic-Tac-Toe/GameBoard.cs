using System.Collections.Generic;

namespace Homework5_Tic_Tac_Toe
{
    public class GameBoard
    {
        private int PlayCount = 0;
        private bool GameOver = false;

        public List<int> AvaibleMoves = new List<int>();

        public List<int> Player1Moves = new List<int>();
        public List<int> Player2Moves = new List<int>();

        public int Playcount
        {
            get { return PlayCount; }
            set { PlayCount = value; }
        }

        public bool Gameover
        {
            get { return GameOver; }
            set { GameOver = value; }
        }
    }
}
