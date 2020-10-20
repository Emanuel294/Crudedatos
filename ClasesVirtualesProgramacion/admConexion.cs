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

            try
            {
                if (oConexion != null && oConexion.State == ConnectionState.Open)
                    oConexion.Close();

                oConexion = new MySqlConnection(cadenaConexion);
                oConexion.Open();
                conectado = true;
            }
                catch (MySqlException Exception)
            {
                MessageBox.Show(Exception.Message, "Error en conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conectado = false;
            }
            return conectado;
        }

        public bool SelectData(string SQL,DataTable Tabla )
        {
            bool ejecucionCorrecta = false;
            if (this.AbrirConexion() == true)
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(SQL, oConexion);
                    da.Fill(Tabla);
                    ejecucionCorrecta = true;
                }
                catch(MySqlException Exception)
                {
                    MessageBox.Show(Exception.Message, "Error en SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ejecucionCorrecta = false;
                }
            }
            return ejecucionCorrecta;
        }
    }
}
