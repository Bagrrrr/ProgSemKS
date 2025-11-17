using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace MinMax_Nim
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialPiles = new List<int> { 2, 2 };
            bool botStarts = true;

            var game = new NimGame(initialPiles, botStarts);
            GameState state;

            do
            {
                state = game.PlayTurn();
            } while (state == GameState.Ongoing);


            if (state == GameState.BotWon)
                Console.WriteLine("Vyhrál počítač!");
            else
                Console.WriteLine("Gratulujeme! Vyhráli jste!");
        }
    }

    public enum GameState
    {
        Ongoing,
        BotWon,
        HumanWon
    }

    public class NimGameState
    {
        public List<int> Piles { get; private set; }
        public int MatchesInGame { get; private set; }

        public NimGameState(List<int> initialPiles)
        {
            Piles = new List<int>(initialPiles);
            MatchesInGame = Piles.Sum();
        }

        public void MakeMove(int pileIndex, byte matchesToRemove)
        {
            if (IsValidMove(pileIndex, matchesToRemove))
            {
                Piles[pileIndex] -= matchesToRemove;
                MatchesInGame -= matchesToRemove;
            }
            else
            {
                throw new ArgumentException("Neplatný tah!");
            }
        }

        private bool IsValidMove(int pileIndex, byte matchesToRemove)
        {
            return pileIndex >= 0 &&
                   pileIndex < Piles.Count &&
                   Piles[pileIndex] >= matchesToRemove &&
                   matchesToRemove > 0;
        }
    }

    public class NimGame
    {
        private NimGameState _state; // pro privátní datové položky používáme podtržítko na začátku jména
        private bool _botStarts;
        private bool _isBotTurn;

        public NimGame(List<int> initialPiles, bool botStarts)
        {
            _state = new NimGameState(initialPiles);
            _botStarts = botStarts;
            _isBotTurn = botStarts;
        }

        public GameState PlayTurn()
        {
            PrintGameState();

            if (_isBotTurn)
            {
                var botMove = GetBestBotMove();
                MakeAndPrintBotMove(botMove);
            }
            else
            {
                var humanMove = GetHumanInput();
                _state.MakeMove(humanMove.Item1, humanMove.Item2);
            }

            _isBotTurn = !_isBotTurn;

            if (_state.MatchesInGame == 0)
                if (_isBotTurn)
                    return GameState.BotWon;
                else
                    return GameState.HumanWon;
            else
                return GameState.Ongoing;
        }

        private Tuple<int, byte> GetBestBotMove()
        {
            int bestPile = 0; // budoucí nejlepší hromádka k odebírání sirek
            byte matchesToRemove = 1; // buoducí nejlepší momentální počet k odebrání

            int depthLimit = 10;
            int bestScore = int.MinValue;

            for (int pile = 0; pile < _state.Piles.Count; pile++)
            {
                int available = _state.Piles[pile];
                if (available <= 0)
                {
                    continue;
                }

                for (int take = 1; take <= available; take++)
                {
                    var nextPiles = _state.Piles.ToList();
                    nextPiles[pile] -= take;

                    int score = minimax(nextPiles, depthLimit - 1, false);

                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestPile = pile;
                        matchesToRemove = (byte)take;
                    }
                }
            }

            int minimax(List<int> piles, int depth, bool maximizingPlayer)
            {
                int total = piles.Sum();
                if (total == 0)
                {
                    return maximizingPlayer ? -1 : 1;
                }

                if (depth == 0)
                {
                    return 0;
                }
                if (maximizingPlayer)
                {
                    int maxEval = int.MinValue;
                    for (int i = 0; i < piles.Count; i++)
                    {
                        if (piles[i] <= 0)
                        {
                            continue;
                        }
                        for (int take = 1; take <= piles[i]; take++)
                        {
                            var child = piles.ToList();
                            child[i] -= take;
                            int eval = minimax(child, depth - 1, false);
                            if (eval > maxEval)
                            {
                                maxEval = eval;
                            }
                            if (maxEval == 1)
                            {
                                return 1;
                            }
                        }
                    }
                    return maxEval;
                }
                else
                {
                    int minEval = int.MaxValue;
                    for (int i = 0; i < piles.Count; i++)
                    {
                        if (piles[i] <= 0) continue;
                        for (int take = 1; take <= piles[i]; take++)
                        {
                            var child = piles.ToList();
                            child[i] -= take;
                            int eval = minimax(child, depth - 1, true);
                            if (eval < minEval)
                            {
                                minEval = eval;
                            }
                            if (minEval == -1)
                            {
                                return -1;
                            }
                        }
                    }
                    return minEval;
                }
            }

            return new Tuple<int, byte>(bestPile, matchesToRemove);
        }

        

        

        private void PrintGameState()
        {
            Console.WriteLine("Aktuální stav hry:");
            foreach (var pile in _state.Piles)
                Console.Write(pile + " ");
            Console.WriteLine();
        }

        private void MakeAndPrintBotMove(Tuple<int, byte> move) 
        {
            _state.MakeMove(move.Item1, move.Item2);
            Console.WriteLine($"Počítač bere {move.Item2} sirky z hromádky {move.Item1}");
        }

        private Tuple<int, byte> GetHumanInput()
        {

            Console.Write("Z které hromádky chcete brát? (");
            for (int i = 0; i < _state.Piles.Count; i++)
            {
                if (_state.Piles[i] > 0)
                    Console.Write($"{i} ");
            }
            Console.Write(")");

            int pileIndex = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Kolik sirek chcete vzít? (1-{_state.Piles[pileIndex]})");
            byte matches = Convert.ToByte(Console.ReadLine());

            return new Tuple<int, byte>(pileIndex, matches);
        }
    }


}
