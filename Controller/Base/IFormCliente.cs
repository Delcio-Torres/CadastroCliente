using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app8.Controller.Base
{
   interface IFormCliente
   {
      TextBox GetTextBoxNome();
      TextBox GetTextBoxEndereco();
      TextBox GetTextBoxCEP();
      TextBox GetTextBoxCidade();
      ComboBox GetComboBoxEstado();
      ComboBox GetComboBoxEstadoCivil();
      ErrorProvider GetErrorProvider();
   }
}
