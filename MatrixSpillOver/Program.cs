// See https://aka.ms/new-console-template for more information
using MatrixSpillOver.Managers;

Console.WriteLine("Hello, World!");

var matrix = new MatrixSystem();

for (int i = 0; i < 100; i++)
{
    matrix.AddNewUser(); 
}

matrix.PrintMatrix();