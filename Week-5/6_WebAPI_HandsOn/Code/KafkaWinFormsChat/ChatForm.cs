using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Confluent.Kafka;

namespace KafkaWinFormsChatApp
{
    public partial class ChatForm : Form
    {
        private IProducer<string, string> producer;
        private IConsumer<string, string> consumer;
        private CancellationTokenSource cancellationTokenSource;
        private Task consumerTask;

        private TextBox usernameTextBox;
        private TextBox messageTextBox;
        private Button sendButton;
        private RichTextBox chatDisplayTextBox;
        private Button connectButton;
        private Button disconnectButton;
        public ChatForm()
        {
            InitializeComponent();
            SetupKafka();
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();

            //  All GUI form properties
            this.Text = "Kafka Chat Application";
            this.Size = new System.Drawing.Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            var usernameLabel = new Label();
            usernameLabel.Text = "Username:";
            usernameLabel.Location = new System.Drawing.Point(12, 15);
            usernameLabel.Size = new System.Drawing.Size(70, 23);
            this.Controls.Add(usernameLabel);

            usernameTextBox = new TextBox();
            usernameTextBox.Location = new System.Drawing.Point(88, 12);
            usernameTextBox.Size = new System.Drawing.Size(150, 23);
            usernameTextBox.Text = "User" + new Random().Next(1, 1000);
            this.Controls.Add(usernameTextBox);

            connectButton = new Button();
            connectButton.Text = "Connect";
            connectButton.Location = new System.Drawing.Point(250, 11);
            connectButton.Size = new System.Drawing.Size(75, 25);
            connectButton.Click += ConnectButton_Click;
            this.Controls.Add(connectButton);

            disconnectButton = new Button();
            disconnectButton.Text = "Disconnect";
            disconnectButton.Location = new System.Drawing.Point(335, 11);
            disconnectButton.Size = new System.Drawing.Size(85, 25);
            disconnectButton.Click += DisconnectButton_Click;
            disconnectButton.Enabled = false;
            this.Controls.Add(disconnectButton);

            chatDisplayTextBox = new RichTextBox();
            chatDisplayTextBox.Location = new System.Drawing.Point(12, 50);
            chatDisplayTextBox.Size = new System.Drawing.Size(560, 350);
            chatDisplayTextBox.ReadOnly = true;
            chatDisplayTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.Controls.Add(chatDisplayTextBox);

            var messageLabel = new Label();
            messageLabel.Text = "Message:";
            messageLabel.Location = new System.Drawing.Point(12, 415);
            messageLabel.Size = new System.Drawing.Size(60, 23);
            this.Controls.Add(messageLabel);

            messageTextBox = new TextBox();
            messageTextBox.Location = new System.Drawing.Point(78, 412);
            messageTextBox.Size = new System.Drawing.Size(400, 23);
            messageTextBox.KeyDown += MessageTextBox_KeyDown;
            this.Controls.Add(messageTextBox);

            sendButton = new Button();
            sendButton.Text = "Send";
            sendButton.Location = new System.Drawing.Point(490, 411);
            sendButton.Size = new System.Drawing.Size(75, 25);
            sendButton.Click += SendButton_Click;
            sendButton.Enabled = false;
            this.Controls.Add(sendButton);
            this.ResumeLayout(false);
        }
        private void SetupKafka()
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = $"winforms-chat-{Guid.NewGuid()}",
                AutoOffsetReset = AutoOffsetReset.Latest,
                EnableAutoCommit = true
            };
            producer = new ProducerBuilder<string, string>(producerConfig).Build();
            consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
        }
        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                cancellationTokenSource = new CancellationTokenSource();
                consumer.Subscribe("chat-messages");
                consumerTask = Task.Run(() => ConsumeMessages(cancellationTokenSource.Token));
                connectButton.Enabled = false;
                disconnectButton.Enabled = true;
                sendButton.Enabled = true;
                messageTextBox.Enabled = true;

                AddMessageToChat("Connected to chat!", "System");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting: {ex.Message}", "Connection Error");
            }
        }
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            DisconnectFromChat();
        }
        private void DisconnectFromChat()
        {
            try
            {
                cancellationTokenSource?.Cancel();
                consumerTask?.Wait(2000);
                consumer?.Unsubscribe();

                connectButton.Enabled = true;
                disconnectButton.Enabled = false;
                sendButton.Enabled = false;
                messageTextBox.Enabled = false;

                AddMessageToChat("Disconnected from chat.", "System");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error disconnecting: {ex.Message}", "Disconnection Error");
            }
        }
        private async void SendButton_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }
        private async void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                await SendMessage();
            }
        }
        private async Task SendMessage()
        {
            if (string.IsNullOrWhiteSpace(messageTextBox.Text) || string.IsNullOrWhiteSpace(usernameTextBox.Text))
                return;

            try
            {
                var chatMessage = $"{usernameTextBox.Text}: {messageTextBox.Text}";
                var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var fullMessage = $"{timestamp} - {chatMessage}";

                await producer.ProduceAsync("chat-messages",
                    new Message<string, string>
                    {
                        Key = usernameTextBox.Text,
                        Value = fullMessage
                    });

                messageTextBox.Clear();
                messageTextBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}", "Send Error");
            }
        }
        private void ConsumeMessages(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var result = consumer.Consume(cancellationToken);
                        if (result != null)
                        {
                            this.Invoke(new Action(() =>
                            {
                                AddMessageToChat(result.Message.Value, "Chat");
                            }));
                        }
                    }
                    catch (ConsumeException ex)
                    {
                        this.Invoke(new Action(() =>
                        {
                            AddMessageToChat($"Error receiving message: {ex.Error.Reason}", "Error");
                        }));
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    AddMessageToChat($"Consumer error: {ex.Message}", "Error");
                }));
            }
        }
        private void AddMessageToChat(string message, string source)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            chatDisplayTextBox.AppendText($"[{timestamp}] {message}\r\n");
            chatDisplayTextBox.ScrollToCaret();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DisconnectFromChat();
            producer?.Dispose();
            consumer?.Dispose();
            base.OnFormClosing(e);
        }
    }
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatForm());
        }
    }
}