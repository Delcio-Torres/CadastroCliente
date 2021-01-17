using System.Windows.Forms;
using System.Collections.Generic;
using app8.Model;
using app8.Controller;

namespace app8.View
{
   class ClientesGridView: DataGridView
   {
      Connection ca;
      ClienteController clienteController = new ClienteController();
      Cliente cliente = new Cliente();

      public ClientesGridView()
      {
         ca = new Connection();
      }
      
      public void PreencheDataGrid()
      {
         this.Rows.Clear();
         this.Columns[0].Visible = false;
         this.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         this.Columns[2].Width = 200;
         this.Columns[3].Width = 150;

         foreach (Cliente cliente in clienteController.LerBancoCliente())
         {
            this.Rows.Add(cliente.IdCliente, cliente.Nome, cliente.Endereco, cliente.Cidade);
         }
      }
   }
}
