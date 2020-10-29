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
    }
}
