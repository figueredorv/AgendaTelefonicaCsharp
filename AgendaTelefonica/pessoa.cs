using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica
{
    class pessoa
    {


        pessoaDAO cdao = new pessoaDAO();




        private int pessoaID;
        private string nome;
        private string email;
        private string telResidencial;
        private string telCelular;
        private string dataNascimento;

        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string TelResidencial { get => telResidencial; set => telResidencial = value; }
        public string TelCelular { get => telCelular; set => telCelular = value; }
        public string DataNascimento { get => dataNascimento; set => dataNascimento = value; }
        public int PessoaID { get => pessoaID; set => pessoaID = value; }

        public void inserir()
        {
            cdao = new pessoaDAO();
            cdao.InserirDados(Nome, Email, TelResidencial, TelCelular, DataNascimento );

          
        }
        public void Atualizar()
        {
           pessoaDAO pessoaDAO = new pessoaDAO();
            pessoaDAO.AtualizarDados(nome, email, telResidencial, telCelular, dataNascimento, pessoaID);
        }

    }
}
