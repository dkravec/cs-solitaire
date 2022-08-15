using Solitaire.structs;

namespace Solitaire.classes
{
    public class Deck
    {
        public int numDiscard = 0; 
        public string[] cardNumbers = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public int amountJokers = 2;
        public string[] cardSuits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        public CardType[] cards = { };
        public CardType[] deck = { };
        public int[] currentDiscard = { };

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

        public HandoutType[] CalucateHandout() {

            List<HandoutType> handout = new List<HandoutType>();
            // currentDiscard
            int[] currentLayout = { 0, 0, 0 };

            foreach(CardType deckCard in this.deck) {
                if (currentLayout[0] == 7) {
                    this.currentDiscard[currentDiscard[2]] = currentDiscard[2];
                    currentDiscard[2]++;
                } else {
                    if (currentLayout[0] == currentDiscard[1]) {
                        currentLayout[0]++;
                        currentLayout[1]++;
                    };

                    HandoutType cardHandout = new HandoutType();

                    cardHandout.layer = currentLayout[0];
                    cardHandout.card = deckCard;

                    handout.Add(cardHandout);
                }
                // Console.WriteLine(card.cardNumber + " of " + card.cardSuit);
            }

            return handout.ToArray();
        }

        public CardType pickNextCard() {
            return cards[0];
        }
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