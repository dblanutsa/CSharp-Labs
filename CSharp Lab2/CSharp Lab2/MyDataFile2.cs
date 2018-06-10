using System;

namespace CSharp_Lab2
{
    public class MyDataFile2<F> : File
    {

        private F MyData2;

        public MyDataFile2(string title, int position, int length)
        {
            this.title = title;
            this.position = position;
            this.length = length;
        }

        public F GetMyData()
        {
            return MyData2;
        }

        public override void Write()
        {
            Console.Write(MyData2);
        }

        public override void Read()
        {
            Console.WriteLine("Readin for " + title + " file.");
        }
        
        public override File DeepCopy()
        {
            return new MyDataFile1<F>(this.title, this.position, this.length);
        }
    }
}