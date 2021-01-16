using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using app8.Controller;
using app8.Model;

namespace app8.View
{
   public partial class Form1 : Form
   {
      Connection ca = new Connection();
      Cliente cliente = new Cliente();
      ClienteController controller = new ClienteController();

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
               controller.InsertClient(cliente);
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
            LimpaForm();
            txtNome.Focus();
         }
      }

      private void cmdFechar_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void dgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
         int idClienteSelecionado = Convert.ToInt32(dgClientes.Rows[e.RowIndex].Cells[0].Value);
         PreencheFormCliente(idClienteSelecionado);
      }

      private void PreencheFormCliente(int idCliente)
      {
         Cliente cliente = Cliente.GetCliente(idCliente);

         txtNome.Text = cliente.Nome;
         txtEndereco.Text =cliente.Endereco;
         txtCidade.Text = cliente.Cidade;
         txtCep.Text = cliente.Cep;
         cboEstado.SelectedValue = cliente.Estado.Id.ToString();
         cboEstadoCivil.SelectedValue = cliente.EstadoCivil.ID.ToString();
      }

      private void LimpaForm()
      {
         txtNome.Text = "";
         txtEndereco.Text = "";
         txtCidade.Text = "";
         txtCep.Text = "";
         txtID.Text = "";
         cboEstado.Text = "";
         cboEstadoCivil.Text = "";
      }
   }
}
