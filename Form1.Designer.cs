
using app8.Entities;
using app8.Controller;
namespace app8
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.txtNome = new System.Windows.Forms.TextBox();
         this.txtEndereco = new System.Windows.Forms.TextBox();
         this.txtCidade = new System.Windows.Forms.TextBox();
         this.txtCep = new System.Windows.Forms.TextBox();
         this.txtID = new System.Windows.Forms.TextBox();
         this.cboEstadoCivil = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.lblStatus = new System.Windows.Forms.Label();
         this.cboEstado = new app8.Controller.EstadoComboBox();
         this.dgClientes = new app8.Entities.ClientesGridView();
         ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
         this.SuspendLayout();
         // 
         // txtNome
         // 
         this.txtNome.Location = new System.Drawing.Point(56, 77);
         this.txtNome.Name = "txtNome";
         this.txtNome.Size = new System.Drawing.Size(254, 20);
         this.txtNome.TabIndex = 0;
         // 
         // txtEndereco
         // 
         this.txtEndereco.Location = new System.Drawing.Point(316, 77);
         this.txtEndereco.Name = "txtEndereco";
         this.txtEndereco.Size = new System.Drawing.Size(211, 20);
         this.txtEndereco.TabIndex = 1;
         // 
         // txtCidade
         // 
         this.txtCidade.Location = new System.Drawing.Point(56, 129);
         this.txtCidade.Name = "txtCidade";
         this.txtCidade.Size = new System.Drawing.Size(100, 20);
         this.txtCidade.TabIndex = 2;
         // 
         // txtCep
         // 
         this.txtCep.Location = new System.Drawing.Point(165, 129);
         this.txtCep.Name = "txtCep";
         this.txtCep.Size = new System.Drawing.Size(100, 20);
         this.txtCep.TabIndex = 3;
         // 
         // txtID
         // 
         this.txtID.Location = new System.Drawing.Point(508, 54);
         this.txtID.Name = "txtID";
         this.txtID.Size = new System.Drawing.Size(55, 20);
         this.txtID.TabIndex = 17;
         this.txtID.Visible = false;
         // 
         // cboEstadoCivil
         // 
         this.cboEstadoCivil.FormattingEnabled = true;
         this.cboEstadoCivil.Location = new System.Drawing.Point(404, 129);
         this.cboEstadoCivil.Name = "cboEstadoCivil";
         this.cboEstadoCivil.Size = new System.Drawing.Size(123, 21);
         this.cboEstadoCivil.TabIndex = 5;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(53, 61);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(38, 13);
         this.label2.TabIndex = 9;
         this.label2.Text = "Nome:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(313, 61);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(56, 13);
         this.label3.TabIndex = 10;
         this.label3.Text = "Endereço:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(53, 115);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(43, 13);
         this.label4.TabIndex = 11;
         this.label4.Text = "Cidade:";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(162, 115);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(31, 13);
         this.label5.TabIndex = 12;
         this.label5.Text = "CEP:";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(403, 114);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(65, 13);
         this.label6.TabIndex = 16;
         this.label6.Text = "Estado Civil:";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(268, 115);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(43, 13);
         this.label7.TabIndex = 13;
         this.label7.Text = "Estado:";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(56, 161);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(108, 23);
         this.button1.TabIndex = 6;
         this.button1.Text = "Incluir";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // label1
         // 
         this.label1.BackColor = System.Drawing.Color.White;
         this.label1.Dock = System.Windows.Forms.DockStyle.Top;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(0, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(575, 46);
         this.label1.TabIndex = 8;
         this.label1.Text = "Detalhes do Cliente";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblStatus
         // 
         this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
         this.lblStatus.ForeColor = System.Drawing.Color.White;
         this.lblStatus.Location = new System.Drawing.Point(0, 196);
         this.lblStatus.Name = "lblStatus";
         this.lblStatus.Size = new System.Drawing.Size(575, 31);
         this.lblStatus.TabIndex = 14;
         this.lblStatus.Text = "Status:";
         this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // cboEstado
         // 
         this.cboEstado.FormattingEnabled = true;
         this.cboEstado.Location = new System.Drawing.Point(274, 129);
         this.cboEstado.Name = "cboEstado";
         this.cboEstado.Size = new System.Drawing.Size(121, 21);
         this.cboEstado.TabIndex = 4;
         // 
         // dgClientes
         // 
         this.dgClientes.AllowUserToAddRows = false;
         this.dgClientes.AllowUserToDeleteRows = false;
         this.dgClientes.AllowUserToResizeColumns = false;
         this.dgClientes.AllowUserToResizeRows = false;
         this.dgClientes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
         this.dgClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.dgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.dgClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
         this.dgClientes.Location = new System.Drawing.Point(0, 227);
         this.dgClientes.MultiSelect = false;
         this.dgClientes.Name = "dgClientes";
         this.dgClientes.ReadOnly = true;
         this.dgClientes.RowHeadersVisible = false;
         this.dgClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dgClientes.Size = new System.Drawing.Size(575, 207);
         this.dgClientes.TabIndex = 7;
         this.dgClientes.TabStop = false;
         // 
         // Form1
         // 
         this.AcceptButton = this.button1;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(575, 434);
         this.Controls.Add(this.lblStatus);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.cboEstado);
         this.Controls.Add(this.cboEstadoCivil);
         this.Controls.Add(this.txtCep);
         this.Controls.Add(this.txtCidade);
         this.Controls.Add(this.txtEndereco);
         this.Controls.Add(this.txtID);
         this.Controls.Add(this.txtNome);
         this.Controls.Add(this.dgClientes);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Name = "Form1";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Cadastro de Clientes";
         this.Load += new System.EventHandler(this.Form1_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private ClientesGridView dgClientes;
      private System.Windows.Forms.TextBox txtNome;
      private System.Windows.Forms.TextBox txtEndereco;
      private System.Windows.Forms.TextBox txtCidade;
      private System.Windows.Forms.TextBox txtCep;
      private System.Windows.Forms.TextBox txtID;
      private System.Windows.Forms.ComboBox cboEstadoCivil;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label lblStatus;
      private EstadoComboBox cboEstado;
   }
}

