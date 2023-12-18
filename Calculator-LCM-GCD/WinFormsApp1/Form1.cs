using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public double lCM, gCD;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                Calculate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonWord_Click(object sender, EventArgs e)
        {
            try
            {
                Calculate();
                Word.Application wordApp = new();
                wordApp.Visible = true;
                Word.Document doc = wordApp.Documents.Add();
                doc.Content.Text = $"Результаты вычислений:\nПервое введённое число = {textBoxFirstNumber.Text}\nВторое введённое число = " +
                    $"{textBoxSecondNumber.Text}\nПолное решение:\nСначала найдём наибольший общий делитель({textBoxFirstNumber.Text}, " +
                    $"{textBoxSecondNumber.Text})\nНОД({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = {gCD:F2}, так как " +
                    $"{textBoxFirstNumber.Text} и {textBoxSecondNumber.Text} делятся на {gCD:F2}\nЗатем найдём наименьшее общее кратное(" +
                    $"{textBoxFirstNumber.Text}, {textBoxSecondNumber.Text})\nНОК({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = " +
                    $"(a * b) / НОД(a, b) = ({textBoxFirstNumber.Text} * {textBoxSecondNumber.Text}) / {gCD:F2} = {lCM:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Calculate();
                Excel.Application excelApp = new();
                excelApp.Visible = true;
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Worksheets[1];
                worksheet.Cells[1, 1] = "Результаты вычислений:";
                worksheet.Cells[2, 1] = $"Первое введённое число = {textBoxFirstNumber.Text}";
                worksheet.Cells[3, 1] = $"Второе введённое число = {textBoxSecondNumber.Text}";
                worksheet.Cells[4, 1] = "Полное решение:";
                worksheet.Cells[5, 1] = $"Сначала найдём наибольший общий делитель({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text})";
                worksheet.Cells[6, 1] = $"НОД({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = {gCD:F2}, так как {textBoxFirstNumber.Text}" +
                    $" и {textBoxSecondNumber.Text} делятся на {gCD:F2}";
                worksheet.Cells[7, 1] = $"Затем найдём наименьшее общее кратное({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text})";
                worksheet.Cells[8, 1] = $"НОК({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = (a * b) / НОД(a, b) = (" +
                    $"{textBoxFirstNumber.Text} * {textBoxSecondNumber.Text}) / {gCD:F2} = {lCM:F2}";
                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonPDF_Click(object sender, EventArgs e)
        {
            try
            {
                Calculate();
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.pdf");
                using var pdfWriter = new PdfWriter(filePath);
                using var pdfDocument = new PdfDocument(pdfWriter);
                using var pdfDoc = new Document(pdfDocument);
                PdfFont timesFont = PdfFontFactory.CreateFont("c:/windows/fonts/times.ttf", PdfEncodings.IDENTITY_H, true);
                pdfDoc.Add(new Paragraph("Результаты вычислений:").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"Первое введённое число = {textBoxFirstNumber.Text}").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"Второе введённое число = {textBoxSecondNumber.Text}").SetFont(timesFont));
                pdfDoc.Add(new Paragraph("Полное решение:").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"Сначала найдём наибольший общий делитель({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text})" +
                    $"").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"НОД({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = {gCD:F2}, так как {textBoxFirstNumber.Text} " +
                    $"и {textBoxSecondNumber.Text} делятся на {gCD:F2}").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"Затем найдём наименьшее общее кратное({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text})" +
                    $"").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"НОК({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = (a * b) / НОД(a, b) = (" +
                    $"{textBoxFirstNumber.Text} * {textBoxSecondNumber.Text}) / {gCD:F2} = {lCM:F2}").SetFont(timesFont));
                pdfDocument.Close();
                ProcessStartInfo psi = new()
                {
                    FileName = "cmd",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                Process process = new() { StartInfo = psi };
                process.Start();
                process.StandardInput.WriteLine($"start {filePath}");
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Calculate()
        {
            try
            {
                lCM = gCD = 0;
                if (textBoxFirstNumber.Text != string.Empty && textBoxSecondNumber.Text != string.Empty)
                {
                    Convert.ToDouble(textBoxFirstNumber.Text);
                    Convert.ToDouble(textBoxSecondNumber.Text);
                    lCM = CalculateLCM(double.Parse(textBoxFirstNumber.Text), double.Parse(textBoxSecondNumber.Text));
                    gCD = CalculateGCD(double.Parse(textBoxFirstNumber.Text), double.Parse(textBoxSecondNumber.Text));
                    labelLCM.Text = $"Наименьшее общее кратное (НОК)\n{lCM:F2}";
                    labelGCD.Text = $"Наибольший общий делитель (НОД)\n{gCD:F2}";
                }
                else
                {
                    Clear();
                    MessageBox.Show("Введите числа!");
                }
            }
            catch
            {
                Clear();
                MessageBox.Show("Можно вводить только числа!");
            }
        }

        private void Clear()
        {
            textBoxFirstNumber.Text = textBoxSecondNumber.Text = string.Empty;
            labelLCM.Text = "Наименьшее общее кратное (НОК)";
            labelGCD.Text = "Наибольший общий делитель (НОД)";
        }

        private static double CalculateLCM(double a, double b)
        {
            double gcd = CalculateGCD(a, b);
            double lcm = Math.Abs(a * b) / gcd;
            return lcm;
        }

        private static double CalculateGCD(double a, double b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b > 0)
            {
                double temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private void textBoxFirstNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}