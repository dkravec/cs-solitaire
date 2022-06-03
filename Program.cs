using System.Text.Json;


namespace Solitaire 
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------");

            Deck myDeck = new Deck();
           //  Deck myDeck = new Deck();
            // myDeck.colour = "red";
            myDeck.Run();
            // myDeck.CardNum();
            // myDeck.changeColor("blue");

            // Console.WriteLine(myDeck.colour);
            // Console.ReadKey().Key;
            // returns capital letter

            myDeck.CalucateCards();

            gameTitle(myDeck);
        }

        public static void gameTitle(Deck myDeck) 
        {
           // Console.Clear();
            WriteConsole("Line", "Welcome to Solitaire!", "Red");

           // Console.WriteLine("Welcome to Solitaire!");
            WriteConsole("Line", "Press 'a' to run last saved game!", "Blue");
            WriteConsole("Line", "Press 'Enter' to begin a new game!", "Green");

            // waitingForKey();

            string keyPressed;
            bool validKey = false;
            
            do {
                keyPressed = Console.ReadKey(true).Key.ToString();
                if (keyPressed=="Enter") {
                    validKey=true;
                    NewGame(myDeck);
                } else if (keyPressed == "A") {
                    validKey=true;
                    Console.WriteLine("This will return to last saved game. (eventually)");
                } else {
                    Console.WriteLine("Invalid key pressed. Please try again.");
                }
            } while (validKey == false);

            bool keyPressedEscape = false;
            do {
                if (Console.ReadKey(true).Key.ToString() == "Escape") {
                    keyPressedEscape = true;
                    Console.WriteLine("Menu... (maybe)... (eventually)...");
                }
            } while (keyPressedEscape == false);

            // Console.WriteLine(keyPressed);

           // Console.WriteLine( );
           
            // characterWriteTest();
           
            Console.ReadLine();
            // Console.Clear();
            // drawCards();
            
        }

        public static void characterWriteTest() {
            WriteConsole("Inline", "[A]", "White");
            WriteConsole("Inline", "[1]", "Green");
            WriteConsole("Inline", "[2]", "Red");
            WriteConsole("Inline", "[3]", "Blue");

            var allColors = Enum.GetValues(typeof (ConsoleColor));

            foreach (var c in allColors)
            {
               // Console.WriteLine("[" + c + "]");
                WriteConsole("Line", "[" + c + "]", $"{c}");
                // Console.ForegroundColor = (ConsoleColor)c;
            }
        }

        public static void drawCards() 
        {
            Console.Clear();
            Console.WriteLine("Drawing cards");
            /* deck layout
                [?] [o]     [:] [:] [:] [:]


                [o] [?] [?] [?] [?] [?] [?] 
                [:] [o] [?] [?] [?] [?] [?]
                [:] [:] [o] [?] [?] [?] [?]
                [:] [:] [:] [o] [?] [?] [?]
                [:] [:] [:] [:] [o] [?] [?]
                [:] [:] [:] [:] [:] [o] [?]
                [:] [:] [:] [:] [:] [:] [o]

                o = revealed card
                ? = hidden card
                : = empty space
            */

        }

        public static void NewGame(Deck myDeck) 
        {
            // get possible cards
            myDeck.CalucateCards();

            // shuffle cards
            // CardType[] shuffledCards = myDeck.shuffleCards();
            myDeck.shuffleCards();

            
            // saving data
            SaveDataType saving = new SaveDataType();
            saving.SaveGameData(myDeck.deck[0]);
            saving.LoadData();

            // Shows each card in the deck (shuffled)
           //  Console.WriteLine(shuffledCards[0].cardNumber);
            String cardsStringCheck = "";

            for (int i = 0; i < myDeck.deck.Length; i++)
            {
               // Console.WriteLine(shuffledCards[i].cardNumber);
                CardType currentCard = myDeck.deck[i];
                // old
                // cardsStringCheck += currentCard.cardNumber + " " + currentCard.cardSuit + " ";
                cardsStringCheck += $"{currentCard.cardNumber} {currentCard.cardSuit} {currentCard.cardColour}\n";
            }
        
            Console.WriteLine(cardsStringCheck);
        }

        public static int SubNums(int a, int b)
        {
            int x = a - b;
            return x;
        }

        public static void WriteConsole(string writeType, string data, string foreground)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), foreground);

            if (writeType == "Inline") {
                Console.Write(data);
                Console.ResetColor();
            } else if (writeType == "Line") {
                Console.WriteLine(data);
                Console.ResetColor();
            } else {
                Console.WriteLine("Error: Invalid write type");
            }
        }
    }

    class SaveDataType
    {
        private string saveLocation = "./saves";

        public void SaveGameData(CardType card) {


            // List<CardType> _data = new List<CardType>();
            // _data.Add(card);

            /* try 1
            string json = JsonSerializer.Serialize(card);

            var newCardtest = new CardType
            {
                cardNumber = "4",
                cardSuit = "Spades",
                cardColour = "Red"
            };


            Console.WriteLine(newCardtest.cardNumber);

           string cardJson = JsonSerializer.Serialize(newCardtest);
            */

            /* try 2
            string jsonString = JsonSerializer.Serialize<CardType>(card);
            Console.WriteLine(jsonString);
            */

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(card, options);

            Console.WriteLine(jsonString);
            System.IO.File.WriteAllText($"{saveLocation}/saveData.json", jsonString);
        }
        public void LoadData() {

            string jsonString = File.ReadAllText($"{saveLocation}/saveData.json");
            CardType weatherForecast = JsonSerializer.Deserialize<CardType>(jsonString)!;
            Console.WriteLine(weatherForecast.cardNumber);

            // string mystring = File.ReadAllText($"{saveLocation}/saveData.json");
            // Console.WriteLine(mystring);
        }
    }

    struct CardType
    {
        public string cardNumber { get; set; }
        public string cardSuit { get; set; }
        public string cardColour { get; set; }
    } 
    
    /*
    struct GameDataType 
    {
        public int numDiscard;
        public string[] cardNumbers;
        public string[] cardSuits;
        public CardType[] cards;
        public CardType[] deck;
        public int[] currentDiscard;
    }
    */

    class Deck 
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