using System;
using System.Collections.Generic;

namespace Editor
{
    // Classe para o editor de texto
    public class Text
    {
        // Atributos e propriedades
        private ListaDupla listaTexto;
        private int linhaAtual;
        
        // Retorna a primeira linha do texto
        public Node FirstLine
        {
            get { return listaTexto.FirstNode; }
        }

        // Número de linhas do texto
        public int NumLines
        {
            get { return listaTexto.Count; }
        }

        // Construtor
        public Text()
        {
            listaTexto = new ListaDupla();
        }

        // Nova linha: o valor -1 indica que o elemento deve ser 
        // inserido na primeira posição
        // Outros valores indicam a posição após a qual o novo elmento será
        // inserido, ininciando em 0
        public void InsertLine(string text, int position)
        {
            if (position == -1)
                listaTexto.Insert(null, text);
            else
            {
                Node p = LocalizaNode(position);

                listaTexto.Insert(p, text);
            }
        }

        // Iniciando em 0, a posição da linha que deve ser alterada
        public void ChangeLine(string text, int position)
        {
            Node p = LocalizaNode(position);

            p.Info = text;
        }

        // Excluindo uma linha - é passada a posição da linha començando em zero
        public void RemoveLine(int position)
        {
            Node p = LocalizaNode(position);
            listaTexto.Remove(p);
        }
        public void DeleteLine(int position)
        {
            // Implementar!
        }

        private Node LocalizaNode(int n)
        {
            Node p = listaTexto.FirstNode;
            for (int i = 0; i < n; i++)
                p = p.Next;
            return p;
        }



       

        public int LinhaAtual
        { get
            {
                return linhaAtual;
            }
            set
            {
                linhaAtual = value;
            }
        }

        public string RetornaTexto(int i)
        {
            
            return "";
        }
        

        public void Copiar(int p1, int p2)
        {
        }

        public void Colar(int position)
        {
        }

        public void CriarMarcador(string p)
        {
        }

        public void IrPara(string p)
        {
        }

    }

}
