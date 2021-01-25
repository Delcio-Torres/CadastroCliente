using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app8.View.Base
{
   abstract class ComboBoxBase<T>: ComboBox
   {
      public ComboBoxBase(string DisplayMember, string ValueMember)
      {
         this.DisplayMember = DisplayMember;
         this.ValueMember = ValueMember;
      }

      public void SetDataSource(BindingList<T> bindings)
      {
         this.DataSource = bindings;
         this.SelectedIndex = -1;
      }

      public abstract T Parse();
   }
}
