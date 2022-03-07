using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzlle_Solver
{
    public partial class sudokuSolver : Form
    {
        // initialise as global arrays for each puzzle to be used throughout the programme
        int[,] puzzleEasy = new int[9, 9]  {
            { 3, 2, 1, 0, 0, 7, 9, 0, 6 },
            { 0, 4, 0, 9, 0, 1, 0, 0, 0 },
            { 9, 0, 0, 4, 2, 6, 0, 3, 0 },
            { 0, 5, 2, 0, 7, 0, 1, 0, 0 },
            { 0, 8, 0, 2, 4, 0, 7, 0, 0 },
            { 0, 0, 7, 0, 0, 0, 3, 8, 2 },
            { 7, 0, 9, 8, 0, 0, 0, 5, 0 },
            { 2, 0, 0, 7, 5, 4, 0, 0, 0 },
            { 0, 1, 4, 0, 9, 0, 0, 0, 8 }
            };

        int[,] puzzleMedium = new int[9, 9]  {
            { 6, 0, 0, 0, 8, 7, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 4, 1, 0, 2 },
            { 1, 0, 0, 5, 0, 0, 0, 0, 0 },
            { 5, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 3, 9, 0, 0 },
            { 3, 0, 0, 0, 0, 0, 2, 7, 0 },
            { 0, 0, 9, 0, 0, 0, 3, 0, 0 },
            { 0, 0, 0, 0, 7, 1, 4, 0, 0 },
            { 0, 0, 2, 6, 0, 0, 0, 0, 1 }
            };

        int[,] puzzleHard = new int[9, 9]  {
            { 0, 0, 0, 3, 5, 6, 2, 0, 0 },
            { 4, 0, 2, 0, 0, 0, 5, 0, 0 },
            { 0, 7, 0, 0, 0, 0, 0, 1, 0 },
            { 8, 0, 0, 0, 4, 0, 0, 7, 0 },
            { 0, 5, 0, 0, 3, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 3, 0, 9 },
            { 0, 0, 4, 1, 6, 5, 0, 0, 0 },
            { 0, 0, 9, 0, 0, 0, 0, 0, 0 },
            { 1, 6, 0, 7, 0, 0, 0, 0, 0 }
            };

        
    

        int[,,] psblty = new int[9, 9, 9];//initialises new 3d array of size 9 by 9 by 9. used to keep track of psblty of each cell
        int[,] difficulty = new int[9, 9];//initialiss new 2d array of size 9 by 9. used to keep track of numbers in each cell


        Pen gridPen = new Pen(Brushes.Black, 2);// used as global pen so can change wherever
        Font gridFont = new Font("Arial", 33);// global font for panel so you can add wherever used for solved numbers
        Font notesFont = new Font("Arial", 9);//global font for panel used to write noes


        public sudokuSolver()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            setPsblty();//sets possibilities for each cell to have numbers from 1 to 9
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // stops running the program when you close the form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu f1 = new Menu();
            f1.ShowDialog();    // when the menu button is pressed it will go back to the main menu and hide the sudoku solver form
        }       

        private void setPsblty()
        {

            for (int y = 0; y <= 8; y++)//loops for rows
            {
                for (int x = 0; x <= 8; x++)//loops for columns
                {
                    for (int z = 0; z <= 8; z++)//loops for numbers 1 to 9
                    {
                        psblty[y, x, z] = z + 1;//sets each coordinate to have numbers 1 to 9 (possibilities)
                    }
                }
            }
        }

        private void checkNotes(int[,] puzzle)
        {
            checkRows(puzzle);
            checkColumns(puzzle);
            checkCage(puzzle);//applies all 3 functions to puzzle
            fillNotes(puzzle);//updates the grid notes
        }


        public void fillCells(int[,] puzzle)//will fill in the cells with numbers based on diffuculty chosen

        {

            Graphics grid = panel1.CreateGraphics();
            float x = 3f;//sets and x and y to starting point for writing
            float y = 3f;
            float xDiff = panel1.Width / 9f;// finds increment for 9 grids based on size of panel
            float yDiff = panel1.Height / 9f;


            for (int row = 0; row <= 8; row++)
            {
                for (int col = 0; col <= 8; col++)
                {
                    int number = puzzle[col, row];//gets the number for the cell based on the puzzle difficulty
                    if (number != 0)//checks if the cell should be empty
                    {

                        clearCell(col, row);
                        grid.DrawString(number.ToString(), gridFont, Brushes.Black, x, y);// writes the number allocated into the cell
                    }
                    x += xDiff;//increments x for next num
                }
                x = 3f;//sets x back to 3 for new row
                y += yDiff;//increments y for next num
            }
        }

        public void fillNotes(int[,] puzzle)
        {

            Graphics grid = panel1.CreateGraphics();
            float x = 3f;
            float y = 3f;//distance between each number
            float xDiff = panel1.Width / 9f;
            float yDiff = panel1.Height / 9f;//distance between each cell
            float xSmallerInc = xDiff / 3f;// give values for the x and y incrementations of the notes
            float ySmallerInc = yDiff / 3f;

            for (int row = 0; row <= 8; row++)
            {
                for (int col = 0; col <= 8; col++)
                {
                    int number = puzzle[col, row];//gets the number for the cell based on the puzzle difficulty                    
                    if (number == 0)//checks if the cell should be empty
                    {
                        clearCell(col, row);//resets cell to write new notes onto
                        for (int i = 0; i <= 2; i++)//loops for each row and column of the notes
                        {
                            for (int j = 0; j <= 2; j++)
                            {

                                if (psblty[col, row, i * 3 + j] != 0)
                                {
                                    grid.DrawString(psblty[col, row, i * 3 + j].ToString(), notesFont, Brushes.DarkBlue, x, y);// writes number                                                                       
                                }

                                x += xSmallerInc;//increments x

                            }
                            x -= xDiff;// resets x back to x pos of same cell for next row
                            y += ySmallerInc;// increments y
                        }
                        y -= yDiff;// resets y back to y pos of the cell for the next cell
                    }
                    x += xDiff;//increments x for next num
                }
                x = 3f;//sets x back to 3 for new row
                y += yDiff;//increments y for next num
            }

        }//will fill the puzzle with the puzzle notes for the empty cells 

        public void clearCell(int x, int y)//parses index of cell being cleared
        {
            Graphics grid = panel1.CreateGraphics();//allows updates on the grid
            Brush eraserBrush = new SolidBrush(this.BackColor);//new brush used to as a eraser

            float startPosX;
            float startPosY;
            float xincrement = 2f;
            float yincrement = 2f;
            float xLength = panel1.Width / 9f - (7 / 2f);
            float yLength = panel1.Height / 9f - (7 / 2f);//intialises all the correct increments to the variables
            if (x % 3 == 0)//if cell is to the right of a bold grid line
            {
                xincrement = 5f;//increases increment value

            }
            else if ((x + 2) % 3 == 0)//if cell is to the left of a bold grid line
            {
                xLength = panel1.Width / 9f - 2;//decrease increment value
            }
            if (y % 3 == 0)//if cell is below a bold grid line
            {
                yincrement = 5f;//increases increment
            }
            else if ((y + 2) % 3 == 0)
            {//if cell is above a bold grid line
                yLength = panel1.Height / 9f - 2;//decreases increment balue
            }
            startPosX = (x * panel1.Width / 9f) + xincrement / 2f;
            startPosY = (y * panel1.Height / 9f) + yincrement / 2f;//finalises starting positions

            grid.FillRectangle(eraserBrush, startPosX, startPosY, xLength, yLength);// clear cell making it background colour
        }


        public void drawGrid()
        {
            float length = panel1.Width / 9f;
            float width = panel1.Height / 9f;
            Graphics grid = panel1.CreateGraphics();

            float x = 0f;//sets starting points for x and y to the top left
            float y = 0f;
            float xDiff = panel1.Width / 9f;// finds increment for 9 grids based on size of panel
            float yDiff = panel1.Height / 9f;


            for (int i = 0; i <= 9; i++)// loops 10 times to draw 10 lines vertically
            {
                if ((i % 3) == 0)// every 3rd line it will make bold
                {
                    gridPen = new Pen(Brushes.Black, 5);//bold
                }
                else
                {
                    gridPen = new Pen(Brushes.Black, 2);//resets pen
                }
                grid.DrawLine(gridPen, x, y, x, panel1.Height);// draws line vertically
                x += xDiff;//increments for next line
            }

            x = 0;//resets x 
            for (int j = 0; j <= 9; j++)// loops 10 times to draw 10 lines horizontally
            {
                if ((j % 3) == 0)// every 3rd line it will make bold
                {
                    gridPen = new Pen(Brushes.Black, 5);//bold
                }
                else
                {
                    gridPen = new Pen(Brushes.Black, 2);//resets pen
                }

                grid.DrawLine(gridPen, x, y, panel1.Width, y);// draws line horizontally
                y += yDiff;//increments for next line
            }

        }//draws the rows and columns when called

        


        public void checkRows(int[,] puzzle)//no numbers can repeate in same row
        {
            for (int y = 0; y <= 8; y++)
            {
                for (int x = 0; x <= 8; x++)//loops for all cells in puzzle
                {
                    if (puzzle[x, y] != 0) //checks if cell is not empty
                    {
                        int number = puzzle[x, y];//takes numbner in cell
                        for (int i = 0; i <= 8; i++)
                        {
                            psblty[i, y, number - 1] = 0;// removes number as a possibility from other cells in same row
                        }
                    }
                }
            }

        }

        public void checkColumns(int[,] puzzle)//no numbers can repeat in the same column
        {

            for (int y = 0; y <= 8; y++)
            {
                for (int x = 0; x <= 8; x++)//loops for all cells in puzzle
                {
                    if (puzzle[x, y] != 0)//checks if cell is not empty
                    {
                        int number = puzzle[x, y];
                        for (int i = 0; i <= 8; i++)//takes numbner in cell
                        {
                            psblty[x, i, number - 1] = 0;// removes number as a possibility from other cells in same column
                        }
                    }
                }
            }
        }

        public void checkCage(int[,] puzzle)//no numbers can repeat in the same cage
        {
            for (int y = 0; y <= 8; y++)
            {
                for (int x = 0; x <= 8; x++)//loops for all cells in the puzzle
                {
                    if (puzzle[x, y] != 0)//checks for cells to be not empty
                    {
                        int number = puzzle[x, y];//takes number from that cell 
                        for (int yCage = 0; yCage <= 2; yCage++)//loops for height of one cage
                        {
                            int xBox = x / 3;//uses div function to find which cage it is in along the x axis
                            int yBox = y / 3;//uses div function to find which cage it is in along the y axis
                            for (int xCage = 0; xCage <= 2; xCage++)//loops for width of one cage
                            {
                                psblty[(xBox * 3) + xCage, (yBox * 3) + yCage, number - 1] = 0;//removes number as a possibility from cells in same cage
                            }
                        }
                    }
                }
            }
        }


        public Boolean hiddenSingles(int[,] puzzle)//calls all 3 hidden singles algorithms at the same time
        {

            bool cageUsed = hiddenSinglesCage(puzzle);//calls all 3 hidden single algorithm and updates notes in between each one
            checkNotes(puzzle);
            bool colUsed = hiddenSinglesCol(puzzle);
            checkNotes(puzzle);
            bool rowUsed = hiddenSinglesRow(puzzle);
            checkNotes(puzzle);
            if (cageUsed || colUsed || rowUsed)// checks if any of three algorithms are used
            {
                return true;// returns true if any are
            }
            else
            {
                return false;// returns false if any arent
            }
        }
        public Boolean hiddenSinglesCage(int[,] puzzle)
        {
            bool used = false;//true or false based on if the algorithm has been used  
            for (int yCage = 0; yCage <= 2; yCage++)
            {
                for (int xCage = 0; xCage <= 2; xCage++)//loops for all cages
                {
                    for (int number = 0; number <= 8; number++)//loops for all numbers
                    {
                        int counter = 0;//tracks number of times the number pops up as a possibility in a cage
                        int coordX = 0;
                        int coordY = 0;//used to track coords of the cell needed to change
                        for (int y = 0; y <= 2; y++)
                        {
                            for (int x = 0; x <= 2; x++)//loops for all numbers in cage
                            {
                                if ((psblty[(xCage * 3) + x, (yCage * 3) + y, number] == number + 1) && (puzzle[(xCage * 3) + x, (yCage * 3) + y] == 0))//checks if cell has notes for number and if it is empty
                                {// checks cell is empty and it has possibility number
                                    counter++;//increments the counter
                                    coordX = (xCage * 3) + x;
                                    coordY = (yCage * 3) + y;//tracks coords of latest cell with a possibility of the number
                                }
                            }
                        }
                        if (counter == 1)
                        {
                            used = true;//the algorithm has been used to solve so changes used value to true
                            highlightNumber(coordX, coordY, number, true,true);//highlights number that is about to be solvde
                            puzzle[coordX, coordY] = number + 1;// solves cell on board with number
                            int cage = coordX / 3 + ((coordY / 3)*3) + 1;// finds cage number using x and y values
                            richTextBox1.Text += string.Format("Hidden Single: {0} only appears once in cage {3} solve cell ({2},{1})", (number + 1), coordY + 1, Convert.ToChar(65 + coordX),cage);//ouputs annotations based what has happened
                            richTextBox1.Text += Environment.NewLine;//new line for text box
                        }
                    }
                }
            }
            return used;// returns value of used

        }

        public Boolean hiddenSinglesRow(int[,] puzzle)
        {
            bool used = false;//true or false based on if the algorithm has been used
            for (int y = 0; y <= 8; y++)//loops for all rows
            {
                for (int number = 0; number <= 8; number++)//loops for all the 9 numbers
                {
                    int counter = 0;//checks to see appearences of a number
                    int coordX = 0;
                    int coordY = 0;//resest all these variables to 0

                    for (int x = 0; x <= 8; x++)//loops through all numbers in one row
                    {
                        if ((psblty[x, y, number] == number + 1) && (puzzle[x, y] == 0))//checks for number as a psblty in current cell and if cell is empty
                        {
                            counter++;//increments counter
                            coordX = x;
                            coordY = y;//stores coords of latest cell with number as a possibility
                        }
                    }
                    if (counter == 1)//if number only appears once as a psblty 
                    {
                        used = true;//algorithm has been used
                        highlightNumber(coordX, coordY, number, true,true);//highlights number in cell blue to show it is about to be solved
                        puzzle[coordX, coordY] = number + 1;//update puzzle array solves number in cell
                        richTextBox1.Text += string.Format("Hidden Single: {0} only appears once in row {1} solve cell ({2},{1})",(number +1),coordY+1,Convert.ToChar(65+coordX));//outputs annotation with parameters explaining what happened
                        richTextBox1.Text += Environment.NewLine;
                    }
                }

            }
            return used;//returns used
        }

        public Boolean hiddenSinglesCol(int[,] puzzle)
        {
            bool used = false;//true or false based on if the algorithm has been used
            for (int x = 0; x <= 8; x++)//loops for all rows
            {
                for (int number = 0; number <= 8; number++)//loops for all the 9 numbers
                {
                    int counter = 0;//checks to see appearances of a number reset s to 0 
                    int coordX = 0;
                    int coordY = 0;//resets coords

                    for (int y = 0; y <= 8; y++)//loops through all numbers in one row
                    {
                        if ((psblty[x, y, number] == number + 1) && (puzzle[x, y] == 0))//checks for number as psblty in the cell and if cell is empty
                        {
                            counter++;// increments counter
                            coordX = x;
                            coordY = y;//stores coords of latest cell with number as a psblty
                        }
                    }
                    if (counter == 1)//checks if number appears only once
                    {
                        used = true;//algorithm has been used
                        highlightNumber(coordX, coordY, number, true,true);//highlights the number in the cell blue to show it is about to be solved
                        puzzle[coordX, coordY] = number + 1;//updates puzzle array with that number
                        richTextBox1.Text += string.Format("Hidden Single: {0} only appears once in col {2} solve cell ({2},{1})", (number + 1), coordY + 1, Convert.ToChar(65 + coordX));//ouputs annotation wiht paremeters explaining what happened
                        richTextBox1.Text += Environment.NewLine;
                    }
                }

            }
            return used;//returns used
        }


        public Boolean SolvedCells(int[,] puzzle)
        {
            int number = 0;//initilises number to be used throughout function
            bool used = false;//tells you whether the algorithm has been used or not
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)//loops for all cells in puzzle
                {
                    int counter = 0;//reset counter
                    if (puzzle[x, y] == 0)//checks if empty
                    {
                        for (int i = 0; i < 9; i++)//loops for numbers 1 to 9
                        {
                            if (psblty[x, y, i] == 0)//checks possibilities of that cell
                            {
                                counter += 1;//increments counter
                            }
                            else
                            {
                                number = psblty[x, y, i];//updates value of number

                            }
                        }

                        if (counter == 8)//if there is 8 empty psblty spots then remaining number must go there
                        {
                            used = true;
                            highlightNumber(x, y, number - 1, true,true);//takes in all parameters for highlighting number
                            puzzle[x, y] = number;//updates puzzle array
                            richTextBox1.Text += "Solved Cell: "+number.ToString() +" only possibility in cell ("+Convert.ToChar(65+x).ToString()+","+(1+y).ToString()+")";//outputs message with parameters explaining what happened
                            richTextBox1.Text += Environment.NewLine;

                        }
                    }

                }
            }
            return used;//returns used


        }

        public Boolean nakedPairsCol(int[,] puzzle)
        { 
            bool used = false;
            for(int x = 0; x<= 8; x++)//loops for all col
            {
                int pairCounter = 0;//resets
                int[] numOfPsblty = new int[9];//new array to count amount of psbltys in each cell     
                for (int y = 0; y <= 8; y++)//loops for rows
                {
                    if (puzzle[x, y] == 0)//checks if cell is empty
                    {
                        for (int number = 0; number <= 8; number++)//loops for all numbers
                        {

                            if (psblty[x, y, number] == number + 1)//checks if number is a psblty
                            {
                                numOfPsblty[y] += 1;//increments
                            }

                        }
                        if(numOfPsblty[y] == 2)//checks if there is only 2 psblty
                        {
                            pairCounter +=1;//increments
                        }
                    }
                }
                if(pairCounter >= 2)//checksif there are 2 or more pairs
                {
                    int[] pairCoords = new int[pairCounter];//creates new of length pairCounter
                    int indexCounter = 0;//resets
                    for (int y2 = 0; y2 <= 8; y2++)//loops for all rows
                    {
                        if (numOfPsblty[y2] == 2)//checks number of posbilities of each cell in a column
                        {
                            //if they are = 2
                            pairCoords[indexCounter] = y2;//stores that index into pairCoords array
                            indexCounter++;//increments
                        }
                    }
                    for(int i = 0; i < pairCounter-1; i++)//loop used to test each combination of indexes of pair cells
                    {
                        int number1 = 0;
                        int number2 = 0;//used to track numbers in the cells
                        for (int num = 0; num <=8 ; num++)//loops for all numbers
                        {
                            if(puzzle[x, pairCoords[i]] == 0)//checks if cell is empty
                            {
                                if (psblty[x, pairCoords[i], num] == num + 1)//checks if cell has num as a psblty
                                {
                                    if (number1 == 0)//first encounter will always be the smaller one
                                    {
                                        number1 = num;//stores num value
                                    }
                                    else//every other encounter
                                    {
                                        number2 = num;//stores num value
                                    }
                                }
                            }                                                                                
                        }
                        for(int j = 0; j < pairCounter - i-1; j++)//loop used to test all combinations of indexes of pair cells
                        {
                            int number3 = 0;
                            int number4 = 0;//track numbers
                            for (int num2 = 0; num2 <= 8; num2++)//loops for all numbers
                            {
                                if (psblty[x, pairCoords[j+i+1], num2] == num2 + 1)//checks one of the cells containing pairs
                                    if (number3 == 0)//first encounter will always be the smaller one
                                    {
                                        number3 = num2;
                                    }
                                    else//second encounter
                                    {
                                        number4 = num2;
                                    }

                            }
                            if ((number1 == number3) && (number2 == number4))//checks if numbers in both cells are the same
                            {
                                
                                for (int y3 = 0; y3 <= 8; y3++)//loops for all rows
                                    {
                                    if (puzzle[x, y3] == 0) //checks if cell is empty
                                    {
                                        if ((y3 != pairCoords[i]) && (y3 != pairCoords[j+i+1]))//checks if current cel is the same as eiter of the cells with pairs in them
                                        {
                                            
                                            if (psblty[x, y3, number1] != 0)//checks if psblty of cell is already 0
                                            {
                                                psblty[x, y3, number1] = 0;//removes number1 as psblty from that cell
                                                highlightNumber(x, y3, number1, true, false);//highlights number that was just removed red
                                                highlightNumber(x, pairCoords[i], number1, false, false);
                                                highlightNumber(x, pairCoords[j + i + 1], number1, false, false);//highlights the cells which caused the algorithm to occur
                                                char asciiX = Convert.ToChar(x + 65);//converts coords to ascii for annotations
                                                richTextBox1.Text += String.Format("Naked Pairs Col: pair of {0}s and {1}s  in column {2} rows {4} and {5} remove {0} from cell ({2},{3})", number1+1,number2+1, asciiX,y3+1,pairCoords[i]+1, pairCoords[j + i + 1]+1);
                                                //outputs annotations using parameters for coords and numbers
                                                richTextBox1.Text += Environment.NewLine;
                                                used = true;//algorithm has been used
                                            }
                                            if (psblty[x, y3, number2] != 0)
                                            {
                                                psblty[x, y3, number2] = 0;//removes number2 as psblty from that cell
                                                highlightNumber(x, y3, number2, true, false);//highlights number that was just removed red
                                                highlightNumber(x, pairCoords[i], number2, false, false);
                                                highlightNumber(x, pairCoords[j + i + 1], number2, false, false);//highlights the cells which caused the algorithm to occur
                                                char asciiX = Convert.ToChar(x + 65);//converts coords to ascii for annotations
                                                richTextBox1.Text += String.Format("Naked Pairs Col: pair of {0}s and {1}s in column {2} rows {4} and {5} removed {1} from cell ({2},{3})", number1+1,number2+1, asciiX, y3+1, pairCoords[i]+1, pairCoords[j + i + 1]+1);
                                                //outputs annotations using parameters for coords and numbers
                                                richTextBox1.Text += Environment.NewLine;
                                                used = true;//algorithm has been used
                                            }
                                        }
                                    }
                                                                        
                                }
                                
                            }
                        }
                        
                    }
                }
                
            }
            return used;//returns true or false based on whether algorithm was used
        }

        public Boolean nakedPairsRow(int[,] puzzle)
        {
            bool used = false;
            for(int y = 0; y<= 8; y++)
            {
                int pairCounter = 0;//resets
                int[] numOfPsblty = new int[9];//new array to count amount of psbltys in each cell     
                for (int x = 0; x <= 8; x++)//loops for columns
                {
                    if (puzzle[x, y] == 0)//checks if cell is empty
                    {
                        for (int number = 0; number <= 8; number++)//loops for all numbers
                        {

                            if (psblty[x, y, number] == number + 1)//checks if number is a psblty
                            {
                                numOfPsblty[x] += 1;//increments
                            }

                        }
                        if (numOfPsblty[x] == 2)//checks if there is only 2 psblty
                        {
                            pairCounter += 1;//increment
                        }
                    }
                }
                if (pairCounter >= 2)//if there are 2 or more cells with pairs
                {
                    int[] pairCoords = new int[pairCounter];//creates new array pairCoords of length pairCounte
                    int indexCounter = 0;//resets
                    for (int x2 = 0; x2 <= 8; x2++)//loops for all columns
                    {
                        if (numOfPsblty[x2] == 2)//if there are 2 psbltys in a cell
                        {
                            pairCoords[indexCounter] = x2;//store index of that cell
                            indexCounter++;//increment
                        }
                    }
                    for(int i  = 0; i < pairCounter-1; i++)//used to test each combinationf of indexes between pairs
                    {
                        int number1 = 0;
                        int number2 = 0;//track numbers in the cells
                        for (int num = 0; num <= 8; num++)//loop for all numbers
                        {
                            if (puzzle[pairCoords[i], y] == 0)//checks if cell is empty
                            {
                                if (psblty[pairCoords[i], y, num] == num + 1)//cehcks if num is a psblty in that cell
                                {
                                    if (number1 == 0)//first encounter is always smaller
                                    {
                                        number1 = num;//tracks num
                                    }
                                    else//every other encounter
                                    {
                                        number2 = num;//tracks num
                                    }
                                }
                            }                            
                        }
                        for (int j = 0; j < pairCounter - i - 1; j++)//loops used to test each combination of indexes between cells with pairs
                        {
                            int number3 = 0;
                            int number4 = 0;//tracks numnbers
                            for (int num2 = 0; num2 <= 8; num2++)//loops for all nummbers
                            {
                                if (puzzle[pairCoords[i], y] == 0)//checks if cell is empty
                                {
                                    if (psblty[pairCoords[j + i + 1], y, num2] == num2 + 1)//checks if num is psblty
                                        if (number3 == 0)//first encounter is always smaller
                                        {
                                            number3 = num2;//tracks num2
                                        }
                                        else
                                        {
                                            number4 = num2;
                                        }
                                }                              

                            }
                            if ((number1 == number3) && (number2 == number4))//checks if numbers are the same between both cells
                            {

                                for (int x3 = 0; x3 <= 8; x3++)//loop for cells in a row
                                {
                                    if (puzzle[x3, y] == 0)//checks if cell is empty
                                    {
                                        if ((x3 != pairCoords[i]) && (x3 != pairCoords[j + i + 1]))//checks if current cell is same as either of the cells with pairs
                                        {

                                            if (psblty[x3, y, number1] != 0)//if number 1 is already removed as a psblty from the cell
                                            {
                                                psblty[x3, y, number1] = 0;//remove number1 as a psblty from cell
                                                highlightNumber(x3, y, number1, true, false);//highlight number that has just been removed
                                                highlightNumber(pairCoords[i], y, number1, false, false);
                                                highlightNumber(pairCoords[j + i + 1], y, number1, false, false);//highligh numbers that caused algorithm to happen in yellow
                                                char asciiX = Convert.ToChar(x3 + 65);
                                                char asciix2 = Convert.ToChar(pairCoords[i]+65);
                                                char asciix3 = Convert.ToChar(pairCoords[j + i + 1 +65]);//convert indexes to ascii for annotations
                                                richTextBox1.Text += String.Format("Naked Pairs Row: Pair of {0}s and {1}s  in row {2} in columns {4} and {5} remove {0} from cell ({3},{2})", number1 + 1, number2 + 1, y + 1,asciiX,asciix2, asciix3);
                                                //output annotations using parameters
                                                richTextBox1.Text += Environment.NewLine;
                                                used = true;//algorithm has already been used
                                            }
                                            if (psblty[x3, y, number2] != 0)//checks if number2 is already removed as a psblty from the cell
                                            {
                                                psblty[x3, y, number2] = 0;//removes number 2 as a psblty from cell
                                                highlightNumber(x3, y, number2, true, false);//highlight number that has just been removed
                                                highlightNumber(pairCoords[i], y, number2, false, false);
                                                highlightNumber(pairCoords[j + i + 1], y, number2, false, false);//highligh numbers that caused algorithm to happen in yellow
                                                char asciiX = Convert.ToChar(x3 + 65);
                                                char asciix2 = Convert.ToChar(pairCoords[i]);
                                                char asciix3 = Convert.ToChar(pairCoords[j + i + 1]);//convert indexes to ascii for annotations
                                                richTextBox1.Text += String.Format("Naked Pairs Row: Pair of {0}s and {1}s  in row {2} in columns {4} and {5} remove {1} from cell ({3},{2})", number1 + 1, number2 + 1, y + 1, asciiX, asciix2, asciix3);
                                                //output annotations using parameters
                                                richTextBox1.Text += Environment.NewLine;
                                                used = true;//algorithm has been used
                                            }
                                        }
                                    }

                                }

                            }
                        }

                    }
                }
            }
            return used;//returns true or falsed based on whether the algorithm has been used or not
        }

        public Boolean nakedPairsCage(int[,] puzzle)
        {
            bool used = false;
            for (int xCage = 0; xCage <= 2; xCage++)//cage number along the x axis of entire puzzle
            {
                for (int yCage = 0; yCage <= 2; yCage++)//cage number along the y axis of enire puzzle
                {
                    int pairCounter = 0;
                    int[] numOfPsblty = new int[9];
                    for (int xCell = 0; xCell <= 2; xCell++)//cell x number along the inside of a cage
                    {
                        for(int yCell = 0; yCell <= 2; yCell++)//cell y number along the inside of a cage
                        {
                            if(puzzle[xCage * 3 + xCell, yCage * 3 + yCell] == 0)//checks if cell is empty
                            {
                                for(int num = 0; num <= 8; num++)//loops for all numbers
                                {
                                    if(psblty[xCage * 3 + xCell, yCage * 3 + yCell, num] == num + 1)//checks if num is a psblty in the cell
                                    {
                                        numOfPsblty[xCell * 3 + yCell] += 1;//increments

                                    }                                    
                                }
                                if (numOfPsblty[xCell * 3 + yCell] == 2)//checks if there is only 2 psblty in the cell
                                {                                    
                                    pairCounter += 1;//increments
                                }
                            }
                        }
                    }
                    if (pairCounter >= 2)//checks if there are 2 or more cells with pairs
                    {
                        
                        int[,] pairCoords = new int[pairCounter,2];//creates new 2d array pairCoords iwht length pairCounter
                        //stores the index of a cell within a cage split into x and y pars
                        int indexCounter = 0;//resets counter
                        for (int xCell2 = 0; xCell2 <= 2; xCell2++)//loops for all columns in a cage
                        {
                            for(int yCell2 = 0;yCell2 <= 2; yCell2++)//loops for all rows in a cage
                            {
                                if (numOfPsblty[xCell2*3 +yCell2] == 2)//checks if cell has only 2 psbltys
                                {
                                    pairCoords[indexCounter,0] = xCell2;//tracks x part of cell inside a cage
                                    pairCoords[indexCounter,1] = yCell2;//tracks y part of cell inside a cage
                                    indexCounter++;//increments
                                }
                            }
                            
                        }
                        for (int i = 0; i < pairCounter - 1; i++)//used to test each combination of indexes of cells with pairs
                        {
                            int number1 = 0;
                            int number2 = 0;//tracks numbers
                            for (int num = 0; num <= 8; num++)//loops for all numbers
                            {
                                if (puzzle[xCage*3 +pairCoords[i,0],yCage*3 + pairCoords[i,1]] == 0)//checks if cell is empty
                                {
                                    if (psblty[xCage * 3 + pairCoords[i, 0], yCage * 3 + pairCoords[i, 1], num] == num + 1)//checks if cell has num as psblty
                                    {
                                        if (number1 == 0)//first encounter is always smaller
                                        {
                                            number1 = num;//tracks number
                                        }
                                        else//any other encounter
                                        {
                                            number2 = num;//tracks number
                                        }
                                    }
                                }
                            }
                            for (int j = 0; j < pairCounter - i - 1; j++)//used to test each combination of indexes of each cells with pairs
                            {
                                int number3 = 0;
                                int number4 = 0;//tracks numbers
                                for (int num2 = 0; num2 <= 8; num2++)//loops for all numbers
                                {
                                    if (puzzle[xCage * 3 + pairCoords[j+i+1, 0], yCage * 3 + pairCoords[j+i+1, 1]] == 0)//checks if cell is empty
                                    {
                                        if (psblty[xCage * 3 + pairCoords[j + i +1, 0], yCage * 3 + pairCoords[j + i +1, 1], num2] == num2 + 1)//checks if num2 is a psblty in cell
                                        {
                                            if (number3 == 0)//first encounter
                                            {
                                                number3 = num2;
                                            }
                                            else//second encounter
                                            {
                                                number4 = num2;
                                            }
                                        }
                                            
                                    }
                                }
                                if ((number1 == number3) && (number2 == number4))//checks if numbers are same between both cells
                                {
                                    for (int xCell3 = 0; xCell3 <= 2; xCell3++)//loops for all cols in a cagae
                                    {
                                        for (int yCell3 = 0; yCell3 <= 2; yCell3++)//loops for all rows in a cage
                                        {
                                            if(puzzle[xCage * 3 + xCell3, yCage * 3 + yCell3] == 0)//checks if cell is empty
                                            {
                                                
                                                if((xCell3 == pairCoords[i, 0]) &&((yCell3 == pairCoords[i, 1])))
                                                {
                                                    //checks if the current cell it is looping on is the same as the first cell with the pairs
                                                }
                                                else if((xCell3 == pairCoords[j + i + 1, 0] && (yCell3 == pairCoords[j + i + 1, 1]))) 
                                                {
                                                    //checks if current cell it is looping on is the same as the second cell with the pairs
                                                }
                                                else
                                                {//if it is not either of the cells with the pairs it will execute the algorithm and remove any possibilities where it can
                                                    if (psblty[xCage * 3 + xCell3, yCage * 3 + yCell3, number1] != 0)//checks if psblty of number1 is already 0
                                                    {
                                                        psblty[xCage * 3 + xCell3, yCage * 3 + yCell3, number1] = 0;//removes number as a psblty
                                                        highlightNumber(xCage * 3 + xCell3, yCage * 3 + yCell3, number1, true, false);//highlights number red showing that it is going to be removed
                                                        highlightNumber(xCage * 3 + pairCoords[i, 0], yCage * 3 + pairCoords[i, 1], number1, false, false);
                                                        highlightNumber(xCage * 3 + pairCoords[j + i + 1, 0], yCage * 3 + pairCoords[j + i + 1, 1], number1, false, false);
                                                        //highlights the numbers that caused the algorithm to occur in yellow
                                                        int cage = xCage + (yCage*3) + 1;
                                                        char asciiX = Convert.ToChar(xCage * 3 + xCell3 +65);
                                                        richTextBox1.Text += String.Format("Naked Pairs Cage: Pair of {0}s and {1}s in cage {2} remove {0} as a possibility from cell ({3},{4})",number1 + 1,number2 + 1,cage,asciiX, yCage * 3 + yCell3+1);
                                                        richTextBox1.Text += Environment.NewLine;
                                                        used = true;//the algorithm has been used
                                                    }
                                                    if (psblty[xCage * 3 + xCell3, yCage * 3 + yCell3, number2] != 0)//same as above but for number 2
                                                    {
                                                        psblty[xCage * 3 + xCell3, yCage * 3 + yCell3, number2] = 0;
                                                        highlightNumber(xCage * 3 + xCell3, yCage * 3 + yCell3, number2, true, false);
                                                        highlightNumber(xCage * 3 + pairCoords[i, 0], yCage * 3 + pairCoords[i, 1], number2, false, false);
                                                        highlightNumber(xCage * 3 + pairCoords[j + i + 1, 0], yCage * 3 + pairCoords[j + i + 1, 1], number2, false, false);
                                                        int cage = xCage + (yCage*3) + 1;
                                                        char asciiX = Convert.ToChar(xCage * 3 + xCell3 + 65);
                                                        richTextBox1.Text += String.Format("Naked Pairs Cage: Pair of {0}s and {1}s in {2} remove {1} as a possibility from cell ({3},{4})", number1 + 1, number2 + 1, cage, asciiX, yCage * 3 + yCell3 + 1);
                                                        richTextBox1.Text += Environment.NewLine;
                                                        used = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return used;//returns true or false based on if algorith was used
                
        }

        
        private Boolean pointingPairs(int[,] puzzle)
        {
            bool used = false;
            for (int yCage = 0; yCage <= 2; yCage++)
            {
                for (int xCage = 0; xCage <= 2; xCage++)//loops for all cages
                {
                    for (int num = 0; num <= 8; num++)//loop for numbers 1 to 9
                    {
                        int counter = 0;
                        int index1X = 0;
                        int index1Y = 0;
                        int index2X = 0;
                        int index2Y = 0;//resets all indexes after checking a number
                        for (int y = 0; y <= 2; y++)
                        {
                            for (int x = 0; x <= 2; x++)//loops for all cells in one cage
                            {
                                if ((puzzle[(yCage * 3) + y, (xCage * 3) + x] == 0) && (psblty[(yCage * 3) + y, (xCage * 3) + x, num] == (num + 1)))
                                {//checks each cell in a cage and checks if it is empty and has the number as a psblty 
                                    counter++;//increments
                                    if (counter == 1)
                                    {
                                        index1X = (xCage * 3) + x;
                                        index1Y = (yCage * 3) + y;//takes index of first encounter with number
                                    }
                                    else
                                    {
                                        index2X = (xCage * 3) + x;
                                        index2Y = (yCage * 3) + y;//takes index of encounter with number after first encounter, replaces old index
                                    }
                                }
                            }
                        }
                        if (counter == 2)//checks if number only appears twice
                        {
                            if (index1X == index2X)//same x change y which is the row
                            {
                                for (int row = 0; row <= 8; row++)//loops for all rows
                                {
                                    if (row / 3 != index2Y / 3)//checks if removing from same cage
                                    {
                                        if(puzzle[row, index2X] == 0)//checks if current cell is empty
                                        {
                                            if (psblty[row, index2X, num] != 0)//checks if there is a psblty for current number in cell
                                            {
                                                highlightNumber(row, index1X, num, true,false);//highlights the number red becuase it is about to be removed in position row index
                                                highlightNumber(index1Y, index1X, num, false,false);
                                                highlightNumber(index2Y, index1X, num, false,false);//highlights the numbers that caused algorithm to occur in yellow in position index1y index1x and index2y
                                                char asciiX = Convert.ToChar(65 + index1Y);//converts position to ascii uses 65 as start for A
                                                char asciiX2 = Convert.ToChar(65+index2Y);//converts position to ascii uses 65 as start for A
                                                char asciiX3 = Convert.ToChar(65+row);//converts position to ascii uses 65 as start for A
                                                richTextBox1.Text += String.Format("Pointing Pairs: {0}s in ({1},{2}) and ({3},{2}) eliminate possibility in cell ({4},{2})",num+1,asciiX,index1X+1,asciiX2,asciiX3);//outputs annoations with parameters explaining what happened
                                                richTextBox1.Text += Environment.NewLine;
                                                psblty[row, index2X, num] = 0;//removes number as possibility
                                                used = true;//algorithm has been used
                                            };//if not it will remove as psblty from other cells in the same row
                                        }
                                        
                                    }

                                }
                            }
                            else if (index1Y == index2Y)//same y change x which is col
                            {
                                for (int col = 0; col <= 8; col++)//loops for all columns
                                {
                                    if (col / 3 != index2X / 3)//checks if removing from same cage
                                    {
                                        if(puzzle[index1Y, col] == 0)//checks if cell is empty
                                        {
                                            if (psblty[index1Y, col, num] != 0)//checks if number is a psblty
                                            {
                                                highlightNumber(index1Y, col, num, true,false);//highlights the number red becuase it is about to be removed in position index1y col
                                                highlightNumber(index1Y,index1X, num, false,false);
                                                highlightNumber(index1Y,index2X,num, false,false);//highlights the numbers that caused algorithm to occur in yellow in position index1y index1x and index2x
                                                char asciix = Convert.ToChar(index1Y +65);//converts position to ascii uses 65 as start for A
                                                richTextBox1.Text += String.Format("Pointing Pairs: {0}s in ({1},{2}) and ({1},{3}) eliminate possibility in cell ({1},{4})",num+1,asciix,index1X+1,index2X+1,col+1);//outputs annoations with parameters explaining what happened
                                                richTextBox1.Text += Environment.NewLine;

                                                psblty[index1Y, col, num] = 0;//removes number as psblty
                                                used = true;//algorithm has been used
                                            }//if not it will remove as psblty from other cells in the same column
                                        }
                                        
                                    }

                                }
                            }
                        }
                    }
                }
            }
            return used;//returns true or false based on if algorithm has been used
        }

        public Boolean boxLineReductionCol(int[,] puzzle)
        {
            bool used = false;//tells you if the algorithm has been used or not
            for (int num = 0; num <= 8; num++)//loops for all numbers
            {
                for (int x = 0; x <= 8; x++)//loops for all columns
                {
                    int xcoord1 = 0;
                    int ycoord1 = 0;
                    int ycoord2 = 0;
                    int ycoord3 = 0;
                    int counter = 0;//initialises all variables and resets every loop

                    for (int y = 0; y <= 8; y++)//loops for all rows
                    {
                        if (puzzle[x, y] == 0)//checks if cell is empty
                        {
                            if (psblty[x, y, num] == num + 1)//checks if number is a psblty
                            {
                                if (counter == 0)//if first encounter with number as psblty
                                {
                                    xcoord1 = x;
                                    ycoord1 = y;//records indexing of first encounter
                                    counter += 1;//increments counter
                                }
                                else if (counter == 1)//if it is the second encounter with number
                                {

                                    ycoord2 = y;//takes index of second encounter
                                    counter += 1;//increments encounter
                                }
                                else//any other encounter
                                {

                                    ycoord3 = y;//updates each time it encounters (replaces old)
                                    counter += 1;//increments
                                }

                            }
                        }

                    }

                    if (counter == 2)//if number is only encountered twice
                    {

                        if ((ycoord1 / 3 == ycoord2 / 3))//checks if they were part of the same cage
                        {
                            for (int i = 0; i <= 2; i++)
                            {
                                for (int j = 0; j <= 2; j++)//loops for all cells in one cage
                                {
                                    if ((xcoord1 / 3) * 3 + i != xcoord1)//checks if current cell is in the same column as the number from first encounter
                                    {
                                        if (puzzle[(xcoord1 / 3) * 3 + i, (ycoord1 / 3)*3+j] == 0)//checks if cell is empty
                                        {
                                            if (psblty[(xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num] != 0)//checks if cell already has no psblty for number
                                            {
                                                psblty[(xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num] = 0;//removes number as a psblty fromt the cell
                                                highlightNumber(xcoord1, ycoord1, num, false,false);
                                                highlightNumber(xcoord1, ycoord2, num, false,false);//highlights numbers yellow that caused number to be removed
                                                highlightNumber((xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num, true,false);//highlights number removed in red
                                                char asciiX = Convert.ToChar(xcoord1+65);//converts indexing to ascii for annotations starting at 65 for A
                                                char asciiX2 = Convert.ToChar((xcoord1 / 3) * 3 + i + 65);//converts indexing to ascii for annotations starting at 65 for A
                                                int cage = ((xcoord1 / 3) * 3 + i) / 3 + (((ycoord1 / 3) * 3 + j)/3)*3 +1;//calculates the cage number it is in
                                                ycoord3 = (ycoord1 / 3) * 3 + j + 1;
                                                richTextBox1.Text += String.Format("box line reduction: {0}s only occur in cage {4} for column {1} so eliminate possibility from ({2},{3})",num+1,asciiX,asciiX2 ,ycoord3,cage);
                                                //outputs annotations explaining what happened using parameters
                                                richTextBox1.Text += Environment.NewLine;
                                                used = true;//algorithm has been used
                                            }
                                        }
                                        
                                    }
                                }
                            }

                        }
                    }
                    else if (counter == 3)//if number is only encountered twice
                    {

                        if ((ycoord1 / 3 == ycoord2 / 3) && (ycoord1 / 3 == ycoord3 / 3))//checks if all 3 were part of the same cage
                        {
                            for (int i = 0; i <= 2; i++)
                            {
                                for (int j = 0; j <= 2; j++)//loops for all cells in a cage
                                {
                                    if ((xcoord1 / 3) * 3 + i != xcoord1)//checks if current cell is in the same column as the number from first encounter
                                    {

                                        if (puzzle[(xcoord1 / 3) * 3 + i, (ycoord1 / 3)*3+j] == 0)//checks if cell is empty
                                        {

                                            if (psblty[(xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num] != 0)//checks if cell already has no psblty for number
                                            {
                                                psblty[(xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num] = 0;//removes number as a psblty fromt the cell
                                                highlightNumber(xcoord1, ycoord1, num, false,false);
                                                highlightNumber(xcoord1, ycoord2, num, false,false);
                                                highlightNumber(xcoord1, ycoord3, num, false,false);//highlights numbers yellow that caused number to be removed
                                                highlightNumber((xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num, true,false);//highlights number removed in red
                                                char asciiX = Convert.ToChar(xcoord1 + 65);//converts indexing to ascii for annotations starting at 65 for A
                                                char asciiX2 = Convert.ToChar((xcoord1 / 3) * 3 + i + 65);//converts indexing to ascii for annotations starting at 65 for A
                                                int cage = ((xcoord1 / 3) * 3 + i) / 3 + (((ycoord1 / 3) * 3 + j) / 3) * 3 + 1;//calculates the cage number it is in
                                                ycoord3 = (ycoord1 / 3) * 3 + j + 1;
                                                richTextBox1.Text += String.Format("box line reduction: {0}s only occur in cage {4} for column {1} so eliminate possibility from ({2},{3})", num + 1, asciiX, asciiX2, ycoord3, cage);
                                                //outputs annotations explaining what happened using parameters
                                                richTextBox1.Text += Environment.NewLine;
                                                used = true;//algorithm has been used
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
            return used;//returns true or false based on if algorithm has been used

        }

        public Boolean boxLineReductionRow(int[,] puzzle)
        {
            bool used = false;//tells the programme if the algorithm has been used or not
            for (int num = 0; num <= 8; num++)//loops for all numbers
            {
                for (int y = 0; y <= 8; y++)//loops for all rows
                {
                    int xcoord1 = 0;
                    int ycoord1 = 0;
                    int xcoord2 = 0;
                    int xcoord3 = 0;
                    int counter = 0;//initalises and resets all variables for loops

                    for (int x = 0; x <= 8; x++)//loops for all columns
                    {
                        if (puzzle[x, y] == 0)//checks cell if empty
                        {
                            if (psblty[x, y, num] == num + 1)//checks if number is a psblty in cell
                            {
                                if (counter == 0)//first encounter
                                {
                                    xcoord1 = x;
                                    ycoord1 = y;//updates variable to current loops
                                    counter += 1;//increments
                                }
                                else if (counter == 1)//second encounter
                                {
                                    xcoord2 = x;//updates variables
                                    counter += 1;
                                }
                                else//any other encounter after 2nd
                                {
                                    xcoord3 = x;//updates variables replaces old indexing
                                    counter += 1;
                                }

                            }
                        }

                    }

                    if (counter == 2)//if number has only been encountered twice
                    {

                        if (xcoord1 / 3 == xcoord2 / 3)//checks if they are in the same cage
                        {
                            for (int i = 0; i <= 2; i++)
                            {
                                for (int j = 0; j <= 2; j++)//loops for all cells in a cage
                                {
                                    if ((ycoord1 / 3) * 3 + j != ycoord1)//checks if current cell is in same row as original encounter
                                    {
                                        if (puzzle[(xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j] == 0)//checks if cell is empty
                                        {
                                            if (psblty[(xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num] != 0)//checks if psblty for number is already 0
                                            {
                                                psblty[(xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num] = 0;//updates number as not a psblty in that cell
                                                highlightNumber(xcoord1, ycoord1, num, false,false);
                                                highlightNumber(xcoord2, ycoord1, num, false, false);//highlights numbers yellow to show that they caused the algorithm to be used
                                                highlightNumber((xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num, true,false);//highlights number red to show it is going the be removed as a psblty
                                                int cage = ((xcoord1 / 3) * 3 + i) / 3 + (((ycoord1 / 3) * 3 + j) / 3) * 3 + 1;//calculates the cage number for annotations
                                                char asciiX = Convert.ToChar(65 + (xcoord1 / 3) * 3 + i);//converts indexing to ascii for annotations
                                                int asciiY = (((ycoord1 / 3) * 3 + j) / 3) * 3 + 1;//converts indexing to ascii for annotations
                                                richTextBox1.Text += String.Format("box line reduction: {0}s only occur in cage {4} for row {1} so eliminate possibility from ({3},{2})", num + 1, xcoord1, asciiY, asciiX, cage);
                                                //outputs annotations explaining what hapenede with parameters
                                                richTextBox1.Text += Environment.NewLine;
                                                used = true;//algorithm has been used
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                    else if (counter == 3)//if number has been encountered 3 times
                    {

                        if ((xcoord1 / 3 == xcoord2 / 3) && (xcoord1 / 3 == xcoord3 / 3))//checks if all 3 are in the same cage
                        {
                            for (int i = 0; i <= 2; i++)
                            {
                                for (int j = 0; j <= 2; j++)//loops for all cells in a cage
                                {
                                    if ((ycoord1 / 3) * 3 + j != ycoord1)//checks if current cell is in the same row as original encounter
                                    {
                                        if (puzzle[(xcoord1 / 3) * 3 + i, (ycoord1 / 3)*3 +j] == 0)//checks if cell is empty
                                        {
                                            if (psblty[(xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num] != 0)//chcecks if psblt of number is already 0
                                            {
                                                psblty[(xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num] = 0;//updates number as not a psblty
                                                highlightNumber(xcoord1, ycoord1, num, false,false);
                                                highlightNumber(xcoord2, ycoord1, num, false,false);
                                                highlightNumber(xcoord3, ycoord1, num, false,false);//highlights numbers yellow to show that they caused the algorithm to be used
                                                highlightNumber((xcoord1 / 3) * 3 + i, (ycoord1 / 3) * 3 + j, num, true,false);//highlights number red to show it is going the be removed as a psblty
                                                int cage = ((xcoord1 / 3) * 3 + i) / 3 + (((ycoord1 / 3) * 3 + j) / 3) * 3 + 1;//calculates the cage number for annotations
                                                char asciiX = Convert.ToChar(65 + (xcoord1 / 3) * 3 + i);//converts indexing to ascii for annotations
                                                int asciiY = (((ycoord1 / 3) * 3 + j) / 3) *3 + 1;//converts indexing to ascii for annotations
                                                richTextBox1.Text += String.Format("box line reduction: {0}s only occur in cage {4} for row {1} so eliminate possibility from ({3},{2})", num + 1, xcoord1, asciiY, asciiX, cage);
                                                ////outputs annotations explaining what hapenede with parameters
                                                richTextBox1.Text += Environment.NewLine;
                                                used = true;//algorithm has been used
                                            }
                                        }
                                            
                                    }
                                }
                            }

                        }
                    }
                }
            }
            return used;//return true or false based on if the algorithm has been used
        }

        public void highlightNumber(int x, int y, int number, bool remove,bool solve)
        {
            Graphics grid = panel1.CreateGraphics();//allows drawing on the panel inside this function
            SolidBrush highlighterPen = new SolidBrush(Color.FromArgb(60, 255, 255, 0));//sets color of brush to yellow and transparent
            float xPos = 0f;
            float yPos = 0f;//starting x and y position
            float xdiff = panel1.Width / 27f;//
            float ydiff = panel1.Height / 27f;//iniialises and sets variables to correct values based on grid size
            xPos = (x * panel1.Width / 9f) + ((number % 3) * xdiff);//calculates starting positions using parameters
            yPos = (y * panel1.Height / 9f) + ((number / 3) * ydiff);//calculates starting positions using parameters
            if (solve == true)//if the number parsed through is going to be solved highlight blue
            {
                highlighterPen.Color = Color.FromArgb(60, 0, 0, 255);//set brush colour to blue
                grid.FillRectangle(highlighterPen, xPos, yPos, 17, 17);//highlight sqare around number using positions
                //17 is the size of square around notes
            }else if (remove == true)//if the number is going to be removed highllight red
            {
                highlighterPen.Color = Color.FromArgb(60, 255, 0, 0);//set colour to red
                grid.FillRectangle(highlighterPen, xPos, yPos, 17, 17);//highlight sqare around number using positions
            }
            else
            {
                grid.FillRectangle(highlighterPen, xPos, yPos, 17, 17);//highlight sqare around number using positions
            }


        }


        private void ldEasy_Click(object sender, EventArgs e)// when the load easy buttons is pressed it will output the easy puzzle to the grid panel
        {
            panel1.Refresh();//clears the board if switching between boards
            richTextBox1.Text = "";//resets text box
            setPsblty();//resets the array psblty if it has been used before
            drawGrid();// calls the procedure drawGrid 
            fillCells(puzzleEasy);//calls the procedure fillCells with puzzleEasy as parameter
            checkNotes(puzzleEasy);//calls checknotes with easy as parameter
            fillNotes(puzzleEasy);//calls the procedure fillNotes with puzzleEasy as parameter
            difficulty = puzzleEasy;//sets difficulty to easy


        }

        private void ldMedium_Click(object sender, EventArgs e) // when load medium is pressed it will output the medium puzzle to the grid panel
        {
            panel1.Refresh();//clears the board if switching between boards
            richTextBox1.Text = "";//resets text box
            setPsblty();//resets the array psblty if it has been used before
            drawGrid();// calls the procedure drawGrid 
            fillCells(puzzleMedium);//calls the procedure fillCells with puzzleMedium as parameter
            checkNotes(puzzleMedium);
            fillNotes(puzzleMedium);//calls the procedure fillNotes with puzzleMedium as parameter
            difficulty = puzzleMedium;//sets difficulty to medium

        }

        private void ldHard_Click(object sender, EventArgs e) // when the load hard buttons is pressed it will output the puzzle to the grid panel
        {
            panel1.Refresh();//clears the board if switching between boards
            richTextBox1.Text = "";//sets difficulty to hard
            setPsblty();//resets the array psblty if it has been used before
            drawGrid();// calls the procedure drawGrid 
            fillCells(puzzleHard);//calls the procedure fillCells with puzzleHard as parameter
            checkNotes(puzzleHard);
            fillNotes(puzzleHard);//calls the procedure fillNotes with puzzleHard as parameter
            difficulty = puzzleHard;//sets ddifficulty to hard

        }

        private void button2_Click_1(object sender, EventArgs e)//when take step button is pressed
        {

            fillCells(difficulty);//updates board each time step is taken
            checkNotes(difficulty);//updates notes each time step is taken
            richTextBox1.Text = "";//resets textbox 1 after each step
            if (SolvedCells(difficulty) == true)//applies solved cell algorithm and checks if it was used
            {
                //if it was used
                pictureBox1.Image = Properties.Resources.Solved_Cell_1;// adds image of an example to picture box for solved cell
                pictureBox2.Image = Properties.Resources.Solved_cell_2;// adds second image to show changes in the example
                richTextBox2.Text = Properties.Resources.SolvedCellExplanation;// adds explanation of solved cells explaining how and what it does
            }
            else if (hiddenSingles(difficulty) == true)//applies hidden singles algorithm and checks if it was used
            {
                //if it was used
                pictureBox1.Image = Properties.Resources.Hidden_singles_1;// adds image of an example to picture box for hiddensingles
                pictureBox2.Image = Properties.Resources.Hidden_singles_2;// adds second image to show changes in the example
                richTextBox2.Text = Properties.Resources.HiddenSingleExplanation;// adds explanation of hidden singles explaining how and what it does
            }
            else if (nakedPairsCage(difficulty)||nakedPairsCol(difficulty)||nakedPairsRow(difficulty))//applies all 3 naked pair algorithms and checks if it was used
            {
                //if it was used
                pictureBox1.Image = Properties.Resources.Naked_Pairs_1;
                pictureBox2.Image = Properties.Resources.Naked_Pairs_2;//adds two pictures of an example of naked pairs occuring
                richTextBox2.Text = Properties.Resources.NakedPairExplanation;// adds explanation of naked pairs explaining how and what it does
            }
            else if (boxLineReductionCol(difficulty) || boxLineReductionRow(difficulty) == true)//applys boxlinereduction row and column and checks if it was used
            {
                //if it was used
                pictureBox1.Image = Properties.Resources.Box_line_reduction_1;
                pictureBox2.Image = Properties.Resources.Box_line_reduction_2;//adds two pictures of an example of naked pairs occuring
                richTextBox2.Text = Properties.Resources.BoxlineReductionExplanation;// adds explanation of naked pairs explaining how and what it does
            }
            else if (pointingPairs(difficulty) == true)//applies pointing pairs and algorithm and checks if it was used
            {
                //if it was used
                pictureBox1.Image = Properties.Resources.Pointing_pairs_1;
                pictureBox2.Image = Properties.Resources.Pointing_pairs_2;//adds two pictures of an example of pointing pairs occuring
                richTextBox2.Text = Properties.Resources.PointingPairsExplanation;// adds explanation of pointing pairs explaining how and what it does
            }
            else//after no algorithm can be used on puzzle
            {
                bool solved = true;//used to check if puzzle is solved
                for(int x = 0; x <= 8; x++)
                {
                    for(int y = 0; y <= 8; y++)//loops through all cells in puzzle
                    {
                        if(difficulty[x,y] == 0)//if any cell is empty 
                        {
                            solved = false;//then puzzle is not solved
                        }
                    }
                }
                if(solved == true)//check if it is solved
                {
                    richTextBox1.Text = "Puzzle is solved";//output appropriate message
                }
                else//not solved
                {
                    richTextBox1.Text = "Not enough algorithms to solve puzzle";//output appropriate message
                }
            }
        }

      

        
       
    }
}
