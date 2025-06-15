using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace open
{
    public partial class MainWindow : Window
    {
        private readonly get_reminder reminder = new get_reminder();
        private string hold_task = string.Empty;

        private List<Question> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameInput.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your name to continue.");
                return;
            }

            MessageBox.Show($"Welcome to the cybersecurity awareness chatbot, {username}. I'm here to make you stay safe online.");
            StartupGrid.Visibility = Visibility.Collapsed;
            MainAppGrid.Visibility = Visibility.Visible;
        }

        private void Chats(object sender, RoutedEventArgs e)
        {
            chats_page.Visibility = Visibility.Visible;
            reminder_page.Visibility = Visibility.Hidden;
            quiz_page.Visibility = Visibility.Hidden;
            activity_page.Visibility = Visibility.Hidden;

            // Initialize chat display with welcome message
            ChatDisplay.Text = "Welcome to Cybersecurity Chatbot! Ask me anything about:\n- Passwords\n- Phishing\n- Safe browsing\n- VPNs\n- Malware\n- Social engineering\nType 'exit' to quit.";
        }

        private void SendChat_Click(object sender, RoutedEventArgs e)
        {
            string userInput = ChatInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return;
            }

            // Add user's question to chat
            ChatDisplay.Text += $"\n\nYou: {userInput}";

            // Process the input (using existing logic)
            string response = ProcessChatInput(userInput.ToLower());

            // Add bot's response to chat
            ChatDisplay.Text += $"\n\nBot: {response}";

            // Clear input box
            ChatInput.Text = "";

            // Scroll to bottom
            var scrollViewer = FindVisualChild<ScrollViewer>(ChatDisplay.Parent as Border);
            scrollViewer?.ScrollToEnd();
        }

        private string ProcessChatInput(string userInput)
        {
            string userName = "User";
            List<string> questions = new List<string>();
            List<ArrayList> answers = new List<ArrayList>();

            void Store_Responses()
            {
                questions.Add("how are you");
                answers.Add(new ArrayList {
            $"I'm just a bot, {userName}, but I'm here to help you stay safe online!",
            "I'm functioning at optimal efficiency! How can I assist you today?"
        });

                questions.Add("purpose");
                answers.Add(new ArrayList {
            "My purpose is to educate you about cybersecurity and help you stay safe online.",
            "I'm here to provide tips and answer questions related to online safety and security."
        });

                questions.Add("password");
                answers.Add(new ArrayList {
            "A strong password should be at least 12 characters long, with a mix of letters, numbers, and symbols.",
            "Avoid using easily guessable passwords like '123456' or your name.",
            "Use a password manager to generate and store complex passwords securely."
        });

                questions.Add("phishing");
                answers.Add(new ArrayList {
            "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
            "Check the sender's email address and avoid clicking on suspicious links.",
            "Phishing emails often create a sense of urgency to trick you into revealing personal data."
        });

                questions.Add("safe browsing");
                answers.Add(new ArrayList {
            "Always check for 'https://' in the URL and avoid clicking on suspicious links.",
            "Keep your browser updated to protect against known vulnerabilities.",
            "Use trusted antivirus and anti-malware extensions for safer browsing."
        });

                questions.Add("vpn");
                answers.Add(new ArrayList {
            "A VPN encrypts your internet traffic, making it safer from hackers.",
            "VPNs help you maintain online privacy, especially on public Wi-Fi.",
            "Choose a reputable VPN service that doesn't log your data."
        });

                questions.Add("browsing");
                answers.Add(new ArrayList {
            "A browser is an application program that provides a way to look at and interact with all the information on the World Wide Web.",
            "Popular browsers include Chrome, Firefox, Safari, and Edge.",
            "Browsers can be enhanced with extensions to improve security and functionality."
        });

                questions.Add("social engineering");
                answers.Add(new ArrayList {
            "Social engineering manipulates victims to control systems or steal personal and financial data.",
            "Be cautious of people asking for sensitive info over the phone or via email.",
            "Attackers often impersonate authority figures to trick targets."
        });

                questions.Add("software attacks");
                answers.Add(new ArrayList {
            "Software attacks include malware, phishing, and SQL injection, compromising systems and data.",
            "Ensure your software is updated to patch known vulnerabilities.",
            "Firewalls and antivirus programs help detect and block software attacks."
        });

                questions.Add("computer security");
                answers.Add(new ArrayList {
            "Computer security is the protection of computer systems and networks from threats that lead to unauthorized access, theft, or damage.",
            "Implementing strong authentication methods is part of good computer security.",
            "Regular system updates and user awareness are key to computer security."
        });

                questions.Add("malware");
                answers.Add(new ArrayList {
            "Malware is intrusive software created by cybercriminals to steal data and damage or destroy computer systems. Examples include viruses.",
            "Avoid downloading software from untrusted sources to reduce the risk of malware.",
            "Use antivirus software to detect and remove malware threats."
        });
            }

            Store_Responses();

            if (userInput == "exit")
            {
                return "Goodbye! Stay safe online!";
            }

            string[] emotionalTriggers = new string[] { "my favourite", "interested", "worried", "curious", "frustrated" };
            string[] topics = new string[] { "purpose", "password", "phishing", "safe browsing", "vpn", "browsing", "social engineering", "software attacks", "computer security", "malware" };

            bool emotionalDetected = emotionalTriggers.Any(trigger => userInput.Contains(trigger));

            if (emotionalDetected)
            {
                foreach (string topic in topics)
                {
                    if (userInput.Contains(topic))
                    {
                        int topicIndex = questions.FindIndex(q => q == topic);
                        if (topicIndex >= 0)
                        {
                            ArrayList relatedAnswers = answers[topicIndex];
                            Random rand = new Random();
                            return $"Since you're {string.Join(" or ", emotionalTriggers.Where(trigger => userInput.Contains(trigger)))} about {topic}, here's something helpful: {relatedAnswers[rand.Next(relatedAnswers.Count)]}";
                        }
                    }
                }
                return $"I appreciate your {string.Join(" or ", emotionalTriggers.Where(trigger => userInput.Contains(trigger)))}! Feel free to ask anything about cybersecurity topics like phishing, malware, or passwords.";
            }

            for (int i = 0; i < questions.Count; i++)
            {
                if (userInput.Contains(questions[i]))
                {
                    ArrayList possibleAnswers = answers[i];
                    Random rand = new Random();
                    return possibleAnswers[rand.Next(possibleAnswers.Count)].ToString().Replace("{userName}", userName);
                }
            }

            return "I did not quite understand that. Could you please ask questions related to Cybersecurity Awareness?";
        }

        private static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        return (T)child;
                    }

                    T childItem = FindVisualChild<T>(child);
                    if (childItem != null) return childItem;
                }
            }
            return null;
        }

        private void Reminder(object sender, RoutedEventArgs e)
        {
            chats_page.Visibility = Visibility.Hidden;
            reminder_page.Visibility = Visibility.Visible;
            quiz_page.Visibility = Visibility.Hidden;
            activity_page.Visibility = Visibility.Hidden;
        }

        private void Quiz(object sender, RoutedEventArgs e)
        {
            chats_page.Visibility = Visibility.Hidden;
            reminder_page.Visibility = Visibility.Hidden;
            quiz_page.Visibility = Visibility.Visible;
            activity_page.Visibility = Visibility.Hidden;

            questions = LoadQuestions();
            currentQuestionIndex = 0;
            score = 0;
            ShowQuestion();
        }

        private List<Question> LoadQuestions()
        {
            return new List<Question>
            {
                new Question("What does 'phishing' mean?", "B", new List<string>
                {
                    "A. Scanning for viruses",
                    "B. Tricking users to reveal personal info",
                    "C. Blocking websites",
                    "D. Encrypting files"
                }, "MC"),

                new Question("Which is a strong password?", "C", new List<string>
                {
                    "A. 123456",
                    "B. password",
                    "C. MyDog$2025!",
                    "D. qwerty"
                }, "MC"),

                new Question("Which website is the safest?", "C", new List<string>
                {
                    "A. http://bank.com",
                    "B. http://gmail.com",
                    "C. https://secure.gov",
                    "D. http://files.net"
                }, "MC"),

                new Question("True or False: You should use the same password for every website.", "False", new List<string>
                {
                    "True",
                    "False"
                }, "TF"),

                new Question("True or False: HTTPS websites are more secure than HTTP.", "True", new List<string>
                {
                    "True",
                    "False"
                }, "TF"),

                new Question("What is two-factor authentication (2FA)?", "A", new List<string>
                {
                    "A. Using two methods to verify identity",
                    "B. Logging in with two different usernames",
                    "C. Changing your password twice",
                    "D. Using two browsers to sign in"
                }, "MC"),

                new Question("Which of the following is a type of malware?", "D", new List<string>
                {
                    "A. Firewall",
                    "B. VPN",
                    "C. CAPTCHA",
                    "D. Ransomware"
                }, "MC"),

                new Question("True or False: Public Wi-Fi is always secure to use for banking.", "False", new List<string>
                {
                    "True",
                    "False"
                }, "TF"),

                new Question("What should you do if you receive a suspicious email?", "B", new List<string>
                {
                    "A. Open all links to verify",
                    "B. Delete it or report as spam",
                    "C. Reply asking for clarification",
                    "D. Forward it to friends"
                }, "MC"),

                new Question("True or False: Antivirus software can help detect and remove malicious software.", "True", new List<string>
                {
                    "True",
                    "False"
                }, "TF")
            };
        }

        private void ShowQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var q = questions[currentQuestionIndex];
                QuestionText.Text = q.Text + "\n" + string.Join("\n", q.Options);
                FeedbackText.Text = "";

                McButtons.Visibility = q.Type == "MC" ? Visibility.Visible : Visibility.Collapsed;
                TfButtons.Visibility = q.Type == "TF" ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                QuestionText.Text = $"✅ Quiz complete! Final score: {score}/{questions.Count}";
                FeedbackText.Text = "Well done!";
                McButtons.Visibility = Visibility.Collapsed;
                TfButtons.Visibility = Visibility.Collapsed;
            }
        }

        private async void Answer_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestionIndex >= questions.Count) return;

            var button = sender as Button;
            var selected = button.Content.ToString();
            var correct = questions[currentQuestionIndex].Answer;

            if (selected.Contains(correct))
            {
                score++;
                FeedbackText.Text = "✅ Correct!";
            }
            else
            {
                FeedbackText.Text = $"❌ Wrong! Correct answer: {correct}";
            }

            ScoreText.Text = $"Score: {score}/{questions.Count}";
            currentQuestionIndex++;

            await Task.Delay(1000);
            ShowQuestion();
        }

        public class Question
        {
            public string Text { get; }
            public string Answer { get; }
            public List<string> Options { get; }
            public string Type { get; }

            public Question(string text, string answer, List<string> options, string type)
            {
                Text = text;
                Answer = answer;
                Options = options;
                Type = type;
            }
        }

        private void activity(object sender, RoutedEventArgs e)
        {
            chats_page.Visibility = Visibility.Hidden;
            reminder_page.Visibility = Visibility.Hidden;
            quiz_page.Visibility = Visibility.Hidden;
            activity_page.Visibility = Visibility.Visible;
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void set_reminder(object sender, RoutedEventArgs e)
        {
            chats_page.Visibility = Visibility.Hidden;
            reminder_page.Visibility = Visibility.Visible;
            quiz_page.Visibility = Visibility.Hidden;
            activity_page.Visibility = Visibility.Hidden;

            string temp_userTask = user_task.Text.ToString();

            if (reminder.validate_input(temp_userTask) != "found")
            {
                MessageBox.Show(reminder.validate_input(temp_userTask));
                return;
            }

            if (temp_userTask.Contains("add task"))
            {
                string get_description = temp_userTask.Replace("add task", "");
                chat_append.Items.Add("task added with desc" + get_description + "\nWould you like a reminder?");
                hold_task = get_description;
            }
            else if (temp_userTask.Contains("remind"))
            {
                if (hold_task != "")
                {
                    string hold_day = reminder.get_days(temp_userTask);

                    if (hold_day == "today")
                    {
                        if (reminder.today_date(hold_task, hold_day) != "error")
                        {
                            chat_append.Items.Add(reminder.today_date(hold_task, hold_day));
                        }
                        else
                        {
                            chat_append.Items.Add("sorry, system chatbot failed to add task.");
                        }
                    }
                    else
                    {
                        if (reminder.get_reminderDate(hold_task, hold_day) == "done")
                        {
                            chat_append.Items.Add("great, i will remind you in " + hold_day + " days");
                        }
                    }
                }
                else
                {
                    System.Console.Beep();
                    chat_append.Items.Add("No task was set to remind you");
                }
            }

            if (temp_userTask.Contains("shows"))
            {
                chat_append.Items.Add("Your reminds are");
                chat_append.Items.Add(reminder.get_remind());
            }

            user_task.Clear();
        }
    }
}