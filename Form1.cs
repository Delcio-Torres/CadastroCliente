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
      Cliente cliente = new Cliente();

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

      private void cmdIncluir_Click(object sender, EventArgs e)
      {
         string status = "";
         if (cmdIncluir.Text == "&Salvar")
         {
            cliente.Nome = txtNome.Text.Trim();
            cliente.Endereco = txtEndereco.Text.Trim();
            cliente.Cep = txtCep.Text.Trim();
            cliente.Cidade = txtCidade.Text.Trim();
            cliente.Estado = cboEstado.ToEstado();
            cliente.EstadoCivil = cboEstadoCivil.ToEstadoCivil();

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
               if (cliente.txtControle == "estadocivil") cboEstadoCivil.Focus();
               cliente.txtControle = "";
            }
            finally
            {
               lblStatus.Text = "Status: " + status;
            }
         }
         else
         {
            cmdIncluir.Text = "&Salvar";
            txtNome.Focus();
         }
      }

      private void cmdFechar_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void dgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
         if (e.RowIndex >= 0)
         {
            lblStatus.Text = e.RowIndex.ToString();
         }
      }

      private void button1_Click(object sender, EventArgs e)
      {

      }
   }
}
