using System.Collections.Generic;

namespace Homework5_Tic_Tac_Toe
{
    class Winning_Key
    {
        private readonly Dictionary<string, List<int>> winningCombo = new Dictionary<string, List<int>>();
        private readonly List<int> Combo;

        public Dictionary<string, List<int>> Wincombo
        {
            get { return winningCombo; }
        }

        public Winning_Key()
        {
            Combo = new List<int> { 0, 1, 2 };
            winningCombo.Add("Combo1", Combo);
            Combo = new List<int> { 10, 11, 12 };
            winningCombo.Add("Combo2", Combo);
            Combo = new List<int> { 20, 21, 22 };
            winningCombo.Add("Combo3", Combo);
            Combo = new List<int> { 0, 10, 20 };
            winningCombo.Add("Combo4", Combo);
            Combo = new List<int> { 1, 11, 21 };
            winningCombo.Add("Combo5", Combo);
            Combo = new List<int> { 2, 12, 22 };
            winningCombo.Add("Combo6", Combo);
            Combo = new List<int> { 0, 11, 22 };
            winningCombo.Add("Combo7", Combo);
            Combo = new List<int> { 2, 11, 20 };
            winningCombo.Add("Combo8", Combo);
        }
    }
}
