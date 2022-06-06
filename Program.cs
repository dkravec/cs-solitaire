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

            myDeck.CalucateCards();

            gameTitle(myDeck);
        }

        public static void gameTitle(Deck myDeck) 
        {
            Console.Clear();
            
            WriteConsole("Line", "Welcome to Solitaire!", "Red");
            WriteConsole("Line", "Press 'a' to run last saved game!", "Blue");
            WriteConsole("Line", "Press 'Enter' to begin a new game!", "Green");

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
            
            GameLoop();

            bool keyPressedEscape = false;
            do {
                if (Console.ReadKey(true).Key.ToString() == "Escape") {
                    keyPressedEscape = true;
                    Console.WriteLine("Menu... (maybe)... (eventually)...");
                }
            } while (keyPressedEscape == false);

            Console.ReadLine();
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
                WriteConsole("Line", "[" + c + "]", $"{c}");
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
            myDeck.shuffleCards();

            // saving data
            SaveDataType saving = new SaveDataType();
            saving.SaveGameData(myDeck);
            saving.LoadData();

            // Shows each card in the deck (shuffled)
            String cardsStringCheck = "";

            for (int i = 0; i < myDeck.deck.Length; i++)
            {
                CardType currentCard = myDeck.deck[i];
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

        public static async void GameLoop() {
            do {
                Console.WriteLine("Game loop");
                await Task.Delay(1000);
            } while (true); 
        }
    }
}