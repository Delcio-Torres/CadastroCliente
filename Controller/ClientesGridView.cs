using System.Windows.Forms;
using System.Collections.Generic;

namespace app8.Entities
{
   class ClientesGridView: DataGridView
   {
      Connection ca;

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

         foreach (Cliente cliente in Cliente.LerBancoClinete())
         {
            this.Rows.Add(cliente.IdCliente, cliente.Nome, cliente.Endereco, cliente.Cidade);
         }
      }

      //public void PreencheDataGrid()
      //{
      //   string query = "SELECT idCliente, Nome, Endereco, Cidade FROM Clientes ORDER BY Nome";
      //   this.DataSource = ca.RunQuery(query,"Clientes");
      //   this.Columns[0].Visible = false;
      //   this.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      //   this.Columns[2].Width = 200;
      //   this.Columns[3].Width = 100;
      //}
   }
}
