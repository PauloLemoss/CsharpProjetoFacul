using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                Console.WriteLine("_______________________ TURMA __________________________________");

              
                              
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("1 - Inserir Turma");
                Console.WriteLine("2 - Deletar Turma");
                Console.WriteLine("3 - Listar Turma");
                Console.WriteLine("4 - Consultar Turma");
                Console.WriteLine("5 - Alterar Turma");
                Console.WriteLine("6 - Contar Turma");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("_______________________ ALUNOS NA TURMA  _______________________");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("7 - Inserir Aluno para essa Turma");
                Console.WriteLine("8 - Listar todas as Turma dos Alunos");
                // Voltando a cor do texto para a cor padrão
                Console.ResetColor();
                // Instanciar o meu repositório
                RepositorioMySQLturma repositorio = new RepositorioMySQLturma();
                try
                {
                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            Console.Clear();

                            // Instanciar o Turma
                            Turma turma = new Turma();
                            // Solicitar o nome do aluno
                            Console.WriteLine("Informe o sua turma:");
                            // Ober o nome da turma (digitado no teclado)
                            turma.NomeTurma = Console.ReadLine();
                            // Solicitar o professor para a turma
                            Console.WriteLine("Informe o professor:");
                            // Ober o email do aluno (digitado no teclado)
                            turma.IdProfessor = Console.ReadLine();
                            Console.WriteLine("Informe o aluno:");
                            // Ober o cpf do cliente (digitado no teclado)
                            truma.IdAluno = int.Parse(Console.ReadLine());
                            truma.IdDisciplina = int.Parse(Console.ReadLine());
                            

                            repositorio.Inserir(turma);
                            break;
                        case '2':
                            Console.Clear();
                            // Listando todas as turmas retornados pela lista de turma através do método repositorio.Listar()
                            ListarAlunos(repositorio);
                            // Perguntar ao usuário qual é o ID que ele deseja deletar
                            Console.WriteLine("Informe o ID da turma que você deseja deletar:");
                            // Chamar o método deletar, passando o ID informado pelo usuário
                            repositorio.Apagar(int.Parse(Console.ReadLine()));
                            break;
                        case '3':
                            Console.Clear();
                            // Listando todos as trumas retornados pela lista de turmas através do método repositorio.Listar()
                            ListarTurma(repositorio);
                            break;
                        case '4':
                            Console.Clear();
                            // Perguntar o nome que deseja consultar
                            Console.WriteLine("Informe o nome da turma que deseja consultar:");
                            // Listando todas as turmas retornados pela lista de turmas através do método repositorio.Listar()
                            foreach (Turma TurmaDaVez in repositorio.Listar(Console.ReadLine()))
                            {
                                // Imprimindo as informações de cada truam na tela, utilizando o "ToString" que foi sobrescrito na classe
                                // Aluno ...
                                Console.WriteLine(TurmaVez.ToString());
                            }
                            break;
                        case '5':
                            Console.Clear();
                            // Perguntar o nome que deseja consultar
                            Console.WriteLine("Informe a turma que deseja alterar:");
                            // Obtendo a lista de turmas
                            List<Aluno> listaDeAlunos = repositorio.Listar(Console.ReadLine());
                            // Listando todas as turmas  retornados pela lista de cliente através do método repositorio.Listar()
                            foreach (Turma turmaDaVez in listaDeTurma)
                            {
                                // Imprimindo as informações de cada cliente na tela, utilizando o "ToString" que foi sobrescrito na classe
                                // Cliente ...
                                Console.WriteLine(turmaDaVez.ToString());
                            }
                            if (listaDeTurma != null && listaDeTurma.Count > 0)
                            {
                                // Solicitar o ID de qual dos clientes listados deseja alterar:
                                Console.WriteLine("Informe, pelo ID, qual das turmas acima você deseja alterar:");
                                // Buscar, na lista de Clientes, pelo Id, o objeto cliente relacionado ...
                                Turma TurmaAlterar = listaDeTurma.FindLast(c => c.Id == int.Parse(Console.ReadLine()));
                                // Solicitar o novo nome
                                Console.WriteLine($"Informe o nome  para {AlunoTurma.NomeTurma}:");
                                // Alterando a Propriedade Nome da turma encontrado ...
                                TurmaAlterar.NomeTurma = Console.ReadLine();
                                // Efetivando a alteração no Banco de Dados
                                repositorio.Alterar(TurmaAlterar);
                            }
                            else
                            {
                                // Caso a lista de Clientes não retorne nenhum registro, exibir mensagem abaixo.
                                Console.WriteLine("Nenhum registro encontrado ...");
                            }
                            break;
                        case '6':
                            Console.Clear();
                            // Informando a quantidade de turmas egistrados, através do método Obter Quantidade ...
                            Console.WriteLine($"Total de turmass registrados: {repositorio.ObterQuantidadeDeTurmas()}");
                            break;
                        case '7':
                            Console.Clear();
                            // Perguntar o nome que deseja adicionar um professor ...
                            Console.WriteLine("Informe o nome do turma para adcionar um Novo professor:");
                            // Obtendo a lista de professores
                            List<Aluno> listaDeProfessores = repositorio.Listar(Console.ReadLine());
                            // Listando todos os professores retornados pela lista de cliente através do método repositorio.Listar()
                            foreach (Professor ProfessorDaVez in listaDeProfessor)
                            {
                                // Imprimindo as informações de cada cliente na tela, utilizando o "ToString" que foi sobrescrito na classe
                                // Cliente ...
                                Console.WriteLine(AlunoDaVez.ToString());
                            }
                            if (listaDeProfessor!= null && listaDeProfessor.Count > 0)
                            {
                                // Solicitar o ID de qual dos clientes listados deseja Adicionar um Novo Carro:
                                Console.WriteLine("Informe, pelo ID, qual dos professores acima você deseja Adicionar um Novo turma:");
                                // Buscar, na lista de Clientes, pelo Id, o objeto cliente relacionado ...
                                Aluno AlunoAdicionaraDisciplina = listaDeClientesCarros.FindLast(c => c.Id == int.Parse(Console.ReadLine()));
                                Turma turma = new Turma();
                                Console.WriteLine("Informe qual é a turma:");
                                turma.NomeTurma = Console.ReadLine();
                                PrpofessorAdicionar.Professor = new List<Professor>();
                                professorAdicionar.Professor.Add(professor);
                                repositorio.InserirProfessor(professorAdicionarProfessor);
                            }
                            else
                            {
                                // Caso a lista de de professor não retorne nenhum registro, exibir mensagem abaixo.
                                Console.WriteLine("Nenhum registro encontrado ...");
                            }
                            break;
                        case '8':
                            Console.Clear();
                            // Perguntar o nome que deseja consultar
                            Console.WriteLine("Informe a turma a qual você deseja listar os professores:");
                            // Obtendo a lista de turma
                            List<Turmo> listaDTurmaDoProfesssor = repositorio.Listar(Console.ReadLine());
                            // 
                            foreach (Turma ProfessorDaVez in listaDeturmaDoProfessor)
                            {
                                // Imprimindo as informações de cada cliente na tela, utilizando o "ToString" que foi sobrescrito na classe
                                // Cliente ...
                                Console.WriteLine(ProfessorDaVez.ToString());
                            }
                            if (listaDeProfessoresPorturma != null && listaDProfessorDoTurma.Count > 0)
                            {
                                // Solicitar o ID de qual dos clientes listados deseja alterar:
                                Console.WriteLine("Informe, pelo ID, qual das turmas acima você deseja listar osprofessores:");
                                // Buscar, na lista de Clientes, pelo Id, o objeto cliente relacionado ...
                                Professor professorListarturma = listaDeprofessorTurma.FindLast(c => c.Id == int.Parse(Console.ReadLine()));
                                List<Professor> carros = repositorio.ListarProfessor(professorListarTurma.Id);
                                foreach (Professor professor in professor)
                                {
                                    Console.WriteLine(carro.ToString());
                                }
                            }
                            else
                            {
                                // Caso a lista de Clientes não retorne nenhum registro, exibir mensagem abaixo.
                                Console.WriteLine("Nenhum registro encontrado ...");
                            }
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

        public static void ListarProfessor(RepositorioMySQLprofessor repositorio)
        {
            // Listando todos os alunos retornados pela lista de aluno através do método repositorio.Listar()
            foreach (Turma TurmaDaVez in repositorio.Listar())
            {
                // Imprimindo as informações de cada aluno na tela, utilizando o "ToString" que foi sobrescrito na classe
                // Aluno ...
                Console.WriteLine(TurmaDaVez.ToString());
            }
        }
    }
}
