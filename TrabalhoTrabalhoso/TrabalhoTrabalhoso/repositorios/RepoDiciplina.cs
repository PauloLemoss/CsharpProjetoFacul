using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Disciplina.Disciplina

namespace TrabalhoTrabalhoso
{
    public class ReposDisciplina
    {
        public void Inserir(Disciplina disciplina)
        {   //conectando ao banco de dados do professor com um método inserir...
            Conexao C = new Conexao();

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
            try
            {


                conexao.Open();

                // Instanciando um "Command" com o código SQL e a Conexão estabelecida anteriormente

                MySqlCommand comando = new MySqlCommand($"INSERT INTO aluno (NomeAluno, Cpf, Email ) VALUES (@NomeAluno, @CpfAluno,EmailAluno)", conexao);
                // Executando (Efetivando) o comando criando anteriormente
                comando.Parameters.AddWithValue("@NomeAluno", disciplina.NomeDisciplina);
               

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
        public void Alterar(Disciplina disciplina)
        {
            // Bloco do Try: Tentando abrir conexão e realizar comando no Banco de Dados
            try
            {
                MySqlConnection conexao = new MySqlConnection(@"Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
                // Abrindo a conexão com o banco de dados;
                conexao.Open();
                // Instanciando um "Command" com o código SQL e a Conexão estabelecida anteriormente
                MySqlCommand comando = new MySqlCommand(string.Format($"UPDATE aluno SET NomeAluno = @NomeAluno, Cpf = @Email, =  WHERE id_aluno = @Id"), conexao);
                // Adicionando parâmetro SQL para o Id
                comando.Parameters.AddWithValue("@Id", disciplina.IdDisciplina);
                // Adicionando parâmetro SQL para o Nome
                comando.Parameters.AddWithValue("@Nome", disciplina.NomeDisciplina);
                // Adicionando parâmetro SQL para o Email
               
                comando.ExecuteNonQuery();
            }
            //tratando possíveis erros
            catch (Exception ex)
            {
                // Escalando o erro para a classe que chama este método
                throw ex;
            }
            // Conseguindo ou não realizar as opções, executar o Finally (Fechando a conexão)
            finally
            {
                MySqlConnection conexao = new MySqlConnection(@"Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
                // Fechando a conexão com o banco de dados (Tem que fechar sempre);
                conexao.Close();
            }


        }
        public void Apagar(int id)
        {
            MySqlConnection conexao = new MySqlConnection(@"Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");

            try
            {
                //Excluindo o registro
                conexao.Open();
                MySqlCommand comando = new MySqlCommand("DELETE FROM aluno WHERE id_aluno = @id", conexao);
                comando.Parameters.AddWithValue("@Id", disciplina.IdDisciplina);
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
        }
        //Método listar, cujo parâmetro nome é "opcional"
        public List<Disciplina> Listar(string nome = null)
        {
            // Criando a lista de clientes vazia
            List<Disciplina> disciplinas = new List<Disciplina>();
            // Bloco do Try: Tentando abrir conexão e realizar comando no Banco de Dados
            try
            {
                MySqlConnection conexao = new MySqlConnection(@"Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
                // Abrindo a conexão com o banco de dados;
                conexao.Open();
                // Instanciando um "Command" com o código SQL e a Conexão estabelecida anteriormente
                MySqlCommand comando = null;
                // Comando SQL em caso do parâmetro "Nome" ser NULL
                if (nome == null)
                {
                    // Comando retornando todos os clientes ser "WHERE"
                    comando = new MySqlCommand("SELECT * FROM aluno", conexao);
                }
                // Comando SQL em caso do parâmetro "Nome" não ser NULL
                else
                {
                    // Comando retornando todos os alunos com "WHERE", cujo
                    // Nome é igual ao informado pelo parâmetro
                    comando = new MySqlCommand("SELECT * FROM aluno WHERE nome LIKE @Nome", conexao);
                    // Adicionando parâmetro SQL para o Nome
                    comando.Parameters.AddWithValue("@Nome", string.Format($"%{nome}%"));
                }
                // Executando (Efetivando) o comando criando anteriormente e salvando os dados no Data Reader
                MySqlDataReader reader = comando.ExecuteReader();
                // Em posse do Data Reader, vou ler os dados, sempre do primeiro até o último e "pra frente"
                while (reader.Read())
                {
                    // Instanciando um objeto chamado "aluno" da classe "Aluno"
                    Disciplina disciplina = new Disciplina();
                    // Buscando a informação ID do Banco de dados e salvando no atributo correspondente
                    aluno.IdAluno = reader.GetString("Id");
                    // Buscando a informação Nome do Banco de dados e salvando no atributo correspondente
                    aluno.NomeAluno = reader.GetString("Nome");
                    // Buscando a informação Email do Banco de dados e salvando no atributo correspondente
                    aluno.EmailAluno = reader.GetString("Email");
                    // Buscando a informação Cpf do Banco de dados e salvando no atributo correspondente
                    aluno.CpfAluno = reader.GetInt32("Cpf");
                    // Adicionando este objeto à lista de alunos (chamada "alunos)
                    alunos.Add(aluno);
                }
            }
            // Tratando possíveis erros ...
            catch (Exception ex)
            {
                // Escalando o erro para a classe que chama este método
                throw ex;
            }
            // Conseguindo ou não realizar as opções, executar o Finally (Fechando a conexão)
            finally
            {
                MySqlConnection conexao = new MySqlConnection(@"Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
                // Fechando a conexão com o banco de dados (Tem que fechar sempre);
                conexao.Close();
            }
            // Retornando a lista de alunos (agora totalmente preenchida)
            return alunos;
        }
        public long ObterQuantidadeDeAlunos()
        {
            long quantidade = 0;
            // Bloco do Try: Tentando abrir conexão e realizar comando no Banco de Dados
            try
            {
                MySqlConnection conexao = new MySqlConnection(@"Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
                // Abrindo a conexão com o banco de dados;
                conexao.Open();
                // Instanciando um "Command" com o código SQL e a Conexão estabelecida anteriormente
                MySqlCommand comando = new MySqlCommand("SELECT COUNT(*) FROM aluno", conexao);
                // Executando (Efetivando) o comando criando anteriormente e salvando os dados inteiro "quantidade"
                quantidade = (long)comando.ExecuteScalar();
            }
            // Tratando possíveis erros ...
            catch (Exception ex)
            {
                // Escalando o erro para a classe que chama este método
                throw ex;
            }
            // Conseguindo ou não realizar as opções, executar o Finally (Fechando a conexão)
            finally
            {
                MySqlConnection conexao = new MySqlConnection(@"Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
                // Fechando a conexão com o banco de dados (Tem que fechar sempre);
                conexao.Close();
            }
            // Retornando a quantidade de aluno
            return quantidade;

        }
        internal void InserirTurma(Aluno aluno)
        {
            // Bloco do Try: Tentando abrir conexão e realizar comando no Banco de Dados

            try
            {
                MySqlConnection conexao = new MySqlConnection(@"Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
                conexao.Open();
                // Instanciando um "Command" com o código SQL e a Conexão estabelecida anteriormente
                MySqlCommand comando = new MySqlCommand(string.Format($"INSERT INTO turma (NomeTurma,id_professor,id_aluno,id_disciplina) VALUES (@NomeTurma,@id_professor,@id_aluno,@id_disciplina)"), conexao);
                // Adicionando parâmetro SQL para o nome (Inserindo apenas do primeiro Nome da disciplina ...)
                comando.Parameters.AddWithValue("@NomeTurma", aluno.Turmas);
                // Adicionando parâmetro SQL para o Modelo (Inserindo apenas do primeiro carro adicionado à lista ...)
                comando.Parameters.AddWithValue("@id_professor", aluno.Turmas);
                // Adicionando parâmetro SQL para o Modelo (Inserindo apenas do primeiro carro adicionado à lista ...)
                comando.Parameters.AddWithValue("@id_aluno", aluno.Turmas);
                // Adicionando parâmetro SQL para o Modelo (Inserindo apenas do primeiro carro adicionado à lista ...)
                comando.Parameters.AddWithValue("@id_disciplina", aluno.Turmas);

                comando.ExecuteNonQuery();
            }
            // Tratando possíveis erros ...
            catch (Exception ex)
            {
                // Escalando o erro para a classe que chama este método
                throw ex;
            }
            // Conseguindo ou não realizar as opções, executar o Finally (Fechando a conexão)
            finally
            {
                MySqlConnection conexao = new MySqlConnection(@"Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
                // Fechando a conexão com o banco de dados (Tem que fechar sempre);
                conexao.Close();
            }
        }
        public List<Aluno> ListarTurmas(int idAluno)
        {
            // Criando a lista de clientes vazia
            List<Aluno> alunos = new List<Aluno>();
            // Bloco do Try: Tentando abrir conexão e realizar comando no Banco de Dados
            try
            {
                MySqlConnection conexao = new MySqlConnection(@"Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
                // Abrindo a conexão com o banco de dados;
                conexao.Open();
                // Instanciando um "Command" com o código SQL e a Conexão estabelecida anteriormente
                MySqlCommand comando = null;

                // Comando retornando todos os carros de um determinado cliente
                comando = new MySqlCommand("SELECT * FROM turma WHERE id_aluno = @id", conexao);
                comando.Parameters.AddWithValue("@id", idAluno);

                // Executando (Efetivando) o comando criando anteriormente e salvando os dados no Data Reader
                MySqlDataReader reader = comando.ExecuteReader();
                // Em posse do Data Reader, vou ler os dados, sempre do primeiro até o último e "pra frente"
                while (reader.Read())
                {
                    // Instanciando um objeto chamado "cliente" da classe "Cliente"
                    Turma turma = new Turma(reader.GetInt32("Id"), reader.GetString("NomeTurma"), reader.GetInt32("IdProfessor"), reader.GetInt32("IdAluno"),reader.GetInt32("IdDisciplina"));
                    // Adicionando este objeto à lista de clientes (chamada "clientes)
                    turmas.Add(rurma);
                }
            }
            // Tratando possíveis erros ...
            catch (Exception ex)
            {
                // Escalando o erro para a classe que chama este método
                throw ex;
            }
            // Conseguindo ou não realizar as opções, executar o Finally (Fechando a conexão)
            finally
            {
                // Fechando a conexão com o banco de dados (Tem que fechar sempre);
                conexao.Close();
            }
            // Retornando a lista de clientes (agora totalmente preenchida)
            return carros;
        }
    }
}

