namespace AddBookApp
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
            this.appPanel = new System.Windows.Forms.Panel();
            this.appLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.requestButton = new System.Windows.Forms.Button();
            this.appPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // appPanel
            // 
            this.appPanel.Controls.Add(this.appLabel);
            this.appPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.appPanel.Location = new System.Drawing.Point(0, 0);
            this.appPanel.Name = "appPanel";
            this.appPanel.Size = new System.Drawing.Size(629, 90);
            this.appPanel.TabIndex = 0;
            // 
            // appLabel
            // 
            this.appLabel.AutoSize = true;
            this.appLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.appLabel.Location = new System.Drawing.Point(127, 18);
            this.appLabel.Name = "appLabel";
            this.appLabel.Size = new System.Drawing.Size(51, 13);
            this.appLabel.TabIndex = 0;
            this.appLabel.Text = "appLabel";
            // 
            // addButton
            // 
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Location = new System.Drawing.Point(201, 269);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить книгу";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // requestButton
            // 
            this.requestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.requestButton.Location = new System.Drawing.Point(458, 268);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(75, 23);
            this.requestButton.TabIndex = 2;
            this.requestButton.Text = "Запросы";
            this.requestButton.UseVisualStyleBackColor = true;
            this.requestButton.Click += new System.EventHandler(this.requestButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 411);
            this.Controls.Add(this.requestButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.appPanel);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.appPanel.ResumeLayout(false);
            this.appPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel appPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.Label appLabel;
    }
}

