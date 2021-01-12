using System.Windows.Forms;

namespace app8.Entities
{
   class ClientesGridView: DataGridView
   {
      Connection ca;

      public ClientesGridView()
      {
         ca = new Connection();

         //var nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
         //nome.HeaderText = "Nome";

         //this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
         //   nome
         //});
      }
         
      public void PreencheDataGrid()
      {
         string query = "SELECT idCliente, Nome, Endereco, Cidade FROM Clientes ORDER BY Nome";
         this.DataSource = ca.RunQuery(query,"Clientes");
         this.Columns[0].Visible = false;
         this.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         this.Columns[2].Width = 200;
         this.Columns[3].Width = 100;
      }
   }
}
