using System.Threading.Channels;

namespace TicTacToe;

class TicTocToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    //the variable, whose turn it is now
    public static char currentPlayer;
    
    static void Main()
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe! Who starts this game? \n Enter X or 0:");
        currentPlayer = Console.ReadLine().ToUpper()[0];
    // TryParse tries to convert a string to a number
    // if it doesn't work or the number is out of range, ask to enter it again
        
    // Main game loop - will run until win or draw
        while (true)
        {
            Console.Clear(); //clear console-screen
            showBoard(); // cell - сurrent value
            
            Console.WriteLine($"Player {currentPlayer} has been selected. Select your cell number (1-9):");
            int move;
            
            while (!int.TryParse(Console.ReadLine(), out move) || move  < 1 || move > 9)
            {
                Console.WriteLine("Wrong number. Try from 1 to 9.");
            }

            if (board [move - 1] == 'X' || board [move-1] == '0')
            {
                Console.WriteLine("The cell is already occupied. Press any key");
                Console.ReadKey();
                continue;
            }
            //If it's free, we put a sign
            board[move -1] = currentPlayer;

            if (CheckWin())
            {
                Console.Clear();
                showBoard();
                Console.WriteLine($"Player {currentPlayer} is the winner!");
                break;
            }

            if (CheckDraw())
            {
                Console.Clear();
                showBoard();
                Console.WriteLine($"The draw!");
                break;
            }
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
        void showBoard()
        {
            //første række, felter 0, 1, 2 adskilt af lodrette  streger
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("___+___+___"); //separator
            //anden række
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("___+___+___");
            //tredje r.
            Console.WriteLine($" {board[6]}, {board[7]}, {board[8]}");
            Console.WriteLine("___+___+___");
        }

    
    static bool CheckWin()
    {
        // Сравниваем «три в ряд» — если все три символа совпадают, кто-то выиграл
        return
            (board[0] == board[1] && board[1] == board[2]) ||
            (board[3] == board[4] && board[4] == board[5]) ||
            (board[6] == board[7] && board[7] == board[8]) ||
            (board[0] == board[3] && board[3] == board[6]) ||
            (board[1] == board[4] && board[4] == board[7]) ||
            (board[2] == board[5] && board[5] == board[8]) ||
            (board[0] == board[4] && board[4] == board[8]) ||
            (board[2] == board[4] && board[4] == board[6]);
    }
}

    static bool CheckDraw()
    {
        foreach (char c in board)
        {
            if (c !='X' && c != '0')
                return false; // found another free cell - not a draw
        }
        return true; // not a single free one - a draw.
    }

}