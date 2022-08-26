using Solitaire.structs;

namespace Solitaire.classes
{
    public class WarGame
    {
        public CardType[] cards = { };
        public CardType[] deck = { };
        public WarLayout[] WarHandout = { };
        public Deck warDeck = new Deck();

        public CurrentWar[] currentWar = { };
        public int amountPlayers = 3;

        public void StartWarGame() {
            // var WarDeck = myDeck;
            warDeck.CalucateCards();
            warDeck.shuffleCards();

            Console.Clear();
            Console.WriteLine("War Game has started.");
            Handout();

            // drawPlayerCards();
            GameLoopWar();
            /*
                * Create a deck of cards
                * Shuffle the deck
                * Deal the deck to each player
                * Play the game
            */
        }

        public void GameLoopWar() {
            Boolean currentWar = false;

            do {
                string keyPressedMovement = Console.ReadKey(true).Key.ToString();
                // Console.WriteLine(keyPressedMovement);
                if (keyPressedMovement == "Enter") {
                    if (currentWar) {
                        
                    } else {
                        drawPlayerCards();
                    }
                } else if (keyPressedMovement == "LeftArrow") {
                    
                } else if (keyPressedMovement == "RightArrow") {

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

        public void drawPlayerCards() {
            // currentWar = null;

            for (int i = 0; i<amountPlayers; i++) {
                WarLayout currentLayout = WarHandout[i];
                if (currentLayout.currentlyPlaying == true) {
                    Console.WriteLine(currentLayout.deck.Count);
                    if (currentLayout.deck.Count>0) {
                        // if (currentLayout.deck.Count == 1) Console.WriteLine("1");
                        // Console.WriteLine(currentLayout.deck.Count);
                        CardType currentCard = currentLayout.deck[currentLayout.deck.Count-1];
                        String formatedCard = formatCard(currentCard);
                        // Console.WriteLine(formatedCard);
                        // WarHandout[i].deck.RemoveAt(currentLayout.deck.Count-1);
                        currentWar[i] = new CurrentWar();
                        currentWar[i].inWar = false;
                        currentWar[i].cardsInDraw = new List<CardType>();
                        currentWar[i].cardsInDraw.Add(currentCard);
                        moveCardToDiscard(currentLayout.deck.Count-1, i);
                    } else {
                        DiscardToDeck(i);
                        Console.WriteLine("You ran out of cards.");
                    }
                }
            }

            CheckWhoWins();

            return;
        }

        public void moveCardToDiscard(int cardIndex, int userIndex) {
            // Console.WriteLine(WarHandout[userIndex]);
            WarHandout[userIndex].discardPile.Add(WarHandout[userIndex].deck[cardIndex]);
            Console.WriteLine(WarHandout[userIndex].discardPile[0].cardNumber);
            WarHandout[userIndex].deck.RemoveAt(cardIndex);
            if (WarHandout[userIndex].deck.Count() == 0) {
                DiscardToDeck(userIndex);
            };
            // if (DiscardToDeck(int usernum))
        }

        public void CheckWhoWins() {
            List<CardType> cardsAgainst = new List<CardType>();
            for (int i = 0; i<amountPlayers; i++) {
                WarLayout currentLayout = WarHandout[i];
                if (currentLayout.currentlyPlaying == true) {
                    if (currentWar[i].inWar) {
                        cardsAgainst.Add(new CardType());
                    } else {
                        cardsAgainst.Add(currentWar[i].cardsInDraw[0]);
                    }
                    // CardType currentCard = currentLayout.deck[currentLayout.deck.Count-1];
                    // String formatedCard = formatCard(currentCard);
                    // Console.WriteLine(formatedCard);
                    // // WarHandout[i].deck.RemoveAt(deck.Length);
                    // currentWar[i] = new CurrentWar();
                    // currentWar[i].inWar = false;
                    // currentWar[i].cardsInDraw = new List<CardType>();
                    // currentWar[i].cardsInDraw.Add(currentCard);
                } else {
                    cardsAgainst.Add(new CardType());
                };
                // WarHandout[i];
                // CardType currentCard = WarHandout[i].deck[deck.Length];
                // String formatedCard = formatCard(currentCard);
                // Console.WriteLine(formatedCard);
            }; 

            int[] winning = { };


            for (int j = 0; j<cardsAgainst.Count(); j++) {
                int convertNum = convertCardtoNum(cardsAgainst[j].cardNumber);
                for (int k = 0; k<cardsAgainst.Count(); k++) {
                    // if (cardsAgainst=="A" || "J")
                    // winning[j] = k;
                };
            };
        }

        public int convertCardtoNum(string cardNumber) {
            int converted = 0;

            bool isNumerical = int.TryParse(cardNumber, out converted);
            if (isNumerical) return converted;
            else if (cardNumber=="A") converted = 1;
            else if (cardNumber=="J") converted = 11;
            else if (cardNumber=="Q") converted = 12;
            else if (cardNumber=="K") converted = 13;
            else if (cardNumber=="JK") converted = 14;

            return converted;
        }


        public void DiscardToDeck(int usernum) {
            // Console.WriteLine(WarHandout[usernum].discardPile[0].cardNumber);
            List<CardType> newDiscard = shuffleDiscard(usernum);
            // WarHandout[usernum].deck = WarHandout[usernum].discardPile;
            WarHandout[usernum].deck = newDiscard;
            WarHandout[usernum].discardPile = new List<CardType>();
            Console.WriteLine("----");
            // Console.WriteLine(WarHandout[usernum].deck[0]);
            Console.WriteLine("Shuffling Cards.");
            Console.WriteLine("----");
        }

        public List<CardType> shuffleDiscard(int usernum) {
            CardType[] currentDiscard = WarHandout[usernum].discardPile.ToArray();
            var rng = new Random();

            int n = currentDiscard.Length;
            while (n > 1) 
            {
                int k = rng.Next(n--);
                CardType temp = currentDiscard[n];
                currentDiscard[n] = currentDiscard[k];
                currentDiscard[k] = temp;
            };

            return currentDiscard.ToList();
        }

        public void WarDraw() {
            // if !currentwar[0]) {

            // }

            for (int i = 0; i<amountPlayers; i++) {
                Boolean playing = currentWar[i].inWar;
                if (playing) {
                    
                }
                // String formatedCard = formatCard(currentCard);
                // Console.WriteLine(formatedCard);
            }
        }

        
        public void Handout() {
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
            List<CurrentWar> PrepareWar = new List<CurrentWar>();

            PrepareLayout.Add(0);
            for (int i = 0; i<amountPlayers; i++) {
                PrepareLayout.Add(0);
                PrepareHandout.Add(new WarLayout());
                PrepareWar.Add(new CurrentWar());
            }

            currentLayout = PrepareLayout.ToArray();
            currentWar = PrepareWar.ToArray();
            // CurrentWar[] currentwar

            int amountDivided = warDeck.deck.Length / amountPlayers;

            foreach(CardType deckCard in warDeck.deck) {
                int length = currentLayout.Length;
                if (currentLayout[0] == 0 || currentLayout[0]==amountPlayers) {
                    currentLayout[0] = 1; 
                } else {
                    currentLayout[0]++; 
                };

                int currentUserFrom0 = currentLayout[0]-1;
                int currentUserNumber = currentLayout[0];
                // if (currentLayout[currentUserNumber] == 0) {
                    
                // }
                if (currentLayout[currentUserNumber]!=amountDivided) {
                    currentLayout[currentUserNumber]++;

                    WarLayout newWar = new WarLayout();
                    newWar = PrepareHandout[currentUserFrom0];
                    newWar.currentCard++;

                    if (currentLayout[currentUserNumber]==1) {
                        newWar.currentlyPlaying = true;
                        newWar.deck = new List<CardType>();
                    }

                    newWar.deck.Add(deckCard);
                    PrepareHandout[currentUserFrom0] = newWar;
                };
            };

            WarHandout = PrepareHandout.ToArray();
            for (int j=0; j<WarHandout.Length; j++) {
                WarHandout[j].discardPile = new List<CardType>();
            };

            // Console.WriteLine(WarHandout[0].deck[0].cardNumber);
            // Console.WriteLine(WarHandout[0].deck[1].cardNumber);
            // Console.WriteLine(WarHandout[1].deck[3].cardNumber);
            // Console.WriteLine(WarHandout[2].deck[10].cardNumber);
        }
    }
}