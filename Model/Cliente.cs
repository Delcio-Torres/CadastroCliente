using System;
using System.Data.OleDb;
using System.Collections.Generic;
using app8.Controller;
using System.Data.SQLite;

namespace app8.Model
{
   class Cliente: Entidade
   {
      static Connection ca = new Connection();

      public int IdCliente { get; set; }
      public string Nome { get; set; }
      public string Endereco { get; set; }
      public string Cidade { get; set; }
      public string Cep { get; set; }
      public Estado Estado { get; set; }
      public EstadoCivil EstadoCivil { get; set; }

      public Cliente()
      {
      }

      public Cliente(int idCliente, string nome, string endereco, string cidade, string cep, Estado estado, EstadoCivil estadoCivil)
      {
         IdCliente = idCliente;
         Nome = nome;
         Endereco = endereco;
         Cidade = cidade;
         Cep = cep;
         Estado = estado;
         EstadoCivil = estadoCivil;
      }

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
            (SQLiteDataReader dr) =>
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
            (SQLiteDataReader dr) =>
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

      public static Cliente GetCliente(int idCliente)
      {
         Cliente cliente = new Cliente();
         ca.RunQuery($@"SELECT c.idCliente, c.Nome, c.Endereco, c.Cidade, c.Cep, e.idEstado, e.Estado, p.idEstadoCivil, p.EstadoCivil
                      FROM((Clientes c INNER JOIN
                         Estados e ON e.idEstado = c.idEstado) INNER JOIN
                         EstadoCivil p ON p.idEstadoCivil = c.idEstadoCivil) WHERE(c.idCliente = {idCliente})", (SQLiteDataReader dr) =>
         {
            if (dr.Read())
            {
               cliente.Nome = dr["Nome"].ToString();
               cliente.Endereco = dr["Endereco"].ToString();
               cliente.Cidade = dr["Cidade"].ToString();
               cliente.Cep = dr["Cep"].ToString();
               cliente.Estado = new Estado { Id = Convert.ToInt32(dr["idEstado"]), Nome = dr["Estado"].ToString() };
               cliente.EstadoCivil = new EstadoCivil { ID = Convert.ToInt32(dr["idEstadoCivil"]), Nome = dr["EstadoCivil"].ToString() };
            }
         });

         return cliente;
      }
   }
}
