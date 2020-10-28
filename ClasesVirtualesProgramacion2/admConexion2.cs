using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ClasesVirtualesProgramacion2
{
    class admConexion2
    {
        public MySqlConnection oConexion2;

        public bool AbrirConexion2()
        {
            bool conectado = false;
            string servidor = "localhost", puerto = "3306";
            string usuario = "root", contrasena = "root", BD = "clasesvirtuales";
            string cadenadeconexion = string.Format("datasource= {0}; port = {1}; username={2}; passwork={3}; database={4}", servidor, puerto, usuario, contrasena, BD);

            try
            {
                if (oConexion2 != null && oConexion2.State == ConnectionState.Open)
                    oConexion2.Close();


                oConexion2 = new MySqlConnection(cadenadeconexion);
                oConexion2.Open();
                conectado = true;

            }
            catch (MySqlException Exception)
            {

                MessageBox.Show(Exception.Message, "Error en conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conectado = false;
            }
            return conectado;

        }

        public bool SelectData(string SQL, DataTable Tabla)
        {
            bool ejecucioncorrecta = false;
            if(this.AbrirConexion2()== true)
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(SQL, oConexion2);
                    da.Fill(Tabla);
                    ejecucioncorrecta = true;
                        
                }
                catch (MySqlException Exception)
                {
                    MessageBox.Show(Exception.Message, "Error en SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ejecucioncorrecta = false;
                    
                }
            }
            return ejecucioncorrecta;
        }
    }

 
   }

