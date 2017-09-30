namespace AruaROSELoginManager.Controls
{
    partial class AccountDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountDisplay));
            this._accountDisplayTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._emblemPicutreBox = new System.Windows.Forms.PictureBox();
            this._actionButtonTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._moveUpArrow = new System.Windows.Forms.PictureBox();
            this._moveDownArrow = new System.Windows.Forms.PictureBox();
            this._deleteButton = new System.Windows.Forms.PictureBox();
            this._accountInfoTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._accountNameLabel = new System.Windows.Forms.Label();
            this._passwordInfo = new System.Windows.Forms.Label();
            this._loginButton = new System.Windows.Forms.Button();
            this._accountDisplayTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._emblemPicutreBox)).BeginInit();
            this._actionButtonTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._moveUpArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._moveDownArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._deleteButton)).BeginInit();
            this._accountInfoTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // _accountDisplayTableLayout
            // 
            this._accountDisplayTableLayout.BackColor = System.Drawing.Color.Transparent;
            this._accountDisplayTableLayout.ColumnCount = 4;
            this._accountDisplayTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._accountDisplayTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this._accountDisplayTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this._accountDisplayTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._accountDisplayTableLayout.Controls.Add(this._emblemPicutreBox, 0, 0);
            this._accountDisplayTableLayout.Controls.Add(this._actionButtonTableLayout, 1, 0);
            this._accountDisplayTableLayout.Controls.Add(this._accountInfoTableLayout, 2, 0);
            this._accountDisplayTableLayout.Controls.Add(this._loginButton, 3, 0);
            this._accountDisplayTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._accountDisplayTableLayout.Location = new System.Drawing.Point(0, 0);
            this._accountDisplayTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this._accountDisplayTableLayout.Name = "_accountDisplayTableLayout";
            this._accountDisplayTableLayout.RowCount = 1;
            this._accountDisplayTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._accountDisplayTableLayout.Size = new System.Drawing.Size(427, 100);
            this._accountDisplayTableLayout.TabIndex = 0;
            // 
            // _emblemPicutreBox
            // 
            this._emblemPicutreBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._emblemPicutreBox.Location = new System.Drawing.Point(15, 12);
            this._emblemPicutreBox.Name = "_emblemPicutreBox";
            this._emblemPicutreBox.Size = new System.Drawing.Size(75, 75);
            this._emblemPicutreBox.TabIndex = 0;
            this._emblemPicutreBox.TabStop = false;
            // 
            // _actionButtonTableLayout
            // 
            this._actionButtonTableLayout.ColumnCount = 1;
            this._actionButtonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._actionButtonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._actionButtonTableLayout.Controls.Add(this._moveUpArrow, 0, 0);
            this._actionButtonTableLayout.Controls.Add(this._moveDownArrow, 0, 1);
            this._actionButtonTableLayout.Controls.Add(this._deleteButton, 0, 2);
            this._actionButtonTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._actionButtonTableLayout.Location = new System.Drawing.Point(106, 0);
            this._actionButtonTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this._actionButtonTableLayout.Name = "_actionButtonTableLayout";
            this._actionButtonTableLayout.RowCount = 3;
            this._actionButtonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this._actionButtonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this._actionButtonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this._actionButtonTableLayout.Size = new System.Drawing.Size(32, 100);
            this._actionButtonTableLayout.TabIndex = 1;
            // 
            // _moveUpArrow
            // 
            this._moveUpArrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this._moveUpArrow.Image = ((System.Drawing.Image)(resources.GetObject("_moveUpArrow.Image")));
            this._moveUpArrow.Location = new System.Drawing.Point(0, 0);
            this._moveUpArrow.Margin = new System.Windows.Forms.Padding(0);
            this._moveUpArrow.Name = "_moveUpArrow";
            this._moveUpArrow.Size = new System.Drawing.Size(32, 33);
            this._moveUpArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._moveUpArrow.TabIndex = 0;
            this._moveUpArrow.TabStop = false;
            this._moveUpArrow.Click += new System.EventHandler(this._moveUpArrow_Click);
            // 
            // _moveDownArrow
            // 
            this._moveDownArrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this._moveDownArrow.Image = ((System.Drawing.Image)(resources.GetObject("_moveDownArrow.Image")));
            this._moveDownArrow.Location = new System.Drawing.Point(0, 33);
            this._moveDownArrow.Margin = new System.Windows.Forms.Padding(0);
            this._moveDownArrow.Name = "_moveDownArrow";
            this._moveDownArrow.Size = new System.Drawing.Size(32, 33);
            this._moveDownArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._moveDownArrow.TabIndex = 1;
            this._moveDownArrow.TabStop = false;
            this._moveDownArrow.Click += new System.EventHandler(this._moveDownArrow_Click);
            // 
            // _deleteButton
            // 
            this._deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("_deleteButton.Image")));
            this._deleteButton.Location = new System.Drawing.Point(0, 66);
            this._deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(32, 34);
            this._deleteButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._deleteButton.TabIndex = 2;
            this._deleteButton.TabStop = false;
            this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
            // 
            // _accountInfoTableLayout
            // 
            this._accountInfoTableLayout.ColumnCount = 1;
            this._accountInfoTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._accountInfoTableLayout.Controls.Add(this._accountNameLabel, 0, 0);
            this._accountInfoTableLayout.Controls.Add(this._passwordInfo, 0, 1);
            this._accountInfoTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._accountInfoTableLayout.Location = new System.Drawing.Point(138, 0);
            this._accountInfoTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this._accountInfoTableLayout.Name = "_accountInfoTableLayout";
            this._accountInfoTableLayout.RowCount = 3;
            this._accountInfoTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this._accountInfoTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._accountInfoTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this._accountInfoTableLayout.Size = new System.Drawing.Size(181, 100);
            this._accountInfoTableLayout.TabIndex = 2;
            // 
            // _accountNameLabel
            // 
            this._accountNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._accountNameLabel.AutoSize = true;
            this._accountNameLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._accountNameLabel.Location = new System.Drawing.Point(3, 6);
            this._accountNameLabel.Name = "_accountNameLabel";
            this._accountNameLabel.Size = new System.Drawing.Size(80, 23);
            this._accountNameLabel.TabIndex = 0;
            this._accountNameLabel.Text = "Account";
            // 
            // _passwordInfo
            // 
            this._passwordInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._passwordInfo.AutoSize = true;
            this._passwordInfo.Font = new System.Drawing.Font("Arial", 8F);
            this._passwordInfo.Location = new System.Drawing.Point(3, 38);
            this._passwordInfo.Name = "_passwordInfo";
            this._passwordInfo.Size = new System.Drawing.Size(78, 14);
            this._passwordInfo.TabIndex = 1;
            this._passwordInfo.Text = "Password Info";
            // 
            // _loginButton
            // 
            this._loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._loginButton.Font = new System.Drawing.Font("Arial", 10F);
            this._loginButton.Location = new System.Drawing.Point(323, 12);
            this._loginButton.Name = "_loginButton";
            this._loginButton.Size = new System.Drawing.Size(100, 75);
            this._loginButton.TabIndex = 3;
            this._loginButton.Text = "Login";
            this._loginButton.UseVisualStyleBackColor = true;
            this._loginButton.Click += new System.EventHandler(this._loginButton_Click);
            // 
            // AccountDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this._accountDisplayTableLayout);
            this.DoubleBuffered = true;
            this.Name = "AccountDisplay";
            this.Size = new System.Drawing.Size(427, 100);
            this._accountDisplayTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._emblemPicutreBox)).EndInit();
            this._actionButtonTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._moveUpArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._moveDownArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._deleteButton)).EndInit();
            this._accountInfoTableLayout.ResumeLayout(false);
            this._accountInfoTableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _accountDisplayTableLayout;
        private System.Windows.Forms.PictureBox _emblemPicutreBox;
        private System.Windows.Forms.TableLayoutPanel _actionButtonTableLayout;
        private System.Windows.Forms.TableLayoutPanel _accountInfoTableLayout;
        private System.Windows.Forms.Button _loginButton;
        private System.Windows.Forms.PictureBox _moveUpArrow;
        private System.Windows.Forms.PictureBox _moveDownArrow;
        private System.Windows.Forms.PictureBox _deleteButton;
        private System.Windows.Forms.Label _accountNameLabel;
        private System.Windows.Forms.Label _passwordInfo;
    }
}
