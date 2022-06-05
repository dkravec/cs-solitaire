using Solitaire.structs;
using Solitaire.classes;

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

        public static void characterWriteTest() 
        {
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
           //  Console.WriteLine(myDeck.deck[0].cardNumber);
            saving.SaveGameData(myDeck);
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
}