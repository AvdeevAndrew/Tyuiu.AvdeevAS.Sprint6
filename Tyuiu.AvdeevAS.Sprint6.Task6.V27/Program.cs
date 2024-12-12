using System;
using System.Windows.Forms;
using Tyuiu.AvdeevAS.Sprint6.Task6.V27.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task6.V27.App
{
    public partial class MainForm : Form
    {
        private TextBox textBoxIn;
        private TextBox textBoxOut;
        private Button loadFileButton;
        private Button processFileButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sprint 6 | Task 6 | Variant 27";
            this.Width = 800;
            this.Height = 600;

            Label inputLabel = new Label
            {
                Text = "Исходный текст:",
                Top = 20,
                Left = 20,
                Width = 200
            };
            this.Controls.Add(inputLabel);

            textBoxIn = new TextBox
            {
                Top = 50,
                Left = 20,
                Width = 740,
                Height = 200,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            this.Controls.Add(textBoxIn);

            Label outputLabel = new Label
            {
                Text = "Результат:",
                Top = 270,
                Left = 20,
                Width = 200
            };
            this.Controls.Add(outputLabel);

            textBoxOut = new TextBox
            {
                Top = 300,
                Left = 20,
                Width = 740,
                Height = 100,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            this.Controls.Add(textBoxOut);

            loadFileButton = new Button
            {
                Text = "Загрузить файл",
                Top = 420,
                Left = 20
            };
            loadFileButton.Click += LoadFileButton_Click;
            this.Controls.Add(loadFileButton);

            processFileButton = new Button
            {
                Text = "Обработать файл",
                Top = 420,
                Left = 150
            };
            processFileButton.Click += ProcessFileButton_Click;
            this.Controls.Add(processFileButton);
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string content = File.ReadAllText(openFileDialog.FileName);
                    textBoxIn.Text = content;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new DataService();
                string path = Path.GetTempFileName();

                // Сохраняем текст из textBoxIn во временный файл
                File.WriteAllText(path, textBoxIn.Text);

                // Обрабатываем файл
                string result = service.CollectTextFromFile(path);

                // Выводим результат в textBoxOut
                textBoxOut.Text = result;

                File.Delete(path); // Удаляем временный файл
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
