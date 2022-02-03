using System;

namespace RatInMaze
{
    class RatMaze
    {
        static int mazeSize; // This will be our maze size  
        void printRatMaze(int[,] matrixSolution) // Prints to Console  
        {
            for (int i = 0; i < mazeSize; i++)
            {
                for (int j = 0; j < mazeSize; j++)
                    Console.Write(" " + matrixSolution[i, j] + " ");
                Console.WriteLine();
            }
        }
        bool isSafePositionForRat(int[,] maze, int x, int y) //safety check to see if valid index position for maze
        {
            return (x >= 0 && x < mazeSize && y >= 0 &&  y < mazeSize && maze[x, y] == 1); // guard to check if outside maze, if out returns false
        }
        bool solveRatMaze(int[,] maze4X4)  // Backtracking, utilizing (solveRateMazeHelper) returns false if no path, otherwise returns true and prints path to console (in form of 1's)
        {
            int[,] matrixSolution = new int[mazeSize, mazeSize];

            if (solveRatMazeHelper(maze4X4, 0, 0, matrixSolution) == false) 
            {
                Console.Write("Sorry there is no solution!");
                return false;
            }
            printRatMaze(matrixSolution);  //print actual path of solution
            return true;
        }
        bool solveRatMazeHelper(int[,] maze4X4, int x, int y, int[,] matrixSolution) //using recursion to solveRatMaze 
        {
            if (x == mazeSize - 1 && y == mazeSize - 1 && maze4X4[x, y] == 1)  //guard, if soltuion, then return true 
            {
                matrixSolution[x, y] = 1;
                return true;
            }
            if (isSafePositionForRat(maze4X4, x, y) == true)  //verify maze4X4 is valid
            {
                if (matrixSolution[x, y] == 1)    //check current position if part of solution
                    return false;

                matrixSolution[x, y] = 1; //mark (x,y) with 1, if part of solution

                if (solveRatMazeHelper(maze4X4, x + 1, y, matrixSolution))   //move forward in x
                    return true;
                if (solveRatMazeHelper(maze4X4, x, y + 1, matrixSolution))   //no solution x, then move down in y
                    return true;
                if (solveRatMazeHelper(maze4X4, x - 1, y, matrixSolution))   //no soloution y, then move backward in x
                    return true;
                if (solveRatMazeHelper(maze4X4, x, y - 1, matrixSolution))   //no solution in backward x, then move up in y
                    return true;
                matrixSolution[x, y] = 0;  //if nothing works, then backtrack while unmark (x,y) as part of solution
                return false;
            }
            return false;
        }
        public static void Main(String[] args)
        {
            RatMaze rat = new RatMaze();
            int[,] maze4X4 = { { 1, 0, 0, 0 },     //creating the maze size
                               { 1, 1, 0, 1 },
                               { 0, 1, 0, 0 },
                               { 1, 1, 1, 1 } };
           
            mazeSize = maze4X4.GetLength(1);
            rat.printRatMaze(maze4X4);    //prints created maze to console so we can double check solution when printed
            Console.WriteLine();
            rat.solveRatMaze(maze4X4); //calls code to check RatMaze
        }
    }
}