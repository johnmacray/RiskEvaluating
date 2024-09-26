using System;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace RiskEvaluating_WinForms_
{
    public partial class Form1 : Form
    {

        public float[] userDataInstant = new float[27];
        public float[] userDataDaily = new float[27];
        public float[] userDataYear = new float[27];

        public float[] HQ_instant = new float[27];
        public float[] HQ_daily = new float[27];
        public float[] HQ_year = new float[27];

        public float HI_instant = 0;
        public float HI_daily = 0;
        public float HI_year = 0;


        Rules rules = new Rules();
        MPCs consts = new MPCs();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableInitialization();

            HIlabel1.Visible = false; Hilabel2.Visible = false; HIlabel3.Visible = false;
            HI_instant_textbox.ReadOnly = true; HI_instant_textbox.Visible = false;
            HI_daily_textbox.ReadOnly = true; HI_daily_textbox.Visible = false;
            HI_instant_textbox.ReadOnly = true; HI_year_textbox.Visible = false;
            HI_year_textbox.ReadOnly = true;

            InstantCombineRiskLabel.Visible = false;
            YearCombineRiskLabel.Visible = false;
            InstantCombineRiskTextBox.Visible = false; InstantCombineRiskTextBox.ReadOnly = true;
            YearCombineRiskTextBox.Visible = false; YearCombineRiskTextBox.ReadOnly = true;
        }


        private void tableInitialization()
        {

            int tableLenght = ChemList.CheckedIndexes.Count;


            userGrid.Columns.Add("ChemElementColumn", "Химический элемент");
            userGrid.Columns.Add("DangerClassColumn", "Класс опасности");

            userGrid.Columns.Add("MPS_instant_Column", "ПДК м.р.");
            userGrid.Columns.Add("MPS_daily_Column", "ПДК с.с.");
            userGrid.Columns.Add("MPS_year_Column", "ПДК с.г.");

            userGrid.Columns.Add("UserData_InstantColumn", "Факт м.р.");
            userGrid.Columns.Add("UserData_DailyColumn", "Факт с.с.");
            userGrid.Columns.Add("UserData_YearColumn", "Факт с.г.");

            userGrid.Columns.Add("HQ_InstantColumn", "Коэффициент опасности развития неканцерогенных эффектов HQ м.р.");
            userGrid.Columns.Add("HQ_DailyColumn", "Коэффициент опасности развития неканцерогенных эффектов HQ с.с.");
            userGrid.Columns.Add("HQ_YearColumn", "Коэффициент опасности развития неканцерогенных эффектов HQ с.г.");

            userGrid.Columns.Add("HQ_instant_risk", "Уровень риска по величине коэф. опасности HQ м.р.");
            userGrid.Columns.Add("HQ_daily_risk", "Уровень риска по величине коэф. опасности HQ с.с.");
            userGrid.Columns.Add("HQ_year_risk", "Уровень риска по величине коэф. опасности HQ с.г.");

            userGrid.Columns.Add("Instant_risk_eval", "Расчет потенциального риска рефлекторного действия");
            userGrid.Columns.Add("Cronic_risk_eval", "Расчет потенциального риска хронического действия");

            userGrid.Columns.Add("ADD", "Среднесуточная доза для взрослого населения, мг/кг в сутки");
            userGrid.Columns.Add("Population", "Численность населения");
            userGrid.Columns.Add("PCR", "Число дополнительных случаев рака в год");

            userGrid.AutoResizeColumns(); userGrid.AutoResizeRows(); // Установка нормальных размеров строк и колонок
            userGrid.Columns[2].Width = 80; userGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            userGrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            userGrid.Columns["ChemElementColumn"].ReadOnly = true; userGrid.Columns["DangerClassColumn"].ReadOnly = true;
            userGrid.Columns["MPS_instant_Column"].ReadOnly = true;
            userGrid.Columns["MPS_daily_Column"].ReadOnly = true;
            userGrid.Columns["MPS_year_Column"].ReadOnly = true;

            userGrid.Columns[5].HeaderCell.Style.BackColor = Color.LightGreen;
            userGrid.Columns[6].HeaderCell.Style.BackColor = Color.LightGreen;
            userGrid.Columns[7].HeaderCell.Style.BackColor = Color.LightGreen;
            userGrid.Columns[17].HeaderCell.Style.BackColor = Color.LightGreen;

            // КОЛОНКА ПОПУЛЯЦИИ И ЕЩЕ ЧЕТО ПОЛЬЗОВАТЕЛЬСКОЕ
            userGrid.EnableHeadersVisualStyles = false;
        }

        public void TableFormer()
        {
            MPCs consts = new MPCs();
            int tableLenght = ChemList.CheckedIndexes.Count;

            userGrid.Rows.Add(tableLenght);

            int j = 0;
            foreach (int i in ChemList.CheckedIndexes)
            {
                userGrid["ChemElementColumn", j].Value = consts.Chemicals[i];
                j++;
            }
        }

        private void SelectChem_Click(object sender, EventArgs e)
        {
            ChemList chmlist = new ChemList();
            chmlist.dgw = this.userGrid;
            chmlist.Show();
        }


        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                InstantCombineRiskLabel.Visible = true;
                YearCombineRiskLabel.Visible = true;
                InstantCombineRiskTextBox.Visible = true;
                YearCombineRiskTextBox.Visible = true;

                CalculateArraysFilling();
                HQCalculate();
                HICalculate();
                RiskEvaluation();
                combineRisk();
                cancerCalc();
            }
            catch(Exception ex)
            {
               // if(ex == ) 
            }

        }
 
        private void CalculateArraysFilling()
        {
            int i = 0;
            foreach (int index in ChemList.CheckedIndexes)
            {
                userDataInstant[index] = float.Parse(userGrid["UserData_InstantColumn", i].Value.ToString());
                //MessageBox.Show($"В user instant было ведено: {float.Parse(userGrid["UserData_InstantColumn", i].Value.ToString())}");
                userDataDaily[index] = float.Parse(userGrid["UserData_DailyColumn", i].Value.ToString());
                //MessageBox.Show($"В user daily было ведено: {float.Parse(userGrid["UserData_DailyColumn", i].Value.ToString())}");
                userDataYear[index] = float.Parse(userGrid["UserData_YearColumn", i].Value.ToString());
                //MessageBox.Show($"В user year было ведено: {float.Parse(userGrid["UserData_YearColumn", i].Value.ToString())}");
                i++;
            }
        }

        private void HQCalculate()
        {
            for (int i = 0; i <= ChemList.CheckedIndexes.Count - 1; i++)
            {
                userGrid["HQ_InstantColumn", i].Value
                    = float.Parse(userGrid["UserData_InstantColumn", i].Value.ToString())
                    / float.Parse(userGrid["MPS_instant_Column", i].Value.ToString());

                userGrid["HQ_DailyColumn", i].Value
                    = float.Parse(userGrid["UserData_DailyColumn", i].Value.ToString())
                    / float.Parse(userGrid["MPS_daily_Column", i].Value.ToString());


                userGrid["HQ_YearColumn", i].Value
                    = float.Parse(userGrid["UserData_YearColumn", i].Value.ToString())
                    / float.Parse(userGrid["MPS_year_Column", i].Value.ToString());


                userGrid["HQ_instant_risk", i].Value = Rules.HQ_rule(float.Parse(userGrid["HQ_InstantColumn", i].Value.ToString()));
                userGrid["HQ_daily_risk", i].Value = Rules.HQ_rule(float.Parse(userGrid["HQ_DailyColumn", i].Value.ToString()));
                userGrid["HQ_year_risk", i].Value = Rules.HQ_rule(float.Parse(userGrid["HQ_YearColumn", i].Value.ToString()));

            }
        }

        private void HICalculate()
        {
            HIlabel1.Visible = true; Hilabel2.Visible = true; HIlabel3.Visible = true;
            HI_instant_textbox.Visible = true;
            HI_daily_textbox.Visible = true;
            HI_year_textbox.Visible = true;

            float resultInst = 0;
            float resultDay = 0;
            float resultYear = 0;
            for (int i = 0; i <= ChemList.CheckedIndexes.Count - 1; i++)
            {
                resultInst += float.Parse(userGrid["HQ_InstantColumn", i].Value.ToString());
                resultDay += float.Parse(userGrid["HQ_DailyColumn", i].Value.ToString());
                resultYear += float.Parse(userGrid["HQ_YearColumn", i].Value.ToString());
            }

            HI_instant_textbox.Text = resultInst.ToString();
            HI_daily_textbox.Text = resultDay.ToString();
            HI_year_textbox.Text = resultYear.ToString();

        }

        private void RiskEvaluation()
        {
            for (int i = 0; i <= ChemList.CheckedIndexes.Count - 1; i++)
            {
                userGrid["Instant_risk_eval", i].Value =
                    Rules.Risk_rule(instantRiskCalculation(i));

                userGrid["Cronic_risk_eval", i].Value =
                    Rules.Risk_rule(chronicRiskCalculation(i));
            }
        }

        private float instantRiskCalculation(int row)
        {
            float result = 0;
            float risk = 0;
            switch (userGrid["DangerClassColumn", row].Value)
            {
                case 1:
                    result = -9.15f + 11.66f * 
                        (float)Math.Log10(float.Parse(userGrid["UserData_InstantColumn", row].Value.ToString()) 
                        / float.Parse(userGrid["MPS_instant_Column", row].Value.ToString()));
                    break;
                case 2:
                    result = -5.51f + 7.49f * (float)Math.Log10(float.Parse(userGrid["UserData_InstantColumn", row].Value.ToString())
                        / float.Parse(userGrid["MPS_instant_Column", row].Value.ToString()));
                    break;
                case 3:
                    result = -2.35f + 3.73f * (float)Math.Log10(float.Parse(userGrid["UserData_InstantColumn", row].Value.ToString())
                        / float.Parse(userGrid["MPS_instant_Column", row].Value.ToString()));
                    break;
                case 4:
                    result = -1.41f + 2.33f * (float)Math.Log10(float.Parse(userGrid["UserData_InstantColumn", row].Value.ToString())
                        / float.Parse(userGrid["MPS_instant_Column", row].Value.ToString()));
                    break;
                default:
                    result = 0;
                    break;
            }
            risk = Rules.RiskProbitTable((float)Math.Round(result, 1));
            return risk;
        }

        private float chronicRiskCalculation(int row)
        {
            float risk;
            risk = 1 - (float)Math.Exp(Math.Log(0.84) *
                (float)Math.Pow((float.Parse(userGrid["UserData_YearColumn", row].Value.ToString())
                / float.Parse(userGrid["MPS_year_Column", row].Value.ToString())),
                b(int.Parse(userGrid["DangerClassColumn", row].Value.ToString())))
                / kz(int.Parse(userGrid["DangerClassColumn", row].Value.ToString())));
            return risk;
        }

        public void combineRisk()
        {
            float combRisk_for_x;
            float combRisk_for_x1;
            float x = 1;
            float x1 = 1;
            for (int i = 0; i <= ChemList.CheckedIndexes.Count - 1; i++)
            {

                x *= (1 - instantRiskCalculation(i));
                x1 *= (1 - chronicRiskCalculation(i));
            }
            combRisk_for_x = 1 - x;
            combRisk_for_x1 = 1 - x1;

            InstantCombineRiskTextBox.Text = combRisk_for_x.ToString();
            YearCombineRiskTextBox.Text = combRisk_for_x1.ToString();
        }

        private float kz(int row)
        {
            float kz_koeff = 0;
            switch (row)
            {
                case 1:
                    kz_koeff = 7.5f;
                    break;
                case 2:
                    kz_koeff = 6;
                    break;
                case 3:
                    kz_koeff = 4.5f;
                    break;
                case 4:
                    kz_koeff = 3;
                    break;
                default:
                    throw new Exception("Такого класса опасности нет. Введите от 1 до 4");
            }
            return kz_koeff;
        }


        private float b(int row)
        {
            float b_koeff = 0;
            switch (row)
            {
                case 1:
                    b_koeff = 2.35f;
                    break;
                case 2:
                    b_koeff = 1.28f;
                    break;
                case 3:
                    b_koeff = 1;
                    break;
                case 4:
                    b_koeff = 0.87f;
                    break;
                default:
                    throw new Exception("Такого класса опасности нет. Введите от 1 до 4");
            }
            return b_koeff;
        }

        private void cancerCalc()
        {
            for (int i = 0; i <= ChemList.CheckedIndexes.Count - 1; i++)
            {
                userGrid["ADD", i].Value = ((float.Parse(userGrid["UserData_DailyColumn", i].Value.ToString())
                    * 8 * 1.4f) + (float.Parse(userGrid["UserData_DailyColumn", i].Value.ToString()) * 16 * 0.63f)) * 350 * 30 / (70 * 30 * 365);

                userGrid["PCR", i].Value = Math.Round(float.Parse(userGrid["ADD", i].Value.ToString()) * float.Parse(userGrid["Population", i].Value.ToString()));
            }
        }

    }
}
