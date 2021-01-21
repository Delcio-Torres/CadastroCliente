using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;

namespace app8.Controller
{
   class Connection
   {
      public SQLiteConnection cx = new SQLiteConnection();
      SQLiteCommand cmd = new SQLiteCommand();

      public void OpenDb()
      {
         //string provider = "Provider=Microsoft.Jet.OLEDB.4.0; ";
         string bank = @"Data Source = C:\Users\delci\source\repos\CadastroCliente\Db\DB_Clientes.db";

         cx.ConnectionString = bank;
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
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, cx);
            DataSet ds = new DataSet();
            da.Fill(ds, table);

            return ds.Tables[table];
         }
         catch
         {
            return new DataTable();
         }
         finally
         {
            
            CloseDb();
         }
      }

      public void RunQuery(string sql, Action<SQLiteDataReader> func)
      {
         OpenDb();

         cmd.CommandText = sql;
         cmd.Connection = cx;
         SQLiteDataReader dr = cmd.ExecuteReader();
         try
         {
            func(dr);
         }
         finally
         {
            dr.Close();
            CloseDb();
         }
      }

      public void RunQuery(string sql)
      {
         OpenDb();

         cmd.CommandText = sql;
         cmd.Connection = cx;
         cmd.ExecuteNonQuery();

         CloseDb();
      }

   }
}
