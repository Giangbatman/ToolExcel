
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Office Files|*.xls;*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook excelWorkbook = excelApp.Workbooks.Open(filePath);
                Worksheet excelWorksheet = excelWorksheet.Sheets
                Range excelRange = excelWorksheet.UsedRange;

                dgvEvents.Rows.Clear();

                for (int row = 2; row <= excelRange.Rows.Count; row++)
                {
                    string index = excelRange.Cells[row, 1].Value?.ToString();
                    string eventDate = excelRange.Cells[row, 4].Value?.ToString();
                    string eventDetail = excelRange.Cells[row, 10].Value?.ToString();

                    dgvEvents.Rows.Add(index, eventDate, eventDetail);
                }

                excelWorkbook.Close();
                excelApp.Quit();
            }


        }
    }
}