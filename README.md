# Cybersecurity Awareness Chatbot

## Overview
This application is a Cybersecurity Awareness Chatbot designed to educate users about online safety through interactive features including:
- Chat interface for cybersecurity questions
- Quiz functionality to test knowledge
- Reminder system for security tasks
- Activity logging

## Features

### 1. Chat Interface
- Ask questions about various cybersecurity topics including:
  - Passwords and authentication
  - Phishing attacks
  - Safe browsing practices
  - VPN usage
  - Malware protection
  - Social engineering
- View your activity history by typing "Ask Activity log"

### 2. Quiz System
- 10-question cybersecurity quiz with:
  - Multiple choice questions
  - True/False questions
  - Instant feedback
  - Score tracking

### 3. Reminder System
- Set reminders for security-related tasks:
  - Add tasks with descriptions
  - Set reminders for today or future dates
  - View all active reminders

### 4. Activity Logging
- Comprehensive logging of all user interactions
- View complete activity history

## Usage Instructions

1. **Startup**
   - Enter your name to begin
   - Click "Start" button

2. **Navigation**
   - Use the left sidebar to switch between features:
     - Chats: Cybersecurity Q&A
     - Reminder: Task reminder system
     - Quiz: Cybersecurity knowledge test
     - Activity: View interaction history
     - Exit: Close application

3. **Chat Interface**
   - Type your cybersecurity questions
   - Receive instant responses
   - Type "exit" to end conversation

4. **Quiz**
   - Answer multiple choice or true/false questions
   - View immediate feedback
   - Track your score progress

5. **Reminders**
   - Add tasks with "add task [description]"
   - Set reminders with "remind [timeframe]"
   - View reminders with "shows"

## Technical Details

- **Platform**: WPF (.NET Framework)
- **Languages**: C#, XAML
- **Dependencies**: None (all functionality built-in)
- **Architecture**: MVVM-inspired with clear separation of UI and logic

## Code Structure

- **MainWindow.xaml**: UI layout and styling
- **MainWindow.xaml.cs**: Core application logic including:
  - Chat processing
  - Quiz functionality
  - Reminder system
  - Activity logging

## Requirements

- .NET Framework 4.7.2 or later
- Windows OS

## Installation

1. Clone or download the repository
2. Open solution in Visual Studio
3. Build and run the application

## Known Issues

- None currently reported

## Future Enhancements

- Expand cybersecurity topic coverage
- Add more quiz questions
- Implement cloud sync for reminders
- Add user authentication

## License

This project is open-source and available for educational purposes.
