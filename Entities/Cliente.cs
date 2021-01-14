using System;
using System.Data.OleDb;

namespace app8.Entities
{
   class Cliente: Entidade
   {
      public string Nome { get; set; }
      public string Endereco { get; set; }
      public string Cidade { get; set; }
      public string Cep { get; set; }
      public Estado Estado { get; set; }
      public EstadoCivil EstadoCivil { get; set; }

      Connection ca = new Connection();

      public string txtControle = "";

      public override void Validar()
      {
         ValidarCamposNulos(Nome, "Nome");
         ValidarCamposNulos(Endereco, "Endereco");
         ValidarCamposNulos(Cidade, "Cidade");
         ValidarCamposNulos(Cep, "Cep");
         ValidarCamposNulos(Estado.Nome, "Estado");
         ValidarCamposNulos(EstadoCivil.Nome, "EstadoCivil");

         ValidarNomeCliente();
         ValidarEnderecoCliente();
         ValidarCep();
      }

      public void ValidarCamposNulos(string text, string campo)
      {
         string msg = $"O campo {campo} não pode estar em branco";
         txtControle = campo.ToLower();
         if (text.Length == 0)
         {
            throw new Exception(msg);
         }
      }

      public void ValidarNomeCliente()
      {
         txtControle = "nome";
   
         ca.RunQuery(
            $"SELECT Nome FROM Clientes WHERE (Nome = '{this.Nome}')",
            (OleDbDataReader dr) =>
            {
               if (dr.Read())
               {
                  throw new Exception($"Cliente \"{this.Nome}\" já está cadastrado!");
               }
            }
         );
      }

      public void ValidarEnderecoCliente()
      {
         txtControle = "endereco";

         ca.RunQuery(
            $"SELECT Endereco FROM Clientes WHERE (Endereco = '{this.Endereco}')",
            (OleDbDataReader dr) =>
            {
               if (dr.Read())
               {
                  throw new Exception($"Endereço \"{this.Endereco}\" já está cadastrado!");
               }
            }
         );
      }

      public void ValidarCep()
      {
         txtControle = "cep";

         string c, y = "";
         int x, digito = 0;

         for (int i = 0; i <= this.Cep.Length - 1; i++)
         {
            c = this.Cep.Substring(i, 1);
            if (c == "-" && i == 5) digito = 5;
            else y += c;

         }
         if (int.TryParse(y, out x) && digito == 5 && this.Cep.Length == 9) { }
         else throw new Exception("CEP não está no formato válido \"00000-000\"");
      }
   }
}
