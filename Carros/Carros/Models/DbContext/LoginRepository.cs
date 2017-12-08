using System.Data.SqlClient;
using System;

namespace Carros.Models.DbContext
{
    public class LoginRepository : RepositoryBase
    {
        public Login ObterPorEmailSenha(string email, string senha)
        {
            Connection();

            Login login = new Login();

            using (SqlCommand command = new SqlCommand("SELECT * FROM LOGIN WHERE Email = @email and senha = @senha", _con))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Senha", senha);

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    login.Id = Convert.ToInt32(reader["Id"]);
                    login.Email = reader["Email"].ToString();
                    login.Senha = reader["Senha"].ToString();
                    login.Nome = reader["Nome"].ToString();
                }
            }

            _con.Close();

            return login;
        }
    }
}