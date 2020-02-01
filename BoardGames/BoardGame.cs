using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames
{
    public class BoardGame
    {
        public int MinimumAmountOfPlayers { get; private set; }
        public int MaximumAmountOfPlayers { get; private set; }
        public string Name { get; private set; }
        public string Owner { get; private set; }
        public BoardGame(int minimumAmountOfPlayers, int maximumAmountOfPlayers, string name, string owner)
        {
            MinimumAmountOfPlayers = minimumAmountOfPlayers;
            MaximumAmountOfPlayers = maximumAmountOfPlayers;
            Name = name;
            Owner = owner;
        }
        public override string ToString()
        {
            string boardGameView = $"{Name} ({MinimumAmountOfPlayers}-{MaximumAmountOfPlayers} spelare) - {Owner}s spel";
            return boardGameView;
        }
    }
}
