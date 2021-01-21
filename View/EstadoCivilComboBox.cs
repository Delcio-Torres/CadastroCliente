using System;
using app8.Model;
using app8.Controller;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;

namespace app8.View
{
   class EstadoCivilComboBox: ComboBox
   {
      Connection ca;
      public EstadoCivilComboBox()
      {
         ca = new Connection();
      }
      
      public void PreencheComboEstadoCivil()
      {
         ca.OpenDb();
         string sql = "SELECT idEstadoCivil, EstadoCivil FROM EstadoCivil";
         SQLiteDataAdapter da = new SQLiteDataAdapter(sql, ca.cx);
         DataSet ds = new DataSet();
         string a = "EstadoCivil";
         da.Fill(ds, a);
         this.DisplayMember = "EstadoCivil";
         this.ValueMember = "idEstadoCivil";
         this.DataSource = ds.Tables[a];
         ca.CloseDb();
         this.Text = "";
      }

      public EstadoCivil ToEstadoCivil()
      {

         return new EstadoCivil
         {
            ID = Convert.ToInt32(this.SelectedValue),
            Nome = this.Text.Trim()
         };
      }
   }
}
