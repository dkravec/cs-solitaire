namespace Solitaire.structs
{
    public struct WarLayout
    {
        public CardType[] deck { get; set; }
        public int[] currentCard { get; set; }
        public CardType[] discardPile { get; set; }
    } 
}