namespace Solitaire.structs
{
    public struct CurrentWar
    {
        public Boolean inWar { get; set; }
        public int choosenWarCard { get; set; }
        public List<CardType> cardsInDraw { get; set; }
    }
}