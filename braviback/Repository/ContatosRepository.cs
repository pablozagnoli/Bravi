using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PessoaRepository
    {
        private string _connectionString;

        public PessoaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Pessoa> ObterTodasPessoas()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Pessoas";
                var pessoas = connection.Query<Pessoa>(query, buffered: false);
                foreach (var pessoa in pessoas)
                {
                    pessoa.Contatos = ObterContatosPorPessoaId(pessoa.Id).ToList();
                }
                return pessoas;
            }
        }

        public Pessoa ObterPessoaPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Pessoas WHERE Id = @Id";
                var pessoa = connection.QueryFirstOrDefault<Pessoa>(query, new { Id = id });
                if (pessoa != null)
                {
                    pessoa.Contatos = ObterContatosPorPessoaId(pessoa.Id).ToList();
                }
                return pessoa;
            }
        }

        public void InserirPessoa(Pessoa pessoa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Pessoas (Nome) VALUES (@Nome); SELECT SCOPE_IDENTITY()";
                int pessoaId = connection.ExecuteScalar<int>(query, new { pessoa.Nome });

                foreach (var contato in pessoa.Contatos)
                {
                    InserirContato(contato, pessoaId);
                }
            }
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Pessoas SET Nome = @Nome WHERE Id = @Id";
                connection.Execute(query, new { pessoa.Nome, pessoa.Id });

                ExcluirContatosPorPessoaId(pessoa.Id);
                foreach (var contato in pessoa.Contatos)
                {
                    InserirContato(contato, pessoa.Id);
                }
            }
        }

        public void ExcluirPessoa(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Pessoas WHERE Id = @Id";
                connection.Execute(query, new { Id = id });

                ExcluirContatosPorPessoaId(id);
            }
        }

        private void InserirContato(Contato contato, int pessoaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Contatos (PessoaId, Tipo, Valor) VALUES (@PessoaId, @Tipo, @Valor)";
                connection.Execute(query, new { PessoaId = pessoaId, contato.Tipo, contato.Valor });
            }
        }

        private IEnumerable<Contato> ObterContatosPorPessoaId(int pessoaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Contatos WHERE PessoaId = @PessoaId";
                return connection.Query<Contato>(query, new { PessoaId = pessoaId }, buffered: false);
            }
        }

        private void ExcluirContatosPorPessoaId(int pessoaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Contatos WHERE PessoaId = @PessoaId";
                connection.Execute(query, new { PessoaId = pessoaId });
            }
        }
    }
}
