namespace Homework5_Tic_Tac_Toe
{
    class PlayerFeedBack
    {
        public const string gameOver = "Gameover!";
        public const string positionFilled = "Position has already been taken.\nChoose again!";
        public const string Player1_Turn = "X's Turn";
        public const string Player2_Turn = "O's Turn";
        public const string Player1_Win = "X wins the game!";
        public const string Player2_Win = "O wins the game!";
        public const string Win = "Winner Winner Chicken Dinner";

        private static string Player
            {
            get { return Player; }
            set { Player = value; }
            }

        public PlayerFeedBack(string player)
        {
            Player = player;
        }
    }
}
