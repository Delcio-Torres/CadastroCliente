using System;
using System.Data;
using System.Data.OleDb;

namespace app8
{
   class Connection
   {
      public OleDbConnection cx = new OleDbConnection();
      OleDbCommand cmd = new OleDbCommand();

      public void OpenDb()
      {
         string provider = "Provider=Microsoft.Jet.OLEDB.4.0; ";
         string bank = @"Data Source = D:\Curso C#\C# Avançado\Aula 08\app8\cadastrocliente\loja.mdb";

         cx.ConnectionString = provider + bank;
         cx.Open();
      }

      public void CloseDb()
      {
         cx.Close();
      }

      public DataTable RunQuery(string sql, string table)
      {
         OpenDb();
         try
         {
            OleDbDataAdapter da = new OleDbDataAdapter(sql, cx);
            DataSet ds = new DataSet();
            da.Fill(ds, table);
            return ds.Tables[table];
         }
         catch (Exception x)
         {
            return new DataTable();
         } finally
         {
            CloseDb();
         }
      }

      public void RunQuery(string sql, Action<OleDbDataReader> func)
      {
         OpenDb();

         cmd.CommandText = sql;
         cmd.Connection = cx;
         OleDbDataReader dr = cmd.ExecuteReader();
         func(dr);
         
         CloseDb();
      }
      
   }
}
