//do while

static void PrintNumTriangleMirroredRightAngle(int N)
{
    int i = 1;
    do
    {
        // Print leading spaces
        int j = 1;
        do
        {
            Console.Write("  "); // 2 spaces
            j++;
        } while (j <= N - i);

        // Print numbers
        int k = 1;
        do
        {
            Console.Write(k + " "); // number and a space
            k++;
        } while (k <= i);

        Console.WriteLine(); // new line
        i++;
    } while (i <= N);
}

static void TestPrintNumTriangleMirroredRightAngle()
{
    Console.Write("Enter number of lines: ");
    int N = int.Parse(Console.ReadLine());
    PrintNumTriangleMirroredRightAngle(N);
}

static void Main(string[] args)
{
    Console.WriteLine("-----TestPrintNumTriangleMirroredRightAngle-----");
    TestPrintNumTriangleMirroredRightAngle();
    Console.WriteLine("-----End TestPrintNumTriangleMirroredRightAngle-----");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}
