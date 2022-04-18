using Nayckerson.App.Comum.Services.Contracts;
using Nayckerson.App.WinUI.Controllers;
using System.Windows.Forms;

namespace Nayckerson.App.WinUI
{
    public partial class ClienteForm : Form
    {
        private readonly IServiceCliente _service;
        private readonly ClienteDataGridViewController _controlador;

        public ClienteForm(IServiceCliente service, ClienteDataGridViewController controlador)
        {
            _service = service;
            _controlador = controlador;
            InitializeComponent();
            LoadGridView(_service);
        }

        private void LoadGridView(IServiceCliente service)
        {
            foreach (var cliente in service.GetClientes())
            {
                _controlador.AddRow(cliente, dataGridView);
            }
        }

        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            new ClienteCrudForm(_service).Show();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var idCliente = GetIdCliente(e);
            new ClienteCrudForm(_service, idCliente).Show();
        }

        private int GetIdCliente(DataGridViewCellEventArgs e)
        {
            return (int)_controlador.GetRow(this.dataGridView, e.RowIndex).Cells["Id"].Value;
        }
    }
}
