using CyberSecurityBot;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        private ChatBot bot = new ChatBot();

        private List<CyberTask> tasks = new();

        private const string TaskFile = "tasks.json";

        private QuizManager quizManager = new QuizManager();
        private bool waitingForNextQuestion = false;

        public MainWindow()
        {

            InitializeComponent();

            LoadTasks();
            LoadQuestion();

            AudioPlayer.PlayGreeting();

            ChatList.Items.Add("Bot: Hello, welcome to the Cybersecurity Awareness Bot. How can i help you today?");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = UserInputTextBox.Text;

            string response = bot.GetResponse(userInput);

            ChatList.Items.Add("You: " + userInput);
            ChatList.Items.Add("Bot: " + response);
            ChatList.Items.Add("");

            UserInputTextBox.Clear();

            ActivityLogListBox.Items.Add(
                $"User asked: {userInput}");


        }


        private async Task TypeBotMessage(string message)
        {
            string current = "";

            foreach (char c in message)
            {
                current += c;

                if (ChatList.Items.Count > 0 &&
                    ChatList.Items[ChatList.Items.Count - 1].ToString().StartsWith("Bot:"))
                {
                    ChatList.Items.RemoveAt(ChatList.Items.Count - 1);
                }

                ChatList.Items.Add("Bot: " + current);

                await Task.Delay(20);
            }
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            CyberTask task = new CyberTask
            {
                Id = tasks.Count + 1,
                Title = TaskTitleTextBox.Text,
                Description = TaskDescriptionTextBox.Text,
                Reminder = ReminderTextBox.Text,
                CreatedAt = DateTime.Now.ToString(),
                IsComplete = false
            };

            tasks.Add(task);

            TasksListBox.Items.Add(
                $"{task.Title} - {task.Description}");

            SaveTasks();

            ActivityLogListBox.Items.Add(
                $"Added task: {task.Title}");

            TaskTitleTextBox.Clear();
            TaskDescriptionTextBox.Clear();
            ReminderTextBox.Clear();


        }

        private void SaveTasks()
        {
            string json =
                Newtonsoft.Json.JsonConvert.SerializeObject(
                    tasks,
                    Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(TaskFile, json);
        }

        private void LoadTasks()
        {
            if (!File.Exists(TaskFile))
                return;

            string json =
                File.ReadAllText(TaskFile);

            tasks =
                Newtonsoft.Json.JsonConvert.DeserializeObject<List<CyberTask>>(json)
                ?? new List<CyberTask>();

            foreach (var task in tasks)
            {
                TasksListBox.Items.Add(
                    $"{task.Title} - {task.Description}");
            }

        }

        private void LoadQuestion()
        {
            if (quizManager.IsFinished())
            {
                QuestionTextBlock.Text =
                    $"Quiz Finished!\n\nScore: {quizManager.GetFinalScore()}\n\n{quizManager.GetFinalMessage()}";

                AnswersPanel.Children.Clear();

                SubmitQuizButton.Visibility =
                    Visibility.Collapsed;

                NextQuestionButton.Visibility =
                    Visibility.Collapsed;

                return;
            }

            QuizQuestion question =
                quizManager.GetCurrentQuestion();

            QuestionTextBlock.Text =
                $"Score: {quizManager.GetFinalScore()}\n\n{question.Question}";

            AnswersPanel.Children.Clear();

            foreach (string option in question.Options)
            {
                RadioButton rb = new RadioButton
                {
                    Content = option,
                    Margin = new Thickness(5),
                    Foreground = Brushes.White,
                    FontSize = 14,
                    GroupName = "QuizOptions"
                };

                AnswersPanel.Children.Add(rb);
            }

            QuizFeedbackText.Text = "";

            SubmitQuizButton.Visibility =
                Visibility.Visible;

            NextQuestionButton.Visibility =
                Visibility.Collapsed;
        }

        private void SubmitQuizButton_Click(
    object sender,
    RoutedEventArgs e)
        {
            RadioButton? selected =
                AnswersPanel.Children
                    .OfType<RadioButton>()
                    .FirstOrDefault(r => r.IsChecked == true);

            if (selected == null)
            {
                MessageBox.Show(
                    "Please select an answer.");
                return;
            }

            bool correct =
                quizManager.SubmitAnswer(
                    selected.Content.ToString()!);

            if (correct)
            {
                QuizFeedbackText.Text =
                    "✅ Correct!\n";
            }
            else
            {
                QuizFeedbackText.Text =
                    "❌ Incorrect!\n";
            }

            QuizFeedbackText.Text +=
                quizManager.GetFeedback(correct);

            ActivityLogListBox.Items.Add(
                "Quiz question answered.");

            SubmitQuizButton.Visibility =
                Visibility.Collapsed;

            NextQuestionButton.Visibility =
                Visibility.Visible;
        }

        private void NextQuestionButton_Click(
    object sender,
    RoutedEventArgs e)
        {
            LoadQuestion();
        }



    }
}