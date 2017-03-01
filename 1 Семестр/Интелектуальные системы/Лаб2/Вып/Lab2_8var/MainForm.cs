using System;
using System.Collections;
using System.Windows.Forms;

namespace Lab2_8var
{
	public partial class MainForm : Form
	{

		private MainFormPresenter _mainFormPresenter;

		public MainForm()
		{
			InitializeComponent();

			_mainFormPresenter = new MainFormPresenter(this);

			FactToCheck.SelectedIndex = 0;
			DeductionType.SelectedIndex = 0;
			TruthMethod.SelectedIndex = 0;
			ConflictMethod.SelectedIndex = 0;
		}


		public void UpdateAllFactsList(ArrayList facts)
		{
			AllFactsList.Items.Clear();
			foreach (Fact fact in facts)
			{
				if (fact.Type == FactType.ForQuestion && !TrueFactsList.Items.Contains(fact))
					AllFactsList.Items.Add(fact);
			}
		}

		public void UpdateFactToCheck(ArrayList facts)
		{
			FactToCheck.Items.Clear();
			foreach (Fact fact in facts)
			{
				if (fact.Type == FactType.ForResult)
					FactToCheck.Items.Add(fact);
			}
			if (FactToCheck.Items.Count > 0)
				FactToCheck.SelectedIndex = 0;
		}

		public void UpdateTrueFactsList(ArrayList facts)
		{
			for (int index = 0; index < TrueFactsList.Items.Count; ++index)
			{
				if (!facts.Contains(TrueFactsList.Items[index]) || ((Fact)TrueFactsList.Items[index]).Type != FactType.ForQuestion)
					TrueFactsList.Items.RemoveAt(index);
			}
		}


		private void FactToCheck_SelectedIndexChanged(object sender, EventArgs e)
		{
			_mainFormPresenter.GetWorkResult();
		}

		private void LoadDataButton_Click(object sender, EventArgs e)
		{
			_mainFormPresenter.LoadData();
		}

		private void AddFactToTrueListButton_Click(object sender, EventArgs e)
		{
			if (AllFactsList.SelectedIndex == -1)
				return;
			TrueFactsList.Items.Add(AllFactsList.SelectedItem);
			AllFactsList.Items.Remove(AllFactsList.SelectedItem);

			_mainFormPresenter.GetWorkResult();
		}

		private void RemoveFactFromTrueListButton_Click(object sender, EventArgs e)
		{
			if (TrueFactsList.SelectedIndex == -1)
				return;
			AllFactsList.Items.Add(TrueFactsList.SelectedItem);
			TrueFactsList.Items.Remove(TrueFactsList.SelectedItem);

			_mainFormPresenter.GetWorkResult();
		}
	}
}
