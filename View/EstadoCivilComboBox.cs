using System;
using Model.Entities;
using app8.Controller;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using app8.View.Base;

namespace app8.View
{
   class EstadoCivilComboBox: ComboBoxBase<EstadoCivil>
   {
      
      public EstadoCivilComboBox(): base("Nome", "Id")
      {
      }

      public override EstadoCivil Parse()
      {
         return new EstadoCivil
         {
            Id = Convert.ToInt32(this.SelectedValue),
            Nome = this.Text.Trim()
         };
      }
   }
}
