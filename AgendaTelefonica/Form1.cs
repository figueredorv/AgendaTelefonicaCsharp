using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AgendaTelefonica
{
    public partial class Form1 : Form
    {
        usuarioDAO usuarioDAO = new usuarioDAO();
        //instancia da classe connection
        connection con = new connection();

        string codigo, login, senha, nivel;

        private void Txb_senha_TextChanged(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Calcula MD% Hash de uma determinada string passada como parametro
        /// </summary>
        /// <param name="Senha">String contendo a senha que deve ser criptografada para MD5 Hash</param>
        /// <returns>string com 32 caracteres com a senha criptografada</returns>
        public static string CalculaHash(string Senha)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Senha);
                byte[] hash = md5.ComputeHash(inputBytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString(); // Retorna senha criptografada 
            }
            catch (Exception)
            {
                return null; // Caso encontre erro retorna nulo
            }
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            

            try
            {
                //condição para campos diferentes de vazios
                if (Txb_usuario.Text != "" && Txb_senha.Text != "")
                {
                    con.Open();
                    //captura do form o campo do login e a senha para calcular hash
                    string query = "select * from usuario WHERE login ='" + Txb_usuario.Text
                                   + "' AND senha ='" + CalculaHash(Txb_senha.Text) + "'";

                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            codigo = row["codigo"].ToString();
                            login = row["login"].ToString();
                            senha = row["senha"].ToString();
                            nivel = row["nivel"].ToString();
                        }

                        MessageBox.Show("Acessado por " + login + " com nível " + nivel);
                        Principal principal = new Principal(); //instanciando formulario principal
                        this.Hide(); //ocultando formulario login
                        principal.Show(); //exibindo formulario principal
                        



                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado!", "Informação");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario e senha vazios.", "Informação");
                }
            }
            catch
            {
                MessageBox.Show("Erro de conexão.", "Informação");
            }


        }
        
    }
}
