using System;
using Model.Entities;
using System.Collections.Generic;
using System.Data.SQLite;
using app8.Controller.Validation;
using app8.Controller.Base;
using System.ComponentModel;

namespace app8.Controller
{
   class ClienteController
   {
      Connection ca = new Connection();
      ValidarCliente validarCliente = new ValidarCliente();

      public void InsertClient(Cliente cliente, IFormCliente form)
      {
         validarCliente.Validar(cliente, form);

         ca.RunQuery($@"INSERT INTO Clientes(Nome, idEstadoCivil, Endereco, CEP, idEstado, Cidade)
             VALUES('{cliente.Nome}', {cliente.EstadoCivil.Id}, '{cliente.Endereco}',
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

      public BindingList<Estado> LerBancoEstado()
      {
         BindingList<Estado> estados = new BindingList<Estado>();         
         ca.RunQuery("SELECT idEstado, Estado FROM Estados order by Estado", (SQLiteDataReader dr) =>
         {
            while (dr.Read())
            {
               Estado estado = new Estado
               {
                  Id = Convert.ToInt32(dr["idEstado"]),
                  Nome = dr["Estado"].ToString()
               };
               estados.Add(estado);
            }
         }
         );

         return estados;
      }

      public BindingList<EstadoCivil> LerBancoEstadoCivil()
      {
         BindingList<EstadoCivil> estadoCivis = new BindingList<EstadoCivil>();
         ca.RunQuery("SELECT idEstadoCivil, EstadoCivil FROM EstadoCivil order by EstadoCivil", (SQLiteDataReader dr) =>
         {
            while (dr.Read())
            {
               EstadoCivil estadoCivil = new EstadoCivil
               {
                  Id = Convert.ToInt32(dr["idEstadoCivil"]),
                  Nome = dr["EstadoCivil"].ToString()
               };
               estadoCivis.Add(estadoCivil);
            }
         }
         );

         return estadoCivis;
      }

      public Cliente GetCliente(int idCliente)
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
               cliente.EstadoCivil = new EstadoCivil { Id = Convert.ToInt32(dr["idEstadoCivil"]), Nome = dr["EstadoCivil"].ToString() };
            }
         });

         return cliente;
      }
   }
}
