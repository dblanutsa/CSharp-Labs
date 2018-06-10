using System;

namespace CSharp_Lab2
{
    public class MyDataFile1<T> : File
    {

        private T MyData1;

        public MyDataFile1(string title, int position, int length)
        {
            this.title = title;
            this.position = position;
            this.length = length;
        }

        public T GetMyData()
        {
            return MyData1;
        }

        public override void Write()
        {
            Console.Write(MyData1);
        }

        public override void Read()
        {
            Console.WriteLine("Readin for " + title + " file.");
        }

        public override File DeepCopy()
        {
            return new MyDataFile1<T>(this.title, this.position, this.length);
        }
    }
}