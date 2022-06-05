using Solitaire.structs;

namespace Solitaire.classes
{
    public class Deck
    {
        // public string colour = "blue";
        // public int numCards = 52;
        // public int numDeck = 52;
        public int numDiscard = 0; 
        public string[] cardNumbers = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public int amountJokers = 2;
        public string[] cardSuits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        public CardType[] cards = { };
        public CardType[] deck = { };
        public int[] currentDiscard = { };

        public void Run() {
            // Console.WriteLine(colour);
        }

        public void CalucateCards() {
            // Add all cards to the cards array
            List<CardType> ls = new List<CardType>();
            foreach(string card in cardNumbers) {
                foreach(string suit in cardSuits) {
                   // Console.WriteLine(card + " of " + suit);
                    CardType cardName = new CardType();
                    cardName.cardNumber = card;
                    cardName.cardSuit = suit;
                    cardName.cardColour = "unknown";
                    cardName.cardColour = checkCardColour(cardName);
                    ls.Add(cardName);
                }
            }
            
            // Add jokers to the cards arary
            string lastJokerColour = "none";
            for (int i = 0; i < amountJokers; i++) {
                CardType cardName = new CardType();
                cardName.cardNumber = "JK";
                cardName.cardSuit = "Joker";

                if (lastJokerColour == "Black") {
                    cardName.cardColour = "Red";
                    lastJokerColour = "Red";
                } else if (lastJokerColour == "Red") {
                    cardName.cardColour = "Black";
                    lastJokerColour = "Black";
                } else {
                    cardName.cardColour = "Red";
                    lastJokerColour = "Red";
                }

                ls.Add(cardName);
            }

            cards = ls.ToArray();
        }

        public CardType[] shuffleCards() {
            deck = cards;
            var rng = new Random();

            int n = deck.Length;
            while (n > 1) 
            {
                int k = rng.Next(n--);
                CardType temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }

            return deck;
        }

        public CardType pickNextCard() {
            return cards[0];
        }

        /*  
        public void CardNum() {
            Console.WriteLine("There are " + numCards + " cards in the deck.");
        }

        public void changeNumDeck(int num) {
            numDeck = num;
        }

        public void changeNumDiscard(int num) {
            numDiscard = num;
        }
    
        public void changeColor(string newColour) {
            colour = newColour;
        }
        */
        public string checkCardColour(CardType card) {
            // Check the colour of any card 
            if (card.cardSuit == "Clubs") {
                return "Black";
            } else if (card.cardSuit == "Diamonds") {
                return "Red";
            } else if (card.cardSuit == "Hearts") {
                return "Red";
            } else if (card.cardSuit == "Spades") {
                return "Black";
            }
            else {
                return "Error";
            }
        }
    }
}