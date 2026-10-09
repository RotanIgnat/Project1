using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ModelBloger;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        private readonly Logic logic = new Logic();

        /// <summary>
        /// Конструктор формы: подписка на события и первичная загрузка данных.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        public Form1()
        {
            InitializeComponent();

            TableYouTubers.SelectionChanged += TableYouTubers_SelectionChanged;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSort.Click += btnSort_Click;
            button1.Click += button1_Click;

            LoadData();
        }

        /// <summary>
        /// Загружает список блогеров в таблицу с учётом текущего фильтра и обновляет ComboBox.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private void LoadData()
        {
            TableYouTubers.DataSource = null;
            TableYouTubers.DataSource = logic.ReadTable().ToList();
            TableYouTubers.AutoGenerateColumns = true;
            TableYouTubers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            RenameColumns();

            if (TableYouTubers.Rows.Count > 0)
            {
                TableYouTubers.Rows[0].Selected = true;
            }
            else
            {
                ClearFields();
            }

            UpdatePlatformList();
        }

        /// <summary>
        /// Обновляет список платформ в ComboBox по полному списку блогеров.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private void UpdatePlatformList()
        {
            string oldChoice = cmbSortPlatform.SelectedItem as string;

            cmbSortPlatform.Items.Clear();

            foreach (Blogger b in logic.GetAllBloggers())
            {
                if (!cmbSortPlatform.Items.Contains(b.Platform))
                {
                    cmbSortPlatform.Items.Add(b.Platform);
                }
            }

            if (oldChoice != null && cmbSortPlatform.Items.Contains(oldChoice))
            {
                cmbSortPlatform.SelectedItem = oldChoice;
            }
            else if (cmbSortPlatform.Items.Count > 0)
            {
                cmbSortPlatform.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Переименовывает заголовки колонок таблицы на русские.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private void RenameColumns()
        {
            SetHeader("Id", "ID");
            SetHeader("Name", "Имя");
            SetHeader("Subscribers", "Подписчики");
            SetHeader("Platform", "Платформа");
            SetHeader("Topic", "Тема");
        }

        /// <summary>
        /// Меняет заголовок указанной колонки, если она существует.
        /// </summary>
        /// <param name="columnName">Имя колонки.</param>
        /// <param name="headerText">Новый заголовок.</param>
        /// <returns>Ничего не возвращает.</returns>
        private void SetHeader(string columnName, string headerText)
        {
            if (TableYouTubers.Columns[columnName] != null)
            {
                TableYouTubers.Columns[columnName].HeaderText = headerText;
            }
        }

        /// <summary>
        /// Очищает все поля ввода на форме.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        private void ClearFields()
        {
            textName.Clear();
            textBoxSubscribers.Clear();
            textBoxPlatform.Clear();
            textBoxTopic.Clear();
        }

        /// <summary>
        /// Читает и проверяет поля ввода. Возвращает false при ошибке.
        /// </summary>
        /// <param name="name">Имя блогера.</param>
        /// <param name="subs">Количество подписчиков.</param>
        /// <param name="platform">Платформа.</param>
        /// <param name="topic">Тематика.</param>
        /// <returns>true — если все поля корректны, иначе false.</returns>
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

        /// <summary>
        /// Обработчик смены выделенной строки: переносит данные блогера в поля ввода.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        /// <returns>Ничего не возвращает.</returns>
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

        /// <summary>
        /// Добавляет нового блогера с автоматически сгенерированным ID.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        /// <returns>Ничего не возвращает.</returns>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name, platform, topic;
            int subs;

            if (!TryReadFields(out name, out subs, out platform, out topic))
            {
                return;
            }

            int newId = 1;
            if (logic.GetAllBloggers().Count > 0)
            {
                newId = logic.GetAllBloggers().Max(b => b.Id) + 1;
            }

            platform = NormalizePlatform(platform);

            Blogger newBlogger = new Blogger(newId, name, subs, platform, topic);
            logic.AddBlogger(newBlogger);

            LoadData();
            ClearFields();
        }

        /// <summary>
        /// Изменяет выбранного в таблице блогера.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        /// <returns>Ничего не возвращает.</returns>
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

            platform = NormalizePlatform(platform);

            logic.Change(name, selected.Id, subs, platform, topic);
            LoadData();
        }

        /// <summary>
        /// Удаляет выбранного блогера после подтверждения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        /// <returns>Ничего не возвращает.</returns>
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

        /// <summary>
        /// Применяет сортировку или фильтрацию в зависимости от состояния галочек.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        /// <returns>Ничего не возвращает.</returns>
        private void btnSort_Click(object sender, EventArgs e)
        {
            bool bySubs = chkSortSubs.Checked;
            bool byPlatform = chkPriorityPlatform.Checked;

            if (!bySubs && !byPlatform)
            {
                MessageBox.Show("Отметьте хотя бы одну галочку.");
                return;
            }

            if (bySubs && byPlatform)
            {
                string platform = cmbSortPlatform.SelectedItem as string;
                if (string.IsNullOrWhiteSpace(platform))
                {
                    MessageBox.Show("Выберите платформу из списка.");
                    return;
                }

                logic.SortSubscribersWithPlatformPriority(platform);
                LoadData();
            }
            else if (byPlatform)
            {
                string platform = cmbSortPlatform.SelectedItem as string;
                if (string.IsNullOrWhiteSpace(platform))
                {
                    MessageBox.Show("Выберите платформу из списка.");
                    return;
                }

                logic.FilterByPlatform(platform);
                LoadData();
            }
            else
            {
                logic.SortSubscribers();
                LoadData();
            }
        }

        /// <summary>
        /// Показывает сумму подписчиков для платформы, выбранной в ComboBox.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Параметры события.</param>
        /// <returns>Ничего не возвращает.</returns>
        private void button1_Click(object sender, EventArgs e)
        {
            string platform = cmbSortPlatform.SelectedItem as string;

            if (platform == null || platform == "")
            {
                MessageBox.Show("Выберите платформу из списка.");
                return;
            }

            long total = logic.GetSubscribersByPlatform(platform);

            MessageBox.Show(
                "Платформа \"" + platform + "\": " + total.ToString("N0") + " подписчиков всего.",
                "Сумма подписчиков",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Возвращает "правильное" написание платформы.
        /// Если такая платформа уже есть у других блогеров — возвращает её написание.
        /// Иначе возвращает строку как есть.
        /// </summary>
        /// <param name="input">Строка, введённая пользователем.</param>
        /// <returns>Нормализованное название платформы или исходную строку без пробелов.</returns>
        private string NormalizePlatform(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            string trimmed = input.Trim();

            foreach (Blogger b in logic.GetAllBloggers())
            {
                if (b.Platform.Equals(trimmed, StringComparison.OrdinalIgnoreCase))
                {
                    return b.Platform;
                }
            }

            return trimmed;
        }

        private void chkPriorityPlatform_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}