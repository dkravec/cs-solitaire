using Solitaire.structs;
namespace Solitaire.classes
{
    public class User
    {
        public int[] currentCoords = { 5, 5 };
        public int[] gridSizeX = { 0,0 };
        public int[] gridSizeY = { 0,0 };
        public borderLocationType[] borderLocations = {};
        public Boolean firstRun = true;

        Boolean debug = false;

        public void GetGridSize() 
        {
            int[] gridSize = {0,0};
            int[] XGrid = {0,0};
            int[] YGrid = {0,0};
            gridSizeX[0] = 0;
            gridSizeX[1] = Console.WindowWidth;
            gridSizeY[0] = 0;
            gridSizeY[1] = Console.WindowHeight;
        }

        public void FllBorder() {
            /*
  xGrid[0]  + + + + + + + + +  xGrid[1]
            +               +
            +               +
            +               +
            +               +
            + + + + + + + + +
          yGrid[0]       yGrid[1]
            */

            List<borderLocationType> ls = new List<borderLocationType>();

            for (int x = 0; x < gridSizeX[1]-1; x++) {
                borderLocationType coordXRun1 = new borderLocationType();
                borderLocationType coordXRun2 = new borderLocationType();
                coordXRun1.x = x;
                coordXRun1.y = 0;
                coordXRun2.x = x;
                coordXRun2.y = gridSizeY[1]-2;
                ls.Add(coordXRun1);
                ls.Add(coordXRun2);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(coordXRun1.x, coordXRun1.y);
                Console.WriteLine("+");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(coordXRun2.x, coordXRun2.y);
                Console.WriteLine("+");
            }

            for (int y = 0; y < gridSizeY[1]-1; y++) {
                borderLocationType coordXRun1_2 = new borderLocationType();
                borderLocationType coordXRun2_2 = new borderLocationType();
                coordXRun1_2.x = 0;
                coordXRun1_2.y = y;
                coordXRun2_2.x = gridSizeX[1]-1;
                coordXRun2_2.y = y;
                ls.Add(coordXRun1_2);
                ls.Add(coordXRun2_2);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(coordXRun1_2.x, coordXRun1_2.y);
                Console.WriteLine("+");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(coordXRun2_2.x, coordXRun2_2.y);
                Console.WriteLine("+");
            }
           
            borderLocations = ls.ToArray();

            Console.ResetColor();
            Console.SetCursorPosition(currentCoords[0], currentCoords[1]);
        }
        public Boolean HitCollision(int moveX, int moveY) {
            for (int i = 0; i < borderLocations.Length; i++) {
                // Console.WriteLine("Collision: " + moveX + "," + moveY + "," + borderLocations[i].x + "," + borderLocations[i].y);
                if (moveX == borderLocations[i].x && moveY == borderLocations[i].y) 
                {
                    if (debug) Console.WriteLine("Collision: " + moveX + "," + moveY + "," + borderLocations[i].x + "," + borderLocations[i].y);
                    return true;
                }
            }
            return false;
        }
        
        public void MoveSelect(string key) 
        {
            GetGridSize();
            FllBorder();

            int[] userCoords = {5,5};


            if (key=="LeftArrow") 
            {
                userCoords[0] = currentCoords[0] - 1;
                Boolean crash = HitCollision(userCoords[0], currentCoords[1]);

                if (!crash && gridSizeX[0] <= userCoords[0] && userCoords[0] <= gridSizeX[1]) 
                {

                    currentCoords[0] = userCoords[0];
                    if (debug) Console.WriteLine("Left | 1");
                }
                else 
                {
                    if (debug) Console.WriteLine("Left | 2");
                    if (debug) Console.WriteLine(userCoords[0] + "," + userCoords[1]);
                    if (debug) Console.WriteLine(gridSizeX[0] + "," + gridSizeX[1]);
                }
            }
            else if (key=="RightArrow") 
            {
                userCoords[0] = currentCoords[0] + 1;
                Boolean crash = HitCollision(userCoords[0], currentCoords[1]);

                if (!crash && gridSizeX[0] <= userCoords[0] && gridSizeX[1] >= userCoords[0]) 
                {
                    currentCoords[0] = userCoords[0];
                    if (debug) Console.WriteLine("Right | 1");
                }
                else 
                {
                    if (debug) Console.WriteLine("Right | 2");
                    if (debug) Console.WriteLine(userCoords[0] + "," + userCoords[1]);
                    if (debug) Console.WriteLine(gridSizeX[0] + "," + gridSizeX[1]);
                }
            }
            else if (key=="UpArrow") 
            {
                userCoords[1] = currentCoords[1] - 1;
                Boolean crash = HitCollision(currentCoords[0], userCoords[1]);

                if (!crash && gridSizeY[0] <= userCoords[1] && gridSizeY[1] >= userCoords[1]) 
                {
                    currentCoords[1] = userCoords[1];
                    if (debug) Console.WriteLine("Up | 1");
                }
                else 
                {
                    if (debug) Console.WriteLine("Up | 2");
                    if (debug) Console.WriteLine(userCoords[0] + "," + userCoords[1]);
                    if (debug) Console.WriteLine(gridSizeY[0] + "," + gridSizeY[1]);
                }
            }
            else if (key=="DownArrow") 
            {
                userCoords[1] = currentCoords[1] + 1;
                Boolean crash = HitCollision(currentCoords[0], userCoords[1]);

                if (!crash && gridSizeY[0] <= userCoords[1] && gridSizeY[1] >= userCoords[1]) 
                {
                    currentCoords[1] = userCoords[1];
                }
                else 
                {
                    if (debug) Console.WriteLine("Down | 2");  
                    if (debug) Console.WriteLine(userCoords[0] + "," + userCoords[1]);
                    if (debug) Console.WriteLine(gridSizeY[0] + "," + gridSizeY[1]);
                }
            }

            Console.SetCursorPosition(currentCoords[0], currentCoords[1]);
            Console.Write("X");
            Console.SetCursorPosition(currentCoords[0], currentCoords[1]);
        }
    }
}