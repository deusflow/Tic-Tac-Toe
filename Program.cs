using System.Threading.Channels;

namespace TicTacToe;

class TicTocToe
{
    static char[] board = {'1','2','3','4','5','6','7','8','9'};
    public static char currentPlayer;
    
    void showBoard()
    {
        //første række, felter 0, 1, 2 adskilt af lodrette  streger
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]}");
            Console.Write("___+___+___"); //separator
        //anden række
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]}");
            Console.Write("___+___+___");
        //tredje r.
        Console.WriteLine($" {board[6]}, {board[7]}, {board[8]}");
    }

    static void Main()
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe! Who starts this game? \n Enter X or 0:");
        currentPlayer = Console.ReadLine().ToUpper()[0];
    }


}