using Solitaire.structs;

namespace Solitaire.classes
{
    public class WarGame
    {
        public CardType[] cards = { };
        public CardType[] deck = { };
        public WarLayout[] WarHandout = { };
        public Deck warDeck = new Deck();
        public int amountPlayers = 2;

        public void StartWarGame() {
            // var WarDeck = myDeck;
            warDeck.CalucateCards();
            warDeck.shuffleCards();

            Console.Clear();
            Console.WriteLine("War Game has started.");
            Handout();
            // GameLoopWar();
            /*
                * Create a deck of cards
                * Shuffle the deck
                * Deal the deck to each player
                * Play the game
            */
        }

        public void GameLoopWar() {
            do {
                string keyPressedMovement = Console.ReadKey(true).Key.ToString();

                if (keyPressedMovement == "Enter") {
                    Console.Clear();
                    DrawNewCard();
                } else if (keyPressedMovement == "Escape") {
                    Console.WriteLine("Menu... (maybe)... (eventually)...");
                };
            } while (true);
        }

        public void DrawNewCard() {
            // both users draw a new card
            Console.WriteLine("Drawing new card");
            for (int i = 0; i < 2; i++) {
            }
        }

        public string formatCard(CardType card) {
            var cardString = "";
            cardString += card.cardNumber;
            cardString += " of ";
            cardString += card.cardSuit;
            return cardString;
        }

        public string stringCheck() {
            return "";
        }
        
        public void Handout() {
            // List<WarLayout> handout = new List<WarLayout>();
            // WarLayout[] handout = {};
            List<WarLayout> PrepareHandout = new List<WarLayout>();

            /* 
                possible idea

                    add another struct, just for another type of card, and add which user it is
                    @ int: user
                    @ CardType: card
                    then you push it to the user's WarLayout over a loop


                    keep the deck and CardType in a List, so you can remove and add indexes easily.
                        remove: PrepareHandout.RemoveAt(<index>)
                        remove: PrepareHandout.Remove(<oldObj>)
                        edit: PrepareHandout[<index>] = <newObj>
                        add: PrepareHandout.Add(<newObj>)
            */
            int[] currentLayout = { };
            // lastUser | currentCard(ofuser)...

            List<int> PrepareLayout = new List<int>();
            PrepareLayout.Add(0);
            for (int i = 0; i<amountPlayers; i++) {
                PrepareLayout.Add(0);
                PrepareHandout.Add(new WarLayout());
            }

            currentLayout = PrepareLayout.ToArray();

            int amountDivided = warDeck.deck.Length / amountPlayers;

            foreach(CardType deckCard in warDeck.deck) {
                // handout.Add(deckCard);
                int length = currentLayout.Length;
                if (currentLayout[0] == 0 || currentLayout[0]==amountPlayers) {
                    currentLayout[0] = 1; // change active to 1 
                } else {
                    currentLayout[0]++; // change active to plus one
                };

                int currentUserFrom0 = currentLayout[0]-1;
                int currentUserNumber = currentLayout[0];

                if (currentLayout[currentUserNumber]!=amountDivided) {
                    currentLayout[currentUserNumber]++; // card number
                    PrepareHandout[currentUserNumber].deck[currentUserNumber] = deckCard; // saves current card

                };
                
                // PrepareHandout[currentUserFrom0].deck
            }

            // PrepareHandout
        }
    }
}