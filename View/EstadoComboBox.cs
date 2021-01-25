using app8.Controller;
using Model.Entities;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using app8.View.Base;

namespace app8.View
{
   class EstadoComboBox: ComboBoxBase<Estado>
   {
      public EstadoComboBox(): base("Nome", "Id")
      {
      }

      public override Estado Parse()
      {
         return new Estado
         {
            Id = Convert.ToInt32(this.SelectedValue),
            Nome = this.Text.Trim()
         };
      }
   }
}
