using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClasesVirtualesProgramacion2.Forms
{
    public partial class frmGastosList : Form
    {
        admConexion2 oConexion2 = new admConexion2();
        public frmGastosList()
        {
            InitializeComponent();
        }

        private void frmGastosList_Load(object sender, EventArgs e)
        {
            dsClasesVirtuales.Gastos.Clear();
            string SelectSQL = "select * from gastos";
            if (oConexion2.SelectData(SelectSQL, dsClasesVirtuales.Gastos) != true)
                MessageBox.Show("No se ha podido cargar ningun dato de Gastos, contacte el departamento de desarrollo tecnico", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Dialogs.GastosDialog frmNuevo = new Dialogs.GastosDialog();
            frmNuevo.descripcionTextBox.Focus();
            frmNuevo.ShowDialog();
            if(frmNuevo.DialogResult == DialogResult.OK)
            {
                string sqlInsert = string.Format("insert into gastos (fecha, categoria, subcategoria, descripcion, valor, formapago) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", frmNuevo.fechaDateTimePicker.Value.ToString("yyyy-MM-dd"), frmNuevo.categoriaComboBox.Text, frmNuevo.subcategoriaComboBox.Text, frmNuevo.descripcionTextBox.Text.Trim(), frmNuevo.nudValor.Text.Trim(), frmNuevo.formapagoComboBox.Text);
                if(oConexion2.AccionSQL(sqlInsert)== true)
                {
                    this.frmGastosList_Load(null, null);
                    MessageBox.Show("La información de gastos ha sido almacenada correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gastosDataGridView.Focus();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(gastosBindingSource.Count > 0)
            {
                Dialogs.GastosDialog frmEditar = new Dialogs.GastosDialog();
                DataGridViewRow Fila = gastosDataGridView.CurrentRow;
                Int16 ID = Int16.Parse(Fila.Cells[0].Value.ToString());
                frmEditar.fechaDateTimePicker.Value = Convert.ToDateTime(Fila.Cells[1].Value);
                frmEditar.categoriaComboBox.Text = Fila.Cells[2].Value.ToString();
                frmEditar.subcategoriaComboBox.Text = Fila.Cells[3].Value.ToString();
                frmEditar.descripcionTextBox.Text = Fila.Cells[4].Value.ToString();
                frmEditar.nudValor.Text = Fila.Cells[5].Value.ToString();
                frmEditar.formapagoComboBox.Text = Fila.Cells[6].Value.ToString();
                frmEditar.fechaDateTimePicker.Focus();
                frmEditar.ShowDialog();
                if(frmEditar.DialogResult == DialogResult.OK)
                {
                    string sqlUpdate = string.Format("update gastos set fecha = '{0}', categoria = '{1}', subcategoria= '{2}', descripcion = '{3}', valor = '{4}', formapago = '{5}' where id = {6}", frmEditar.fechaDateTimePicker.Value.ToString("yyyy-MM-dd"), frmEditar.categoriaComboBox.Text, frmEditar.subcategoriaComboBox.Text, frmEditar.descripcionTextBox.Text.Trim(), frmEditar.nudValor.Text.Trim(), frmEditar.formapagoComboBox.Text, ID);
                    if(oConexion2.AccionSQL(sqlUpdate) == true)
                    {
                        this.frmGastosList_Load(null, null);
                        MessageBox.Show("La informacion de gastos ha sido actualizada correctamente.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gastosDataGridView.Focus();
                    }
                }

            
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(gastosBindingSource.Count > 0)
            {

            if(MessageBox.Show("Esta seguro que quiere eliminar la informacion de gastos?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                    DataGridViewRow Fila = gastosDataGridView.CurrentRow;
                    Int16 ID = Int16.Parse(Fila.Cells[0].Value.ToString());
                    string sqlDelete = string.Format("delete from gastos where id = {0}", ID);
                    if(oConexion2.AccionSQL(sqlDelete)== true)
                    {
                        this.frmGastosList_Load(null, null);
                        MessageBox.Show("La informacion de gastos ha sido eliminada correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gastosDataGridView.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay información para eliminar un registro", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
