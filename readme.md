# Solitare
Created by Daniel Kravec, on June 1st, 2022

## About
This is a project to help me learn C#, so the code may not be perfect. And some earlier commits may be confusing compared to what the final project with be, since i would be testing random stuff.

## Usage
Run "dotnet run" in the terminal with the project root folder as your entry point. this will automatically run Program.cs

## Version history
### 1.0 (1.2022.06.01)
- created base program.
- created a "Deck" class (also helped with learning classes in c#).
    - this will be used to keep data and functions to change those data easier.
- created layout for drawcards, which will be the terminal screen eventually.
- The program basically does nothing at this moment.

### 1.0 (2.2022.06.02)
- class Program (updated).
    - Renamed Deck to myDeck (from myObj).
    - Created a WriteConsole function, which writes to the console in colour.
    - Created function characterWriteTest, prints every possiblie colour for the console. (Commented out function) 
    - listens for your input.
        - a goes to a saved game (eventually).
        - enter goes to a new game (eventually).
        - you can press escape (even from in game) and it will show a menu (eventually...).
    - created NewGame function.
        - runs after pressing Enter.
        - calucate cards, shuffles, then saves one card to json file, then shows every single card in the console.
- struct CardType (new).
    - how cards are stored in a deck.
- class Deck (updated).
    - created a function that calucates the cards in a deck.
    - created a function that shuffles the cards in the deck (you can even add more cards later on).
    - Commented extra Deck data and functions that didnt need to be saved (colour, numCards, numDeck).
    - Created CheckCardColour function (even though it should have it already, i might remove the function later).
- class SaveDataType (new).
    - created functions to save and read data (currently for just one card).
    - Data can now be saved to /saves/saveData.json (for now, only saves first card in your shuffled deck).
- other
    - added /saves to .gitignore