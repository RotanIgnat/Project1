using System;
using System.Linq;
using System.Windows.Forms;
using ModelBloger;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        private readonly Logic logic = new Logic();

        public Form1()
        {
            InitializeComponent();

            TableYouTubers.SelectionChanged += TableYouTubers_SelectionChanged;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSort.Click += btnSort_Click;

            LoadData();
        }

        // Загружаем список блогеров в таблицу
        private void LoadData()
        {
            TableYouTubers.DataSource = null;
            TableYouTubers.DataSource = logic.ReadTable().ToList();
            TableYouTubers.AutoGenerateColumns = true;
            TableYouTubers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Переименовываем колонки на русский
            RenameColumns();

            // Сразу выделяем первую строку
            if (TableYouTubers.Rows.Count > 0)
            {
                TableYouTubers.Rows[0].Selected = true;
            }

            // Обновляем список платформ в ComboBox
            UpdatePlatformList();
        }

        // Обновляем список платформ в ComboBox
        private void UpdatePlatformList()
        {
            // Запоминаем, что было выбрано раньше
            string oldChoice = cmbSortPlatform.SelectedItem as string;

            // Очищаем список
            cmbSortPlatform.Items.Clear();

            // Проходим по всем блогерам и добавляем платформы, которых ещё нет
            foreach (Blogger b in logic.ReadTable())
            {
                if (!cmbSortPlatform.Items.Contains(b.Platform))
                {
                    cmbSortPlatform.Items.Add(b.Platform);
                }
            }

            // Возвращаем прежний выбор, если он ещё есть в списке
            if (oldChoice != null && cmbSortPlatform.Items.Contains(oldChoice))
            {
                cmbSortPlatform.SelectedItem = oldChoice;
            }
            else if (cmbSortPlatform.Items.Count > 0)
            {
                cmbSortPlatform.SelectedIndex = 0;
            }
        }

        // Переименование заголовков колонок
        private void RenameColumns()
        {
            SetHeader("Id", "ID");
            SetHeader("Name", "Имя");
            SetHeader("Subscribers", "Подписчики");
            SetHeader("Platform", "Платформа");
            SetHeader("Topic", "Тема");
        }

        // Метод: если колонка есть — меняем заголовок
        private void SetHeader(string columnName, string headerText)
        {
            if (TableYouTubers.Columns[columnName] != null)
            {
                TableYouTubers.Columns[columnName].HeaderText = headerText;
            }
        }

        // Чистим поля ввода
        private void ClearFields()
        {
            textName.Clear();
            textBoxSubscribers.Clear();
            textBoxPlatform.Clear();
            textBoxTopic.Clear();
        }

        // Читаем поля и проверяем их. Если что-то не так — вернём false
        private bool TryReadFields(out string name, out int subs, out string platform, out string topic)
        {
            name = textName.Text.Trim();
            platform = textBoxPlatform.Text.Trim();
            topic = textBoxTopic.Text.Trim();
            subs = 0;

            if (name == "" || platform == "" || topic == "")
            {
                MessageBox.Show("Заполните все поля.");
                return false;
            }

            if (!int.TryParse(textBoxSubscribers.Text, out subs) || subs < 0)
            {
                MessageBox.Show("Подписчики должны быть целым числом (и не отрицательным).");
                return false;
            }

            return true;
        }

        // Клик по строке — данные летят в поля
        private void TableYouTubers_SelectionChanged(object sender, EventArgs e)
        {
            if (TableYouTubers.CurrentRow == null)
            {
                return;
            }

            Blogger b = TableYouTubers.CurrentRow.DataBoundItem as Blogger;
            if (b == null)
            {
                return;
            }

            textName.Text = b.Name;
            textBoxSubscribers.Text = b.Subscribers.ToString();
            textBoxPlatform.Text = b.Platform;
            textBoxTopic.Text = b.Topic;
        }

        // Добавить блогера
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name, platform, topic;
            int subs;

            if (!TryReadFields(out name, out subs, out platform, out topic))
            {
                return;
            }

            // Новый ID — на 1 больше максимального
            int newId = 1;
            if (logic.ReadTable().Count > 0)
            {
                newId = logic.ReadTable().Max(b => b.Id) + 1;
            }

            Blogger newBlogger = new Blogger(newId, name, subs, platform, topic);
            logic.AddBlogger(newBlogger);

            LoadData();
            ClearFields();
        }

        // Изменить выбранного блогера
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (TableYouTubers.CurrentRow == null)
            {
                MessageBox.Show("Сначала выберите блогера в таблице.");
                return;
            }

            Blogger selected = TableYouTubers.CurrentRow.DataBoundItem as Blogger;
            if (selected == null)
            {
                return;
            }

            string name, platform, topic;
            int subs;

            if (!TryReadFields(out name, out subs, out platform, out topic))
            {
                return;
            }

            logic.Change(name, selected.Id, subs, platform, topic);
            LoadData();
        }

        // Удалить выбранного блогера
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TableYouTubers.CurrentRow == null)
            {
                MessageBox.Show("Сначала выберите блогера в таблице.");
                return;
            }

            Blogger selected = TableYouTubers.CurrentRow.DataBoundItem as Blogger;
            if (selected == null)
            {
                return;
            }

            // Спрашиваем подтверждение
            string question = "Удалить блогера \"" + selected.Name + "\"?";
            DialogResult answer = MessageBox.Show(question, "Подтверждение",
                MessageBoxButtons.YesNo);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            logic.RemoveBlogger(selected.Id);
            LoadData();
            ClearFields();
        }

        // Сортировка по галочкам
        private void btnSort_Click(object sender, EventArgs e)
        {
            bool bySubs = chkSortSubs.Checked;
            bool byPlatform = chkPriorityPlatform.Checked;

            if (!bySubs && !byPlatform)
            {
                MessageBox.Show("Отметьте хотя бы одну галочку.");
                return;
            }

            // Если нужна платформа — берём её из ComboBox
            string platform = null;
            if (byPlatform)
            {
                platform = cmbSortPlatform.SelectedItem as string;
                if (platform == null || platform == "")
                {
                    MessageBox.Show("Выберите платформу из списка.");
                    return;
                }
            }

            // Три варианта сортировки
            if (bySubs && byPlatform)
            {
                logic.SortSubscribersWithPlatformPriority(platform);
            }
            else if (byPlatform)
            {
                logic.FilterByPlatform(platform);
            }
            else
            {
                logic.SortSubscribers();
            }

            LoadData();
        }
    }
}