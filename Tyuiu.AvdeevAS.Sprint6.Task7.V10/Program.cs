using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tyuiu.AvdeevAS.Sprint6.Task7.V10.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task7.V10.App
{
    public partial class MainForm : Form
    {
        private DataGridView dataGridViewIn;
        private DataGridView dataGridViewOut;
        private Button loadFileButton;
        private Button saveFileButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sprint 6 | Task 7 | Variant 10";
            this.Width = 800;
            this.Height = 600;

            dataGridViewIn = new DataGridView
            {
                Top = 20,
                Left = 20,
                Width = 740,
                Height = 200,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dataGridViewIn);

            dataGridViewOut = new DataGridView
            {
                Top = 250,
                Left = 20,
                Width = 740,
                Height = 200,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dataGridViewOut);

            loadFileButton = new Button
            {
                Text = "Загрузить файл",
                Top = 480,
                Left = 20
            };
            loadFileButton.Click += LoadFileButton_Click;
            this.Controls.Add(loadFileButton);

            saveFileButton = new Button
            {
                Text = "Сохранить результат",
                Top = 480,
                Left = 150
            };
            saveFileButton.Click += SaveFileButton_Click;
            this.Controls.Add(saveFileButton);
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new DataService();
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int[,] matrix = service.GetMatrix(openFileDialog.FileName);

                    dataGridViewIn.Columns.Clear();
                    dataGridViewIn.Rows.Clear();
                    int rows = matrix.GetLength(0);
                    int cols = matrix.GetLength(1);

                    for (int j = 0; j < cols; j++)
                    {
                        dataGridViewIn.Columns.Add(j.ToString(), j.ToString());
                        dataGridViewOut.Columns.Add(j.ToString(), j.ToString());
                    }

                    for (int i = 0; i < rows; i++)
                    {
                        var rowIn = new object[cols];
                        var rowOut = new object[cols];
                        for (int j = 0; j < cols; j++)
                        {
                            rowIn[j] = matrix[i, j];
                            rowOut[j] = matrix[i, j];
                        }
                        dataGridViewIn.Rows.Add(rowIn);
                        dataGridViewOut.Rows.Add(rowOut);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (DataGridViewRow row in dataGridViewOut.Rows)
                        {
                            var values = row.Cells.Cast<DataGridViewCell>()
                                .Select(cell => cell.Value?.ToString() ?? "")
                                .ToArray();
                            writer.WriteLine(string.Join(",", values));
                        }
                    }

                    MessageBox.Show("Результат сохранён успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
