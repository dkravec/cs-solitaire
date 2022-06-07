namespace Solitaire.classes
{
    public class User
    {
        public int[] currentCoords = { 0, 0 };
        public int[] gridSizeX = { 0,0 };
        public int[] gridSizeY = { 0,0 };
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

        public void MoveSelect(string key) 
        {
            GetGridSize();

            int[] userCoords = {0,0};
            Boolean debug = false;

            if (key=="LeftArrow") 
            {
                userCoords[0] = currentCoords[0] - 1;

                if (gridSizeX[0] <= userCoords[0] && gridSizeX[1] >= userCoords[0]) 
                {
                    // userCoord bigger than GridSizeX(small) and samller than big size X
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
                if (gridSizeX[0] <= userCoords[0] && gridSizeX[1] >= userCoords[0]) 
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

                if (gridSizeY[0] <= userCoords[1] && gridSizeY[1] >= userCoords[1]) 
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
                if (gridSizeY[0] <= userCoords[1] && gridSizeY[1] >= userCoords[1]) 
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
    }
}