using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_1
{
    public enum GameState
    {
        running,
        lost,
        won,
        tie
    }

    class Game
    {
        public Game()
        {
            _deck = new Deck();
            _playerHand = new PlayerHand();
            _dealerHand = new DealerHand();

            Play();
        }

        private void Play()
        {
            InitializeGame();
            HandleBlackjacks();
            PlayerTurn();
            DealerTurn();
            EndGame();
        }

        private void HandleBlackjacks()
        {
            ComputeBlackjacks();

            if (_dealerBlackjack)
            {
                DealerBlackjack();

                if (_playerBlackjack)
                {
                    Console.WriteLine("But...");
                    PlayerBlackjack();
                    _gameState = GameState.tie;
                }
                else
                {
                    _gameState = GameState.lost;
                }
            }
            else if (_playerBlackjack)
            {
                PlayerBlackjack();
                _dealerHand.NormalPrint();
                Console.WriteLine("He hasn't got a blackjack!");
                _gameState = GameState.won;
            }
        }

        private void DealerBlackjack()
        {
            Console.WriteLine();
            Console.WriteLine("In fact...");
            _dealerHand.NormalPrint();
            Blackjack();
        }

        private void PlayerBlackjack()
        {
            _playerHand.Print();
            Blackjack();
        }

        private void ComputeBlackjacks()
        {
            _playerBlackjack = CheckBlackjack(_playerHand);
            _dealerBlackjack = CheckBlackjack(_dealerHand);
        }

        private void Blackjack()
        {
            Console.WriteLine("Blackjack!");
        }

        private void EndGame()
        {
            Console.WriteLine();
            switch (_gameState)
            {
                case GameState.won:
                    Win();
                    break;
                case GameState.lost:
                    Lose();
                    break;
                case GameState.tie:
                    Tie();
                    break;
                default:
                    throw new InvalidGameStateException("Game still running when it should be over.");
            }
        }

        private void Tie()
        {
            Console.WriteLine("It's a tie! Nobody wins.");
        }

        private void Lose()
        {
            Console.WriteLine("You lose! Dealer wins!");
        }

        private void Win()
        {
            Console.WriteLine("You win!");
        }

        private void DealerTurn()
        {
            if (GameOver())
            {
                return;
            }

            _dealerHand.NormalPrint();

            while (_dealerHand.Score() < 17)
            {
                Console.WriteLine();
                Console.WriteLine("The dealer draws a card.");
                Deal(_dealerHand);
                _dealerHand.NormalPrint();
            }

            if (_dealerHand.Score() > 21)
            {
                BustDealer();
            }
            else
            {
                CompareHands();
            }
        }

        private void CompareHands()
        {
            int playerAdvantage = _playerHand.Score() - _dealerHand.Score();
            if (playerAdvantage > 0)
            {
                _gameState = GameState.won;
            }
            else if (playerAdvantage == 0)
            {
                _gameState = GameState.tie;
            }
            else
            {
                _gameState = GameState.lost;
            }

        }

        private void BustDealer()
        {
            _gameState = GameState.won;
            Bust();
        }

        private void PlayerTurn()
        {
            if (GameOver())
                return;

            while (!_playerStanding)
            {
                _playerHand.Print();
                if (_playerHand.Score() > 21)
                {
                    BustPlayer();
                    break;
                }
                PlayerAction();
            }
        }

        private void BustPlayer()
        {
            Bust();
            _gameState = GameState.lost;
        }

        private void Bust()
        {
            Console.WriteLine("Busted!");
        }

        private void PlayerAction()
        {
            if (IsInputAHit(PlayerInput()))
            {
                Console.WriteLine("Hitting.");
                Deal(_playerHand);
            }
            else
            {
                _playerStanding = true;
                Console.WriteLine("Standing.");
                Console.WriteLine();
            }
        }

        private bool IsInputAHit(string input)
        {
            return input == "Y" || input == "y";
        }

        private string PlayerInput()
        {
            Console.WriteLine("Another card? Y/N");
            string input = Console.ReadLine();
            Console.WriteLine();
            return input;
        }

        private void InitializeGame()
        {
            Deal(_playerHand, 2);
            Deal(_dealerHand, 2);
            _dealerHand.InitialPrint();
        }

        private bool CheckBlackjack(Hand hand)
        {
            return (hand.Score() == 21 && hand.Cards.Count == 2) ? true : false;
        }
        private void Deal (Hand hand)
        {
            hand.Add(_deck.Draw());
        }

        private void Deal (Hand hand, int number)
        {
            for (int i = 0; i < number; i++)
                Deal(hand);
        }

        private bool GameOver()
        {
            if (_gameState != GameState.running)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Deck _deck;
        private PlayerHand _playerHand;
        private DealerHand _dealerHand;
        private bool _playerStanding;
        private bool _playerBlackjack;
        private bool _dealerBlackjack;
        private GameState _gameState;
    }
}
