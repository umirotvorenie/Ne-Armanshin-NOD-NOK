namespace WinFormsApp1
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
            buttonCalculate = new Button();
            buttonClear = new Button();
            buttonWord = new Button();
            buttonExcel = new Button();
            buttonPDF = new Button();
            textBoxFirstNumber = new TextBox();
            textBoxSecondNumber = new TextBox();
            labelAnd = new Label();
            labelLCM = new Label();
            labelGCD = new Label();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // buttonCalculate
            // 
            buttonCalculate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCalculate.Location = new Point(782, 123);
            buttonCalculate.Name = "buttonCalculate";
            buttonCalculate.Size = new Size(150, 56);
            buttonCalculate.TabIndex = 0;
            buttonCalculate.Text = "Рассчитать";
            buttonCalculate.UseVisualStyleBackColor = true;
            buttonCalculate.Click += ButtonCalculate_Click;
            // 
            // buttonClear
            // 
            buttonClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClear.Location = new Point(782, 185);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(150, 56);
            buttonClear.TabIndex = 1;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += ButtonClear_Click;
            // 
            // buttonWord
            // 
            buttonWord.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonWord.Location = new Point(782, 247);
            buttonWord.Name = "buttonWord";
            buttonWord.Size = new Size(150, 56);
            buttonWord.TabIndex = 2;
            buttonWord.Text = "Вывод в Word";
            buttonWord.UseVisualStyleBackColor = true;
            buttonWord.Click += ButtonWord_Click;
            // 
            // buttonExcel
            // 
            buttonExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonExcel.Location = new Point(782, 309);
            buttonExcel.Name = "buttonExcel";
            buttonExcel.Size = new Size(150, 56);
            buttonExcel.TabIndex = 3;
            buttonExcel.Text = "Вывод в Excel";
            buttonExcel.UseVisualStyleBackColor = true;
            buttonExcel.Click += ButtonExcel_Click;
            // 
            // buttonPDF
            // 
            buttonPDF.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonPDF.Location = new Point(782, 371);
            buttonPDF.Name = "buttonPDF";
            buttonPDF.Size = new Size(150, 56);
            buttonPDF.TabIndex = 4;
            buttonPDF.Text = "Вывод в PDF";
            buttonPDF.UseVisualStyleBackColor = true;
            buttonPDF.Click += ButtonPDF_Click;
            // 
            // textBoxFirstNumber
            // 
            textBoxFirstNumber.Font = new Font("Segoe UI", 14F);
            textBoxFirstNumber.Location = new Point(72, 93);
            textBoxFirstNumber.MaxLength = 29;
            textBoxFirstNumber.Name = "textBoxFirstNumber";
            textBoxFirstNumber.Size = new Size(300, 32);
            textBoxFirstNumber.TabIndex = 5;
            textBoxFirstNumber.TextAlign = HorizontalAlignment.Center;
            textBoxFirstNumber.TextChanged += textBoxFirstNumber_TextChanged;
            // 
            // textBoxSecondNumber
            // 
            textBoxSecondNumber.Font = new Font("Segoe UI", 14F);
            textBoxSecondNumber.Location = new Point(402, 93);
            textBoxSecondNumber.MaxLength = 29;
            textBoxSecondNumber.Name = "textBoxSecondNumber";
            textBoxSecondNumber.Size = new Size(300, 32);
            textBoxSecondNumber.TabIndex = 6;
            textBoxSecondNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // labelAnd
            // 
            labelAnd.AutoSize = true;
            labelAnd.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelAnd.Location = new Point(378, 96);
            labelAnd.Name = "labelAnd";
            labelAnd.Size = new Size(18, 25);
            labelAnd.TabIndex = 7;
            labelAnd.Text = ";";
            // 
            // labelLCM
            // 
            labelLCM.AutoSize = true;
            labelLCM.Font = new Font("Segoe UI", 14F);
            labelLCM.Location = new Point(12, 198);
            labelLCM.Name = "labelLCM";
            labelLCM.Size = new Size(318, 25);
            labelLCM.TabIndex = 8;
            labelLCM.Text = "Наименьшее общее кратное (НОК)";
            labelLCM.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGCD
            // 
            labelGCD.AutoSize = true;
            labelGCD.Font = new Font("Segoe UI", 14F);
            labelGCD.Location = new Point(446, 198);
            labelGCD.Name = "labelGCD";
            labelGCD.Size = new Size(331, 25);
            labelGCD.TabIndex = 9;
            labelGCD.Text = "Наибольший общий делитель (НОД)";
            labelGCD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonExit
            // 
            buttonExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonExit.Location = new Point(782, 433);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(150, 56);
            buttonExit.TabIndex = 10;
            buttonExit.Text = "Выход";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 501);
            Controls.Add(buttonExit);
            Controls.Add(labelGCD);
            Controls.Add(labelLCM);
            Controls.Add(labelAnd);
            Controls.Add(textBoxSecondNumber);
            Controls.Add(textBoxFirstNumber);
            Controls.Add(buttonPDF);
            Controls.Add(buttonExcel);
            Controls.Add(buttonWord);
            Controls.Add(buttonClear);
            Controls.Add(buttonCalculate);
            Name = "Form1";
            Text = "Калькулятор НОД и НОК";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCalculate;
        private Button buttonClear;
        private Button buttonWord;
        private Button buttonExcel;
        private Button buttonPDF;
        private TextBox textBoxFirstNumber;
        private TextBox textBoxSecondNumber;
        private Label labelAnd;
        private Label labelLCM;
        private Label labelGCD;
        private Button buttonExit;
    }
}
