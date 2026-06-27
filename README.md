# Part3_POE_CybersecurityChatBot
 Part 3 is solely a GUI-based application. 

# Cybersecurity Awareness Chatbot & Learning System

## Overview

This project is a WPF desktop application built in C# that combines a chatbot, task manager, quiz system, and activity logging tool into a single cybersecurity awareness platform. The goal is to educate users about cybersecurity threats while allowing them to interact with an AI-style chatbot and test their knowledge through quizzes.

---
Features

Chatbot System

* Interactive chatbot interface
* Responds to cybersecurity-related questions
* Simulated conversational AI logic
* Logs user interactions in an activity log

---

Task Manager

* Add cybersecurity-related tasks
* Store task title, description, and reminders
* Save tasks locally using JSON (Newtonsoft.Json)
* Load tasks automatically on startup
* Persistent storage between sessions

---

###Quiz System

* 12-question cybersecurity quiz
* Covers:

  * Phishing
  * Password security
  * Safe browsing (HTTPS & Wi-Fi safety)
  * Social engineering
  * Two-factor authentication
  * Malware & ransomware
  * Privacy settings
  * Data backups
* One question displayed at a time
* Immediate feedback after each answer
* Final score and performance message
* Restart quiz functionality

---

Activity Log

* Tracks user interactions
* Logs:

  * Chatbot queries
  * Task creation
  * Quiz attempts

---

Technologies Used

* C# (.NET WPF)
* XAML UI Design
* Newtonsoft.Json (for data persistence)
* Object-oriented programming principles
* Event-driven programming

---

Project Structure

* `MainWindow.xaml` – UI layout and tabs
* `MainWindow.xaml.cs` – Application logic
* `ChatBot.cs` – Chat response logic
* `QuizManager.cs` – Quiz handling system
* `QuizQuestion.cs` – Quiz question model
* `CyberTask.cs` – Task model
* `MemoryStore.cs` – User memory storage
* `Activity logging system`

---

How to Run

1. Clone repository
2. Open solution in Visual Studio
3. Restore NuGet packages
4. Build solution
5. Run (F5)

---

Learning Outcomes

* WPF UI development
* Event-driven programming
* JSON file handling
* State management in applications
* Basic AI chatbot logic
* Quiz system design
* Software architecture fundamentals

---

Future Improvements

* Real AI integration (OpenAI API)
* Cloud-based task storage
* User authentication system
* Improved chatbot intelligence
* Mobile version (MAUI)

---
YouTube: https://youtu.be/yI1EJaE3zsI
---
Author

Developed as a cybersecurity awareness learning project.
