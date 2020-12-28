using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using app8.Entities;

namespace app8
{
   public partial class Form1 : Form
   {
      Connection ca = new Connection();
      Validacao funcao = new Validacao();

      public Form1()
      {
         InitializeComponent();
      }

      private void PreencheDataGrid()
      {
         try
         {
            ca.OpenDb();
            string sql = "SELECT idCliente, Nome, Endereco, Cidade FROM Clientes ORDER BY Nome";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, ca.cx);
            DataSet ds = new DataSet();
            string a = "Clientes";
            da.Fill(ds, a);
            dgClientes.DataSource = ds.Tables[a];
            ca.CloseDb();
         }
         catch (Exception x)
         {
            lblStatus.Text = x.Message;
         }
      }

      private void PreencheComboEstado()
      {
         ca.OpenDb();
         string sql = "SELECT idEstado, Estado FROM Estados";
         OleDbDataAdapter da = new OleDbDataAdapter(sql, ca.cx);
         DataSet ds = new DataSet();
         string a = "Estados";
         da.Fill(ds, a);
         cboEstado.DisplayMember = "Estado";
         cboEstado.ValueMember = "idEstado";
         cboEstado.DataSource = ds.Tables[a];
         ca.CloseDb();
         cboEstado.Text = "";
      }

      private void PreencheComboEstadoCivil()
      {
         ca.OpenDb();
         string sql = "SELECT idEstadoCivil, EstadoCivil FROM EstadoCivil";
         OleDbDataAdapter da = new OleDbDataAdapter(sql, ca.cx);
         DataSet ds = new DataSet();
         string a = "EstadoCivil";
         da.Fill(ds, a);
         cboEstadoCivil.DisplayMember = "EstadoCivil";
         cboEstadoCivil.ValueMember = "idEstadoCivil";
         cboEstadoCivil.DataSource = ds.Tables[a];
         ca.CloseDb();
         cboEstadoCivil.Text = "";
      }
      private void Form1_Load(object sender, EventArgs e)
      {
         PreencheDataGrid();
         PreencheComboEstado();
         PreencheComboEstadoCivil();
         dgClientes.Columns[0].Visible = false;
         dgClientes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         dgClientes.Columns[2].Width = 200;
         dgClientes.Columns[3].Width = 100;
      }

      private void button1_Click(object sender, EventArgs e)
      {
         Connection ca = new Connection();
         OleDbCommand cmd = new OleDbCommand();

         string sql = "";
         string nome = "";
         string endereco = "";
         string cep = "";
         string cidade = "";
         string estado = "";
         int idEstado;
         string estadoCivil = "";
         int idEstadoCivil;
         string status = "";

         try
         {

            Validation2 valida = new Validation2
            {
               Nome = txtNome.Text.Trim(),
               Endereco = txtEndereco.Text.Trim(),
               Cep = txtCep.Text.Trim(),
               Cidade = txtCidade.Text.Trim(),
               Estado = cboEstado.Text.Trim(),
               IdEstado = Convert.ToInt32(cboEstado.SelectedValue),
               EstadoCivil = cboEstadoCivil.Text.Trim(),
               IdEstadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue)
            };


            valida.Valida();

            //nome = txtNome.Text;
            //endereco = txtEndereco.Text;
            //cep = txtCep.Text;
            //cidade = txtCidade.Text;
            //estado = cboEstado.Text;
            //idEstado = Convert.ToInt32(cboEstado.SelectedValue);
            //estadoCivil = cboEstadoCivil.Text;
            //idEstadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue);


            funcao.ValidarNomeCliente(valida.Nome.Trim());
            funcao.ValidarEnderecoCliente(endereco.Trim());
            valida.ValidarCep();

            valida.IsertClient();
            //sql = "INSERT INTO Clientes (Nome, idEstadoCivil, Endereco, CEP, idEstado, Cidade)";
            //sql += $" VALUES('{nome}', {idEstadoCivil}, '{endereco}', '{cep}', {idEstado}, '{cidade}')";

            //ca.OpenDb();
            //OleDbCommand com = new OleDbCommand();
            //com.Connection = ca.cx;
            //com.CommandText = sql;
            //com.ExecuteNonQuery();
            //status = "Cliente cadastrado";
            //ca.CloseDb();
            PreencheDataGrid();
         }
         catch (Exception x)
         {
            status = x.Message;
            if (funcao.txtControle == "nome") txtNome.Focus();
            if (funcao.txtControle == "endereco") txtEndereco.Focus();
            if (funcao.txtControle == "cidade") txtCidade.Focus();
            if (funcao.txtControle == "cep") txtCep.Focus();
            if (funcao.txtControle == "estado") cboEstado.Focus();
            if (funcao.txtControle == "estadoCivil") cboEstadoCivil.Focus();
         }
         finally
         {
            lblStatus.Text = "Status: " + status;
         }
      }
   }
}
