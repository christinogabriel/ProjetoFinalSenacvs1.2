using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Workspace.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class Cadastro
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public int DataNascimento { get; set; }
    }
    public class FluxoDataBase2
    {
        private string connectionString = "Data Source=seu_servidor;Initial Catalog=seu_banco_de_dados;User ID=seu_usuario;Password=sua_senha;";


        public void CadastrarUsuario(Cadastro cadastro)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Cadastro (email, senha, endereco, complemento, dataNascimento) " +
                               "VALUES (@email, @senha, @endereco, @complemento, @dataNascimento)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", cadastro.Email);
                    command.Parameters.AddWithValue("@senha", cadastro.Senha);
                    command.Parameters.AddWithValue("@endereco", cadastro.Endereco);
                    command.Parameters.AddWithValue("@complemento", cadastro.Complemento);
                    command.Parameters.AddWithValue("@dataNascimento", cadastro.DataNascimento);

                    command.ExecuteNonQuery();
                }
            }
        }
                public bool VerificarCredenciais(Login login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Login WHERE email = @email AND senha = @senha";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", login.Email);
                    command.Parameters.AddWithValue("@senha", login.Senha);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }


    }
}