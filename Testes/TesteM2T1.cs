using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExercArvore;
using Editor;

namespace Testes
{
    [TestClass]
    public class TesteArvoreM2T1
    {
        /// <summary>
        /// O método minimax é uma mistura de minimo e máximo dos nós das árvores.  
        /// Quando o nó é folha, seu valor minimax é seu próprio valor. 
        /// Um nó inexistente tem valor minimax de zero. 
        /// Se o nó não é folha, minimax pode ser:
        /// - o maior valor minimax dos filhos, se o nível do nó é par
        /// - o menor valor minimax dos filhos, se o nível do nó é impar
        /// </summary>
        [TestMethod]
        public void P1_MinimaxSimples()
        {
            BTree bt = new BTree();
            bt.Insert(30);
            Assert.AreEqual(30, bt.Minimax());
        }
        [TestMethod]
        public void P2_MinimaxManco()
        {
            BTree bt = new BTree();
            bt.Insert(20);
            bt.Insert(10);
            bt.Insert(30);
            bt.Insert(40);
            Assert.AreEqual(10, bt.Minimax());
        }
        [TestMethod]
        public void P3_MinimaxMultiNivel()
        {
            BTree bt = new BTree();
            bt.Insert(500);
            bt.Insert(250);
            bt.Insert(750);
            bt.Insert(125);
            bt.Insert(385);
            bt.Insert(625);
            bt.Insert(1000);
            bt.Insert(80);
            bt.Insert(200);
            bt.Insert(300);
            bt.Insert(400);
            bt.Insert(550);
            bt.Insert(700);
            bt.Insert(900);
            bt.Insert(1200);
            Assert.AreEqual(700, bt.Minimax());
        }
        /// <summary>
        /// Neste método você deve montar a árvore para minimax processar. 
        /// A árvore deve seguir ose seguintes parametros:
        /// - A altura é passada por parâmetro e a árvore é binária e completa. 
        /// - Cada um de seus nós folhas tem o valor de um contador, iniciando em 1, no 
        ///  nó folha mais a esquerda. 
        /// </summary>
        [TestMethod]
        public void P4_MinimaxArvoreGerada()
        {
            BTree bt = new BTree();
            bt.GeraArvore(2);
            Assert.AreEqual(2, bt.Minimax());
            bt.GeraArvore(5);
            Assert.AreEqual(11, bt.Minimax());
            bt.GeraArvore(10);
            Assert.AreEqual(342, bt.Minimax());
        }


    }

    [TestClass]
    public class TesteListaM2T1
    {

        private string TextoInteiro(Node p)
        {
            string temp = "";
            while (p != null)
            {
                temp += p.Info.ToString() + ",";
                p = p.Next;
            }
            temp += ",";
            temp = temp.Replace(",,", "");
            return temp;
        }

        /// <summary>
        /// Criar um método Copiar "public void Copiar(int p1, int p2)" que copia da linha inicial p1 até a linha final p2 um trecho do texto. 
        /// Além disso, crie um método Colar "public void Colar(int p)" que cola as linhas copiadas na posição indicada por p. 
        /// </summary>
        [TestMethod]
        public void P2_CopiarColar()
        {
            Text t = new Text();
            t.InsertLine("A1", -1);
            t.InsertLine("B2", 0);
            t.InsertLine("C3", 1);
            t.InsertLine("D4", 2);
            t.InsertLine("E5", 3);
            t.InsertLine("F6", 4);
            t.Copiar(2, 4);
            t.Colar(2);
            string temp = TextoInteiro(t.FirstLine);
            Assert.AreEqual("A1,B2,C3,D4,E5,C3,D4,E5,F6", temp);
        }

        /// <summary>
        /// Criar a propriedade "linha atual" na classe texto. Esta propriedade definir ou consultar a linha que o usuário está lendo. 
        /// Além disso, criar o método "retornatexto". Este método retorna o texto de uma linha do editor. 
        /// </summary>
        [TestMethod]
        public void P1_TesteLinhaAtual()
        {
            Text t = new Text();
            t.InsertLine("A1", -1);
            t.InsertLine("B2", 0);
            t.InsertLine("C3", 1);
            t.InsertLine("D4", 2);
            t.InsertLine("E5", 3);
            t.InsertLine("F6", 4);
            t.LinhaAtual = 3;
            string temp = t.RetornaTexto(t.LinhaAtual);
            Assert.AreEqual("C3", temp);
        }

        /// <summary>
        /// Usando a linha atual, você deve criar um método capaz de adicinar marcadores no texto. 
        /// Para criar um marcador, o usuário dá um nome para o marcador e chama o método CriarMarcador. Ao alterar a linha atual, o usuário pode voltar para a linha 
        /// do marcador chamando um método IrPara.
        /// </summary>
        [TestMethod]
        public void P2_TesteMarcador()
        {
            Text t = new Text();
            t.InsertLine("A1", -1);
            t.InsertLine("B2", 0);
            t.InsertLine("C3", 1);
            t.InsertLine("D4", 2);
            t.InsertLine("E5", 3);
            t.InsertLine("F6", 4);
            t.LinhaAtual = 3;
            t.CriarMarcador("M1");
            t.LinhaAtual = 5;
            t.CriarMarcador("M2");
            t.LinhaAtual = 1;
            string temp = t.RetornaTexto(t.LinhaAtual);
            Assert.AreEqual("A1", temp);
            t.IrPara("M1");
            temp = t.RetornaTexto(t.LinhaAtual);
            Assert.AreEqual("C3", temp);
            t.IrPara("M2");
            temp = t.RetornaTexto(t.LinhaAtual);
            Assert.AreEqual("E5", temp);
        }

    }
}
