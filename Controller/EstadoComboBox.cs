using app8.Entities;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace app8.Controller
{
   class EstadoComboBox: ComboBox
   {
      Connection ca;
      public EstadoComboBox()
      {
         ca = new Connection();
      }

      public void PreencheComboEstado()
      {
         ca.OpenDb();
         string sql = "SELECT idEstado, Estado FROM Estados";
         OleDbDataAdapter da = new OleDbDataAdapter(sql, ca.cx);
         DataSet ds = new DataSet();
         string a = "Estados";
         da.Fill(ds, a);
         this.DisplayMember = "Estado";
         this.ValueMember = "idEstado";
         this.DataSource = ds.Tables[a];
         ca.CloseDb();
         this.Text = "";
      }

      public Estado ToEstado()
      {
         return new Estado
         {
            Id = Convert.ToInt32(this.SelectedValue),
            Nome = this.Text.Trim()
         };
      }
   }
}
