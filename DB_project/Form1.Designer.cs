namespace DB_project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableDataGridView = new System.Windows.Forms.DataGridView();
            this.CreateButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.ViewButton = new System.Windows.Forms.Button();
            this.SelectTableComboBox = new System.Windows.Forms.ComboBox();
            this.ColumnContainer = new System.Windows.Forms.ComboBox();
            this.SelectTableLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MainTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableDataGridView
            // 
            this.tableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDataGridView.Location = new System.Drawing.Point(151, 221);
            this.tableDataGridView.Name = "tableDataGridView";
            this.tableDataGridView.ReadOnly = true;
            this.tableDataGridView.Size = new System.Drawing.Size(655, 236);
            this.tableDataGridView.TabIndex = 0;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(12, 60);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(133, 42);
            this.CreateButton.TabIndex = 1;
            this.CreateButton.Text = "Добавить запись";
            this.CreateButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Редактировать запись";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 156);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 42);
            this.button3.TabIndex = 3;
            this.button3.Text = "Удалить запись";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(12, 12);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(133, 42);
            this.SelectButton.TabIndex = 4;
            this.SelectButton.Text = "Посмотреть данные";
            this.SelectButton.UseVisualStyleBackColor = true;
            // 
            // ViewButton
            // 
            this.ViewButton.Location = new System.Drawing.Point(12, 221);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(133, 42);
            this.ViewButton.TabIndex = 8;
            this.ViewButton.Text = "Отчеты";
            this.ViewButton.UseVisualStyleBackColor = true;
            // 
            // SelectTableComboBox
            // 
            this.SelectTableComboBox.FormattingEnabled = true;
            this.SelectTableComboBox.Location = new System.Drawing.Point(271, 57);
            this.SelectTableComboBox.Name = "SelectTableComboBox";
            this.SelectTableComboBox.Size = new System.Drawing.Size(184, 21);
            this.SelectTableComboBox.TabIndex = 10;
            this.SelectTableComboBox.Visible = false;
            // 
            // ColumnContainer
            // 
            this.ColumnContainer.FormattingEnabled = true;
            this.ColumnContainer.Location = new System.Drawing.Point(587, 57);
            this.ColumnContainer.Name = "ColumnContainer";
            this.ColumnContainer.Size = new System.Drawing.Size(184, 21);
            this.ColumnContainer.TabIndex = 11;
            this.ColumnContainer.Visible = false;
            // 
            // SelectTableLabel
            // 
            this.SelectTableLabel.Location = new System.Drawing.Point(151, 60);
            this.SelectTableLabel.Name = "SelectTableLabel";
            this.SelectTableLabel.Size = new System.Drawing.Size(114, 20);
            this.SelectTableLabel.TabIndex = 12;
            this.SelectTableLabel.Text = "Выберите таблицу:";
            this.SelectTableLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(467, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = " Выберите столбец:";
            this.label2.Visible = false;
            // 
            // MainTitle
            // 
            this.MainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainTitle.Location = new System.Drawing.Point(271, 48);
            this.MainTitle.Name = "MainTitle";
            this.MainTitle.Size = new System.Drawing.Size(375, 88);
            this.MainTitle.TabIndex = 14;
            this.MainTitle.Text = "Psql_GUI";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectTableLabel);
            this.Controls.Add(this.ColumnContainer);
            this.Controls.Add(this.SelectTableComboBox);
            this.Controls.Add(this.ViewButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.tableDataGridView);
            this.Name = "Form1";
            this.Text = "Psql_GUI";
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label MainTitle;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label SelectTableLabel;

        private System.Windows.Forms.ComboBox SelectTableComboBox;
        private System.Windows.Forms.ComboBox ColumnContainer;

        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button ViewButton;

        private System.Windows.Forms.DataGridView tableDataGridView;

        #endregion
    }
}