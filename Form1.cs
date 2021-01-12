using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using app8.Entities;

namespace app8
{
   public partial class Form1 : Form
   {
      Connection ca = new Connection();
      Validacao funcao = new Validacao();

      public Form1()
      {
         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         dgClientes.PreencheDataGrid();
         cboEstado.PreencheComboEstado();
         cboEstadoCivil.PreencheComboEstadoCivil();
      }

      private void button1_Click(object sender, EventArgs e)
      {

         string status = "";

         Cliente cliente = new Cliente
         {
            Nome = txtNome.Text.Trim(),
            Endereco = txtEndereco.Text.Trim(),
            Cep = txtCep.Text.Trim(),
            Cidade = txtCidade.Text.Trim(),
            Estado = cboEstado.ToEstado(),
            EstadoCivil = cboEstadoCivil.ToEstadoCivil()
         };

         try
         {
            cliente.Validar();

            Validation2 valida = new Validation2
            {
               Nome = txtNome.Text.Trim(),
               Endereco = txtEndereco.Text.Trim(),
               Cep = txtCep.Text.Trim(),
               Cidade = txtCidade.Text.Trim(),
               Estado = cboEstado.Text.Trim(),
               IdEstado = Convert.ToInt32(cboEstado.SelectedValue),
               EstadoCivil = cboEstadoCivil.Text.Trim(),
               IdEstadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue)
            };

            valida.IsertClient();

            dgClientes.PreencheDataGrid();
         }
         catch (Exception x)
         {
            status = x.Message;
            if (cliente.txtControle == "nome") txtNome.Focus();
            if (cliente.txtControle == "endereco") txtEndereco.Focus();
            if (cliente.txtControle == "cidade") txtCidade.Focus();
            if (cliente.txtControle == "cep") txtCep.Focus();
            if (cliente.txtControle == "estado") cboEstado.Focus();
            if (cliente.txtControle == "estadoCivil") cboEstadoCivil.Focus();
         }
         finally
         {
            lblStatus.Text = "Status: " + status;
         }
      }

   }
}
