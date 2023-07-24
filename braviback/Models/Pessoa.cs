using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Contato> Contatos { get; set; }
    }

    public class Contato
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
    }
}
