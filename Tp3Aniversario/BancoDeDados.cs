using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Tp3Aniversario
{
    class BancoDeDados
    {
       public static List<Pessoa> pessoaCadastrada = new List<Pessoa>();

        public static void Salvar(Pessoa pessoa)
        {
            pessoaCadastrada.Add(pessoa);
        }

        public static List<Pessoa> BuscarTodasPessoas()
        {
            return pessoaCadastrada;
        }

        public static IEnumerable<Pessoa> BuscarTodasPessoas(string nome, string sobreNome)
        {
            return pessoaCadastrada
                .Where(pessoa => pessoa.Nome.Contains(nome, StringComparison.InvariantCultureIgnoreCase));
        }

        public static IEnumerable<Pessoa> BuscarTodasPessoas(string sobreNome)
        {
            return pessoaCadastrada
                .Where(pessoa => pessoa.SobreNome.Contains(sobreNome, StringComparison.InvariantCultureIgnoreCase));
        }


        public static IEnumerable<Pessoa> BuscarTodasPessoas(DateTime dataNascimento)
        {
            return pessoaCadastrada
                .Where(pessoa => pessoa.DataNascimento.Date == dataNascimento);
        }

    }
}
