using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaTelefonica
{
    public partial class Principal : Form
    {

        pessoa pessoa1 = new pessoa();
        pessoaDAO pessoaDAO = new pessoaDAO();

        private dbs db;//cria variavel tipo conexao banco dados
        private pessoa cruds;//cria variavel tipo classe pessoa
        private int catchRowIndex;

        public Principal()
        {
            InitializeComponent();
        }

        private void Btn_inserir_Click(object sender, EventArgs e)
        {
            pessoa1.Nome = Txb_nome.Text;
            pessoa1.Email = Txb_email.Text;
            pessoa1.TelResidencial = Txb_telefone.Text;
            pessoa1.TelCelular = Txb_celular.Text;
            pessoa1.DataNascimento = Txb_datanascimento.Text;
            LimparDados();
            pessoa1.inserir();
            carregaDados();




        }

        private void Principal_Load(object sender, EventArgs e)
        {
            usuarioDAO usuarioDAO1 = new usuarioDAO();

            carregaDados();
            Txb_nome.Focus();
            comboBox1.Text = "Portugês"; // Inicializa tradução em portugûes
            lbl_nomeusuario.Text = usuarioDAO1.Usuario;


           


        }

        private void carregaDados()
        {
            db = new dbs();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            string connectionString = db.getConnectionString();
            string query = "SELECT * FROM pessoa";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    try
                    {
                        

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3], dataTable.Rows[i][4], dataTable.Rows[i][5]);

                            

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
            }
        }

        private void Btn_excluir_Click(object sender, EventArgs e)
        {
            if (Txb_id.Text != "") // Tratando erro ao excluir célula não selecionada.
            {
                pessoa1.PessoaID = Convert.ToInt32(Txb_id.Text);
                dataGridView1.Rows.RemoveAt(catchRowIndex);
                pessoaDAO.RemoverDados(pessoa1.PessoaID);
                LimparDados();
            }
            else
            {
                MessageBox.Show("Selecione algum campo para exclusão!");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            catchRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Txb_id.Text = row.Cells[0].Value.ToString();
                Txb_nome.Text = row.Cells[1].Value.ToString();
                Txb_email.Text = row.Cells[2].Value.ToString();
                Txb_celular.Text = row.Cells[3].Value.ToString();
                Txb_telefone.Text = row.Cells[4].Value.ToString();
                Txb_datanascimento.Text = row.Cells[5].Value.ToString();
               



            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            catchRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Txb_id.Text = row.Cells[0].Value.ToString();
                Txb_nome.Text = row.Cells[1].Value.ToString();
                Txb_email.Text = row.Cells[2].Value.ToString();
                Txb_celular.Text = row.Cells[3].Value.ToString();
                Txb_telefone.Text = row.Cells[4].Value.ToString();
                Txb_datanascimento.Text = row.Cells[5].Value.ToString();


                


            }
        }

        public void LimparDados()
        {
            Txb_celular.Text = "";
            Txb_datanascimento.Text = "";
            Txb_email.Text = "";
            Txb_id.Text = "";
            Txb_nome.Text = "";
            Txb_telefone.Text = "";


        }

        private void Btn_pesquisar_Click(object sender, EventArgs e)
        {


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {


            try
            {
                pessoa1.Nome = Txb_nome.Text;
                pessoa1.Email = Txb_email.Text;
                pessoa1.TelResidencial = Txb_telefone.Text;
                pessoa1.TelCelular = Txb_celular.Text;
                pessoa1.DataNascimento = Txb_datanascimento.Text;

                pessoa1.PessoaID = int.Parse(Txb_id.Text);
                pessoa1.Atualizar();
                dataGridView1[0, catchRowIndex].Value = Txb_id.Text;
                dataGridView1[1, catchRowIndex].Value = Txb_nome.Text;
                dataGridView1[2, catchRowIndex].Value = Txb_email.Text;
                dataGridView1[3, catchRowIndex].Value = Txb_telefone.Text;
                dataGridView1[4, catchRowIndex].Value = Txb_celular.Text;
                dataGridView1[5, catchRowIndex].Value = Txb_datanascimento.Text;

                LimparDados();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao realizar a operação", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buscarDados()
        {
            db = new dbs();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            string connectionString = db.getConnectionString();
            string query = "select * from pessoa WHERE nome LIKE '" + Txb_nome.Text + "%'";      //SELECT * FROM `pessoa` WHERE nome LIKE "gabriel%";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3], dataTable.Rows[i][4], dataTable.Rows[i][5]);
                            lbl_nomeusuario.Text = dataTable.Rows[i][1].ToString();


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);

                    }
                }
            }
        }

        private void Btn_pesquisar_Click_1(object sender, EventArgs e)
        {
            buscarDados();
        }

        private void bunifuPanel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Português")
            {
                IdiomaPortugues();
            }
            if (comboBox1.Text == "Inglês")
            {
                Idiomaingles();
            }

        }


        private void IdiomaPortugues()
        {
            // alterando imagem do país
            img_br.Visible = true;
            img_eua.Visible = false;
            // mudandando a linguagem do software
            Txb_nome.PlaceholderText = "Nome";
            Txb_email.PlaceholderText = "Email";
            Txb_telefone.PlaceholderText = "Telefone";
            bunifuLabel1.Text = "Data de nascimento";
            Txb_celular.PlaceholderText = "Celular";
            bunifuLabel3.Text = "Pesquisar pelo nome";
            bunifuLabel4.Text = "Pesquisar pelo código";
            bunifuLabel6.Text = "Alterar idioma";
            Btn_inserir.Text = "INSERIR";
            Btn_excluir.Text = "EXCLUIR";
            bunifuButton1.Text = "ATUALIZAR";


        }
        private void Idiomaingles()
        {
            // alterando imagem do país
            img_br.Visible = false;
            img_eua.Visible = true;
            // mudandando a linguagem do software
            Txb_nome.PlaceholderText = "Name";
            Txb_email.PlaceholderText = "Email";
            Txb_telefone.PlaceholderText = "Telephone";
            bunifuLabel1.Text = "Date of birth";
            Txb_celular.PlaceholderText = "Cell";
            bunifuLabel3.Text = "Search by name";
            bunifuLabel4.Text = "Search by code";
            bunifuLabel6.Text = "Change the language";
            Btn_inserir.Text = "INSERT";
            Btn_excluir.Text = "DELETE";
            bunifuButton1.Text = "UPDATE";


        }

    }
}
