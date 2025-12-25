namespace NTierTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //path
            //system.Io
            //File.Create("..\\Mello.txt");
            //File.Move("A\\hello.txt","B\\mello.txt");
            File.Copy("A\\hello.txt", "B\\mello.txt");
        }
    }
}
