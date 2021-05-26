using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace TrabalhoTrabalhoso
{
    public class RepositorioMySQL
    {
        public void Inserir(Aluno aluno)
        {   //conectando ao banco de dados do professor com um método inserir...
            Conexao C = new Conexao();

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
            try
            {


                conexao.Open();

                // Instanciando um "Command" com o código SQL e a Conexão estabelecida anteriormente

                MySqlCommand comando = new MySqlCommand($"INSERT INTO aluno (NomeAluno, Cpf, Email ) VALUES (@NomeAluno, @CpfAluno,EmailAluno)", conexao);
                // Executando (Efetivando) o comando criando anteriormente
                comando.Parameters.AddWithValue("@Aluno", aluno.NomeAluno);
                comando.Parameters.AddWithValue("@Aluno", aluno.EmailAluno);
                comando.Parameters.AddWithValue("@Aluno", aluno.CpfAluno);

                comando.ExecuteNonQuery();


            }
            catch
            {
                System.Console.WriteLine("Não foi possível inserir os dados...");
            }
            finally
            {
                // Fechando a conexão com o banco de dados ();;
                conexao.Close();
            }




        }
        public void Apagar(int id)
        {
            MySqlConnection conexao = new MySqlConnection(@"Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
            conexao.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand("DELETE FROM aluno WHERE id_aluno = @id", conexao);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch
            {
                System.Console.WriteLine("Não foi possível deletar");
            }
            finally
            {
                conexao.Close();
            }

               List<Aluno> Listar()
            {
                // Criando a lista de alunos vazia
                // Abrindo a conexão com o banco de dados;
                conexao.Open();
                // Instanciando um "Command" com o código SQL e a Conexão estabelecida anteriormente
                List<Aluno> alunos = new List<Aluno>();
                MySqlCommand comando = new MySqlCommand("SELECT * FROM aluno", conexao);
                // Executando (Efetivando) o comando criando anteriormente e salvando os dados no Data Reader
                MySqlDataReader reader = comando.ExecuteReader();
                // Em posse do Data Reader, vou ler os dados, sempre do primeiro até o último e "pra frente"
                while (reader.Read())
                {
                    // Instanciando um objeto chamado "aluno" da classe "Aluno"
                    Aluno aluno = new Aluno ();
                    // Buscando a informação ID do Banco de dados e salvando no atributo correspondente
                    aluno.NomeAluno = reader.GetString("NomeAluno");
                    // Buscando a informação Nome do Banco de dados e salvando no atributo correspondente
                    // Buscando a informação Email do Banco de dados e salvando no atributo correspondente
                    aluno.EmailAluno = reader.GetString("EmailAluno");
                    // Buscando a informação CPF do Banco de dados e salvando no atributo correspondente
                    aluno.CpfAluno = reader.GetInt32("CpfAluno");
                    // Adicionando este objeto à lista de alunos (chamada "alunos)
                    alunos.Add(aluno);
                }
                // Fechando a conexão com o banco de dados (Tem que fechar sempre);
                conexao.Close();
                // Retornando a lista de clientes (agora totalmente preenchida)
                return alunos;
            }
        }

    }
}
