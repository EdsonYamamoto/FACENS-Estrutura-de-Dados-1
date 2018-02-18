using System;

namespace Editor
{
    /// <summary>
    /// Lista duplamente ligada linear
    /// </summary>
    public class ListaDupla
    {
        private Node list;
        private int count;
        private ListaDupla backup;

        public Node FirstNode
        {
            get { return list; }
        }
        public int Count
        {
            get { return count; }
        }

        // Construtor
        public ListaDupla()
        {
            list = null;
            count = 0;
        }

        // Se está vazia
        public bool Empty()
        {
            return (count==0);
        }

        // Insere um novo nó
        public void Insert(Node p, object x)
        {
            Node n = new Node();
            n.Info = x;
            n.Next = null;
            n.Prior = null;
            count++;

            if (list == null)
                list = n;
            else if (p == null)
            {
                n.Next = list;
                list.Prior = n;
                list = n;
            }
            else
            {
                n.Prior = p;
                n.Next = p.Next;
                if (p.Next != null) p.Next.Prior = n;
                p.Next = n;
            }
        }

        // Remove um nó
        public void Remove(Node p)
        {
            if (p.Next != null) p.Next.Prior = p.Prior;
            if (p.Prior != null) p.Prior.Next = p.Next;
            count--;
        }


        // Copia a lista
        public ListaDupla CopiaLista()
        {
            return null;
        }

        // Salva a lista
        public void Salvar()
        {

        }

        // Carrega lista padrão
        public void Recuperar()
        {
        }

        // Carrega uma lista com um nome
        public void Recuperar(int nivel)
        {
        }



    }

}
