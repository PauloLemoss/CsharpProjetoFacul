using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoTrabalhoso
{
    public class Aluno
    {
       public  string NomeAluno { get; set; }
       public int CpfAluno { get; set; }
       public string IdAluno { get; set; }
       
       public string EmailAluno { get; set; }
        public List<Turma> Turmas { get; set; }

        public override string ToString()
        {
            return string.Format($" {NomeAluno} {CpfAluno} {EmailAluno}");
        }
    }
}
