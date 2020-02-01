using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames
{
    public class ProgramLogic
    {
        public List<string> owners = new List<string>(7)
        {"Alice", "Dogge", "Gherald", "Olivia", "Runa", "Sly", "Tim"};
        public List<BoardGame> boardGames = new List<BoardGame>();
        private List<BoardGame> availableBoardGames = new List<BoardGame>();
        public Random random = new Random();
        public int ParseMaxAmountOfPlayers(string amountOfPlayers)
        {             
            if (amountOfPlayers.Contains("-"))
            {
                string maxAmountOfPlayers = amountOfPlayers.Split('-')[1];              
                int maximumAmountOfPlayers;
                
                if (int.TryParse(maxAmountOfPlayers, out maximumAmountOfPlayers))
                {
                    return maximumAmountOfPlayers;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public int ParseMinAmountOfPlayers(string amountOfPlayers)
        {
            if (amountOfPlayers.Contains("-"))
            {
                string minAmountOfPlayers = amountOfPlayers.Split('-')[0];            
                int minimumAmountOfPlayers;
                if (int.TryParse(minAmountOfPlayers, out minimumAmountOfPlayers))
                {
                    return minimumAmountOfPlayers;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public void AddNewGame(string name, string owner, string amountOfPlayers) 
        {
            int maximumAmountOfPlayers = ParseMaxAmountOfPlayers(amountOfPlayers);
            int minimumAmountOfPlayers = ParseMinAmountOfPlayers(amountOfPlayers);
            BoardGame newBoardGame = new BoardGame(minimumAmountOfPlayers, maximumAmountOfPlayers, name, owner);
            boardGames.Add(newBoardGame);
        }        
        public List<BoardGame> FilterRelevantGamesNumberOfPlayers(List<BoardGame> boardGamesToFilter, int numberOfPlayers) 
        {
            foreach (BoardGame boardGame in boardGamesToFilter)
            {
                if (boardGame.MinimumAmountOfPlayers<=numberOfPlayers && boardGame.MaximumAmountOfPlayers>=numberOfPlayers)
                {
                    availableBoardGames.Add(boardGame);
                }
            }
            return availableBoardGames;
        }
        public List<BoardGame> FilterRelevantGamesOwnersAvailable(List<BoardGame> boardGamesToFilter, List<string> availableOwners)
        {
            foreach (BoardGame boardGame in boardGamesToFilter)
            {
                if (!availableOwners.Contains(boardGame.Owner))
                {
                    boardGamesToFilter.Remove(boardGame);
                }
            }
            return boardGamesToFilter;
        }
        public List<BoardGame> FilterRelevantGames(List<string> availableOwners, int numberOfPlayers) 
        {
            if (availableBoardGames.Count > 0)
            {
                availableBoardGames.Clear();
            }
            List<BoardGame> listToFilterFurther = FilterRelevantGamesNumberOfPlayers(boardGames, numberOfPlayers);
            availableBoardGames = FilterRelevantGamesOwnersAvailable(listToFilterFurther, availableOwners);
            return availableBoardGames;
        }
        public BoardGame SuggestRandomGame(List<BoardGame> availableBoardGames) 
        {
            int randomIndex = random.Next(availableBoardGames.Count);
            BoardGame randomGame = availableBoardGames[randomIndex];
            return randomGame;
        }
    }
}
