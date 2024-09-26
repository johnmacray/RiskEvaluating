namespace RiskEvaluating_WinForms_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            userGrid = new DataGridView();
            label1 = new Label();
            SelectChem = new Button();
            CalculateButton = new Button();
            HIlabel1 = new Label();
            HI_instant_textbox = new TextBox();
            HI_daily_textbox = new TextBox();
            HI_year_textbox = new TextBox();
            Hilabel2 = new Label();
            HIlabel3 = new Label();
            InstantCombineRiskLabel = new Label();
            YearCombineRiskLabel = new Label();
            InstantCombineRiskTextBox = new TextBox();
            YearCombineRiskTextBox = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)userGrid).BeginInit();
            SuspendLayout();
            // 
            // userGrid
            // 
            userGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userGrid.Location = new Point(35, 116);
            userGrid.Name = "userGrid";
            userGrid.Size = new Size(1537, 623);
            userGrid.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 18);
            label1.Name = "label1";
            label1.Size = new Size(811, 15);
            label1.TabIndex = 1;
            label1.Text = "Для начала расчета, введите велечины концентраций Факт м.р., Факт с.с и Факт с.г., а также величину популяции, необходимую для расчета PCR";
            // 
            // SelectChem
            // 
            SelectChem.Location = new Point(102, 70);
            SelectChem.Name = "SelectChem";
            SelectChem.Size = new Size(184, 24);
            SelectChem.TabIndex = 2;
            SelectChem.Text = " Изменить список элементов";
            SelectChem.UseVisualStyleBackColor = true;
            SelectChem.Click += SelectChem_Click;
            // 
            // CalculateButton
            // 
            CalculateButton.Location = new Point(35, 770);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(201, 61);
            CalculateButton.TabIndex = 3;
            CalculateButton.Text = "Расчет";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // HIlabel1
            // 
            HIlabel1.AutoSize = true;
            HIlabel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HIlabel1.Location = new Point(691, 758);
            HIlabel1.Name = "HIlabel1";
            HIlabel1.Size = new Size(72, 20);
            HIlabel1.TabIndex = 4;
            HIlabel1.Text = "HI м.р. = ";
            // 
            // HI_instant_textbox
            // 
            HI_instant_textbox.Location = new Point(766, 759);
            HI_instant_textbox.Name = "HI_instant_textbox";
            HI_instant_textbox.Size = new Size(100, 23);
            HI_instant_textbox.TabIndex = 5;
            // 
            // HI_daily_textbox
            // 
            HI_daily_textbox.Location = new Point(766, 788);
            HI_daily_textbox.Name = "HI_daily_textbox";
            HI_daily_textbox.Size = new Size(100, 23);
            HI_daily_textbox.TabIndex = 6;
            // 
            // HI_year_textbox
            // 
            HI_year_textbox.Location = new Point(766, 817);
            HI_year_textbox.Name = "HI_year_textbox";
            HI_year_textbox.Size = new Size(100, 23);
            HI_year_textbox.TabIndex = 7;
            // 
            // Hilabel2
            // 
            Hilabel2.AutoSize = true;
            Hilabel2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Hilabel2.Location = new Point(691, 787);
            Hilabel2.Name = "Hilabel2";
            Hilabel2.Size = new Size(66, 20);
            Hilabel2.TabIndex = 8;
            Hilabel2.Text = "HI с.с. = ";
            // 
            // HIlabel3
            // 
            HIlabel3.AutoSize = true;
            HIlabel3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HIlabel3.Location = new Point(691, 817);
            HIlabel3.Name = "HIlabel3";
            HIlabel3.Size = new Size(65, 20);
            HIlabel3.TabIndex = 9;
            HIlabel3.Text = "HI с.г. = ";
            // 
            // InstantCombineRiskLabel
            // 
            InstantCombineRiskLabel.AutoSize = true;
            InstantCombineRiskLabel.Location = new Point(890, 763);
            InstantCombineRiskLabel.Name = "InstantCombineRiskLabel";
            InstantCombineRiskLabel.Size = new Size(357, 15);
            InstantCombineRiskLabel.TabIndex = 10;
            InstantCombineRiskLabel.Text = "Оценка комбинированного риска рефлекторного воздействия:";
            // 
            // YearCombineRiskLabel
            // 
            YearCombineRiskLabel.AutoSize = true;
            YearCombineRiskLabel.Location = new Point(890, 788);
            YearCombineRiskLabel.Name = "YearCombineRiskLabel";
            YearCombineRiskLabel.Size = new Size(357, 15);
            YearCombineRiskLabel.TabIndex = 11;
            YearCombineRiskLabel.Text = "Оценка комбинированного риска рефлекторного воздействия:";
            // 
            // InstantCombineRiskTextBox
            // 
            InstantCombineRiskTextBox.Location = new Point(1263, 760);
            InstantCombineRiskTextBox.Name = "InstantCombineRiskTextBox";
            InstantCombineRiskTextBox.Size = new Size(100, 23);
            InstantCombineRiskTextBox.TabIndex = 12;
            // 
            // YearCombineRiskTextBox
            // 
            YearCombineRiskTextBox.Location = new Point(1263, 790);
            YearCombineRiskTextBox.Name = "YearCombineRiskTextBox";
            YearCombineRiskTextBox.Size = new Size(100, 23);
            YearCombineRiskTextBox.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 33);
            label2.Name = "label2";
            label2.Size = new Size(385, 15);
            label2.TabIndex = 14;
            label2.Text = "(Поля пользовательского ввода данных отмечены зеленым цветом)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(label2);
            Controls.Add(YearCombineRiskTextBox);
            Controls.Add(InstantCombineRiskTextBox);
            Controls.Add(YearCombineRiskLabel);
            Controls.Add(InstantCombineRiskLabel);
            Controls.Add(HIlabel3);
            Controls.Add(Hilabel2);
            Controls.Add(HI_year_textbox);
            Controls.Add(HI_daily_textbox);
            Controls.Add(HI_instant_textbox);
            Controls.Add(HIlabel1);
            Controls.Add(CalculateButton);
            Controls.Add(SelectChem);
            Controls.Add(label1);
            Controls.Add(userGrid);
            Name = "Form1";
            Text = "Оценка риска для здоровья населения, проживающего вблизи автомагистралей";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)userGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView userGrid;
        private Label label1;
        private Button SelectChem;
        private Button CalculateButton;
        private Label HIlabel1;
        private TextBox HI_instant_textbox;
        private TextBox HI_daily_textbox;
        private TextBox HI_year_textbox;
        private Label Hilabel2;
        private Label HIlabel3;
        private Label InstantCombineRiskLabel;
        private Label YearCombineRiskLabel;
        private TextBox InstantCombineRiskTextBox;
        private TextBox YearCombineRiskTextBox;
        private Label label2;
    }
}
