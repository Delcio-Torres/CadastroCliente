using System.Windows.Forms;
using app8.Model;
using app8.Controller;

namespace app8.View
{
   class ClientesGridView : DataGridView
   {
      public void PreencheDataGrid(ClienteController clienteController)
      {
         this.Rows.Clear();

         foreach (Cliente cliente in clienteController.LerBancoCliente())
         {
            this.Rows.Add(cliente.IdCliente, cliente.Nome, cliente.Endereco, cliente.Cidade);
         }
      }
   }
}
