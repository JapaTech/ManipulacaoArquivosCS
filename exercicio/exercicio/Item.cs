using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio
{
    internal class Item
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }

        public Item(string nome, float preco, int quantidade) 
        { 
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }   

        public float ValorTotal()
        {
            return Preco * Quantidade;
        }
    }
}
