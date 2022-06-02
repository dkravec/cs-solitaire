namespace Solitaire 
{
    class Program 
    {
        static void Main(string[] args)
        {
            Deck myObj = new Deck();
            myObj.colour = "red";
            myObj.Run();
            myObj.CardNum();
            myObj.changeColor("blue");
            Console.WriteLine(myObj.colour);
            gameTitle();
        }

        public static void gameTitle() 
        {
            // Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Welcome to Solitaire!");
            Console.WriteLine("Press 'Enter' to begin!");
            Console.ReadLine();
            Console.Clear();
            drawCards();
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

        public static int SubNums(int a, int b)
        {
            int x = a - b;
            return x;
        }

        public static void shuffleCards() 
        {
            Console.Clear();
            Console.WriteLine("Shuffling cards");

        }
    }

    class Deck 
    {
        public string colour = "blue";
        public int numCards = 52;
        public int numDeck = 52;
        public int numDiscard = 0;
        public int[] currentDiscard = { };

        public void Run() {
            Console.WriteLine(colour);
        }
        public void CardNum() {
            Console.WriteLine(numCards);
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
    }
}