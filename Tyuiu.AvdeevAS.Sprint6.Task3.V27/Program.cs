using System;
using System.Windows.Forms;
using Tyuiu.AvdeevAS.Sprint6.Task3.V27.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task3.V27.App
{
    public partial class MainForm : Form
    {
        private DataGridView matrixGridView;
        private Button sortButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sprint 6 | Task 3 | Variant 27";
            this.Width = 600;
            this.Height = 400;

            matrixGridView = new DataGridView
            {
                Top = 20,
                Left = 20,
                Width = 540,
                Height = 200,
                ColumnCount = 5,
                AllowUserToAddRows = false
            };
            for (int i = 0; i < 5; i++)
            {
                matrixGridView.Columns[i].Name = $"Столбец {i + 1}";
            }
            this.Controls.Add(matrixGridView);

            sortButton = new Button
            {
                Text = "Сортировать",
                Top = 240,
                Left = 20
            };
            sortButton.Click += SortButton_Click;
            this.Controls.Add(sortButton);

            LoadMatrix();
        }

        private void LoadMatrix()
        {
            int[,] matrix =
            {
                { 9, 13, -14, 23, 1 },
                { 15, -17, 21, 25, 23 },
                { -4, 29, -20, -10, 14 },
                { 27, 33, 12, 33, -12 },
                { 18, -9, -5, 6, 3 }
            };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                object[] row = new object[matrix.GetLength(1)];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }
                matrixGridView.Rows.Add(row);
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new DataService();
                int[,] matrix = new int[matrixGridView.RowCount, matrixGridView.ColumnCount];

                for (int i = 0; i < matrixGridView.RowCount; i++)
                {
                    for (int j = 0; j < matrixGridView.ColumnCount; j++)
                    {
                        matrix[i, j] = Convert.ToInt32(matrixGridView.Rows[i].Cells[j].Value);
                    }
                }

                int[,] sortedMatrix = service.Calculate(matrix);

                matrixGridView.Rows.Clear();
                for (int i = 0; i < sortedMatrix.GetLength(0); i++)
                {
                    object[] row = new object[sortedMatrix.GetLength(1)];
                    for (int j = 0; j < sortedMatrix.GetLength(1); j++)
                    {
                        row[j] = sortedMatrix[i, j];
                    }
                    matrixGridView.Rows.Add(row);
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
