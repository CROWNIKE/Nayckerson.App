using Nayckerson.App.Comum.Models;
using System.Windows.Forms;

namespace Nayckerson.App.WinUI.Controllers
{
    public class ClienteDataGridViewController
    {
        public void AddRow(Cliente cliente, DataGridView dataGridView)
        {
            int rowIndex = CrieNovaRow(dataGridView);
            DataGridViewRow row = GetRow(dataGridView, rowIndex);
            SetCells(cliente, row);
        }

        private void SetCells(Cliente cliente, DataGridViewRow row)
        {
            row.Cells["Id"].Value = cliente.Id;
            row.Cells["Cliente"].Value = cliente.Nome;
            row.Cells["Telefone"].Value = cliente.Contato.Telefone;
        }

        public DataGridViewRow GetRow(DataGridView dataGridView, int rowIndex)
        {
            return dataGridView.Rows[rowIndex];
        }

        private int CrieNovaRow(DataGridView dataGridView)
        {
            return dataGridView.Rows.Add();
        }
    }
}
