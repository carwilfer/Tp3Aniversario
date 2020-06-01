using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Tp3Aniversario
{
    public class Pessoa
    {
            public string Nome { get; set; }
            public string SobreNome { get; set; }
            public DateTime DataNascimento { get; set; }
            public DateTime DataDeCadastro { get; set; }
    }
}