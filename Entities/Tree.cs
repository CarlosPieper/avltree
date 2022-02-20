using System;

namespace avl.Entities
{
    public class Tree
    {
        public Tree()
        {
            Root = null;
        }

        public Node Root { get; set; }

        private int Higher(int a, int b)
        {
            return (a > b ? a : b);
        }

        private int NodeHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.Height;
        }

        private int GetBalance(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return NodeHeight(node.Left) - NodeHeight(node.Right);
        }

        private Node LessValuableNode(Node node)
        {
            Node current = node;

            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        private Node RotateRight(Node node)
        {
            Node left = node.Left;
            Node right = left.Right;

            left.Right = node;
            node.Left = right;

            node.Height = Higher(NodeHeight(node.Left), NodeHeight(node.Right)) + 1;
            left.Height = Higher(NodeHeight(left.Left), NodeHeight(left.Right)) + 1;

            return left;
        }

        private Node RotateLeft(Node node)
        {
            Node right = node.Right;
            Node left = right.Left;

            right.Left = node;
            node.Right = left;

            node.Height = Higher(NodeHeight(node.Left), NodeHeight(node.Right)) + 1;
            right.Height = Higher(NodeHeight(right.Left), NodeHeight(right.Right)) + 1;

            return right;
        }

        public Node Insert(Book book)
        {
            return this.Insert(this.Root, book);
        }

        private Node Insert(Node node, Book book)
        {
            if (node == null)
            {
                return new Node(book);
            }

            if (book.Id < node.Book.Id)
            {
                node.Left = Insert(node.Left, book);
            }
            else if (book.Id > node.Book.Id)
            {
                node.Right = Insert(node.Right, book);
            }
            else
            {
                return node;
            }

            node.Height = Higher(NodeHeight(node.Left), NodeHeight(node.Right)) + 1;

            int balance = GetBalance(node);

            if (balance > 1 && book.Id < node.Left.Book.Id)
            {
                return RotateRight(node);
            }
            if (balance < -1 && book.Id > node.Right.Book.Id)
            {
                return RotateLeft(node);
            }
            if (balance > 1 && book.Id > node.Left.Book.Id)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            if (balance < -1 && book.Id < node.Right.Book.Id)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public void InOrder()
        {
            this.InOrder(this.Root);
        }

        private void InOrder(Node node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                Console.WriteLine(node.Book.Id + " - " + node.Book.Name);
                InOrder(node.Right);
            }
        }

        public void PreOrder()
        {
            this.PreOrder(this.Root);
        }

        private void PreOrder(Node node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Book.Id + " - " + node.Book.Name);
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }

        public void PostOrder()
        {
            this.PostOrder(this.Root);
        }

        private void PostOrder(Node node)
        {
            if (node != null)
            {
                PostOrder(node.Left);
                PostOrder(node.Right);
                Console.WriteLine(node.Book.Id + " - " + node.Book.Name);
            }
        }

        public Node FindById(int id)
        {
            return this.FindById(this.Root, id);
        }

        private Node FindById(Node node, int id)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Book.Id == id)
            {
                return node;
            }

            Node found = FindById(node.Left, id);
            if (found != null)
            {
                return found;
            }

            return FindById(node.Right, id);
        }

        public Node Delete(int id)
        {
            return this.Delete(this.Root, id);
        }

        private Node Delete(Node node, int id)
        {
            if (node == null)
            {
                return node;
            }

            if (id < node.Book.Id)
            {
                node.Left = Delete(node.Left, id);
            }
            else if (id > node.Book.Id)
            {
                node.Right = Delete(node.Right, id);
            }
            else
            {
                if (node.Left == null || node.Right == null)
                {
                    Node aux = null;

                    if (aux == node.Left)
                    {
                        aux = node.Right;
                    }
                    else
                    {
                        aux = node.Left;
                    }

                    if (aux == null)
                    {
                        aux = node;
                        node = null;
                    }
                    else
                    {
                        node = aux;
                    }
                }
                else
                {
                    Node aux = this.LessValuableNode(node.Right);
                    node.Book = aux.Book;
                    node.Right = Delete(node.Right, aux.Book.Id);
                }
            }

            if (node == null)
            {
                return node;
            }

            node.Height = Higher(NodeHeight(node.Left), NodeHeight(node.Right)) + 1;

            int balance = GetBalance(node);

            if (balance > 1 && GetBalance(node.Left) >= 0)
            {
                return RotateRight(node);
            }

            if (balance > 1 && GetBalance(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && GetBalance(node.Right) <= 0)
            {
                return RotateLeft(node);
            }

            if (balance < -1 && GetBalance(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }
    }
}