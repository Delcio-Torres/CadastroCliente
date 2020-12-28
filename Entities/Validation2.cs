using System;
using System.Data.OleDb;

namespace app8.Entities
{
   class Validation2
   {
      Connection ca = new Connection();

      public string txtControle;

      public string Nome { get; set; }
      public string Endereco { get; set; }
      public string Cidade { get; set; }
      public string Cep { get; set; }
      public string Estado { get; set; }
      public string EstadoCivil { get; set; }
      public string Status { get; set; }
      public int IdEstado { get; set; }
      public int IdEstadoCivil { get; set; }

      public Validation2()
      {
      }

      public Validation2(string nome, string endereco, string cidade, string cep, string estado, 
                         string estadoCivil, int idEstado, int idEstadoCivil)
      {
         Nome = nome;
         Endereco = endereco;
         Cidade = cidade;
         Cep = cep;
         Estado = estado;
         EstadoCivil = estadoCivil;
         IdEstado = idEstado;
         IdEstadoCivil = idEstadoCivil;
      }

      public void Valida()
      {
         if (Nome.Length == 0) throw new Exception("Nome não ser nulo!");
         if (Endereco.Length == 0) throw new Exception("Endereço  não ser nulo!");
         if (Cidade.Length == 0) throw new Exception("Cidade não ser nulo!");
         if (Cep.Length == 0) throw new Exception("Cep não ser nulo!");
         if (Estado.Length == 0) throw new Exception("Estado não ser nulo!");
         if (EstadoCivil.Length == 0) throw new Exception("Estado Civil não ser nulo!");
      }

      public void IsertClient()
      {
         string sql = "INSERT INTO Clientes (Nome, idEstadoCivil, Endereco, CEP, idEstado, Cidade)";
         sql += $" VALUES('{Nome}', {IdEstadoCivil}, '{Endereco}', '{Cep}', {IdEstado}, '{Cidade}')";

         ca.OpenDb();
         OleDbCommand com = new OleDbCommand();
         com.Connection = ca.cx;
         com.CommandText = sql;
         com.ExecuteNonQuery();
         Status = "Cliente cadastrado";
         ca.CloseDb();
      }

      public void ValidarCep()
      {
         //string txtControle = "cep";
         
         string c, y = "";
         int x, digito = 0;

         for (int i = 0; i <= Cep.Length - 1; i++)
         {
            c = Cep.Substring(i, 1);
            if (c == "-" && i == 5) digito = 5;
            else y += c;

         }
         if (int.TryParse(y, out x) && digito == 5 && Cep.Length == 9) { }
         else throw new Exception("CEP não está no formato válido \"00000-000\"");
      }
   }
}
