using System;
using System.Collections.Generic;

namespace ExercArvore
{
	// Classe com o nó
	public class TreeNode
	{
		private int info;
		private TreeNode esq, dir, pai;
        private int nivel;
        public TreeNode [] Filhos;

        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

		// Construtor
		public TreeNode (int x, TreeNode p)
		{
            Filhos = new TreeNode[0];
			info = x;
			pai = p;
			esq = null;
			dir = null;
            if (p == null)
                nivel = 0;
            else
                nivel = p.nivel+1;
		}

		// Properties
		public int Info
		{
			get
			{
				return info;
			}
			set
			{
				info = value;
			}
		}
		public TreeNode Esq
		{
			get
			{
				return esq;
			}
			set
			{
				esq = value;
			}
		}
		public TreeNode Dir
		{
			get
			{
				return dir;
			}
			set
			{
				dir = value;
			}
		}
		public TreeNode Pai
		{
			get
			{
				return pai;
			}
			set
			{
				pai = value;
			}
		}

        public void AdicionarFilhos(TreeNode [] filhos)
        {
            this.Filhos = filhos;
        }

	}
	
	// Classe com a árvore
	public class BTree
	{
		// Nó raiz
		private TreeNode raiz;
		public TreeNode Raiz
		{
			get
			{
				return raiz;
			}
			set
			{
				raiz = value;
			}
		}

		// Construtor
		public BTree()
		{
			raiz = null;
		}

		// Inserindo na árvore
		public void Insert(int x)
		{
            if (raiz == null)
                raiz = new TreeNode(x, null);
            else
                insert(raiz, x);
		}

        private void insert(TreeNode n, int x)
        {
            if (x < n.Info)
            {
                if (n.Esq == null)
                    n.Esq = new TreeNode(x, n);
                else
                    insert(n.Esq, x);
            }
            else
            {
                if (n.Dir == null)
                    n.Dir = new TreeNode(x, n);
                else
                    insert(n.Dir, x);
            }
        }


		// Pesquisa na árvore
		public TreeNode Find(int x)
		{
			return find(raiz, x);
		}


        private TreeNode find(TreeNode n, int x)
        {
            if ((n == null) || (n.Info == x)) return n;
            if (x < n.Info)
                return find(n.Esq, x);
            else
                return find(n.Dir, x);
        }

		// Função para excluir nó
		public void Remove(int x)
		{

		}

        public int Minimax()
        {
            if (raiz.Dir == null && raiz.Esq == null)
                return raiz.Info;
            else if (raiz == null)
                return 0;
            else if (nivel(raiz) % 2 == 0)
                return Math.Max(Minimax());
            
            //else 
            //    return MinimaxManco(p);
        }

        int MinimaxManco(TreeNode p) {
            if (nivel(p) % 2 == 0)
            {
                if (p == null)
                    return 0;
                if (p.Dir == null && p.Esq == null)
                    return p.Info;
                return Math.Max(MinimaxManco(p.Esq), MinimaxManco(p.Dir));
            }
            else
            {
                if (p == null)
                    return 0;
                if (p.Dir == null && p.Esq == null)
                    return p.Info;
                return Math.Min(MinimaxManco(p.Esq), MinimaxManco(p.Dir));
            }
        }

        public int nivel(TreeNode p)
        {
            int cont =0;

            do{
                cont++;
                p = p.Pai;
            } while (p != null);

            return cont;
        }

        private int maior(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }

        private int menor(int a, int b)
        {
            if (a < b)
                return a;
            else
                return b;
        }

        private int altura(TreeNode pRaiz)
        {
            if ((pRaiz == null) || (pRaiz.Esq == null && pRaiz.Dir == null))
                return 0;
            else
                return 1 + maior(altura(pRaiz.Esq), altura(pRaiz.Dir));
        }

        int contarFolhas(TreeNode pRaiz)
        {
            if (pRaiz == null)
                return 0;
            if (pRaiz.Esq == null && pRaiz.Dir == null)
                return 1;
            return contarFolhas(pRaiz.Esq) + contarFolhas(pRaiz.Dir);
        }

        public void GeraArvore(int p)
        {
        }

    }
}
