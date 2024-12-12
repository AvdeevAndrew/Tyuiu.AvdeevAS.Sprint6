using System;
using System.Windows.Forms;
using Tyuiu.AvdeevAS.Sprint6.Task4.V12.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task4.V12.App
{
    public partial class MainForm : Form
    {
        private TextBox resultTextBox;
        private Button calculateButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sprint 6 | Task 4 | Variant 12";
            this.Width = 800;
            this.Height = 600;

            Label label = new Label
            {
                Text = "Результаты:",
                Top = 20,
                Left = 20,
                Width = 100
            };
            this.Controls.Add(label);

            resultTextBox = new TextBox
            {
                Top = 50,
                Left = 20,
                Width = 300,
                Height = 400,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            this.Controls.Add(resultTextBox);

            calculateButton = new Button
            {
                Text = "Рассчитать",
                Top = 500,
                Left = 20
            };
            calculateButton.Click += CalculateButton_Click;
            this.Controls.Add(calculateButton);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new DataService();
                int startValue = -5;
                int stopValue = 5;

                double[] results = service.GetMassFunction(startValue, stopValue);
                resultTextBox.Clear();

                for (int i = 0; i < results.Length; i++)
                {
                    int x = startValue + i;
                    resultTextBox.AppendText($"x = {x}, f(x) = {results[i]}\r\n");
                }

                string filePath = service.SaveToFile(results, startValue);
                MessageBox.Show($"Результаты сохранены в файл: {filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}