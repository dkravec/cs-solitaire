using Solitaire.structs;
using Solitaire.classes;
using System.Text.Json;

namespace Solitaire.classes
{
    public class SaveDataType
    {
        private string saveLocation = "./saves";

        public void SaveGameData(Deck deck) {
            // Create a new DeckJsonType object to store the deck data
            DeckJsonType deckJson = new DeckJsonType();

            deckJson.numDiscard = deck.numDiscard;
            deckJson.cardNumbers = deck.cardNumbers;
            deckJson.amountJokers = deck.amountJokers;
            deckJson.cardSuits = deck.cardSuits;
            deckJson.cards = deck.cards;
            deckJson.deck = deck.deck;
            deckJson.currentDiscard = deck.currentDiscard;
            
            // Console.WriteLine(deckJson.deck[0].cardNumber);

            // List<CardType> _data = new List<CardType>();
            // _data.Add(card);

            /* try 1
            string json = JsonSerializer.Serialize(card);

            var newCardtest = new CardType
            {
                cardNumber = "4",
                cardSuit = "Spades",
                cardColour = "Red"
            };


            Console.WriteLine(newCardtest.cardNumber);

           string cardJson = JsonSerializer.Serialize(newCardtest);
            */

            /* try 2
            string jsonString = JsonSerializer.Serialize<CardType>(card);
            Console.WriteLine(jsonString);
            */

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(deckJson, options);

            Console.WriteLine(jsonString);
            System.IO.File.WriteAllText($"{saveLocation}/saveData.json", jsonString);
        }
        public void LoadData() {

            string jsonString = File.ReadAllText($"{saveLocation}/saveData.json");
            CardType weatherForecast = JsonSerializer.Deserialize<CardType>(jsonString)!;
            Console.WriteLine(weatherForecast.cardNumber);

            // string mystring = File.ReadAllText($"{saveLocation}/saveData.json");
            // Console.WriteLine(mystring);
        }
    }
}