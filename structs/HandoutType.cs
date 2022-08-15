namespace Solitaire.structs
{
    public struct HandoutType
    {
        public CardType card { get; set; }
        // layout is which deck the card is in the handout
        public int layer { get; set; }

        // public string cardSuit { get; set; }
        // public string cardColour { get; set; }
    } 
}