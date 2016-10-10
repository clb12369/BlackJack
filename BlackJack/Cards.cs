using System;

namespace BlackJack
{
    public enum Suit
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    public enum Rank
    {
        Ace,
        Deuce,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        public Suit suit;
        public Rank rank;

        public Card(Suit s, Rank r)
        {
            suit = s;
            rank = r;
        }

        public override string ToString()
        {
            return rank.ToString() + " of " + suit.ToString();
        }


    }

    public class Deck
    {
        public Card[] cards;
        public int numberDealt = 0;

        public Deck()
        {
            cards = new Card[52];
            int i = 0; // 1
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                int j = 0;
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    cards[i * 4 + j] = new Card(s, r);
                    j++;
                }
                i++;
            }
        }


        public Deck ShuffleDeck()
        {
            Random randomCard = new Random();
            for (int i = 0; i < 52; i++)
            {
                var temp = cards[i];
                int cardIndex = randomCard.Next(51);
                cards[i] = cards[cardIndex];
                cards[cardIndex] = temp;
            }
            return this;
        }

        public Card deal() => (numberDealt < cards.Length) ? cards[numberDealt++] : null;


        public Card DealFromDeck()
        {
            if (numberDealt < cards.Length)
            {
                return cards[numberDealt++];
            }
            else
            {
                return null;
            }
        }
    }

    public class Hand
    {
        public int score { get; private set; } = 0;
        public Card[] hand = new Card[10];
        public int handPosition {get; private set;} = 0;

        public void TakeCard(Card newCard)
        {
            hand[handPosition] = newCard;
            handPosition++;
        }

        public void CalculateScore() {
            score = 0;
            for(int i = 0; i < handPosition; i++)
            {
                switch (hand[i].rank)
                {
                    case Rank.Ace:
                        score += 11;
                        break;
                    case Rank.Deuce:
                        score += 2;
                        break;
                    case Rank.Three:
                        score += 3;
                        break;
                    case Rank.Four:
                        score += 4;
                        break;
                    case Rank.Five:
                        score += 5;
                        break;
                    case Rank.Six:
                        score += 6;
                        break;
                    case Rank.Seven:
                        score += 7;
                        break;
                    case Rank.Eight:
                        score += 8;
                        break;
                    case Rank.Nine:
                        score += 9;
                        break;
                    case Rank.Ten:
                        score += 10;
                        break;
                    case Rank.Jack:
                        score += 10;
                        break;
                    case Rank.Queen:
                        score += 10;
                        break;
                    case Rank.King:
                        score += 10;
                        break;
                    default:
                        score += 0;
                        break;
                }
            }
        }
    }
}
