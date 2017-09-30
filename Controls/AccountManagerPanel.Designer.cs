namespace AruaROSELoginManager.Controls
{
    partial class AccountManagerPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountManagerPanel));
            this._mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._addAccountPictureBox = new System.Windows.Forms.PictureBox();
            this._folderSearchTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._rosePathButton = new System.Windows.Forms.Button();
            this._rosePathLabel = new System.Windows.Forms.Label();
            this._rosePathTextBox = new System.Windows.Forms.TextBox();
            this._accountFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this._runAsAdminCheckBox = new System.Windows.Forms.CheckBox();
            this._mainTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._addAccountPictureBox)).BeginInit();
            this._folderSearchTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTableLayout
            // 
            this._mainTableLayout.BackColor = System.Drawing.Color.Transparent;
            this._mainTableLayout.ColumnCount = 3;
            this._mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this._mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this._mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this._mainTableLayout.Controls.Add(this._addAccountPictureBox, 2, 0);
            this._mainTableLayout.Controls.Add(this._folderSearchTableLayout, 1, 2);
            this._mainTableLayout.Controls.Add(this._accountFlowLayout, 1, 1);
            this._mainTableLayout.Controls.Add(this._runAsAdminCheckBox, 1, 3);
            this._mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTableLayout.Location = new System.Drawing.Point(0, 0);
            this._mainTableLayout.Name = "_mainTableLayout";
            this._mainTableLayout.RowCount = 4;
            this._mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this._mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this._mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this._mainTableLayout.Size = new System.Drawing.Size(700, 650);
            this._mainTableLayout.TabIndex = 6;
            // 
            // _addAccountPictureBox
            // 
            this._addAccountPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._addAccountPictureBox.BackColor = System.Drawing.Color.Transparent;
            this._addAccountPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("_addAccountPictureBox.Image")));
            this._addAccountPictureBox.Location = new System.Drawing.Point(613, 7);
            this._addAccountPictureBox.Name = "_addAccountPictureBox";
            this._addAccountPictureBox.Size = new System.Drawing.Size(50, 50);
            this._addAccountPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._addAccountPictureBox.TabIndex = 4;
            this._addAccountPictureBox.TabStop = false;
            this._addAccountPictureBox.Click += new System.EventHandler(this._addAccountPictureBox_Click);
            // 
            // _folderSearchTableLayout
            // 
            this._folderSearchTableLayout.ColumnCount = 3;
            this._folderSearchTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._folderSearchTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._folderSearchTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._folderSearchTableLayout.Controls.Add(this._rosePathButton, 2, 0);
            this._folderSearchTableLayout.Controls.Add(this._rosePathLabel, 0, 0);
            this._folderSearchTableLayout.Controls.Add(this._rosePathTextBox, 1, 0);
            this._folderSearchTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._folderSearchTableLayout.Location = new System.Drawing.Point(122, 585);
            this._folderSearchTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this._folderSearchTableLayout.Name = "_folderSearchTableLayout";
            this._folderSearchTableLayout.RowCount = 1;
            this._folderSearchTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._folderSearchTableLayout.Size = new System.Drawing.Size(455, 26);
            this._folderSearchTableLayout.TabIndex = 5;
            // 
            // _rosePathButton
            // 
            this._rosePathButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._rosePathButton.CausesValidation = false;
            this._rosePathButton.Location = new System.Drawing.Point(371, 0);
            this._rosePathButton.Margin = new System.Windows.Forms.Padding(0);
            this._rosePathButton.Name = "_rosePathButton";
            this._rosePathButton.Size = new System.Drawing.Size(75, 20);
            this._rosePathButton.TabIndex = 3;
            this._rosePathButton.Text = "Locate...";
            this._rosePathButton.UseVisualStyleBackColor = true;
            this._rosePathButton.Click += new System.EventHandler(this._rosePathButton_Click);
            // 
            // _rosePathLabel
            // 
            this._rosePathLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._rosePathLabel.AutoSize = true;
            this._rosePathLabel.BackColor = System.Drawing.Color.Transparent;
            this._rosePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rosePathLabel.Location = new System.Drawing.Point(13, 3);
            this._rosePathLabel.Margin = new System.Windows.Forms.Padding(3);
            this._rosePathLabel.Name = "_rosePathLabel";
            this._rosePathLabel.Size = new System.Drawing.Size(110, 13);
            this._rosePathLabel.TabIndex = 1;
            this._rosePathLabel.Text = "AruaROSE Folder:";
            // 
            // _rosePathTextBox
            // 
            this._rosePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._rosePathTextBox.Location = new System.Drawing.Point(136, 0);
            this._rosePathTextBox.Margin = new System.Windows.Forms.Padding(0);
            this._rosePathTextBox.Name = "_rosePathTextBox";
            this._rosePathTextBox.ReadOnly = true;
            this._rosePathTextBox.Size = new System.Drawing.Size(227, 20);
            this._rosePathTextBox.TabIndex = 2;
            // 
            // _accountFlowLayout
            // 
            this._accountFlowLayout.AutoScroll = true;
            this._accountFlowLayout.BackColor = System.Drawing.Color.LightGray;
            this._accountFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._accountFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._accountFlowLayout.Location = new System.Drawing.Point(122, 65);
            this._accountFlowLayout.Margin = new System.Windows.Forms.Padding(0);
            this._accountFlowLayout.Name = "_accountFlowLayout";
            this._accountFlowLayout.Size = new System.Drawing.Size(455, 520);
            this._accountFlowLayout.TabIndex = 6;
            this._accountFlowLayout.WrapContents = false;
            // 
            // _runAsAdminCheckBox
            // 
            this._runAsAdminCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._runAsAdminCheckBox.AutoSize = true;
            this._runAsAdminCheckBox.Checked = true;
            this._runAsAdminCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._runAsAdminCheckBox.Location = new System.Drawing.Point(303, 614);
            this._runAsAdminCheckBox.Name = "_runAsAdminCheckBox";
            this._runAsAdminCheckBox.Size = new System.Drawing.Size(92, 17);
            this._runAsAdminCheckBox.TabIndex = 7;
            this._runAsAdminCheckBox.Text = "Run as Admin";
            this._runAsAdminCheckBox.UseVisualStyleBackColor = true;
            // 
            // AccountManagerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this._mainTableLayout);
            this.DoubleBuffered = true;
            this.Name = "AccountManagerPanel";
            this.Size = new System.Drawing.Size(700, 650);
            this._mainTableLayout.ResumeLayout(false);
            this._mainTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._addAccountPictureBox)).EndInit();
            this._folderSearchTableLayout.ResumeLayout(false);
            this._folderSearchTableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTableLayout;
        private System.Windows.Forms.PictureBox _addAccountPictureBox;
        private System.Windows.Forms.TableLayoutPanel _folderSearchTableLayout;
        private System.Windows.Forms.Button _rosePathButton;
        private System.Windows.Forms.Label _rosePathLabel;
        private System.Windows.Forms.TextBox _rosePathTextBox;
        private System.Windows.Forms.FlowLayoutPanel _accountFlowLayout;
        private System.Windows.Forms.CheckBox _runAsAdminCheckBox;
    }
}
