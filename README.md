# Municipal Services Application (Part 1)

## How to Compile & Run
1. Open `MunicipalServicesApp.sln` in Microsoft Visual Studio.
2. Ensure `.NET Framework` (v4.7.2 or later) is installed.
3. Press **F5** or click **Start** to run the application.

## Features Implemented
- Main Menu with three tasks (only "Report Issues" is active).
- "Report Issues" form includes:
  - Location input
  - Category selection
  - Description box
  - File attachment
  - Submit & Back buttons
  - Engagement message label

## Data Storage
- Issues are stored in memory using a static list (`IssueStorage`).
- Each issue is represented by the `ReportedIssue` class.

## Notes
- Local Events & Service Status will be implemented in Part 2.
- Files are not uploaded, only the file path is stored.
