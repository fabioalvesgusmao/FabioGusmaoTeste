using FabioGusmao.Ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace FabioGusmao.Ui
{
    public partial class Form : System.Windows.Forms.Form
    {
        private static HttpClient client = new HttpClient();

        private Dictionary<string, bool> groupByDownloadAvailableDictionary = new Dictionary<string, bool>();

        public Form()
        {
            InitializeComponent();

            comboBoxGroup.SelectedIndex = 0;
        }

        private void dataGridViewStockOrders_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridViewStockOrders.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fileType = string.Empty;
                string groupBy = string.Empty;

                if (radioButtonCsv.Checked)
                {
                    fileType = "csv";
                }
                else if (radioButtonExcel.Checked)
                {
                    fileType = "xlsx";
                }
                else if (radioButtonPdf.Checked)
                {
                    fileType = "pdf";
                }

                string fileName = "arquivo" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + "." + fileType;

                switch (comboBoxGroup.SelectedItem.ToString())
                {
                    case "Sem Agrupamento":
                        groupBy = string.Empty;
                        break;
                    case "Fixa":
                        groupBy = "/Fixed";
                        break;
                    case "Conta":
                        groupBy = "/Account";
                        break;
                    case "Tipo Operação":
                        groupBy = "/OperationType";
                        break;
                    case "Ativo":
                        groupBy = "/Ticker";
                        break;
                }

                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        var uri = new Uri("https://localhost:44343/api/StockOrderDownload/" + groupBy + "/" + fileType);
                        HttpClient client = new HttpClient();
                        var response = await client.GetAsync(uri);
                        using (var fs = new FileStream(Path.Combine(fbd.SelectedPath, fileName),
                            FileMode.CreateNew))
                        {
                            await response.Content.CopyToAsync(fs);
                        }
                    }
                }

                MessageBox.Show(string.Format("Arquivo \"{0}\" foi salvo com sucesso.", fileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<StockOrder> stockOrders = null;

                dataGridViewStockOrders.Rows.Clear();

                string groupBy = string.Empty;
                string priceColumnHeader = "Preço";

                switch (comboBoxGroup.SelectedItem.ToString())
                {
                    case "Sem Agrupamento":
                        priceColumnHeader = "Preço";
                        groupBy = string.Empty;
                        break;
                    case "Fixa":
                        priceColumnHeader = "Preço Médio";
                        groupBy = "/GroupBy/Fixed";
                        break;
                    case "Conta":
                        priceColumnHeader = "Preço Médio";
                        groupBy = "/GroupBy/Account";
                        break;
                    case "Tipo Operação":
                        priceColumnHeader = "Preço Médio";
                        groupBy = "/GroupBy/OperationType";
                        break;
                    case "Ativo":
                        priceColumnHeader = "Preço Médio";
                        groupBy = "/GroupBy/Ticker";
                        break;
                }

                HttpResponseMessage response = await client.GetAsync("https://localhost:44343/api/StockOrder" + groupBy);
                if (response.IsSuccessStatusCode)
                {
                    stockOrders = await response.Content.ReadAsAsync<List<StockOrder>>();

                    int i = 0;

                    dataGridViewStockOrders.Rows.Add();

                    dataGridViewStockOrders.Rows[i].Cells[0].Value = "Id";
                    dataGridViewStockOrders.Rows[i].Cells[1].Value = "DateTime";
                    dataGridViewStockOrders.Rows[i].Cells[2].Value = "Tipo Operação";
                    dataGridViewStockOrders.Rows[i].Cells[3].Value = "Ativo";
                    dataGridViewStockOrders.Rows[i].Cells[4].Value = "Quantidade";
                    dataGridViewStockOrders.Rows[i].Cells[5].Value = priceColumnHeader;
                    dataGridViewStockOrders.Rows[i].Cells[6].Value = "Conta";

                    i++;

                    foreach (var stockOrder in stockOrders)
                    {
                        dataGridViewStockOrders.Rows.Add();

                        dataGridViewStockOrders.Rows[i].Cells[0].Value = stockOrder.Id;
                        dataGridViewStockOrders.Rows[i].Cells[1].Value = stockOrder.DateTime;
                        dataGridViewStockOrders.Rows[i].Cells[2].Value = stockOrder.OperationType;
                        dataGridViewStockOrders.Rows[i].Cells[3].Value = stockOrder.Ticker;
                        dataGridViewStockOrders.Rows[i].Cells[4].Value = stockOrder.Quantity;
                        dataGridViewStockOrders.Rows[i].Cells[5].Value = stockOrder.Price;
                        dataGridViewStockOrders.Rows[i].Cells[6].Value = stockOrder.Account;

                        i++;
                    }

                    this.dataGridViewStockOrders.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewStockOrders_RowPostPaint);

                    MessageBox.Show("Arquivo disponível para download.");

                    if (!groupByDownloadAvailableDictionary.ContainsKey(comboBoxGroup.SelectedItem.ToString()))
                    {
                        groupByDownloadAvailableDictionary.Add(comboBoxGroup.SelectedItem.ToString(), true);
                    }

                    CheckIfDownloadAvailable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIfDownloadAvailable();
        }

        private void CheckIfDownloadAvailable()
        {
            if (groupByDownloadAvailableDictionary.ContainsKey(comboBoxGroup.SelectedItem.ToString()))
            {
                buttonDownload.Enabled = true;
            }
            else
            {
                buttonDownload.Enabled = false;
            }
        }
    }
}
