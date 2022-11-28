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
- other.
    - added /saves to .gitignore.

### 1.0 (3.2022.06.03)
- started dividing classes and types from the main file (Deck and CardType).

### 1.0 (4.2022.06.04)
- Moved SaveDataType into a new file (in /classes).
- Renamed /types to /structs.
- added DeckJsonType.cs, to convert the Deck class into a json saveable object. 
- Now saves entire deck data to saveData.json.

### 1.0 (5.2022.06.05)
- Removed Deck.Run function.
- Removed extra commented out code from every file.
- Added GameLoop function, to test once its ready. (Loops every 1s)
- Created new GameDataType (from comments in Program.cs).

### 1.0 (6.2022.06.07)
- Commented out call to GameLoop function. 
- Updated GameLoop to tell which frame you are currently on.
- Where the function checks for escape button, program also checks for user movement.
- created drawCards function.
    - It is a prototype, it draws cards on points on the terminal. 
- Created new class, User.
    - 2 functions, GetGridSize, MoveSelect.
    - GetGridSize function checks your terminal size.
    - MoveSelect checks your input prevously, and moves accordingly.

### 1.0 (7.2022.06.09)
- Rewrote /classes/User.cs (then commented, then reworked).
- Created a border around the terminal, and stores the coordinates of each wall.
- Created a new function that checks the coordinates of the wall, and checks if you ran into it.
    - Currently only the right side is not working.
- Created new /structs/borderLocationType.cs, made it easier to save the data of the walls.

### 1.0 (8.2022.06.10)
- Removed extra comments.
- Fixed problem where it wouldnt understand the border on the left side. it was due to me not adding a -1 in the coordinate of the border itself.

### 1.0 (9.2022.06.11)
- Removed /saves from .gitignore, and replaced with /saves/* (when you run without the folder, it crashes)
- GetGridSize returns a Boolean to check if the grid remained the same size as last requested.
- Now only creates the border when the grid changed size.
- Removed myUser.GetGridSize from Program.cs. (unrequired)

### 1.0 (10.2022.06.19)
- Escape will now always be working when pressing Escape.
- Created new Layout.cs.
    - Draws the deck, and discard pile.
    - Will keep in place where piles are.
    - function to draw a card in the discard.
- Game draws deck, discard.
- In the main loop, it will now check if you pressed enter.
    - if you are where deck is, it will add a card in discard pile.

### 1.0 (11.2022.08.14)
- At gameTitle, it shows the card types with icons.
- added CalucateHandout in deck.cs.
    - it should calucate your handout (but it might not work, untested).
- Added type HandoutType.
    - keeps track of your layers in handout.

### 1.0 (12.2022.08.21)
- Created a new War game option.
- WarGame Class.
    - StartWarGame(), starts the game, and sets the deck and shuffles.
    - GameLoopWar(), which will draw new cards.
    - Handout(), attempts to divide cards to the different users (currently not finished)
    - formatCard(), which will be used once cards are drawn on screen.

### 1.0 (13.2022.08.22)
- Played around with setting methods of setting values. 
- Changed WarLayout from arrays to Lists.
- unsuccessful.

### 1.0 (14.2022.08.23)
- Successfully added cards to Users WarLayout on handout.
- Saves PrepareHandout to Global WarHandout.
- More commented testing.

### 1.0 (15.2022.08.24)
- Cleaned up testing code for dealing cards.
- added drawPlayerCards, gets the last card in the list, and saves it.
- Added CurrentWar, which will keep track of cards and war.
- added CheckWhoWins, not completed, but it will check the lastest played card.
- Handout() now prepares the war as well. 
- added currentlyPlaying to warLayout.

### 1.0 (16.2022.08.25)
- Updated GameLoopWar, it now checks for when you press enter, and runs drawPlayerCards().
- drawPlayerCards 
    - will check if your count is greater than 0
    - then run DiscardToDeck(), otherwise it will draw the card (not on the console but in a draw deck).
    - runs moveCardToDiscard after drawing a card.
- created moveCardToDiscard(), saves drawn card to discard pile, if deck is empty after ran, runs DiscardToDeck().
- updated CheckWhoWins(), (not completed), adds to an array and runs over that array and will later check who has the higher card.
- created convertCardtoNum(), will convert the card to a number, so its easier to check who won.
- created DiscardToDeck(), it will shuffle the discard and copy the list to the user deck.
-  Prepares discardpile when dealing cards.
- updated CurrentWar struct, to have drawnCardsWar, for the current war.
- updated WarLayout, added userID, and location. (both unused)

### 1.0 (17.2022.11.27)
- cleaned up war code, removed extra console logs.

bug fix
- 

## Helpful resources.

### Types
https://www.c-sharpcorner.com/article/c-sharp-list/