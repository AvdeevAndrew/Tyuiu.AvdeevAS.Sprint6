using System;
using System.Windows.Forms;
using Tyuiu.AvdeevAS.Sprint6.Task2.V10.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task2.V10.App
{
    public partial class MainForm : Form
    {
        private TextBox inputStart;
        private TextBox inputStop;
        private Button calculateButton;
        private DataGridView resultGridView;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sprint 6 | Task 2 | Variant 10";
            this.Width = 600;
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

            resultGridView = new DataGridView
            {
                Top = 230,
                Left = 20,
                Width = 540,
                Height = 120,
                ColumnCount = 2
            };
            resultGridView.Columns[0].Name = "x";
            resultGridView.Columns[1].Name = "f(x)";
            this.Controls.Add(resultGridView);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new DataService();
                int startValue = int.Parse(inputStart.Text);
                int stopValue = int.Parse(inputStop.Text);
                double[] results = service.GetMassFunction(startValue, stopValue);

                resultGridView.Rows.Clear();
                for (int i = 0; i < results.Length; i++)
                {
                    resultGridView.Rows.Add(startValue + i, results[i]);
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
