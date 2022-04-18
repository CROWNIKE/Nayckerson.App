using Nayckerson.App.Comum.Models;
using Nayckerson.App.Comum.Services.Contracts;
using System;
using System.Windows.Forms;

namespace Nayckerson.App.WinUI
{
    public partial class ClienteCrudForm : Form
    {
        private readonly IServiceCliente _service;
        private readonly bool _ehRegistroExistente;
        private readonly Cliente _cliente;

        public ClienteCrudForm(IServiceCliente service)
        {
            this._service = service;
            InitializeComponent();
        }

        public ClienteCrudForm(IServiceCliente service, int idCliente) : this (service)
        {
            _ehRegistroExistente = EhRegistroNovo(idCliente);
            _cliente = _service.GetCliente(idCliente);
            LoadInformacoesCliente(_cliente);
            this.btnExcluir.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_ehRegistroExistente)
            {
                _service.Create(GetClientFromForm());
            }
            else
            {
                _service.Update(GetClientFromForm());
            }

            MessageBox.Show("Registro Salvo", this.GetType().Name);
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            _service.Delete(_cliente.Id);
            MessageBox.Show("Registro Deletado", this.GetType().Name);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Cliente GetClientFromForm()
        {
            return new Cliente
            {
                Nome = this.tbNome.Text,
                Nascimento = this.dtpNascimento.Value,
                Contato = new Contato
                {
                    Email = this.tbEmail.Text,
                    Telefone = this.tbTelefone.Text
                },
                Endereco = new Endereco
                {
                    Rua = tbRua.Text,
                    Numero = tbRua.Text,
                    Quadra = tbQuadra.Text,
                    Lote = tbLote.Text
                }
            };
        }

        private void LoadInformacoesCliente(Cliente cliente)
        {
            this.tbNome.Text = cliente.Nome;
            this.dtpNascimento.Value = cliente.Nascimento;
            this.tbEmail.Text = cliente.Contato.Email;
            this.tbTelefone.Text = cliente.Contato.Telefone;
            this.tbRua.Text = cliente.Endereco.Rua;
            this.tbLote.Text = cliente.Endereco.Lote;
            this.tbNumero.Text = cliente.Endereco.Numero;
            this.tbQuadra.Text = cliente.Endereco.Quadra;
        }

        private bool EhRegistroNovo(int idCliente)
        {
            return idCliente != 0;
        }
    }
}
