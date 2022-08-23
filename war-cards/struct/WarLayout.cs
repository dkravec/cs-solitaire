namespace Solitaire.structs
{
    public struct WarLayout
    {
        public List<CardType> deck { get; set; }
        public int currentCard { get; set; }
        public List<CardType> discardPile { get; set; }
    }
}