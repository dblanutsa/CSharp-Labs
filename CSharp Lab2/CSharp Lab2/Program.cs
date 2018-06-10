namespace CSharp_Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var folder1 = new Folder();
            folder1.Add(new MyDataFile1<string>("File1", 5, 7));
            folder1.Add(new MyDataFile1<string>("File2", 20, 8));
            folder1.PrintLengths();
            folder1.PrintTitles();

            var folder2 = folder1.DeepCopy();
            folder2.Add(new MyDataFile1<string>("File3", 753, 5753));
            folder2.PrintLengths();
            folder2.PrintTitles();
            
        }
    }
}