using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_logins
{
    public partial class Manipulador : Form
    {
        public Manipulador()
        {
            InitializeComponent();
        }

        private void tabelaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tabelaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myLoginsDataSet);

        }

        private void Manipulador_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myLoginsDataSet.tabela' table. You can move, or remove it, as needed.
            this.tabelaTableAdapter.Fill(this.myLoginsDataSet.tabela);

        }
    }
}
