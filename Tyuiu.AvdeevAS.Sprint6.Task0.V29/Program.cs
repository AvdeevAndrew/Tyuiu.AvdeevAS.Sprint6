using System;
using System.Windows.Forms;
using Tyuiu.AvdeevAS.Sprint6.Task0.V29.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task0.V29.App
{
    public partial class MainForm : Form
    {
        private TextBox inputX;
        private Button calculateButton;
        private Label resultLabel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sprint 6 | Task 0 | Variant 29";
            this.Width = 400;
            this.Height = 300;

            Label inputLabel = new Label
            {
                Text = "Введите значение X:",
                Top = 20,
                Left = 20,
                Width = 150
            };
            this.Controls.Add(inputLabel);

            inputX = new TextBox
            {
                Top = 50,
                Left = 20,
                Width = 100
            };
            this.Controls.Add(inputX);

            calculateButton = new Button
            {
                Text = "Выполнить",
                Top = 100,
                Left = 20
            };
            calculateButton.Click += CalculateButton_Click;
            this.Controls.Add(calculateButton);

            resultLabel = new Label
            {
                Text = "Результат:",
                Top = 150,
                Left = 20,
                Width = 300
            };
            this.Controls.Add(resultLabel);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new DataService();
                int x = int.Parse(inputX.Text);
                double result = service.Calculate(x);
                resultLabel.Text = $"Результат: {result}";
            }
            catch (DivideByZeroException ex)
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
