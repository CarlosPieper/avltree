namespace avl.Entities
{
    public class Node
    {
        public Node(Book book)
        {
            this.Book = book;
            this.Left = null;
            this.Right = null;
            this.Height = 1;
        }

        public Book Book { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Height {get;set;}
    }
}