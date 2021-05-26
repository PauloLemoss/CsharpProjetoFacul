using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace TrabalhoTrabalhoso
{
    class Conexao
    {
        public MySqlConnection Conectar()
        {    //Método que retorna a conexão do banco foi criado uma classe para separar os códigos...
            MySqlConnection conexao = new MySqlConnection("Server=MYSQL5030.site4now.net;Port=3306;Database=db_a2d8fc_aula;Uid=a2d8fc_aula;Pwd=abc12345;");
            return conexao;
        }
    }
}
