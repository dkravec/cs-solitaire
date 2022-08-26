namespace Solitaire.structs
{
    public struct WarLayout
    {
        public List<CardType> deck { get; set; }
        public Boolean currentlyPlaying { get; set; }
        public int currentCard { get; set; }

        public int userID { get; set;}
        public List<CardType> discardPile { get; set; }

        public int[][] location { get; set; }
        // current location of cards
        /*
            [ x, y ], warCardOn
            [ x, y ], card
            [ x, y ] card
        */
    }
}