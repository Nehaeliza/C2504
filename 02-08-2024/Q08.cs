//USING WHILE
class Q08
    {
        //[Ashna, Neha, Nivya, Kuriakose[doubt], Rishwin[discussion], Giris]

        static void PrintNumTriangleMirroredRightAngle(int N)
        {

            int I = 1;
            while ( I <= N )
            {
                int J = 1;
                while ( J <= N - I )
                {
                    Console.Write("  "); //2 spaces
                    J++;
                }
                int K = 1;
                while ( K <= I )
                {
                    Console.Write($"{K} ");//num and space
                    K++;
                }
                
                Console.WriteLine();//new line
                I++;
            }
        }
        //input=4,output=4 lines triangle 
        //input=5,output=5 lines triangle 
        //input=7,output=7 lines triangle 
        static void TestPrintNumTriangleMirroredRightAngle()
        {
            Console.Write("Enter number of lines:");
            int N = int.Parse(Console.ReadLine());
            PrintNumTriangleMirroredRightAngle(N);
        }
        static void Main(string[] args) //user: p
        {
            Console.WriteLine("-----TestPrintNumTriangleMirroredRightAngle-----");
            TestPrintNumTriangleMirroredRightAngle();
            Console.WriteLine("-----End TestPrintNumTriangleMirroredRightAngle-----");
            Console.WriteLine("Press any key to contine...");
            Console.ReadKey();
        }
    }
}
