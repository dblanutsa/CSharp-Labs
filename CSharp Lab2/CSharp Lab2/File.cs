using System;
using System.Collections.Generic;
using System.IO;

namespace CSharp_Lab2
{
    public abstract class File
    {
        protected int position;
        protected string title;
        protected int length;

        protected File()
        {
        }

        public int GetPosition()
        {
            return position; 
        }

        public string GetTitle()
        {
            return title;
        }


        public int GetLength()
        {
            return length;
        }

        public virtual void Open()
        {
            Console.WriteLine("File " + title + " is opened.");
        }

        public virtual void Close()
        {
            Console.WriteLine("File " + title + " is closed.");
        }

        public virtual void Seek(int n)
        {
            position = n;
        }

        public abstract void Write();


        public abstract void Read();


        private sealed class PositionTitleLengthEqualityComparer : IEqualityComparer<File>
        {
            public bool Equals(File x, File y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.position == y.position && x.title == y.title && x.length == y.length;
            }

            public int GetHashCode(File obj)
            {
                unchecked
                {
                    var hashCode = obj.position;
                    hashCode = (hashCode * 397) ^ obj.title.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.length;
                    return hashCode;
                }
            }
        }

        private static readonly IEqualityComparer<File> PositionTitleLengthComparerInstance = new PositionTitleLengthEqualityComparer();

        public static IEqualityComparer<File> PositionTitleLengthComparer
        {
            get
            {
                if (PositionTitleLengthComparerInstance != null) return PositionTitleLengthComparerInstance;
                return null;
            }
        }

        public override string ToString()
        {
            return "File{position: " + position + ", length: " + length + ", title :" + title + " }";
        }
        
        public static bool operator ==(File file1, File file2)
        {
            return file1.Equals(file2);
        }

        public static bool operator !=(File file1, File file2)
        {
            return !(file1 == file2);
        }

        public abstract File DeepCopy();

    }
}