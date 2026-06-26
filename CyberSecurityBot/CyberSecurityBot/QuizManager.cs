using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityBot
{
   
        public class QuizManager
        {
            private List<QuizQuestion> _questions;
            private int _currentIndex = 0;
            private int _score = 0;

            public QuizManager()
            {
                _questions = new List<QuizQuestion>()
            {
                new QuizQuestion
                {
                    Question = "What is phishing?",
                    Options = new List<string>
                    {
                        "A type of scam email",
                        "An antivirus",
                        "A firewall",
                        "A password manager"
                    },
                    CorrectAnswer = "A type of scam email",
                    Explanation = "Phishing tricks people into revealing sensitive information."
                },

                new QuizQuestion
                {
                    Question = "You should click links in emails from unknown senders.",
                    Options = new List<string>{ "True", "False" },
                    CorrectAnswer = "False",
                    Explanation = "Unknown links can lead to phishing websites.",
                    IsTrueFalse = true
                },

                new QuizQuestion
                {
                    Question = "Which password is strongest?",
                    Options = new List<string>
                    {
                        "123456",
                        "Password",
                        "John123",
                        "T@9k!7Lp#2"
                    },
                    CorrectAnswer = "T@9k!7Lp#2",
                    Explanation = "Strong passwords use symbols, numbers and mixed case."
                },

                new QuizQuestion
                {
                    Question = "Using the same password everywhere is safe.",
                    Options = new List<string>{ "True", "False" },
                    CorrectAnswer = "False",
                    Explanation = "One breach can compromise all your accounts.",
                    IsTrueFalse = true
                },

                new QuizQuestion
                {
                    Question = "What does HTTPS indicate?",
                    Options = new List<string>
                    {
                        "Secure website connection",
                        "Free internet",
                        "Fast internet",
                        "Antivirus protection"
                    },
                    CorrectAnswer = "Secure website connection",
                    Explanation = "HTTPS encrypts communication with the website."
                },

                new QuizQuestion
                {
                    Question = "Public Wi-Fi is always safe.",
                    Options = new List<string>{ "True", "False" },
                    CorrectAnswer = "False",
                    Explanation = "Public networks can be monitored by attackers.",
                    IsTrueFalse = true
                },

                new QuizQuestion
                {
                    Question = "Social engineering attacks mainly target:",
                    Options = new List<string>
                    {
                        "People",
                        "Printers",
                        "Routers",
                        "Hardware"
                    },
                    CorrectAnswer = "People",
                    Explanation = "Social engineering manipulates people rather than technology."
                },

                new QuizQuestion
                {
                    Question = "A scammer pretending to be your bank is social engineering.",
                    Options = new List<string>{ "True", "False" },
                    CorrectAnswer = "True",
                    Explanation = "Impersonation is a common social engineering technique.",
                    IsTrueFalse = true
                },

                new QuizQuestion
                {
                    Question = "What is two-factor authentication?",
                    Options = new List<string>
                    {
                        "Two passwords",
                        "Two security checks",
                        "Two antivirus programs",
                        "Two usernames"
                    },
                    CorrectAnswer = "Two security checks",
                    Explanation = "2FA requires another form of verification."
                },

                new QuizQuestion
                {
                    Question = "Ransomware encrypts your files and demands payment.",
                    Options = new List<string>{ "True", "False" },
                    CorrectAnswer = "True",
                    Explanation = "That is exactly how ransomware works.",
                    IsTrueFalse = true
                },

                new QuizQuestion
                {
                    Question = "Why should you review privacy settings?",
                    Options = new List<string>
                    {
                        "To control who sees your information",
                        "To speed up your PC",
                        "To install updates",
                        "To delete viruses"
                    },
                    CorrectAnswer = "To control who sees your information",
                    Explanation = "Privacy settings help protect personal information."
                },

                new QuizQuestion
                {
                    Question = "Why are backups important?",
                    Options = new List<string>
                    {
                        "To recover lost files",
                        "To increase internet speed",
                        "To improve graphics",
                        "To charge your battery"
                    },
                    CorrectAnswer = "To recover lost files",
                    Explanation = "Backups protect you from hardware failure and ransomware."
                }
            };
            }

            public QuizQuestion GetCurrentQuestion()
            {
                return _questions[_currentIndex];
            }

            public bool SubmitAnswer(string answer)
            {
                bool correct =
                    answer == _questions[_currentIndex].CorrectAnswer;

                if (correct)
                    _score++;

                _currentIndex++;

                return correct;
            }

            public string GetFeedback(bool correct)
            {
                return _questions[_currentIndex - 1].Explanation;
            }

            public bool IsFinished()
            {
                return _currentIndex >= _questions.Count;
            }

            public string GetFinalScore()
            {
                return $"{_score} / {_questions.Count}";
            }

            public string GetFinalMessage()
            {
                double percentage =
                    (double)_score / _questions.Count;

                if (percentage >= 0.8)
                    return "Great job! You're cybersecurity aware.";

                if (percentage >= 0.5)
                    return "Good effort. Keep learning.";

                return "Keep learning. Cybersecurity skills improve with practice.";
            }

            public void ResetQuiz()
            {
                _currentIndex = 0;
                _score = 0;
            }
        }
    }
   

