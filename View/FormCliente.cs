using System;
using System.Data;
using System.Windows.Forms;
using app8.Controller;
using app8.Controller.Base;
using Model.Entities;

namespace app8.View
{
   public partial class FormCliente : Form, IFormCliente
   {
      ClienteController controller = new ClienteController();

      public FormCliente()
      {
         InitializeComponent();
      }

      private void FormCliente_Load(object sender, EventArgs e)
      {
         dgClientes.PreencheDataGrid(controller);
         cboEstado.SetDataSource(controller.LerBancoEstado());
         cboEstadoCivil.SetDataSource(controller.LerBancoEstadoCivil());
      }

      private void cmdIncluir_Click(object sender, EventArgs e)
      {
         string status = "";
         if (cmdIncluir.Text == "&Salvar")
         {
            Cliente cliente = new Cliente
            {
               Nome = txtNome.Text.Trim(),
               Endereco = txtEndereco.Text.Trim(),
               Cep = txtCep.Text.Trim(),
               Cidade = txtCidade.Text.Trim(),
               Estado = cboEstado.Parse(),
               EstadoCivil = cboEstadoCivil.Parse()
            };

            try
            {
               controller.InsertClient(cliente, this);
               dgClientes.PreencheDataGrid(controller);
            }
            catch (Exception x)
            {
               status = x.Message;
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
         Cliente cliente = controller.GetCliente(idCliente);

         txtNome.Text = cliente.Nome;
         txtEndereco.Text = cliente.Endereco;
         txtCidade.Text = cliente.Cidade;
         txtCep.Text = cliente.Cep;
         cboEstado.SelectedValue = cliente.Estado.Id.ToString();
         cboEstadoCivil.SelectedValue = cliente.EstadoCivil.Id.ToString();
      }

      private void LimpaForm()
      {
         txtNome.Text = "";
         txtEndereco.Text = "";
         txtCidade.Text = "";
         txtCep.Text = "";
         txtID.Text = "";
         cboEstado.SelectedIndex = -1;
         cboEstadoCivil.SelectedIndex = -1;
      }

      public TextBox GetTextBoxNome()
      {
         return txtNome;
      }

      public TextBox GetTextBoxEndereco()
      {
        return txtEndereco;
      }

      public TextBox GetTextBoxCEP()
      {
         return txtCep;
      }

      public TextBox GetTextBoxCidade()
      {
         return txtCidade;
      }

      public ComboBox GetComboBoxEstado()
      {
         return cboEstado;
      }

      public ComboBox GetComboBoxEstadoCivil()
      {
         return cboEstadoCivil;
      }

      public ErrorProvider GetErrorProvider()
      {
         return errorProvider1;
      }
   }
}
