/* Problem 14 – Matrix Shuffle
You are given an input string which you should fill in a square spiral matrix with a given size. After filling up the matrix you should move through it and extract from it all the letters in a chessboard pattern.
Your next task is to check if the newly formed sentence, read in lowercase and with all non-letter characters removed, is a palindrome (reading it from left to right is the same as reading it from right to left).
Example: You are given the string “Rvioes roi tset ” and a size of 4. You fill the matrix in a spiral as shown below.

R	v	i	o
t
s	e
e
		t	s
i	o
r	

After filling it up, extract all letters in a chessboard pattern. Frist extract all white squares, after that all black squares.
R	v	i	o
t	s	e	e
 		t	s
i	o	r	 
R	v	i	o
t	s	e	e
 		t	s
i	o	r	 

	“Rise to ” +  	“vote sir” 


Result: “Rise to vote sir”.
After obtaining the string we must check if it is a palindrome.  “ris etov ot esir” == “rise to vote sir”. They are equal so we found a palindrome. 
 * The output consists of a single “<div>” tag which holds the found sentence. If the sentence is a palindrome the “div” tag’s background should be set to #4FE000. 
 * If the sentence is not a palindrome its background should be #E0000F.
Input
The input will be read from the console. The first line will hold a number – the size of the matrix. The second line will hold the text. 
 * The input data will always be valid and in the format described. There is no need to check it explicitly.
Output
The output should be an HTML <div> tag that shows the newly found sentence, colored by changing its background to #E0000F (see the examples below) 
 * if the sentence is not a palindrome or #4FE000 if the sentence is a palindrome. Follow strictly the sample HTML output format below.
Constraints
•	The text is a non-empty text field.
•	 The size is an integer in the range [1 … 9].
•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.


Examples
Input
4
Rvioes roi tset
Output
<div style='background-color:#4FE000'>Rise to vote sir </div>
 */

using System;
using System.Linq;
using System.Text;

class MatrixShuffle
{
    static void Main()
    {
        // input
        int size = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();

        // turn text into spiral
        var spiralMatrix = SpiralMatrix(size, text);

        // extract sentence
        var sentence = ComposeSentence(size, spiralMatrix);

        // palindrome check
        var isPalindrome = IsPalindrome(sentence);

        // print
        Console.WriteLine("<div style='background-color:{0}'>{1}</div>", isPalindrome ? "#4FE000" : "#E0000F", sentence);        
    }

    private static bool IsPalindrome(string sentence)
    {
        string str = sentence.ToLower();
        StringBuilder temp = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= 97 && str[i] <= 122)
            {
                temp.Append(str[i]);
            }
        }
        string one = string.Join("", temp);
        string two = string.Join("", one.Reverse());

        bool isPalindrome = one == two;
        return isPalindrome;
    }

    private static char[,] SpiralMatrix(int size, string text)
    {
        int totalCells = size*size;
        text = text.PadRight(totalCells, ' ');
        char[,] spiralMatrix = new char[size, size];

        int leftColumn = 0;
        int rightColumn = size - 1;
        int upperRow = 0;
        int bottomRow = size - 1;
        int count = 0;
        do
        {
            for (int i = leftColumn; i <= rightColumn; i++) // filling the upper row
            {
                spiralMatrix[upperRow, i] = text[count];
                count++;
            }
            upperRow++; // we go one row down

            for (int i = upperRow; i <= bottomRow; i++) // filling the right column
            {
                spiralMatrix[i, rightColumn] = text[count];
                count++;
            }
            rightColumn--; // we go to the next column

            for (int i = rightColumn; i >= leftColumn; i--) // filling bottom row
            {
                spiralMatrix[bottomRow, i] = text[count];
                count++;
            }
            bottomRow--; // one row up 

            for (int i = bottomRow; i >= upperRow; i--) // filling the leftmost column
            {
                spiralMatrix[i, leftColumn] = text[count];
                count++;
            }
            leftColumn++;
             // we go one column to the right
        } while (count < totalCells); // and continuing the spiral to the end of the text string
        return spiralMatrix;
    }

    private static string ComposeSentence(int size, char[,] spiralMatrix)
    {
        StringBuilder whiteText = new StringBuilder();
        StringBuilder blackText = new StringBuilder();
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if ((col%2 == 0 && row%2 == 0) || (col%2 != 0 && row%2 != 0))
                {
                    whiteText.Append(spiralMatrix[row, col]);
                }
                else if ((col%2 != 0 && row%2 == 0) || (col%2 == 0 && row%2 != 0))
                {
                    blackText.Append(spiralMatrix[row, col]);
                }
            }
        }

        string sentence = whiteText + blackText.ToString();
        return sentence;
    }
}

