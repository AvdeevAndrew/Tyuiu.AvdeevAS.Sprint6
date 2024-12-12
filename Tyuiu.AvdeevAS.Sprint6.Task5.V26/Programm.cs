using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tyuiu.AvdeevAS.Sprint6.Task5.V26.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task5.V26.App
{
    public partial class MainForm : Form
    {
        private DataGridView dataGridView;
        private Button loadButton;
        private Label resultLabel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sprint 6 | Task 5 | Variant 26";
            this.Width = 800;
            this.Height = 600;

            dataGridView = new DataGridView
            {
                Top = 20,
                Left = 20,
                Width = 740,
                Height = 300,
                ColumnCount = 1,
                AllowUserToAddRows = false
            };
            dataGridView.Columns[0].Name = "Числа";
            this.Controls.Add(dataGridView);

            loadButton = new Button
            {
                Text = "Загрузить данные",
                Top = 350,
                Left = 20
            };
            loadButton.Click += LoadButton_Click;
            this.Controls.Add(loadButton);

            resultLabel = new Label
            {
                Text = "Результат: ",
                Top = 400,
                Left = 20,
                Width = 500
            };
            this.Controls.Add(resultLabel);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new DataService();
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    double[] data = service.LoadFromDataFile(openFileDialog.FileName);
                    dataGridView.Rows.Clear();

                    foreach (var number in data)
                    {
                        dataGridView.Rows.Add(number);
                    }

                    resultLabel.Text = $"Результат: {string.Join(", ", data)}";
                }
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
