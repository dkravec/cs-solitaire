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