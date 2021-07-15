using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaTelefonica
{
    class pessoaDAO
    {
        private dbs db;
        private MySqlConnection con;

        public void InserirDados(String nome, String email, string telresidencial, string telcelular, string datanascimento)
        {
            con = new MySqlConnection();
            db = new dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "INSERT INTO pessoa (nome, email, telresidencial, telcelular,datanascimento) VALUES";
            query += "(?nome, ?email, ?telresidencial, ?telcelular, ?datanascimento)";

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?telresidencial", telresidencial);
                cmd.Parameters.AddWithValue("?telcelular", telcelular);
                cmd.Parameters.AddWithValue("?datanascimento", datanascimento);
                MessageBox.Show("Cadastrado com sucesso!");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch
            {

                con.Close();
                MessageBox.Show("Falha ao acesar o banco!");
            }
        }

        public void RemoverDados(Int32 pessoaID)
        {
            con = new MySqlConnection();
            db = new dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "DELETE FROM pessoa ";
            query += "WHERE pessoaID = ?pessoaID";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pessoaID", pessoaID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Deletado com sucesso!");
            }
            finally
            {
                con.Close();
            }
        }

        public void AtualizarDados(String nome, String email, String telResidencial, String telCelular, String dataNascimento, Int32 pessoaID)
        {
            con = new MySqlConnection();
            db = new dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE pessoa SET nome = ?nome, email = ?email, telResidencial = ?telResidencial, telCelular = ?telCelular, dataNascimento = ?dataNascimento, pessoaID = ?pessoaID";
            query += " WHERE pessoaID = ?pessoaID";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?email", email);
                cmd.Parameters.AddWithValue("?telResidencial", telResidencial);
                cmd.Parameters.AddWithValue("?telCelular", telCelular);
                cmd.Parameters.AddWithValue("?dataNascimento", dataNascimento);
                cmd.Parameters.AddWithValue("?pessoaID", pessoaID);
                MessageBox.Show("Atualizado com sucesso!");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }


    }

    
}
