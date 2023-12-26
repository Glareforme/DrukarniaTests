using DrukarniaTests.SqlManager.Data;
using DrukarniaTests.SqlManager.DB;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
            args = new string[] { "-insert" };

        switch (args[0])
        {
            case "-insert":
                DatabaseConnect.InsertPost(DataReqest.ColectAllDataForPost());
                Console.WriteLine("Complete");
                break;
            case "-cleanup":
                DatabaseConnect.CleanUpTable();
                Console.WriteLine("Complete");
                break;
            case "-select":
                
                break;
        }
    }
}
