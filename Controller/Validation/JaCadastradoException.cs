using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app8.Controller.Validation
{
   class JaCadastradoException: Exception
   {
      public JaCadastradoException(string campo, string valor): base($"{campo} \"{valor}\" já está cadastrado!")
      {

      }
   }
}
