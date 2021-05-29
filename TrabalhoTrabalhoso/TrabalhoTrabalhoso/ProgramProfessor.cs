using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioMySQLDisciplina;


namespace TrabalhoTrabalhoso
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();
                // Perguntar qual é a ação que o usuário deseja
                Console.WriteLine("Escolha uma opção:");
                // Mudando a cor de fundo do texto para Azul
                
                
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("_______________________ Professor__________________________________");

                Professor professor = new Professor();
                professor.NomeNomeProfessor = "João Paulo";
                professor.CpfProf = "541.621.695-06";
                professor.EmailProf = "jp@pm.gov.br";
                              
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("1 - Inserir Professor");
                Console.WriteLine("2 - Deletar Professor");
                Console.WriteLine("3 - Listar Professor");
                Console.WriteLine("4 - Consultar Professor");
                Console.WriteLine("5 - Alterar Professor");
                Console.WriteLine("6 - Contar Professor");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
              
                Console.ResetColor();
                // Instanciar o meu repositório
                RepositorioMySQLProfessor repositorio = new RepositorioMySQLProfessor();
                try
                {
                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            Console.Clear();

                            // Instanciar do professor
                            Professo discilina = new Professor();
                            // Solicitar o nome do profesor
                            Console.WriteLine("Informe o professor:");
                            // Ober o nome da dsiciplina (digitado no teclado)
                            professor.NomeProfessor = Console.ReadLine();
                           

                            repositorio.Inserir(professor);
                            break;
                        case '2':
                            Console.Clear();
                            // Listando todos as disciplinas retornados pela lista de dsiciplina através do método repositorio.Listar()
                            ListarProfessor(repositorio);
                            // Perguntar  qual é o ID que ele deseja deletar
                            Console.WriteLine("Informe o ID do professor que você deseja deletar:");
                            // Chamar o método deletar, passando o ID informado pelo usuário
                            repositorio.Apagar(int.Parse(Console.ReadLine()));
                            break;
                        case '3':
                            Console.Clear();
                            // Listando todos os professpres retornados pela lista de profesor através do método repositorio.Listar()
                            ListarProfessor(repositorio);
                            break;
                        case '4':
                            Console.Clear();
                            // Perguntar o nome que deseja consultar
                            Console.WriteLine("Informe o nome que deseja consultar:");
                            // Listando todos as disciplinas retornados pela lista do professor através do método repositorio.Listar()
                            foreach (Professor ProfessorDaVez in repositorio.Listar(Console.ReadLine()))
                            {
                                
                                Console.WriteLine(ProfessoraDaVez.ToString());
                            }
                            break;
                        case '5':
                            Console.Clear();
                            // Perguntar o nome que deseja consultar
                            Console.WriteLine("Informe o professor que deseja alterar:");
                            // Obtendo a lista de professor
                            List<Professor> listaDeProfessor = repositorio.Listar(Console.ReadLine());
                            // Listando todas as dsiciplenas retornados pela lista de professor  através do método repositorio.Listar()
                            foreach (ProfessorprofessorDaVez in listaDeProfessor)
                            {
                               
                                Console.WriteLine(professorDaVez.ToString());
                            }
                            if (listaDeDisciplina != null && listaDeDisciplina.Count > 0)
                            {
                                // Solicitar o ID de qual das disciplinas listados deseja alterar:
                                Console.WriteLine("Informe, pelo ID, qual dos professores acima você deseja alterar:");
                               
                               Disciplina DisciplinaAlterar = listaDeDisciplina.FindLast(c => c.Id == int.Parse(Console.ReadLine()));
                                // Solicitar o novo nome
                                Console.WriteLine($"Informe o  nome para {ProfessorAlterar.NomeProfessor}:");
                                
                               ProfessorAlterar.NomeProfesssor = Console.ReadLine();
                                // Efetivando a alteração no Banco de Dados
                                repositorio.Professor(ProfessorAlterar);
                            }
                            else
                            {
                                // Caso a lista de dsiciplinas não retorne nenhum registro, exibir mensagem abaixo.
                                Console.WriteLine("Nenhum registro encontrado ...");
                            }
                            break;
                        case '6':
                            Console.Clear();
                            // Informando a quantidade de dsiciplas registradas, através do método Obter Quantidade ...
                            Console.WriteLine($"Total de Professor registradas: {repositorio.ObterQuantidadeDeProfessor()}");
                            break;
                        
                           
                        default:
                            Console.Clear();
                            Console.WriteLine("Opção Indisponível!");
                            break;
                    }
                }
                catch (MySqlException ex)
                {
                    // Mudando a cor do texto para Vermelho (Informações Críticas)
                    Console.ForegroundColor = ConsoleColor.Red;
                    // Exibindo mensagens de erro de banco de dados
                    Console.WriteLine("Ocorreu um erro ao tentar realizar a Operação no Banco de Dados.");
                    Console.WriteLine("Contacte o suporte.");
                    // Voltando a cor do texto para a cor padrão
                    Console.ResetColor();
                }
                catch (FormatException ex)
                {
                    // Mudando a cor do texto para Amarelo (Informações Importantes)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    // Eixibindo mensagem de erro de Formato
                    Console.WriteLine("Alguma das informações não estava no formato correto.");
                    Console.WriteLine("Tente novamente, inserindo as informações corretas.");
                    // Voltando a cor do texto para a cor padrão
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    // Mudando a cor do texto para Vermelho (Informações Críticas)
                    Console.ForegroundColor = ConsoleColor.Red;
                    // Exibindo mensagens genéricas ...
                    Console.WriteLine("Ocorreu um erro.");
                    Console.WriteLine("Contacte o suporte.");
                    // Voltando a cor do texto para a cor padrão
                    Console.ResetColor();
                }
                Console.WriteLine("Você deseja continuar? s p/ sim ...");
            } while (Console.ReadKey().KeyChar == 's');
        }

        public static void ListarProfessor(RepositorioMySQLProfessor repositorio)
        {
            // Listando todos os alunos retornados pela lista de aluno através do método repositorio.Listar()
            foreach (Professor ProfessorDaVez in repositorio.Listar())
            {
                // Imprimindo as informações de cada aluno na tela, utilizando o "ToString" que foi sobrescrito na classe
                // Aluno ...
                Console.WriteLine(ProfessorDaVez.ToString());
            }
        }
    }
}
