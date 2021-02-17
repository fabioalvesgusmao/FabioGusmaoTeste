
namespace FabioGusmao.Ui
{
    partial class Form
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
            this.dataGridViewStockOrders = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoOperacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxDownload = new System.Windows.Forms.GroupBox();
            this.radioButtonPdf = new System.Windows.Forms.RadioButton();
            this.radioButtonExcel = new System.Windows.Forms.RadioButton();
            this.radioButtonCsv = new System.Windows.Forms.RadioButton();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.groupBoxStockOrders = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockOrders)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxDownload.SuspendLayout();
            this.groupBoxStockOrders.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewStockOrders
            // 
            this.dataGridViewStockOrders.AllowUserToAddRows = false;
            this.dataGridViewStockOrders.AllowUserToDeleteRows = false;
            this.dataGridViewStockOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStockOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DateTime,
            this.TipoOperacao,
            this.Ativo,
            this.Quantidade,
            this.Preco,
            this.Conta});
            this.dataGridViewStockOrders.Location = new System.Drawing.Point(12, 74);
            this.dataGridViewStockOrders.Name = "dataGridViewStockOrders";
            this.dataGridViewStockOrders.ReadOnly = true;
            this.dataGridViewStockOrders.Size = new System.Drawing.Size(745, 373);
            this.dataGridViewStockOrders.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "A";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // DateTime
            // 
            this.DateTime.HeaderText = "B";
            this.DateTime.Name = "DateTime";
            this.DateTime.ReadOnly = true;
            // 
            // TipoOperacao
            // 
            this.TipoOperacao.HeaderText = "C";
            this.TipoOperacao.Name = "TipoOperacao";
            this.TipoOperacao.ReadOnly = true;
            // 
            // Ativo
            // 
            this.Ativo.HeaderText = "D";
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            // 
            // Quantidade
            // 
            this.Quantidade.HeaderText = "E";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            // 
            // Preco
            // 
            this.Preco.HeaderText = "F";
            this.Preco.Name = "Preco";
            this.Preco.ReadOnly = true;
            // 
            // Conta
            // 
            this.Conta.HeaderText = "G";
            this.Conta.Name = "Conta";
            this.Conta.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxDownload);
            this.panel1.Controls.Add(this.groupBoxStockOrders);
            this.panel1.Controls.Add(this.dataGridViewStockOrders);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 1;
            // 
            // groupBoxDownload
            // 
            this.groupBoxDownload.Controls.Add(this.radioButtonPdf);
            this.groupBoxDownload.Controls.Add(this.radioButtonExcel);
            this.groupBoxDownload.Controls.Add(this.radioButtonCsv);
            this.groupBoxDownload.Controls.Add(this.buttonDownload);
            this.groupBoxDownload.Location = new System.Drawing.Point(319, 13);
            this.groupBoxDownload.Name = "groupBoxDownload";
            this.groupBoxDownload.Size = new System.Drawing.Size(438, 55);
            this.groupBoxDownload.TabIndex = 2;
            this.groupBoxDownload.TabStop = false;
            this.groupBoxDownload.Text = "Download";
            // 
            // radioButtonPdf
            // 
            this.radioButtonPdf.AutoSize = true;
            this.radioButtonPdf.Enabled = false;
            this.radioButtonPdf.Location = new System.Drawing.Point(116, 18);
            this.radioButtonPdf.Name = "radioButtonPdf";
            this.radioButtonPdf.Size = new System.Drawing.Size(46, 17);
            this.radioButtonPdf.TabIndex = 3;
            this.radioButtonPdf.Text = "PDF";
            this.radioButtonPdf.UseVisualStyleBackColor = true;
            // 
            // radioButtonExcel
            // 
            this.radioButtonExcel.AutoSize = true;
            this.radioButtonExcel.Location = new System.Drawing.Point(59, 18);
            this.radioButtonExcel.Name = "radioButtonExcel";
            this.radioButtonExcel.Size = new System.Drawing.Size(51, 17);
            this.radioButtonExcel.TabIndex = 2;
            this.radioButtonExcel.Text = "Excel";
            this.radioButtonExcel.UseVisualStyleBackColor = true;
            // 
            // radioButtonCsv
            // 
            this.radioButtonCsv.AutoSize = true;
            this.radioButtonCsv.Checked = true;
            this.radioButtonCsv.Location = new System.Drawing.Point(7, 18);
            this.radioButtonCsv.Name = "radioButtonCsv";
            this.radioButtonCsv.Size = new System.Drawing.Size(46, 17);
            this.radioButtonCsv.TabIndex = 1;
            this.radioButtonCsv.TabStop = true;
            this.radioButtonCsv.Text = "CSV";
            this.radioButtonCsv.UseVisualStyleBackColor = true;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(181, 15);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonDownload.TabIndex = 0;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxStockOrders
            // 
            this.groupBoxStockOrders.Controls.Add(this.buttonSearch);
            this.groupBoxStockOrders.Controls.Add(this.comboBoxGroup);
            this.groupBoxStockOrders.Location = new System.Drawing.Point(12, 13);
            this.groupBoxStockOrders.Name = "groupBoxStockOrders";
            this.groupBoxStockOrders.Size = new System.Drawing.Size(301, 55);
            this.groupBoxStockOrders.TabIndex = 1;
            this.groupBoxStockOrders.TabStop = false;
            this.groupBoxStockOrders.Text = "Agrupamento";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(135, 20);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Buscar";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Items.AddRange(new object[] {
            "Sem Agrupamento",
            "Fixa",
            "Ativo",
            "Tipo Operação",
            "Conta"});
            this.comboBoxGroup.Location = new System.Drawing.Point(7, 20);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGroup.TabIndex = 0;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form";
            this.Text = "Ordens Renda Variável";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockOrders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBoxDownload.ResumeLayout(false);
            this.groupBoxDownload.PerformLayout();
            this.groupBoxStockOrders.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStockOrders;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxStockOrders;
        private System.Windows.Forms.GroupBox groupBoxDownload;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoOperacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conta;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.RadioButton radioButtonPdf;
        private System.Windows.Forms.RadioButton radioButtonExcel;
        private System.Windows.Forms.RadioButton radioButtonCsv;
    }
}

