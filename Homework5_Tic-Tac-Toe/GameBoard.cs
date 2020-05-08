using System;
using System.Collections.Generic;

namespace Homework5_Tic_Tac_Toe
{
    class GameBoard
    {
        private string[,] Board = new string[3, 3];
        private int PlayCount = 1;

        //private List<int> AvaibleMoves = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        //private Nullable<int> [] Player1Moves  = new Nullable<int>[] { null, null, null, null, null, null, null, null, null };
        //private Nullable<int>[] Player2Moves = new Nullable<int>[] { null, null, null, null, null, null, null, null, null };


        public string[,] board
        {
            get { return Board; }
            set { Board = value; }
        }

        public int playcount
        {
            get { return PlayCount; }
            set { PlayCount = value; }
        }
    }
}
