using System;
using app8.Model;
using System.Collections.Generic;
using System.Data.SQLite;

namespace app8.Controller
{
   class ClienteController
   {
      Connection ca = new Connection();

      public void InsertClient(Cliente cliente)
      {
         ca.RunQuery($@"INSERT INTO Clientes(Nome, idEstadoCivil, Endereco, CEP, idEstado, Cidade)
             VALUES('{cliente.Nome}', {cliente.EstadoCivil.ID}, '{cliente.Endereco}',
            '{cliente.Cep}', {cliente.Estado.Id}, '{cliente.Cidade}')");
      }

      public List<Cliente> LerBancoCliente()
      {
         List<Cliente> clientes = new List<Cliente>();
         ca.RunQuery("SELECT idCliente, Nome, Endereco, Cidade FROM Clientes ORDER BY Nome", (SQLiteDataReader dr) =>
         {
            while (dr.Read())
            {
               Cliente cliente = new Cliente
               {
                  IdCliente = Convert.ToInt32(dr["idCliente"]),
                  Nome = dr["Nome"].ToString(),
                  Endereco = dr["Endereco"].ToString(),
                  Cidade = dr["Cidade"].ToString(),
               };
               clientes.Add(cliente);
            }
         }
         );

         return clientes;
      }
   }
}
