using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClasesVirtualesProgramacion.Forms
{
    public partial class frmEstudiantesList : Form
    {
        admConexion oConexion = new admConexion();
        public frmEstudiantesList()
        {
            InitializeComponent();
        }

        private void frmEstudiantesList_Load(object sender, EventArgs e)
        {
            dsClasesVirtuales.Estudiantes.Clear();
            string SelectSQL = "Select * from estudiantes";
            if(oConexion.SelectData(SelectSQL, dsClasesVirtuales.Estudiantes) != true)
                MessageBox.Show("No se ha podido cargar ningun dato de estudiantes, contacte el departamento de desarrollo tecnico", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Dialogs.EstudianteDialog frmNuevo = new Dialogs.EstudianteDialog();
            frmNuevo.ShowDialog();
        }
    }
}
