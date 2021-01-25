using Model.Entities;
using System.Data.SQLite;
using app8.Controller.Base;
using System.Windows.Forms;
using System;

namespace app8.Controller.Validation
{
   class ValidarCliente : Model.Validations.ValidarCliente
   {
      Connection ca = new Connection();
      IFormCliente FormCliente;
      Exception Error = null;

      private void FocusIfFails(Control control, Action action)
      {
         try
         {
            action();
         }
         catch (Exception e)
         {
            FormCliente.GetErrorProvider().SetError(control, e.Message);
            control.Focus();
            Error = e;
         }
      }

      public void Validar(Cliente cliente, IFormCliente formCliente)
      {
         FormCliente = formCliente;
         FormCliente.GetErrorProvider().Clear();
         Validar(cliente);
         if (Error != null)
         {
            throw Error;
         }
      }

      public override void ValidarCEP(Cliente cliente)
      {
         FocusIfFails(FormCliente.GetTextBoxCEP(), () =>
         {
            base.ValidarCEP(cliente);
         });
      }

      public override void ValidarCidade(Cliente cliente)
      {
         FocusIfFails(FormCliente.GetTextBoxCidade(), () =>
         {
            base.ValidarCidade(cliente);
         });
      }

      public override void ValidarEstado(Cliente cliente)
      {
         FocusIfFails(FormCliente.GetComboBoxEstado(), () =>
         {
            base.ValidarEstado(cliente);
         });
      }

      public override void ValidarEstadoCivil(Cliente cliente)
      {
         FocusIfFails(FormCliente.GetComboBoxEstadoCivil(), () =>
         {
            base.ValidarEstadoCivil(cliente);
         });
      }

      public override void ValidarEndereco(Cliente cliente)
      {
         FocusIfFails(FormCliente.GetTextBoxEndereco(), () =>
         {
            base.ValidarEndereco(cliente);
            ca.RunQuery(
               $"SELECT Endereco FROM Clientes WHERE (Endereco = '{cliente.Endereco}')",
               (SQLiteDataReader dr) =>
               {
                  if (dr.Read())
                  {
                     throw new JaCadastradoException("Endereco", cliente.Endereco);
                  }
               }
            );
         });
      }

      public override void ValidarNome(Cliente cliente)
      {
         FocusIfFails(FormCliente.GetTextBoxNome(), () =>
         {
            base.ValidarNome(cliente);
            ca.RunQuery(
               $"SELECT Nome FROM Clientes WHERE (Nome = '{cliente.Nome}')",
               (SQLiteDataReader dr) =>
               {
                  if (dr.Read())
                  {
                     throw new JaCadastradoException("Nome", cliente.Nome);
                  }
               }
            );
         });
      }
   }
}
