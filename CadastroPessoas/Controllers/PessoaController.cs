using Microsoft.AspNetCore.Mvc;
using CadastroPessoas.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace CadastroPessoas.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Cadastro(string nome, string email, string cpf, string endereco, string dataNascimento)
        {
            Pessoa p1 = new Pessoa();

            p1.Nome = nome;
            p1.Email = email;
            p1.Cpf = cpf;
            p1.Endereco = endereco;
            p1.DataNascimento = dataNascimento;

            IDbConnection conexao = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=CadastroPessoas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conexao.Open();

            string sql = "INSERT INTO dbo.PESSOA (ID, NOME, CPF, EMAIL, ENDERECO, DATA_NASCIMENTO) " +
                "VALUES (@Id, @Nome, @Cpf, @Email, @Endereco, @DataNascimento)";

            conexao.Execute(sql, new
            {
                Id = new Random().Next(100),
                Nome = p1.Nome,
                Cpf = p1.Cpf,
                Email = p1.Email,
                Endereco = p1.Endereco,
                DataNascimento = p1.DataNascimento
            });

            //conexao.Execute(sql, p1);
            conexao.Close();

            return View();

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
