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
       // public int[,] gridSize = {{},{}};

        public void GetGridSize() 
        {
            int[] gridSize = {0,0};
            int[] XGrid = {0,0};
            int[] YGrid = {0,0};
            gridSizeX[0] = 0;
            gridSizeX[1] = Console.WindowWidth;
            gridSizeY[0] = 0;
            gridSizeY[1] = Console.WindowHeight;
            //gridSize = { gridSizeX, gridSizeY };
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

              //  if (x==0) { Console.WriteLine("ok");}
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
                coordXRun2_2.x = gridSizeX[1];
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
            // check if currentCoords is in the border area
            // Console.WriteLine("Collision: " + moveX + "," + moveY );

            for (int i = 0; i < borderLocations.Length; i++) {
                // Console.WriteLine("Collision: " + moveX + "," + moveY + "," + borderLocations[i].x + "," + borderLocations[i].y);

                if (moveX == borderLocations[i].x && moveY == borderLocations[i].y) 
                // x3 == x3 && y4 == y4
                {
                Console.WriteLine("Collision: " + moveX + "," + moveY + "," + borderLocations[i].x + "," + borderLocations[i].y);

                  //   if (borderLocations[i].x == 1 && borderLocations[i].y == 10 || borderLocations[i].x == 1 && borderLocations[i].y == 1) {
                  //       return false;
                  //   }
                // -> 1,0 v 1,1
                    
                    // Console.Clear();

                    // Console.WriteLine("borderLocations[0] = " + borderLocations[i].x);
                    // Console.WriteLine("borderLocations[1] = " + borderLocations[i].y);
                    // Console.WriteLine("movingTo[0] = " + moveX);
                    // Console.WriteLine("movingTo[1] = " + moveY);
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

            // if (firstRun) {
            //    currentCoords[1] = 5;
            //    currentCoords[0] = 5;
            // }

            // userCoords = currentCoords;

            Boolean debug = false;

            if (key=="LeftArrow") 
            {
                userCoords[0] = currentCoords[0] - 1;
                // Console.WriteLine(userCoords[0] + "," + userCoords[1]);
                // Console.WriteLine(userCoords[0] + " " + currentCoords[1]);
                Boolean crash = HitCollision(userCoords[0], currentCoords[1]);
                // Console.WriteLine(gridSizeX[0] + "," + gridSizeX[1]);
                if (!crash && gridSizeX[0] <= userCoords[0] && userCoords[0] <= gridSizeX[1]) 
                // 0 <-3 && 
                {

                    // userCoord bigger than GridSizeX(small) and smaller than big size X
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
                    // userCoord bigger than GridSizeX(small) and samller than big size X
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
                    // grid top is bigger than userY | grid bottom smaller than userY
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
                    // grid top is bigger than userY | grid bottom smaller than userY
                    currentCoords[1] = userCoords[1];
                    // Console.WriteLine("Down | 1");
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
        /*
        public void MoveSelect(string key) 
        {
            GetGridSize();
            FllBorder();

            int[] userCoords = { gridSizeX[1]/2, gridSizeY[1]/2};
            int changedCoord = 0;

            if (firstRun) {
                currentCoords = userCoords;
                firstRun = false;
            }
            else {
                userCoords = currentCoords;
            }
            Console.WriteLine(userCoords[0]);
            Console.WriteLine(gridSizeX[0]);
            Console.WriteLine(gridSizeX[1]);
            Boolean HitGrid = false;

            if (key=="LeftArrow") 
            {
                if (gridSizeX[0] <= userCoords[0] && gridSizeX[1] >= userCoords[0]) 
                {
                    changedCoord = 1;
                    userCoords[0] = currentCoords[0] - 1;
                }
                else 
                {
                    HitGrid = true;
                }
            }
            else if (key=="RightArrow") 
            {
                if (gridSizeX[0] <= userCoords[0] && gridSizeX[1] >= userCoords[0]) 
                {
                    changedCoord = 1;
                    userCoords[0] = currentCoords[0] + 1;
                }
                else
                {
                    HitGrid = true;
                }
            }
            else if (key=="UpArrow") 
            {
                if (gridSizeY[0] <= userCoords[1] && gridSizeY[1] >= userCoords[1]) 
                {
                    changedCoord = 2;
                    userCoords[1] = currentCoords[1] - 1;
                }
                else
                {
                    HitGrid = true;
                }
            }
            else if (key=="DownArrow") 
            {
               // if 0 <= 3 && 10 >= 3
               // 0 <= 3, 3 <= 10 
               
                if (gridSizeY[0] <= userCoords[1] && gridSizeY[1] >= userCoords[1])  
                {
                    changedCoord = 2;
                    userCoords[1] = currentCoords[1] + 1;
                }
                else
                {
                    HitGrid = true;
                }
            }

            Boolean crash = HitCollision(userCoords);

            if (HitGrid) {
                Console.WriteLine("HitGrid");
            }
            if (!crash || !HitGrid) 
            {
                if (changedCoord == 1) {
                    currentCoords[0] = userCoords[0];
                }
                else if (changedCoord == 2) {
                    currentCoords[1] = userCoords[1];
                }
                else {
                    Console.WriteLine("Error");
                }
                Console.SetCursorPosition(currentCoords[0], currentCoords[1]);
                Console.Write("X");
                Console.SetCursorPosition(currentCoords[0], currentCoords[1]);
            }
        }
        */
    }
}