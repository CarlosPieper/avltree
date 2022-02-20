using System;
using avl.Entities;

namespace avl
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Root = tree.Insert(new Book { Id = 1, Name = "First book" });
            tree.Root = tree.Insert(new Book { Id = 2, Name = "Second book" });
            tree.Root = tree.Insert(new Book { Id = 3, Name = "Third book" });
            tree.Root = tree.Insert(new Book { Id = 4, Name = "Fourth book" });
            tree.Root = tree.Insert(new Book { Id = 5, Name = "Fifth book" });
            tree.Root = tree.Insert(new Book { Id = 6, Name = "Sixth book" });
            tree.Root = tree.Insert(new Book { Id = 7, Name = "Seventh book" });
            tree.Root = tree.Insert(new Book { Id = 8, Name = "Eighth book" });
            tree.Root = tree.Insert(new Book { Id = 9, Name = "Ninth book" });
            tree.Root = tree.Insert(new Book { Id = 10, Name = "Tenth book" });
            tree.Root = tree.Insert(new Book { Id = 11, Name = "Eleventh book" });

            Console.WriteLine("In order");
            tree.InOrder();

            Console.WriteLine("Pre order");
            tree.PreOrder();

            Console.WriteLine("Post order");
            tree.PostOrder();

            Console.WriteLine("Find node by id");
            var node = tree.FindById(10);
            if (node != null)
            {
                Console.WriteLine(node.Book.Name);
            }
            Console.WriteLine("Deleting item");
            tree.Root = tree.Delete(10);

            Console.WriteLine("In order");
            tree.InOrder();
        }
    }
}
