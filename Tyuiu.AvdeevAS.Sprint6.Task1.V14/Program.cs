using System;
using System.Windows.Forms;
using Tyuiu.AvdeevAS.Sprint6.Task1.V14.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task1.V14.App
{
    public partial class MainForm : Form
    {
        private TextBox inputStart;
        private TextBox inputStop;
        private Button calculateButton;
        private TextBox resultTextBox;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sprint 6 | Task 1 | Variant 14";
            this.Width = 500;
            this.Height = 400;

            Label startLabel = new Label
            {
                Text = "Начальное значение:",
                Top = 20,
                Left = 20,
                Width = 150
            };
            this.Controls.Add(startLabel);

            inputStart = new TextBox
            {
                Top = 50,
                Left = 20,
                Width = 100
            };
            this.Controls.Add(inputStart);

            Label stopLabel = new Label
            {
                Text = "Конечное значение:",
                Top = 100,
                Left = 20,
                Width = 150
            };
            this.Controls.Add(stopLabel);

            inputStop = new TextBox
            {
                Top = 130,
                Left = 20,
                Width = 100
            };
            this.Controls.Add(inputStop);

            calculateButton = new Button
            {
                Text = "Выполнить",
                Top = 180,
                Left = 20
            };
            calculateButton.Click += CalculateButton_Click;
            this.Controls.Add(calculateButton);

            resultTextBox = new TextBox
            {
                Top = 230,
                Left = 20,
                Width = 400,
                Height = 100,
                Multiline = true,
                ReadOnly = true
            };
            this.Controls.Add(resultTextBox);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new DataService();
                int startValue = int.Parse(inputStart.Text);
                int stopValue = int.Parse(inputStop.Text);
                double[] results = service.GetMassFunction(startValue, stopValue);

                resultTextBox.Text = "Результаты:\r\n";
                for (int i = 0; i < results.Length; i++)
                {
                    resultTextBox.Text += $"x = {startValue + i}, f(x) = {results[i]}\r\n";
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
