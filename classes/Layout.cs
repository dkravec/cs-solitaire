using Solitaire.structs;

namespace Solitaire.classes
{
    public class Layout
    {
        public Boolean cardInDeck = true;

        public Boolean cardInDiscard = false;

        public int[] DeckLocation = { 2, 2 };
        public int[] DiscardLocation = { 8, 2 };

        public void DrawDeck() {
            Console.SetCursorPosition(DeckLocation[0], DeckLocation[1]);
            if (cardInDeck) {
                Console.Write("[x]");
            } else {
                Console.Write("[ ]");
            }
        }

        public void DrawDiscard() {
            Console.SetCursorPosition(DiscardLocation[0], DiscardLocation[1]);
            if (cardInDiscard) {
                Console.Write("[x]");
            } else {
                Console.Write("[ ]");
            };
        }
        public void DrawCardDiscord(CardType card) {
            Console.SetCursorPosition(DiscardLocation[0], DiscardLocation[1]);
            Console.Write("[" + card.cardNumber + "]");
        }
        /*
            card locations


            +++++++++++
            +         +
            +   >[c]  +
            +      [c]+
            +++++++++++
        */
    }
}