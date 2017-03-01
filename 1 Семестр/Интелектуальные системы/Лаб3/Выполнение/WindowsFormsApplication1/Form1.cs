using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;




namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}




		private void Create()
		{
			Matrix.RowCount = Convert.ToInt32(NodeCount.Text);
			Matrix.ColumnCount = Matrix.RowCount;
			for (int i = 0; i < Matrix.ColumnCount; i++)
			{
				Matrix.Columns[i].Width = 30;
				for (int j = 0; j < Matrix.ColumnCount; j++)
					Matrix.Rows[j].Cells[i].Value = "0";

			}
		}

		private void Open()
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				string filename = openFileDialog1.FileName;
				StreamReader f = new StreamReader(filename);
				string s = "";
				int j = 0;
				int z = 0;
				while (true)
				{
					s = f.ReadLine();
					if (s == null) break;
					if (z == 0)
					{
						int l = s.Length;
						NodeCount.Text = l.ToString();
						Matrix.RowCount = l;
						Matrix.ColumnCount = Matrix.RowCount;
						for (int i = 0; i < Matrix.ColumnCount; i++)
							Matrix.Columns[i].Width = 30;
						z++;
					}
					for (int i = 0; i < Matrix.ColumnCount; i++)
						Matrix.Rows[j].Cells[i].Value = s[i].ToString();
					j++;
				}
				f.Close();
			}
		}

		private void SaveMatrix()
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				string filename = saveFileDialog1.FileName;
				StreamWriter f = new StreamWriter(filename);
				string s = "";
				for (int j = 0; j < Matrix.RowCount; j++)
				{
					for (int i = 0; i < Matrix.RowCount; i++)
						s += Matrix.Rows[j].Cells[i].Value.ToString();
					f.WriteLine(s);
					s = "";
				}
				f.Close();
			}
		}

		private void OpenButton_Click(object sender, EventArgs e)
		{
			Open();
		}

		private void CreateBurron_Click(object sender, EventArgs e)
		{
			Create();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			SaveMatrix();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			var algoritm = new GeneticAlgoritm(
				Convert.ToInt32(NodeCount.Text),
				Convert.ToInt32(IndividualCountTextBox.Text));
			Result.Rows.Clear();
			Result.Refresh();
			ResultTextBox.Text = algoritm.StartGeneticAlgoritm(Matrix, Result);
		}
	}
}
