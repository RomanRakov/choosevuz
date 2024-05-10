using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace choosevuz
{
    public partial class MainForm : Form
    {
        List<InfoUniversity> universities = new List<InfoUniversity>();
        public MainForm()
        {
            InitializeComponent();
            FillCitiesComboBox();
            comboBoxCities.SelectedIndexChanged += ComboBoxCities_SelectedIndexChanged;
        }

        private void FillCitiesComboBox()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "City.txt");

            if (File.Exists(filePath))
            {
                try
                {
                    string[] cities = File.ReadAllLines(filePath);

                    foreach (string city in cities)
                    {
                        comboBoxCities.Items.Add(city);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Файл с городами не найден.");
            }
        }

        private void ComboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            string universitiesFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Universities.txt");

            if (File.Exists(universitiesFilePath))
            {
                try
                {
                    string[] universities = File.ReadAllLines(universitiesFilePath);

                    string selectedCity = comboBoxCities.SelectedItem.ToString();

                    this.universities.Clear();

                    foreach (string universityInfo in universities)
                    {
                        string[] parts = universityInfo.Split(',');
                        if (parts.Length == 3)
                        {
                            if (parts[1].Trim() == selectedCity)
                            {
                                string id = parts[0];
                                InfoUniversity info = new InfoUniversity(parts[2], parts[0], parts[1]);
                                this.universities.Add(info);
                            }
                        }
                    }
                    TableUniversities.Rows.Clear();
                    TableUniversities.Columns.Clear();

                    TableUniversities.Columns.Add("Id", "Id");
                    TableUniversities.Columns.Add("Name", "Название");
                    TableUniversities.Columns.Add("City", "Город");

                    foreach (var info in this.universities)
                    {
                        TableUniversities.Rows.Add(info.Id, info.Name, info.City);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Файл с информацией о вузах не найден.");
            }
        }

        private void TableUniversities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow selectedRow = TableUniversities.Rows[e.RowIndex];

                string id = selectedRow.Cells["Id"].Value.ToString();
                string name = selectedRow.Cells["Name"].Value.ToString();
                string city = selectedRow.Cells["City"].Value.ToString();

                InfoForm infoForm = new InfoForm();
                infoForm.NameTextBox.Text = name;
                infoForm.CityTextBox.Text = city;

                string imagePath = Path.Combine("images", name + ".jpg");

                if (File.Exists(imagePath))
                {
                    infoForm.ImageUniversity.BackgroundImage = Image.FromFile(imagePath);
                }
                else
                {
                    MessageBox.Show("Фотография не найдена");
                }

                infoForm.Show();
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm(); 
            if (infoForm.ShowDialog() == DialogResult.OK)
            {
                string name = infoForm.NameTextBox.Text;
                string city = infoForm.CityTextBox.Text;

                string newId = Guid.NewGuid().ToString();

                InfoUniversity newUniversity = new InfoUniversity(newId, name, city);

                universities.Add(newUniversity);

                TableUniversities.DataSource = null;
                TableUniversities.DataSource = universities;
            }
        }
        private bool isDeleteMode = false;
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDeleteMode = true; 

            MessageBox.Show("Пожалуйста, выберите университет, который хотите удалить", "Удаление", MessageBoxButtons.OK);

        }
        private void TableUniversities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isDeleteMode) 
            {
                if (e.RowIndex >= 0) 
                {
                    DataGridViewRow selectedRow = TableUniversities.Rows[e.RowIndex]; 

                    string selectedId = selectedRow.Cells["Id"].Value.ToString(); 

                    InfoUniversity itemToRemove = universities.FirstOrDefault(item => item.Id == selectedId); 

                    if (itemToRemove != null)
                    {
                        universities.Remove(itemToRemove);

                        UpdateDataGridView(universities);
                        
                    }
                    foreach (var item in universities)
                    {
                        MessageBox.Show(item.Name);

                    }

                    isDeleteMode = false; 
                }
            }
        }
        private void UpdateDataGridView(List<InfoUniversity> infoItems)
        {
            TableUniversities.Rows.Clear();

            foreach (var item in infoItems)
            {
                TableUniversities.Rows.Add(item.Id, item.Name, item.City);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TableUniversities.SelectedCells.Count > 0)
            {
                int rowIndex = TableUniversities.SelectedCells[0].RowIndex;
                int columnIndex = TableUniversities.SelectedCells[0].ColumnIndex;

                DataGridViewCell selectedCell = TableUniversities.Rows[rowIndex].Cells[columnIndex];

                InfoForm infoForm = new InfoForm();
                if (infoForm.ShowDialog() == DialogResult.OK)
                {
                    selectedCell.Value = infoForm.NameTextBox.Text;
                }
            }
        }
    }
}
