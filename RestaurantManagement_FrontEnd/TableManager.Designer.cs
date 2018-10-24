namespace RestaurantManagement_FrontEnd
{
    partial class TableManagerForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this._billView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this._totalPriceLabel = new System.Windows.Forms.Label();
            this._totalPriceTextBox = new System.Windows.Forms.TextBox();
            this._switchTableButton = new System.Windows.Forms.Button();
            this._switchTableComboBox = new System.Windows.Forms.ComboBox();
            this._discountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this._payButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this._countNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._addOrderButton = new System.Windows.Forms.Button();
            this._foodComboBox = new System.Windows.Forms.ComboBox();
            this._categoryComboBox = new System.Windows.Forms.ComboBox();
            this._tableManagerFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._discountNumericUpDown)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._countNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountInfoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(665, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountInfoToolStripMenuItem
            // 
            this.accountInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.accountInfoToolStripMenuItem.Name = "accountInfoToolStripMenuItem";
            this.accountInfoToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.accountInfoToolStripMenuItem.Text = "Account Info";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._billView);
            this.panel2.Location = new System.Drawing.Point(297, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 226);
            this.panel2.TabIndex = 2;
            // 
            // _billView
            // 
            this._billView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this._billView.GridLines = true;
            this._billView.Location = new System.Drawing.Point(6, 3);
            this._billView.Name = "_billView";
            this._billView.Size = new System.Drawing.Size(350, 220);
            this._billView.TabIndex = 0;
            this._billView.UseCompatibleStateImageBehavior = false;
            this._billView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Food Name";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Count";
            this.columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Total Price";
            this.columnHeader4.Width = 77;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._totalPriceLabel);
            this.panel3.Controls.Add(this._totalPriceTextBox);
            this.panel3.Controls.Add(this._switchTableButton);
            this.panel3.Controls.Add(this._switchTableComboBox);
            this.panel3.Controls.Add(this._discountNumericUpDown);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this._payButton);
            this.panel3.Location = new System.Drawing.Point(297, 316);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 107);
            this.panel3.TabIndex = 1;
            // 
            // _totalPriceLabel
            // 
            this._totalPriceLabel.AutoSize = true;
            this._totalPriceLabel.Location = new System.Drawing.Point(163, 8);
            this._totalPriceLabel.Name = "_totalPriceLabel";
            this._totalPriceLabel.Size = new System.Drawing.Size(55, 13);
            this._totalPriceLabel.TabIndex = 8;
            this._totalPriceLabel.Text = "TotalPrice";
            // 
            // _totalPriceTextBox
            // 
            this._totalPriceTextBox.Location = new System.Drawing.Point(162, 28);
            this._totalPriceTextBox.Name = "_totalPriceTextBox";
            this._totalPriceTextBox.ReadOnly = true;
            this._totalPriceTextBox.Size = new System.Drawing.Size(100, 20);
            this._totalPriceTextBox.TabIndex = 7;
            this._totalPriceTextBox.Text = "0";
            this._totalPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _switchTableButton
            // 
            this._switchTableButton.Location = new System.Drawing.Point(3, 3);
            this._switchTableButton.Name = "_switchTableButton";
            this._switchTableButton.Size = new System.Drawing.Size(69, 45);
            this._switchTableButton.TabIndex = 6;
            this._switchTableButton.Text = "Switch Table";
            this._switchTableButton.UseVisualStyleBackColor = true;
            this._switchTableButton.Click += new System.EventHandler(this._switchTableButton_Click);
            // 
            // _switchTableComboBox
            // 
            this._switchTableComboBox.FormattingEnabled = true;
            this._switchTableComboBox.Location = new System.Drawing.Point(0, 54);
            this._switchTableComboBox.Name = "_switchTableComboBox";
            this._switchTableComboBox.Size = new System.Drawing.Size(72, 21);
            this._switchTableComboBox.TabIndex = 4;
            // 
            // _discountNumericUpDown
            // 
            this._discountNumericUpDown.Location = new System.Drawing.Point(87, 54);
            this._discountNumericUpDown.Name = "_discountNumericUpDown";
            this._discountNumericUpDown.Size = new System.Drawing.Size(42, 20);
            this._discountNumericUpDown.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(87, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 45);
            this.button3.TabIndex = 5;
            this.button3.Text = "Discount";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // _payButton
            // 
            this._payButton.Location = new System.Drawing.Point(284, 3);
            this._payButton.Name = "_payButton";
            this._payButton.Size = new System.Drawing.Size(69, 45);
            this._payButton.TabIndex = 4;
            this._payButton.Text = "Payment";
            this._payButton.UseVisualStyleBackColor = true;
            this._payButton.Click += new System.EventHandler(this._payButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this._countNumericUpDown);
            this.panel4.Controls.Add(this._addOrderButton);
            this.panel4.Controls.Add(this._foodComboBox);
            this.panel4.Controls.Add(this._categoryComboBox);
            this.panel4.Location = new System.Drawing.Point(303, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(350, 50);
            this.panel4.TabIndex = 2;
            // 
            // _countNumericUpDown
            // 
            this._countNumericUpDown.Location = new System.Drawing.Point(279, 18);
            this._countNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this._countNumericUpDown.Name = "_countNumericUpDown";
            this._countNumericUpDown.Size = new System.Drawing.Size(42, 20);
            this._countNumericUpDown.TabIndex = 3;
            // 
            // _addOrderButton
            // 
            this._addOrderButton.Location = new System.Drawing.Point(195, 4);
            this._addOrderButton.Name = "_addOrderButton";
            this._addOrderButton.Size = new System.Drawing.Size(69, 45);
            this._addOrderButton.TabIndex = 2;
            this._addOrderButton.Text = "Add Order";
            this._addOrderButton.UseVisualStyleBackColor = true;
            this._addOrderButton.Click += new System.EventHandler(this._addOrderButton_Click);
            // 
            // _foodComboBox
            // 
            this._foodComboBox.FormattingEnabled = true;
            this._foodComboBox.Location = new System.Drawing.Point(4, 26);
            this._foodComboBox.Name = "_foodComboBox";
            this._foodComboBox.Size = new System.Drawing.Size(185, 21);
            this._foodComboBox.TabIndex = 1;
            // 
            // _categoryComboBox
            // 
            this._categoryComboBox.FormattingEnabled = true;
            this._categoryComboBox.Location = new System.Drawing.Point(4, 4);
            this._categoryComboBox.Name = "_categoryComboBox";
            this._categoryComboBox.Size = new System.Drawing.Size(185, 21);
            this._categoryComboBox.TabIndex = 0;
            this._categoryComboBox.SelectedIndexChanged += new System.EventHandler(this._categoryComboBox_SelectedIndexChanged);
            // 
            // _tableManagerFlowLayoutPanel
            // 
            this._tableManagerFlowLayoutPanel.Location = new System.Drawing.Point(12, 32);
            this._tableManagerFlowLayoutPanel.Name = "_tableManagerFlowLayoutPanel";
            this._tableManagerFlowLayoutPanel.Size = new System.Drawing.Size(279, 391);
            this._tableManagerFlowLayoutPanel.TabIndex = 3;
            // 
            // TableManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 434);
            this.Controls.Add(this._tableManagerFlowLayoutPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "TableManagerForm";
            this.Text = "TableManager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._discountNumericUpDown)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._countNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountInfoToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView _billView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button _payButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown _countNumericUpDown;
        private System.Windows.Forms.Button _addOrderButton;
        private System.Windows.Forms.ComboBox _foodComboBox;
        private System.Windows.Forms.ComboBox _categoryComboBox;
        private System.Windows.Forms.FlowLayoutPanel _tableManagerFlowLayoutPanel;
        private System.Windows.Forms.Button _switchTableButton;
        private System.Windows.Forms.ComboBox _switchTableComboBox;
        private System.Windows.Forms.NumericUpDown _discountNumericUpDown;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label _totalPriceLabel;
        private System.Windows.Forms.TextBox _totalPriceTextBox;
    }
}