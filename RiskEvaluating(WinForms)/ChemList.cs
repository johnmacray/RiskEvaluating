using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskEvaluating_WinForms_
{
    public partial class ChemList : Form
    {
        public DataGridView dgw = new DataGridView();

        MPCs consts = new MPCs();
        public static List<int> CheckedIndexes = new List<int>();
        public ChemList()
        {
            InitializeComponent();
            ChemNameBox.ReadOnly = true;
            DangerClass_Label.Text = "";
            MPCdaily_Label.Text = "";
            MPCinstant_Label.Text = "";
            MPCyear_Label.Text = "";

            // CheckBoxesList.ItemCheck += checkElementEvent;
            CheckBoxesList.SelectedIndexChanged += selectedElementEvent;
        }

        private void ChemList_Load(object sender, EventArgs e)
        {

            //checkedListBox1.Items.Add("test1");

            for (int i = 1; i <= consts.Chemicals.Length - 1; i++)
            {
                CheckBoxesList.Items.Add(consts.Chemicals[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Кнопка Применить после выбора хим элементов
        {
            dgw.Rows.Clear();
            CheckedIndexes.Clear();
            foreach (int index in CheckBoxesList.CheckedIndices)
            {
                CheckedIndexes.Add(index + 1);
                this.Close();
            }


            MPCs consts = new MPCs();
            int tableLenght = ChemList.CheckedIndexes.Count;

            dgw.Rows.Add(tableLenght);

            int j = 0;
            foreach (int i in ChemList.CheckedIndexes)
            {
                dgw["ChemElementColumn", j].Value = consts.Chemicals[i];
                j++;
            }

            dgw.AllowUserToAddRows = false;

            tableFilling();

        }

        private void selectedElementEvent(object sender, EventArgs e)
        {
            //MessageBox.Show($"{CheckBoxesList.SelectedItem.ToString()}, {CheckBoxesList.SelectedIndex.ToString()}");
            int index = CheckBoxesList.SelectedIndex;
            ChemNameBox.Text = $"{CheckBoxesList.SelectedItem.ToString()}";
            DangerClass_Label.Text = $"Класс опасности: {consts.DangerClass[index + 1]}";
            MPCinstant_Label.Text = $"ПДК м.р.: {consts.MPSc_instant[index + 1].ToString("0.#######")}";
            MPCdaily_Label.Text = $"ПДК с.с.: {consts.MPSc_daily[index + 1].ToString("0.#######")}";
            MPCyear_Label.Text = $"ПДК с.г.: {consts.MPSc_year[index + 1].ToString("0.#######")}";

        }

        private bool isAll = true;
        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            if (isAll == false)
            {
                
                for (int i = 0; i <= 25; i++)
                {
                    CheckBoxesList.SetItemChecked(i, false);
                }
                SelectAllButton.Text = "Выбрать все";
                isAll = true;
                return;
            } 

            if (isAll == true)
            {
                for (int i = 0; i <= 25; i++)
                {
                    CheckBoxesList.SetItemChecked(i, true);
                }
                SelectAllButton.Text = "Отменить все";
                isAll = false;
                return;
            }
        }


        private void tableFilling()
        {
            // for(int i = 0; ) ОСТАНОВИЛСЯ НА ТОМ, ЧТО НАДО ЗАПОЛНЯТЬ ТАБЛИЦУ ПДК И КЛАССОМ ОПАСНОСТИ
            int i = 0;
           foreach(int index in CheckedIndexes)
            {
                dgw["DangerClassColumn", i].Value = consts.DangerClass[index];
                dgw["MPS_instant_Column", i].Value = consts.MPSc_instant[index].ToString("0.######");
                dgw["MPS_daily_Column", i].Value = consts.MPSc_daily[index].ToString("0.######");
                dgw["MPS_year_Column", i].Value = consts.MPSc_year[index].ToString("0.######");
                i++;
            }
        }
    }
}
