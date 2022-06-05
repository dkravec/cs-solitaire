namespace Solitaire.structs
{
    public struct DeckJsonType
    {
        public int numDiscard { get; set; }
        public string[] cardNumbers { get; set; }
        public int amountJokers { get; set; }
        public string[] cardSuits { get; set; }
        public CardType[] cards  { get; set; }
        public CardType[] deck { get; set; }
        public int[] currentDiscard  { get; set; }
    }
}