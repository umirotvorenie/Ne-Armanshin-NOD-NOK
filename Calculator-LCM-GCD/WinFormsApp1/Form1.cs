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
                doc.Content.Text = $"���������� ����������:\n������ �������� ����� = {textBoxFirstNumber.Text}\n������ �������� ����� = " +
                    $"{textBoxSecondNumber.Text}\n������ �������:\n������� ����� ���������� ����� ��������({textBoxFirstNumber.Text}, " +
                    $"{textBoxSecondNumber.Text})\n���({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = {gCD:F2}, ��� ��� " +
                    $"{textBoxFirstNumber.Text} � {textBoxSecondNumber.Text} ������� �� {gCD:F2}\n����� ����� ���������� ����� �������(" +
                    $"{textBoxFirstNumber.Text}, {textBoxSecondNumber.Text})\n���({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = " +
                    $"(a * b) / ���(a, b) = ({textBoxFirstNumber.Text} * {textBoxSecondNumber.Text}) / {gCD:F2} = {lCM:F2}";
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
                worksheet.Cells[1, 1] = "���������� ����������:";
                worksheet.Cells[2, 1] = $"������ �������� ����� = {textBoxFirstNumber.Text}";
                worksheet.Cells[3, 1] = $"������ �������� ����� = {textBoxSecondNumber.Text}";
                worksheet.Cells[4, 1] = "������ �������:";
                worksheet.Cells[5, 1] = $"������� ����� ���������� ����� ��������({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text})";
                worksheet.Cells[6, 1] = $"���({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = {gCD:F2}, ��� ��� {textBoxFirstNumber.Text}" +
                    $" � {textBoxSecondNumber.Text} ������� �� {gCD:F2}";
                worksheet.Cells[7, 1] = $"����� ����� ���������� ����� �������({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text})";
                worksheet.Cells[8, 1] = $"���({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = (a * b) / ���(a, b) = (" +
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
                pdfDoc.Add(new Paragraph("���������� ����������:").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"������ �������� ����� = {textBoxFirstNumber.Text}").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"������ �������� ����� = {textBoxSecondNumber.Text}").SetFont(timesFont));
                pdfDoc.Add(new Paragraph("������ �������:").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"������� ����� ���������� ����� ��������({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text})" +
                    $"").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"���({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = {gCD:F2}, ��� ��� {textBoxFirstNumber.Text} " +
                    $"� {textBoxSecondNumber.Text} ������� �� {gCD:F2}").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"����� ����� ���������� ����� �������({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text})" +
                    $"").SetFont(timesFont));
                pdfDoc.Add(new Paragraph($"���({textBoxFirstNumber.Text}, {textBoxSecondNumber.Text}) = (a * b) / ���(a, b) = (" +
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
                    labelLCM.Text = $"���������� ����� ������� (���)\n{lCM:F2}";
                    labelGCD.Text = $"���������� ����� �������� (���)\n{gCD:F2}";
                }
                else
                {
                    Clear();
                    MessageBox.Show("������� �����!");
                }
            }
            catch
            {
                Clear();
                MessageBox.Show("����� ������� ������ �����!");
            }
        }

        private void Clear()
        {
            textBoxFirstNumber.Text = textBoxSecondNumber.Text = string.Empty;
            labelLCM.Text = "���������� ����� ������� (���)";
            labelGCD.Text = "���������� ����� �������� (���)";
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