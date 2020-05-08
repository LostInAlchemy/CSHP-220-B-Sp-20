using System.Collections.Generic;

namespace Homework5_Tic_Tac_Toe
{
    class Winning_Key
    {
        private Dictionary<string, List<int>> winningCombo = new Dictionary<string, List<int>>();
        private List<int> Combo;

        public Dictionary<string, List<int>> wincombo
        {
            get { return winningCombo; }
        }

        public Winning_Key()
        {
            Combo = new List<int> { 0, 1, 2 };
            winningCombo.Add("Combo1", Combo);
            Combo = new List<int> { 3, 4, 5 };
            winningCombo.Add("Combo2", Combo);
            Combo = new List<int> { 6, 7, 8 };
            winningCombo.Add("Combo3", Combo);
            Combo = new List<int> { 0, 3, 6 };
            winningCombo.Add("Combo4", Combo);
            Combo = new List<int> { 1, 4, 7 };
            winningCombo.Add("Combo5", Combo);
            Combo = new List<int> { 2, 5, 8 };
            winningCombo.Add("Combo6", Combo);
            Combo = new List<int> { 0, 4, 8 };
            winningCombo.Add("Combo7", Combo);
            Combo = new List<int> { 2, 4, 6 };
            winningCombo.Add("Combo8", Combo);
        }
    }
}
