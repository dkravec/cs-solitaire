namespace Solitaire.structs
{
    public struct GameDataType 
    {
        public int numDiscard;
        public string[] cardNumbers;
        public string[] cardSuits;
        public CardType[] cards;
        public CardType[] deck;
        public int[] currentDiscard;
    }
}