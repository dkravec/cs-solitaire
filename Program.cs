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
            WriteConsole("Line", "Press 'b' to play the card game, War!", "Blue");
            WriteConsole("Line", "Press 'Enter' to begin a new game!", "Green");
            WriteConsole("Line", "Clubs (♣), Diamonds (♦), Hearts (♥), and Spades (♠)", "Yellow");

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
                } else if (keyPressed == "B") {
                    validKey=true;
                    new WarGame().StartWarGame();
                    return;
                } else {
                    Console.WriteLine("Invalid key pressed. Please try again.");
                }
            } while (validKey == false);
            
           //  GameLoop();
            drawCards(myDeck);

            User myUser = new User();
            Layout myLayout = new Layout();
            myLayout.DrawDeck();
            myLayout.DrawDiscard();

           // bool keyPressedEscape = false;
            int[] currentCoords = {0,0};
            do {
                string keyPressedMovement = Console.ReadKey(true).Key.ToString();

                if (keyPressedMovement == "Enter") {
                    if ((myUser.currentCoords[0] == myLayout.DeckLocation[0]) && (myUser.currentCoords[1] == myLayout.DeckLocation[1])) {
                        Console.WriteLine(myUser.currentCoords[0] + ", " + myUser.currentCoords[1]);

                        CardType nextDiscard = myDeck.pickNextCard();
                        myLayout.DrawCardDiscord(nextDiscard);
                    };
                    
                }

                myUser.MoveSelect(keyPressedMovement);

                if (keyPressedMovement == "Escape") {
                   // keyPressedEscape = true;
                    Console.WriteLine("Menu... (maybe)... (eventually)...");
                }
            } while (true);
            //  Console.ReadLine();
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

        public static void drawCards(Deck myDeck) 
        {
            Console.Clear();
            Console.WriteLine("Drawing cards");

            int[,] coords = {
                // x , y , card
                {3, 3, 3},
                {5, 6, 5},
                {2, 4, 6},
                {4, 5, 7},
                {4, 6, 7}
            };

            for (int i = 0; i < coords.GetLength(0); i++)
            {
                Console.SetCursorPosition(coords[i, 0], coords[i, 1]);
                // Console.Write(myDeck.deck[coords[i, 2]].cardNumber);
                Console.SetCursorPosition(0, 0);

            }

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
            int current = 0;
            do {
                current++;
                Console.WriteLine("Game loop: " + current);
                await Task.Delay(10);
                // 1000 = 1s  = 1fps
                // 500 = 0.5s = 2fps
                // 250 = 0.25s = 4fps
                // 100 = 0.1s = 8fps
                // 50 = 0.05s = 16fps
                // 25 = 0.025s = 32fps
                // 10 = 0.01s = 64fps

            } while (true); 
        }
    }
}