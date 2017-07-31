using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class gameBoardClass
    {

        //Set gameboard
        string[,] gameBoard = new string[4, 4];

        public void fillGameBoard()
        {
            for (int cols = 0; cols < 4; cols++)
            {
                //for each row
                for (int rows = 0; rows < 4; rows++)
                {
                    this.gameBoard[rows, cols] = "-";
                }
            }
            //Inital Values
            gameBoard[1, 1] = "2";
            gameBoard[3, 1] = "2";
            gameBoard[3, 3] = "2";
        }


        public void printOutGameBoard()
        {
            Console.Clear();
            Console.WriteLine("");
            for (int cols = 0; cols < 4; cols++)
            {
                Console.WriteLine("\n");
                //for each row
                for (int rows = 0; rows < 4; rows++)
                {
                    Console.Write(" [   " + gameBoard[rows, cols] + "   ]   ");

                }
            }
            Console.WriteLine();
        }

        //Bool Check to see if the selected x y coords are empty
        private bool checkIfEmpty(int x,int y)
        {
            // If the selected item in the array is empty return true
            if(gameBoard[x,y].Equals("-"))
            {
                return true;
            }
            return false;
        }

        //Win check, see if any of the strings have 2048
        public bool gameWinCheck()
        {
            foreach (string stringtocheck in gameBoard)
            {
                if (stringtocheck == "2048")
                {
                    return true;
                }
            }
            return false;
        }
         
        // THis is the game over check
        public bool gameOverCheck()
        {
            // Check all the strings in the gameboard to see if there
            // is any empty slots
            foreach (string stringtocheck in gameBoard)
            {
                // check each string to empty slot, if there is, return 
                //false meaning the game is still active
                if (stringtocheck == "-")
                {
                    return false;
                }
                else
                {
                    //if there is no empty places, check there are no moves
                    //possible, if there are , return false, else drop out of the loop
                    //return true
                    for (int row = 0; row < 4; row++)
                    {
                        for (int col = 0; col < 4; col++)
                        {
                            if (row < 3)
                            {
                                if (gameBoard[row, col].Equals(gameBoard[row + 1, col]))
                                {
                                    return false;
                                }
                            }
                            if (col < 3)
                            {
                                if (gameBoard[row, col].Equals(gameBoard[row, col + 1]))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

 

        private void placeNewTileOnBoard(int constantVariableForPositionAxis, string xy)
        {
            //Random
            Random rnd = new Random();
            // Need a 10 percent chance that it will drop a 4 tile
            int percentageChance = rnd.Next(0, 9);
            // Random position for the tile
            int randomSeedPosition = rnd.Next(0, 3);
            // Timeout, prevents infinate loop
            int tries = 0;
            string outputTile = "";
            // Switch based on the last direction placed so the tile
            // will output on the opposite side of the board
            if (percentageChance == 0)
            {
                outputTile = "4";
            }
            else
            { outputTile = "2"; }

            if (xy == "x")
            {
                while (!checkIfEmpty(constantVariableForPositionAxis, randomSeedPosition))
                {
                    randomSeedPosition = rnd.Next(0, 3);
                    tries++;
                    if (tries == 10)
                    {
                        break;
                    }
                }
                gameBoard[constantVariableForPositionAxis, randomSeedPosition] = outputTile;
            }
            else
            {
                while (!checkIfEmpty(randomSeedPosition,constantVariableForPositionAxis))
                {
                    randomSeedPosition = rnd.Next(0, 3);
                    tries++;
                    if (tries == 10)
                    {
                        break;
                    }
                }
                gameBoard[randomSeedPosition,constantVariableForPositionAxis] = outputTile;
            }
        }


        // THis is the function to place a new tile
        private void placeNewTile(string lastDirection)
        {
            switch (lastDirection)
            {
                case "left":
                    placeNewTileOnBoard(3,"x");
                    break;
                case "right":
                    placeNewTileOnBoard(0,"x");
                    break;
                case "up":
                    placeNewTileOnBoard(3, "y");
                    break;
                case "down":
                    placeNewTileOnBoard(0, "y");
                    break;
            }
        }




        // This method shifts the values in the array, couldnt not find
        // an efficent way to shift an array =[
        private void moveArrayToDirection(string Direction)
        {
            switch (Direction)
            {
                #region rightshift
                case "right":

                    for (int col = 3; col > -1; col--)
                    {
                        for (int rows = 0; rows < 4; rows++)
                        {
                            if (!gameBoard[col, rows].Equals("-"))
                            {
                                if (col < 3)
                                {
                                    if (gameBoard[col + 1, rows].Equals("-"))
                                    {
                                        for (int i = 3; i > -1; i--)
                                        {
                                            if (gameBoard[i, rows].Equals("-"))
                                            {
                                                gameBoard[i, rows] = gameBoard[col, rows];
                                                gameBoard[col, rows] = "-";
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                    break;
                #endregion
                #region leftshift
                case "left":
                    for (int col = 0; col < 4; col++)
                    {
                        for (int rows = 0; rows < 4; rows++)
                        {
                            if (!gameBoard[col, rows].Equals("-"))
                            {
                                if (col > 0)
                                {
                                    if (gameBoard[col - 1, rows].Equals("-"))
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            if (gameBoard[i, rows].Equals("-"))
                                            {
                                                gameBoard[i, rows] = gameBoard[col, rows];
                                                gameBoard[col, rows] = "-";
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    break;
                #endregion
                #region upshift
                case "up":
                    for (int col = 0; col < 4; col++)
                    {
                        for (int rows = 0; rows < 4; rows++)
                        {
                            if (!gameBoard[col, rows].Equals("-"))
                            {
                                if (rows > 0)
                                {
                                    if (gameBoard[col, rows - 1].Equals("-"))
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            if (gameBoard[col, i].Equals("-"))
                                            {
                                                gameBoard[col, i] = gameBoard[col, rows];
                                                gameBoard[col, rows] = "-";
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    break;
                #endregion
                #region downshift
                case "down":
                    for (int col = 3; col > -1; col--)
                    {
                        for (int rows = 3; rows > -1; rows--)
                        {
                            if (!gameBoard[col, rows].Equals("-"))
                            {
                                if (rows < 3)
                                {
                                    if (gameBoard[col, rows + 1].Equals("-"))
                                    {
                                        for (int i = 3; i > -1; i--)
                                        {
                                            if (gameBoard[col, i].Equals("-"))
                                            {
                                                gameBoard[col, i] = gameBoard[col, rows];
                                                gameBoard[col, rows] = "-";
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    #endregion
                    break;
            }

        }


        public void switchPositionFunction(int originRow, int originCol, int targetCol,int targetRow)
        {
            int numberToTransform;   
            Int32.TryParse(gameBoard[originRow, originCol], out numberToTransform);
            numberToTransform = numberToTransform * 2;
            gameBoard[targetCol, targetRow] = numberToTransform.ToString();
            gameBoard[originRow, originCol] = "-";   
        }

        //This function will deal with the movement of the game pieces,
        //the movement of the elements in the array is dealt with in the
        //moveArrayToDirection function
        public void doMovementAction(string Direction)
        {
            // Allows to turn the string array into an int for manuplation
            //for switching
            int numberTransform = 0;
            switch (Direction)
            {
                #region right movement
                case "right":
                    moveArrayToDirection("right");
                    /////Logic
                    for (int col = 3; col > -1; col--)
                    {
                        for (int rows = 0; rows < 4; rows++)
                        {
                            if (col < 3)
                            {
                                if ((gameBoard[col, rows].Equals(gameBoard[col + 1, rows]))&(!(gameBoard[col, rows].Equals("-"))))
                                {
                                    switchPositionFunction(col, rows, col+1, rows);
                                }
                                moveArrayToDirection("right");
                            }
                        }
                    }
                    placeNewTile("right");
                    break;

                #endregion
                #region left movement
                case "left":

                    moveArrayToDirection("left");
                    /////Logic
                    for (int col = 0; col <4; col++)
                    {
                        for (int rows = 0; rows < 4; rows++)
                        {
                            if (col < 3)
                            {
                                if ((gameBoard[col, rows].Equals(gameBoard[col + 1, rows])) & (!(gameBoard[col, rows].Equals("-"))))
                                {
                                     switchPositionFunction(col, rows, col+1, rows);
                                }
                                moveArrayToDirection("left");
                            }
                        }
                    }

                    placeNewTile("left");
                    break;
                    
                #endregion
                #region up movement
                case "up":


                    moveArrayToDirection("up");
                    /////Logic
                    for (int col = 0; col < 4; col++)
                    {
                        for (int rows = 0; rows < 4; rows++)
                        {
                            if (rows < 3)
                            {
                                if ((gameBoard[col, rows].Equals(gameBoard[col, rows+1])) & (!(gameBoard[col, rows].Equals("-"))))
                                {
                                    switchPositionFunction(col, rows, col, rows+1);
                                }
                                moveArrayToDirection("up");
                            }
                        }
                    }

                    placeNewTile("up");
                    break;
                    
                #endregion
                #region down movement
                case "down":
                    moveArrayToDirection("down");
                    /////Logic
                    for (int col = 0; col < 4; col++)
                    {
                        for (int rows = 3; rows >-1; rows--)
                        {
                            if (rows >0)
                            {
                                if ((gameBoard[col, rows].Equals(gameBoard[col, rows - 1])) & (!(gameBoard[col, rows].Equals("-"))))
                                {
                                    switchPositionFunction(col, rows, col, rows - 1);

                                }
                                moveArrayToDirection("down");
                            }
                        }
                    }
                    placeNewTile("down");
                    break;
                        #endregion


                    
            }
        }
    }
}





