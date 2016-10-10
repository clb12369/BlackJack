using System;

namespace BlackJack
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Would you like to play BlackJack (Y/N)?");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                Play();
            } else
            {
                Environment.Exit(0);
            }
        }

        static void Play()
        {
            Hand playerHand = new Hand();
            Hand dealerHand = new Hand();

            Deck dealerDeck = new Deck().ShuffleDeck();
            for (int i = 0; i < 2; i++)
            {
                playerHand.TakeCard(dealerDeck.DealFromDeck());
                dealerHand.TakeCard(dealerDeck.DealFromDeck());
            }
            Console.WriteLine("Players hand:");
            for (int i = 0; i <= playerHand.handPosition; i++)
            {
                Console.WriteLine(playerHand.hand[i]);
            }
            playerHand.CalculateScore();
            Console.WriteLine("Player score: {0}", playerHand.score);
            if (playerHand.score == 21)
            {
                Console.WriteLine("BlackJack!! you're the winner");
                AskToPlayAgain();
            }
            Console.WriteLine();
            Console.WriteLine("Dealer's hand:");
            Console.WriteLine(dealerHand.hand[0]);
            dealerHand.CalculateScore();
            Console.WriteLine();
            //Console.WriteLine("Dealer score: {0}", dealerHand.score);

            string playerAnswer;
            do
            {
                Console.WriteLine("Would you like to hit or stay (H/S)?");
                playerAnswer = Console.ReadLine().ToUpper();
                if (playerAnswer == "H")
                {
                    Console.WriteLine("Player's hand:");
                    playerHand.TakeCard(dealerDeck.DealFromDeck());
                    Console.WriteLine(playerHand.hand[playerHand.handPosition - 1]);
                    playerHand.CalculateScore();
                    Console.WriteLine("Player score: {0}", playerHand.score);
                    if (playerHand.score > 21)
                    {
                        Console.WriteLine("You're busted!!");
                        AskToPlayAgain();
                    }
                }
            } while (playerAnswer == "H");

            for (int i = 0; i <= playerHand.handPosition; i++)
            {
                Console.WriteLine(playerHand.hand[i]);
            }
            Console.WriteLine("Player score: {0}", playerHand.score);

            if (playerHand.score > 21)
            {
                Console.WriteLine("You're busted!!");
                AskToPlayAgain();
            }

            if (dealerHand.score < 16)
            {
                dealerHand.TakeCard(dealerDeck.DealFromDeck());
                dealerHand.CalculateScore();
                if (dealerHand.score < 16)
                {
                    dealerHand.TakeCard(dealerDeck.DealFromDeck());
                    dealerHand.CalculateScore();
                }
                    if (dealerHand.score < 16)
                    {
                        dealerHand.TakeCard(dealerDeck.DealFromDeck());
                        dealerHand.CalculateScore();
                    }
            }

            dealerHand.CalculateScore();
            Console.WriteLine("Dealer score {0}", dealerHand.score);

            if (dealerHand.score > 21 && playerHand.score <= 21)
            {
                Console.WriteLine("Dealer busts! Player wins!");
            } else if (playerHand.score > dealerHand.score)   
            {
                Console.WriteLine("Player wins!!");
                AskToPlayAgain();

            } else if (dealerHand.score > playerHand.score) {
                Console.WriteLine("Dealer wins!!");
                AskToPlayAgain();
            } else if (playerHand.score > 21 && dealerHand.score > 21)
            {
                Console.WriteLine("It's a draw!!");
                AskToPlayAgain();
            } else if (dealerHand.score == playerHand.score)
            {
                Console.WriteLine("It's a tie...");
                AskToPlayAgain();
            }

            Console.WriteLine("Goodbye");
            Console.ReadLine();
        }

        static void AskToPlayAgain()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to play again (Y/N)?");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                Play();
            } else
            {
                Environment.Exit(0);
            }
        }
    }
}









