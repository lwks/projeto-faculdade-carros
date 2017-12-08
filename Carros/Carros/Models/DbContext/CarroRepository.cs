using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Carros.Models.DbContext
{
    public class CarroRepository : RepositoryBase
    {
        /// <summary>
        /// Método responsalvel por adicionar Carro.
        /// </summary>
        /// <param name="carro">Objeto com as informações que será armazanado</param>
        /// <returns>true/false</returns>
        public bool Adicionar(Carro carro)
        {
            int resultado;
            bool result = false;
            Connection();

            using (SqlCommand command = new SqlCommand("InserindoCarro", _con))
            {
                _con.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Nome", carro.Nome);
                command.Parameters.AddWithValue("@Categoria", carro.Categoria);
                command.Parameters.AddWithValue("@Cor", carro.Cor);

                resultado = command.ExecuteNonQuery();

                if (string.IsNullOrEmpty(resultado.ToString()) || resultado == 0)
                {
                    result = false;
                }

                result = true;
            }

            _con.Close();

            return result;
        }

        /// <summary>
        /// Método responsavel por Obter todos os carros que estão armezandos no banco
        /// </summary>
        /// <returns>Lista de carros</returns>
        public List<Carro> Obter()
        {
            Connection();
            List<Carro> listCarro = new List<Carro>();

            using (SqlCommand command = new SqlCommand("ObterCarros", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listCarro.Add(new Carro
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString(),
                        Categoria = (Categoria)Enum.Parse(typeof(Categoria), (reader["Categoria"].ToString())),
                        Cor = (Cor)Enum.Parse(typeof(Cor), reader["Cor"].ToString())
                    });
                }
            }

            _con.Close();

            return listCarro;
        }

        /// <summary>
        /// Método responsavel por atualizar as informações
        /// </summary>
        /// <param name="carro">Objeto contendo os dados que serão atualizados</param>
        /// <returns>true/false</returns>
        public bool Atualizar(Carro carro)
        {
            int retorno;
            bool resultado = false;
            Connection();

            using (SqlCommand command = new SqlCommand("AtualizarCarro", _con))
            {
                _con.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", carro.Id);
                command.Parameters.AddWithValue("@Nome", carro.Nome);
                command.Parameters.AddWithValue("@Categoria", carro.Categoria);
                command.Parameters.AddWithValue("@Cor", carro.Cor);

                retorno = command.ExecuteNonQuery();

                if (string.IsNullOrEmpty(retorno.ToString()) || retorno == 0)
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }
            }

            _con.Close();

            return resultado;
        }

        /// <summary>
        /// Método responsavel para excluir item
        /// </summary>
        /// <param name="Id">Objeto de parametro para exclusão</param>
        /// <returns>true/false</returns>
        public bool Excluir(int Id)
        {
            int retorno;
            bool resultado = false;
            Connection();

            using (SqlCommand command = new SqlCommand("ExcluirCarro", _con))
            {
                _con.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", Id);
                
                retorno = command.ExecuteNonQuery();

                if (string.IsNullOrEmpty(retorno.ToString()) || retorno == 0)
                {
                    resultado = false;
                }

                resultado = true;
            }

            _con.Close();

            return resultado;
        }
    }
}