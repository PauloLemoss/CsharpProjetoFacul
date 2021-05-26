using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace TrabalhoTrabalhoso
{
    public class RepositorioMySQL
    {
        public void Inserir(Curso curso)
        {   //conectando ao banco de dados do professor com um método vazio notas...
            MySqlConnection conexao = new MySqlConnection("Server=MYSQL5030.site4now.net;Port=3306;Database=db_a2d8fc_aula;Uid=a2d8fc_aula;Pwd=abc12345;");

            conexao.Open();
            // Instanciando um "Command" com o código SQL e a Conexão estabelecida anteriormente

            MySqlCommand comando = new MySqlCommand("INSERT INTO curso (curso ) VALUES (@Curso)", conexao);
            // Executando (Efetivando) o comando criando anteriormente
            comando.Parameters.AddWithValue("@Curso", curso.Cursoo);

            comando.ExecuteNonQuery();

            // Fechando a conexão com o banco de dados ();;
            conexao.Close();
        }
        public void Apagar(int id)
        {
            MySqlConnection conexao = new MySqlConnection(@"");
            conexao.Open();
            MySqlCommand comando = new MySqlCommand("DELETE FROM curso WHERE id_curso = @id", conexao);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
        
}
