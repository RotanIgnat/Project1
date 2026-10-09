namespace WindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            TableYouTubers = new System.Windows.Forms.DataGridView();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            btnAdd = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            btnDelete = new System.Windows.Forms.Button();
            btnSort = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            chkPriorityPlatform = new System.Windows.Forms.CheckBox();
            chkSortSubs = new System.Windows.Forms.CheckBox();
            panelFields = new System.Windows.Forms.Panel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            labelSortPlatform = new System.Windows.Forms.Label();
            labelSubscribers = new System.Windows.Forms.Label();
            labelPlatform = new System.Windows.Forms.Label();
            labelTopic = new System.Windows.Forms.Label();
            labelName = new System.Windows.Forms.Label();
            textName = new System.Windows.Forms.TextBox();
            textBoxSubscribers = new System.Windows.Forms.TextBox();
            textBoxPlatform = new System.Windows.Forms.TextBox();
            textBoxTopic = new System.Windows.Forms.TextBox();
            cmbSortPlatform = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TableYouTubers).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panelFields.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(TableYouTubers);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel3);
            splitContainer1.Panel2.Controls.Add(panelFields);
            splitContainer1.Size = new System.Drawing.Size(1089, 568);
            splitContainer1.SplitterDistance = 769;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // TableYouTubers
            // 
            TableYouTubers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TableYouTubers.Dock = System.Windows.Forms.DockStyle.Fill;
            TableYouTubers.Location = new System.Drawing.Point(0, 0);
            TableYouTubers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TableYouTubers.Name = "TableYouTubers";
            TableYouTubers.Size = new System.Drawing.Size(769, 568);
            TableYouTubers.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.50794F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.49206F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 1, 1);
            tableLayoutPanel3.Controls.Add(chkPriorityPlatform, 0, 1);
            tableLayoutPanel3.Controls.Add(chkSortSubs, 0, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(0, 263);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new System.Drawing.Size(315, 305);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(btnAdd, 0, 0);
            tableLayoutPanel4.Controls.Add(btnEdit, 0, 1);
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel4.Location = new System.Drawing.Point(118, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new System.Drawing.Size(194, 146);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            btnAdd.Location = new System.Drawing.Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(188, 67);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            btnEdit.Location = new System.Drawing.Point(3, 76);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(188, 67);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Изменить";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(btnDelete, 0, 0);
            tableLayoutPanel5.Controls.Add(btnSort, 0, 1);
            tableLayoutPanel5.Controls.Add(button1, 0, 2);
            tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel5.Location = new System.Drawing.Point(118, 155);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 3;
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.Size = new System.Drawing.Size(194, 147);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            btnDelete.Location = new System.Drawing.Point(3, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(188, 43);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSort
            // 
            btnSort.Dock = System.Windows.Forms.DockStyle.Fill;
            btnSort.Location = new System.Drawing.Point(3, 52);
            btnSort.Name = "btnSort";
            btnSort.Size = new System.Drawing.Size(188, 43);
            btnSort.TabIndex = 3;
            btnSort.Text = "Сортировать";
            btnSort.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Dock = System.Windows.Forms.DockStyle.Fill;
            button1.Location = new System.Drawing.Point(3, 101);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(188, 43);
            button1.TabIndex = 4;
            button1.Text = "Сумма подписчиков по выбранной платформе";
            button1.UseVisualStyleBackColor = true;
            // 
            // chkPriorityPlatform
            // 
            chkPriorityPlatform.Dock = System.Windows.Forms.DockStyle.Top;
            chkPriorityPlatform.Location = new System.Drawing.Point(3, 155);
            chkPriorityPlatform.Name = "chkPriorityPlatform";
            chkPriorityPlatform.Size = new System.Drawing.Size(109, 147);
            chkPriorityPlatform.TabIndex = 5;
            chkPriorityPlatform.Text = "Фильтрация по платформе";
            chkPriorityPlatform.UseVisualStyleBackColor = true;
            chkPriorityPlatform.CheckedChanged += chkPriorityPlatform_CheckedChanged;
            // 
            // chkSortSubs
            // 
            chkSortSubs.Location = new System.Drawing.Point(3, 3);
            chkSortSubs.Name = "chkSortSubs";
            chkSortSubs.Size = new System.Drawing.Size(109, 146);
            chkSortSubs.TabIndex = 4;
            chkSortSubs.Text = "Сортировка по подписчикам";
            chkSortSubs.UseVisualStyleBackColor = true;
            // 
            // panelFields
            // 
            panelFields.Controls.Add(tableLayoutPanel1);
            panelFields.Dock = System.Windows.Forms.DockStyle.Top;
            panelFields.Location = new System.Drawing.Point(0, 0);
            panelFields.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelFields.Name = "panelFields";
            panelFields.Size = new System.Drawing.Size(315, 263);
            panelFields.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.1428566F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.8571434F));
            tableLayoutPanel1.Controls.Add(labelSortPlatform, 0, 4);
            tableLayoutPanel1.Controls.Add(labelSubscribers, 0, 1);
            tableLayoutPanel1.Controls.Add(labelPlatform, 0, 2);
            tableLayoutPanel1.Controls.Add(labelTopic, 0, 3);
            tableLayoutPanel1.Controls.Add(labelName, 0, 0);
            tableLayoutPanel1.Controls.Add(textName, 1, 0);
            tableLayoutPanel1.Controls.Add(textBoxSubscribers, 1, 1);
            tableLayoutPanel1.Controls.Add(textBoxPlatform, 1, 2);
            tableLayoutPanel1.Controls.Add(textBoxTopic, 1, 3);
            tableLayoutPanel1.Controls.Add(cmbSortPlatform, 1, 4);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(315, 263);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelSortPlatform
            // 
            labelSortPlatform.AutoSize = true;
            labelSortPlatform.Dock = System.Windows.Forms.DockStyle.Fill;
            labelSortPlatform.Location = new System.Drawing.Point(4, 208);
            labelSortPlatform.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSortPlatform.Name = "labelSortPlatform";
            labelSortPlatform.Size = new System.Drawing.Size(109, 55);
            labelSortPlatform.TabIndex = 8;
            labelSortPlatform.Text = "Платформа для сортировки";
            // 
            // labelSubscribers
            // 
            labelSubscribers.AutoSize = true;
            labelSubscribers.Dock = System.Windows.Forms.DockStyle.Fill;
            labelSubscribers.Location = new System.Drawing.Point(4, 52);
            labelSubscribers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSubscribers.Name = "labelSubscribers";
            labelSubscribers.Size = new System.Drawing.Size(109, 52);
            labelSubscribers.TabIndex = 1;
            labelSubscribers.Text = "Подписчики";
            // 
            // labelPlatform
            // 
            labelPlatform.AutoSize = true;
            labelPlatform.Dock = System.Windows.Forms.DockStyle.Fill;
            labelPlatform.Location = new System.Drawing.Point(4, 104);
            labelPlatform.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelPlatform.Name = "labelPlatform";
            labelPlatform.Size = new System.Drawing.Size(109, 52);
            labelPlatform.TabIndex = 2;
            labelPlatform.Text = "Платформа";
            // 
            // labelTopic
            // 
            labelTopic.AutoSize = true;
            labelTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            labelTopic.Location = new System.Drawing.Point(4, 156);
            labelTopic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelTopic.Name = "labelTopic";
            labelTopic.Size = new System.Drawing.Size(109, 52);
            labelTopic.TabIndex = 3;
            labelTopic.Text = "Тема";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            labelName.Location = new System.Drawing.Point(4, 0);
            labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelName.Name = "labelName";
            labelName.Size = new System.Drawing.Size(109, 52);
            labelName.TabIndex = 0;
            labelName.Text = "Имя";
            // 
            // textName
            // 
            textName.Dock = System.Windows.Forms.DockStyle.Fill;
            textName.Location = new System.Drawing.Point(120, 3);
            textName.Name = "textName";
            textName.Size = new System.Drawing.Size(192, 23);
            textName.TabIndex = 4;
            // 
            // textBoxSubscribers
            // 
            textBoxSubscribers.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxSubscribers.Location = new System.Drawing.Point(120, 55);
            textBoxSubscribers.Name = "textBoxSubscribers";
            textBoxSubscribers.Size = new System.Drawing.Size(192, 23);
            textBoxSubscribers.TabIndex = 5;
            // 
            // textBoxPlatform
            // 
            textBoxPlatform.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxPlatform.Location = new System.Drawing.Point(120, 107);
            textBoxPlatform.Name = "textBoxPlatform";
            textBoxPlatform.Size = new System.Drawing.Size(192, 23);
            textBoxPlatform.TabIndex = 6;
            // 
            // textBoxTopic
            // 
            textBoxTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxTopic.Location = new System.Drawing.Point(120, 159);
            textBoxTopic.Name = "textBoxTopic";
            textBoxTopic.Size = new System.Drawing.Size(192, 23);
            textBoxTopic.TabIndex = 7;
            // 
            // cmbSortPlatform
            // 
            cmbSortPlatform.Dock = System.Windows.Forms.DockStyle.Fill;
            cmbSortPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSortPlatform.FormattingEnabled = true;
            cmbSortPlatform.Items.AddRange(new object[] { "YouTube", "Twitch", "Telegram" });
            cmbSortPlatform.Location = new System.Drawing.Point(120, 211);
            cmbSortPlatform.Name = "cmbSortPlatform";
            cmbSortPlatform.Size = new System.Drawing.Size(192, 23);
            cmbSortPlatform.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1089, 568);
            Controls.Add(splitContainer1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Блогеры";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TableYouTubers).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            panelFields.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView TableYouTubers;
        private System.Windows.Forms.Panel panelFields;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelSubscribers;
        private System.Windows.Forms.Label labelPlatform;
        private System.Windows.Forms.Label labelTopic;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textBoxSubscribers;
        private System.Windows.Forms.TextBox textBoxPlatform;
        private System.Windows.Forms.TextBox textBoxTopic;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.CheckBox chkSortSubs;
        private System.Windows.Forms.CheckBox chkPriorityPlatform;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelSortPlatform;
        private System.Windows.Forms.ComboBox cmbSortPlatform;
        private System.Windows.Forms.Button button1;
    }
}