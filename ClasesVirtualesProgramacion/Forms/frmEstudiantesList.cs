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
            frmNuevo.identidadTextBox.Focus();
            frmNuevo.ShowDialog();
            if (frmNuevo.DialogResult == DialogResult.OK)
            {
                string sqlInsert = string.Format("insert into estudiantes (identidad, nombres, apellidos, fechanac, sexo, direccion, obs) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",frmNuevo.identidadTextBox.Text.Trim(), frmNuevo.nombresTextBox.Text.Trim(), frmNuevo.apellidosTextBox.Text.Trim(), frmNuevo.fechanacDateTimePicker.Value.ToString("yyyy-MM-dd"), frmNuevo.sexoComboBox.Text, frmNuevo.direccionTextBox.Text.Trim(), frmNuevo.obsTextBox.Text.Trim() );
                if (oConexion.AccionSQL(sqlInsert) == true)
                {
                    this.frmEstudiantesList_Load(null, null);
                    MessageBox.Show("La información de estudiante ha sido almacenada correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estudiantesDataGridView.Focus();
                }
            }
        }
    }
}
