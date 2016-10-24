using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL_logins
{
    public partial class Banco : Form
    {
        public Banco()
        {
            InitializeComponent();
        }

        private void Banco_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*A variável strcon é o connection string que copiamos anteriormente enquanto criávamos o banco de dados, essa variável poderia ser utilizada para todos os botões do programa, mas irei repeti-la várias vezes para fixar a idéia dos passos que precisamos seguir para fazer a conexão com o banco, Obs.: note que o caminho do seu banco precisa estar com “\\” se não estiver coloque */
            string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MyLogins.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection conexao = new SqlConnection(strcon); /* conexao irá conectar o C# ao banco de dados */
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tabela", conexao); /*cmd possui mais de um parâmetro, neste caso coloquei o comando SQL "SELECT * FROM tabela" que irá selecionar tudo(*) de tabela, o segundo parâmetro indica onde o banco está conectado,ou seja se estamos selecionando informações do banco precisamos dizer onde ele está localizado */
            //Try //Tenta executar o que estiver abaixo
            try{
                conexao.Open(); // abre a conexão com o banco   
                cmd.ExecuteNonQuery(); // executa cmd
                                       /*Pronto após o cmd.ExecuteNonQuery(); selecionamos tudo o que tinha dentro do banco, agora os passos seguintes irão exibir as informações para que o usuário possa vê-las    */
                SqlDataAdapter da = new SqlDataAdapter(); /* da, adapta o banco de dados ao nosso projeto */
                DataSet ds = new DataSet();
                da.SelectCommand = cmd; // adapta cmd ao projeto
                da.Fill(ds); // preenche todas as informações dentro do DataSet                                          
                dataGridView1.DataSource = ds; //Datagridview recebe ds já preenchido
                dataGridView1.DataMember = ds.Tables[0].TableName;  /*Agora Datagridview exibe o banco de dados*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message); /*Se ocorer algum erro será informado em um msgbox*/
                throw;
            }
            finally
            {
                conexao.Close(); /* Se tudo ocorrer bem fecha a conexão com o banco da dados, sempre é bom fechar a conexão após executar até o final o que nos interessa, isso pode evitar problemas futuros */
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manipulador f = new Manipulador(); //instância de Form2                      
            f.Show(); //abre o Form2
        }
    }
}
