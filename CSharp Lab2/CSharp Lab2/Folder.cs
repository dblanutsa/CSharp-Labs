using System;
using System.Collections.Generic;

namespace CSharp_Lab2
{
    public class Folder
    {
        private List<File> files = new List<File>();

        public Folder()
        {
        }

        public Folder(List<File> files)
        {
            this.files = files;
        }

        public void Add(File file)
        {
            files.Add(file);
        }
        
        public void RemoveAt(int index)
        {
            files.RemoveAt(index);
        }

        public void PrintTitles()
        {
            Console.Write("Titles of files in folder: ");
            foreach (var file in files)
            {
                Console.Write(file.GetTitle() + " ");
            }
            Console.WriteLine();
        }
        
        public void PrintLengths()
        {
            Console.Write("Lengths of files in folder: ");
            foreach (var file in files)
            {
                Console.Write(file.GetLength() + " ");
            }
            Console.WriteLine();
        }

        public Folder DeepCopy()
        {
            var files = new List<File>();
            foreach (var file in this.files)
            {
                files.Add(file.DeepCopy());
            }
            return new Folder(files);
        }

        private sealed class FilesEqualityComparer : IEqualityComparer<Folder>
        {
            public bool Equals(Folder x, Folder y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return Equals(x.files, y.files);
            }

            public int GetHashCode(Folder obj)
            {
                return (obj.files != null ? obj.files.GetHashCode() : 0);
            }
        }
        
        
    }
}