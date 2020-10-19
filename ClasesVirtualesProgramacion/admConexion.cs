using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ClasesVirtualesProgramacion
{
    class admConexion
    {
        public MySqlConnection oConexion;

        public bool AbrirConexion()
        {
            bool conectado = false;
            string servidor = "localhost", puerto = "3306";
            string usuario = "root", contrasena = "root", BD = "clasesvirtuales";
            string cadenaConexion = string.Format("datasource={0}; port={1}; username={2}; password={3}; database={4}", servidor,puerto,usuario,contrasena,BD);
            return conectado;
        }
    }
}
