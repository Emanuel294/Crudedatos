using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasesVirtualesProgramacion2.Dialogs;

namespace ClasesVirtualesProgramacion2.Dialogs
{
    public partial class GastosDialog : baseDialog
    {
        public GastosDialog()
        {
            InitializeComponent();
        }
        protected override bool ValidarEntrada()
        {
            erp.Clear();
            if (nudValor.Text.Trim() == string.Empty)
                return NotificacionDeValidacion("Por favor escriba el valor de gasto", nudValor);

            if (formapagoComboBox.SelectedIndex < 0)
                return NotificacionDeValidacion("Por favor seleccione uno de los elementos de forma de pago",formapagoComboBox);

            if (categoriaComboBox.SelectedIndex < 0)
                return NotificacionDeValidacion("Por favor seleccione uno de los elementos de Categoria", categoriaComboBox);

            if (subcategoriaComboBox.SelectedIndex < 0)
                return NotificacionDeValidacion("Por favor seleccione uno de los elementos de Subcategoria", subcategoriaComboBox);

            if (descripcionTextBox.Text.Trim() == string.Empty)
                return NotificacionDeValidacion("Por favor escriba la descripcion del producto", descripcionTextBox);
            return true;
        }

        private void GastosDialog_Load(object sender, EventArgs e)
        {

        }

        private void fechaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudValor_ValueChanged(object sender, EventArgs e)
        {

        }

        private void formapagoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void categoriaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void subcategoriaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
