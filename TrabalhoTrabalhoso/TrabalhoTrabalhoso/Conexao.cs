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
            MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;DataBase=bdprovapaulo;Uid=root;Pwd=kabuterimon12;");
            return conexao;
        }
    }
}
