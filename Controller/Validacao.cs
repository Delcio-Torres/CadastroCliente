using System;
using System.Data.OleDb;

namespace app8
{
   class Validacao
   {
      //Connection ca = new Connection();
      //OleDbCommand cmd = new OleDbCommand();

      //public string txtControle = "";

      //public void ValidarCamposNulos(string text, string campo)
      //{
      //   string msg = $"O campo {campo} não pode estar em branco";
      //   txtControle = campo;
      //   if (text.Length == 0)
      //   {
      //      throw new Exception(msg);
      //   }
      //}

      //public void ValidarNomeCliente(string nome)
      //{
      //   txtControle = "nome";
      //   string msg = $"Cliente \"{nome}\" já está cadastrado!";
      //   ca.OpenDb();
      //   string sql = $"SELECT Nome FROM Clientes WHERE (Nome = '{nome}')";
      //   cmd.CommandText = sql;
      //   cmd.Connection = ca.cx;
      //   OleDbDataReader dr = cmd.ExecuteReader();

      //   if (dr.Read())
      //   {
      //      ca.CloseDb();
      //      throw new Exception(msg);
      //   }
      //   ca.CloseDb();
      //}

      //public void ValidarEnderecoCliente(string endereco)
      //{
      //   txtControle = "endereco";
      //   string msg = $"Endereço \"{endereco}\" já está cadastrado!";
      //   ca.OpenDb();
      //   string sql = $"SELECT Endereco FROM Clientes WHERE (Endereco = '{endereco}')";
      //   cmd.CommandText = sql;
      //   cmd.Connection = ca.cx;
      //   OleDbDataReader dr = cmd.ExecuteReader();

      //   if (dr.Read())
      //   {
      //      ca.CloseDb();
      //      throw new Exception(msg);
      //   }
      //   ca.CloseDb();
      //}

      //public void ValidarCep(string cep)
      //{
      //   txtControle = "cep";

      //   string c, y = "";
      //   int x, digito = 0;

      //   for (int i = 0; i <= cep.Length - 1; i++)
      //   {
      //      c = cep.Substring(i, 1);
      //      if (c == "-" && i == 5) digito = 5;
      //      else y += c;

      //   }
      //   if (int.TryParse(y, out x) && digito == 5 && cep.Length == 9) { }
      //   else throw new Exception("CEP não está no formato válido \"00000-000\"");
      //}
   }
}
