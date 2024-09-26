namespace RiskEvaluating_WinForms_
{
    partial class ChemList
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
            CheckBoxesList = new CheckedListBox();
            button1 = new Button();
            label1 = new Label();
            DangerClass_Label = new Label();
            MPCinstant_Label = new Label();
            MPCdaily_Label = new Label();
            MPCyear_Label = new Label();
            ChemNameBox = new TextBox();
            nameLabel = new Label();
            SelectAllButton = new Button();
            SuspendLayout();
            // 
            // CheckBoxesList
            // 
            CheckBoxesList.FormattingEnabled = true;
            CheckBoxesList.Location = new Point(12, 69);
            CheckBoxesList.Name = "CheckBoxesList";
            CheckBoxesList.Size = new Size(220, 220);
            CheckBoxesList.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(129, 307);
            button1.Name = "button1";
            button1.Size = new Size(80, 23);
            button1.TabIndex = 1;
            button1.Text = "Применить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 25);
            label1.Name = "label1";
            label1.Size = new Size(357, 15);
            label1.TabIndex = 2;
            label1.Text = "Выберите из списка необходимые для рассчета хим. элементы";
            // 
            // DangerClass_Label
            // 
            DangerClass_Label.AutoSize = true;
            DangerClass_Label.Location = new Point(251, 167);
            DangerClass_Label.Name = "DangerClass_Label";
            DangerClass_Label.Size = new Size(38, 15);
            DangerClass_Label.TabIndex = 4;
            DangerClass_Label.Text = "label3";
            // 
            // MPCinstant_Label
            // 
            MPCinstant_Label.AutoSize = true;
            MPCinstant_Label.Location = new Point(251, 202);
            MPCinstant_Label.Name = "MPCinstant_Label";
            MPCinstant_Label.Size = new Size(38, 15);
            MPCinstant_Label.TabIndex = 5;
            MPCinstant_Label.Text = "label4";
            // 
            // MPCdaily_Label
            // 
            MPCdaily_Label.AutoSize = true;
            MPCdaily_Label.Location = new Point(251, 236);
            MPCdaily_Label.Name = "MPCdaily_Label";
            MPCdaily_Label.Size = new Size(38, 15);
            MPCdaily_Label.TabIndex = 6;
            MPCdaily_Label.Text = "label5";
            // 
            // MPCyear_Label
            // 
            MPCyear_Label.AutoSize = true;
            MPCyear_Label.Location = new Point(251, 271);
            MPCyear_Label.Name = "MPCyear_Label";
            MPCyear_Label.Size = new Size(38, 15);
            MPCyear_Label.TabIndex = 7;
            MPCyear_Label.Text = "label6";
            // 
            // ChemNameBox
            // 
            ChemNameBox.Location = new Point(251, 87);
            ChemNameBox.Multiline = true;
            ChemNameBox.Name = "ChemNameBox";
            ChemNameBox.Size = new Size(148, 68);
            ChemNameBox.TabIndex = 8;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(251, 69);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(148, 15);
            nameLabel.TabIndex = 9;
            nameLabel.Text = "Наименование элемента:";
            // 
            // SelectAllButton
            // 
            SelectAllButton.Location = new Point(23, 307);
            SelectAllButton.Name = "SelectAllButton";
            SelectAllButton.Size = new Size(89, 23);
            SelectAllButton.TabIndex = 10;
            SelectAllButton.Text = "Выбрать все";
            SelectAllButton.UseVisualStyleBackColor = true;
            SelectAllButton.Click += SelectAllButton_Click;
            // 
            // ChemList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 342);
            Controls.Add(SelectAllButton);
            Controls.Add(nameLabel);
            Controls.Add(ChemNameBox);
            Controls.Add(MPCyear_Label);
            Controls.Add(MPCdaily_Label);
            Controls.Add(MPCinstant_Label);
            Controls.Add(DangerClass_Label);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(CheckBoxesList);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ChemList";
            Text = "Список хим. элементов";
            Load += ChemList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox CheckBoxesList;
        private Button button1;
        private Label label1;
        private Label DangerClass_Label;
        private Label MPCinstant_Label;
        private Label MPCdaily_Label;
        private Label MPCyear_Label;
        private TextBox ChemNameBox;
        private Label nameLabel;
        private Button SelectAllButton;
    }
}