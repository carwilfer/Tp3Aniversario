using System;
using System.Linq;
using System.Collections.Generic;

namespace Tp3Aniversario
{
    class Program
    {
 
        static void Main(string[] args)
        {
            MenuPrincipal();
        }
        public static void MenuPrincipal()
        {
            EscreverNaTela("Menu do sistema de gerência de Aniversários:");
            EscreverNaTela("Selecione uma operação");
            EscreverNaTela("1 - Pesquisar pessoa");
            EscreverNaTela("2 - Adicionar pessoa");
            EscreverNaTela("3 - Sair");

            char operacao = Console.ReadLine().ToCharArray()[0];

            switch (operacao)
            {
                case '1':
                    PesquisarPessoa(); break;

                case '2':
                    AdicionarPessoa(); break;

                default: EscreverNaTela("Opção inexistente"); break;
            }
        }
        private static void EscreverNaTela(string texto)
        {
            Console.WriteLine(texto);
        }

        static void AdicionarPessoa()
        {
            LimparTela();

            EscreverNaTela("Entre com o Nome:");
            string nome = Console.ReadLine();

            EscreverNaTela("Entre com o Sobrenome:");
            string sobreNome = Console.ReadLine();

            DateTime niver;
            EscreverNaTela("Entre com a data de Nascimento no formato: DD/MM/YYYY");
            niver = DateTime.Parse(Console.ReadLine());

            DateTime dataDeCadastro = DateTime.Now;

            TimeSpan resultado;
            resultado = dataDeCadastro - niver;
            //DateTime idade = (New DateTime() + result).AddYears(-1).AddDays(-1);
            //return idade.Year;
            
            Console.WriteLine($"Você tem {(resultado.Days / 30 / 12 )- 1} anos");

            Pessoa pessoa = new Pessoa();
            pessoa.Nome = nome;
            pessoa.SobreNome = sobreNome;
            pessoa.DataNascimento = niver;
            pessoa.DataDeCadastro = dataDeCadastro;

            BancoDeDados.pessoaCadastrada.Add(pessoa);

            BancoDeDados.Salvar(pessoa);

            StatusCadastro();

        }
        private static void LimparTela()
        {
            Console.Clear();
        }

        private static void PesquisarPessoa()
        {
            LimparTela();

            foreach (var pessoa in BancoDeDados.BuscarTodasPessoas())
            {
                EscreverNaTela($"Nome: {pessoa.Nome} " +
                    $"SobreNome: {pessoa.SobreNome} " +
                    $"Aniversário em: {pessoa.DataNascimento} " +
                    $"Pessoa cadastrada em: {pessoa.DataDeCadastro} ");
            }
            StatusCadastro();
            ExibirOpcoesDeFiltro();

        }

        static void ExibirOpcoesDeFiltro()
        {
            EscreverNaTela("Escolha uma opção do filtro: ");
            EscreverNaTela("1 - Entre com o nome: ");
            EscreverNaTela("2 - Data de Nascimento ");
            string tipoConsulta = Console.ReadLine();


            switch (tipoConsulta)
            {
                case "1":
                    ConsultaPeloNome(); break;

                case "2":
                    ConsultarPelaData(); break;

                case "3":
                    ConsultaPeloSobreNome(); break;

                default:
                    EscreverNaTela("Consulta incorreta");
                    ExibirOpcoesDeFiltro();
                    break;
            }


            /*if(tipoConsulta == "1")
            {
                ConsultaPeloNome();
                ConsultaPeloSobreNome();
            }
            else
            {
                ConsultarPelaData();
            }
            MenuPrincipal();*/
        }

        static void StatusCadastro()
        {
            EscreverNaTela("Os dados cadastrados estão corretos? ");
            EscreverNaTela("1 - sim: ");
            EscreverNaTela("2 - Não: ");

            string tipoConsulta = Console.ReadLine();


            switch (tipoConsulta)
            {
                case "1":
                    ExibirOpcoesDeFiltro(); break;

                case "2":
                    MenuPrincipal(); break;

                default:
                    EscreverNaTela("Consulta incorreta");
                    MenuPrincipal();
                    break;
            }
        }

        static void ConsultaPeloNome()
        {
            EscreverNaTela("Entre com o nome da pessoa: ");
            string nome = Console.ReadLine();

            var pessoaEncontrada = BancoDeDados.BuscarTodasPessoas().Where(pessoa => pessoa.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));

            int quantidadePessoaEncontrada = pessoaEncontrada.Count();

            if (quantidadePessoaEncontrada > 0)
            {
                EscreverNaTela("Pessoa encontrada");

                foreach (var pessoa in pessoaEncontrada)
                {
                    Console.WriteLine(pessoa.Nome);
                }

            }
            else
            {
                EscreverNaTela("Nenhuma pessoa encontrada para o nome digitado: " + nome);
            }

            MenuPrincipal();

        }

        static void ConsultaPeloSobreNome()
        {
            EscreverNaTela("Entre com o nome da pessoa: ");
            string sobreNome = Console.ReadLine();

            var pessoaEncontrada = BancoDeDados.BuscarTodasPessoas().Where(pessoa => pessoa.SobreNome.Contains(sobreNome, StringComparison.OrdinalIgnoreCase));

            int quantidadePessoaEncontrada = pessoaEncontrada.Count();

            if (quantidadePessoaEncontrada > 0)
            {
                EscreverNaTela("Pessoa encontrada");

                foreach (var pessoa in pessoaEncontrada)
                {
                    Console.WriteLine(pessoa.SobreNome);
                }

            }
            else
            {
                EscreverNaTela("Nenhuma pessoa encontrada para o nome digitado: " + sobreNome);
            }

            MenuPrincipal();

        }

        static void ConsultarPelaData()
        {
            Console.WriteLine("Entre com a data");
            var dataNascimento = DateTime.Parse(Console.ReadLine());

            var filtroPessoaPelaDataNascimento = BancoDeDados.BuscarTodasPessoas().Where(pessoa => pessoa.DataNascimento.Date == dataNascimento);

            EscreverNaTela("Pessoa encontrada");

            foreach (var pessoa in filtroPessoaPelaDataNascimento)
            {
                Console.WriteLine(pessoa.Nome);
            }
            MenuPrincipal();
        }

    }
}
