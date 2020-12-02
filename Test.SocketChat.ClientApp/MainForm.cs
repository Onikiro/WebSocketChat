using System;
using System.Windows.Forms;

namespace Test.SocketChat.ClientApp
{
    public partial class MainForm : Form
    {
        private readonly SocketChatSocketClient _socketClient = new SocketChatSocketClient();

        public MainForm()
        {
            InitializeComponent();

            _socketClient.OnMessageReceived += msg =>
            {
                this.InvokeIfRequired(() =>
                {
                    if (_chatBox.Text.Equals(string.Empty))
                    {
                        _chatBox.AppendText(msg);
                    }
                    else
                    {
                        _chatBox.AppendText(Environment.NewLine + msg);
                    }
                });
            };
        }

        private void _connectButton_Click(object sender, EventArgs e)
        {
            _errorLabel.Text = string.Empty;

            if (string.IsNullOrEmpty(_nameBox.Text))
            {
                _errorLabel.Text = "Nickname cannot be empty.";
                return;
            }

            if (string.IsNullOrEmpty(_statusBox.Text))
            {
                _errorLabel.Text = "Status cannot be empty.";
                return;
            }

            if (_socketClient.TryConnect(_nameBox.Text, _statusBox.Text))
            {
                _nameBox.Enabled = false;
                _statusBox.Enabled = false;
                _connectButton.Enabled = false;
                _disconnectButton.Enabled = true;
                _sendMessageButton.Enabled = true;
            }
            else
            {
                _errorLabel.Text = "Something went wrong, try again later..";
            }
        }

        private void _disconnectButton_Click(object sender, EventArgs e)
        {
            _socketClient.Disconnect(_nameBox.Text);

            _nameBox.Enabled = true;
            _statusBox.Enabled = true;
            _connectButton.Enabled = true;
            _disconnectButton.Enabled = false;
            _sendMessageButton.Enabled = false;
        }

        private void _sendMessageButton_Click(object sender, EventArgs e)
        {
            _socketClient.SendMessage(_inputBox.Text);
            _inputBox.Text = string.Empty;
        }
    }

    public static class Utils
    {
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public static void InvokeIfRequired(this Form form, MethodInvoker action)
        {
            if (form.InvokeRequired)
            {
                form.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}