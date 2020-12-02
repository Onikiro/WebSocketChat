namespace Test.SocketChat.ClientApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this._nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._statusBox = new System.Windows.Forms.TextBox();
            this._connectButton = new System.Windows.Forms.Button();
            this._disconnectButton = new System.Windows.Forms.Button();
            this._chatBox = new System.Windows.Forms.RichTextBox();
            this._inputBox = new System.Windows.Forms.TextBox();
            this._sendMessageButton = new System.Windows.Forms.Button();
            this._errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _nameBox
            // 
            this._nameBox.Location = new System.Drawing.Point(101, 12);
            this._nameBox.Name = "_nameBox";
            this._nameBox.Size = new System.Drawing.Size(107, 22);
            this._nameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nickname";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status";
            // 
            // _statusBox
            // 
            this._statusBox.Location = new System.Drawing.Point(101, 51);
            this._statusBox.MaxLength = 30;
            this._statusBox.Name = "_statusBox";
            this._statusBox.Size = new System.Drawing.Size(107, 22);
            this._statusBox.TabIndex = 4;
            // 
            // _connectButton
            // 
            this._connectButton.Location = new System.Drawing.Point(12, 106);
            this._connectButton.Name = "_connectButton";
            this._connectButton.Size = new System.Drawing.Size(196, 25);
            this._connectButton.TabIndex = 5;
            this._connectButton.Text = "Connect";
            this._connectButton.UseVisualStyleBackColor = true;
            this._connectButton.Click += new System.EventHandler(this._connectButton_Click);
            // 
            // _disconnectButton
            // 
            this._disconnectButton.Enabled = false;
            this._disconnectButton.Location = new System.Drawing.Point(12, 137);
            this._disconnectButton.Name = "_disconnectButton";
            this._disconnectButton.Size = new System.Drawing.Size(196, 25);
            this._disconnectButton.TabIndex = 6;
            this._disconnectButton.Text = "Disconnect";
            this._disconnectButton.UseVisualStyleBackColor = true;
            this._disconnectButton.Click += new System.EventHandler(this._disconnectButton_Click);
            // 
            // _chatBox
            // 
            this._chatBox.Location = new System.Drawing.Point(214, 9);
            this._chatBox.Name = "_chatBox";
            this._chatBox.ReadOnly = true;
            this._chatBox.Size = new System.Drawing.Size(574, 409);
            this._chatBox.TabIndex = 7;
            this._chatBox.Text = "";
            // 
            // _inputBox
            // 
            this._inputBox.Location = new System.Drawing.Point(214, 416);
            this._inputBox.MaxLength = 30;
            this._inputBox.Name = "_inputBox";
            this._inputBox.Size = new System.Drawing.Size(419, 22);
            this._inputBox.TabIndex = 8;
            // 
            // _sendMessageButton
            // 
            this._sendMessageButton.Enabled = false;
            this._sendMessageButton.Location = new System.Drawing.Point(639, 415);
            this._sendMessageButton.Name = "_sendMessageButton";
            this._sendMessageButton.Size = new System.Drawing.Size(149, 23);
            this._sendMessageButton.TabIndex = 9;
            this._sendMessageButton.Text = "Send";
            this._sendMessageButton.UseVisualStyleBackColor = true;
            this._sendMessageButton.Click += new System.EventHandler(this._sendMessageButton_Click);
            // 
            // _errorLabel
            // 
            this._errorLabel.ForeColor = System.Drawing.Color.Red;
            this._errorLabel.Location = new System.Drawing.Point(12, 80);
            this._errorLabel.Name = "_errorLabel";
            this._errorLabel.Size = new System.Drawing.Size(196, 23);
            this._errorLabel.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AcceptButton = this._sendMessageButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._errorLabel);
            this.Controls.Add(this._sendMessageButton);
            this.Controls.Add(this._inputBox);
            this.Controls.Add(this._chatBox);
            this.Controls.Add(this._disconnectButton);
            this.Controls.Add(this._connectButton);
            this.Controls.Add(this._statusBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._nameBox);
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label _errorLabel;

        private System.Windows.Forms.TextBox _inputBox;
        private System.Windows.Forms.Button _sendMessageButton;

        private System.Windows.Forms.RichTextBox _chatBox;

        private System.Windows.Forms.Button _connectButton;
        private System.Windows.Forms.Button _disconnectButton;
        private System.Windows.Forms.TextBox _statusBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox _nameBox;

        #endregion
    }
}