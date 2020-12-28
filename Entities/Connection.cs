using System.Data.OleDb;

namespace app8
{
   class Connection
   {
      public OleDbConnection cx = new OleDbConnection();

      public void OpenDb()
      {
         string provider = "Provider=Microsoft.Jet.OLEDB.4.0; ";
         string bank = "Data Source = D:\\Curso C#\\C# Avançado\\Aula 08\\app8\\loja.mdb";

         //cx.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = D:\\Curso C#\\C# Avançado\\Aula 08\\app8\\loja.mdb";
         cx.ConnectionString = provider + bank;
         cx.Open();
      }
      
      public void CloseDb()
      {
         cx.Close();
      }
      
   }
}
