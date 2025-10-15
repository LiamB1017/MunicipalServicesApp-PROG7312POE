# Municipal Services Application (Part 1 and 2)

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
 
Local Events & Announcements

- New feature added in Part 2.
- Displays a list of community events and announcements.
Users can:
- Click “Show” to view all events.
- Use the search box to filter by event name.
- Use the category dropdown to filter by event type.
- View recommendations based on search input.
- Return to the main menu via Back button.

## Data Storage
- Issues are stored in memory using a static list (`IssueStorage`).
- Each issue is represented by the `ReportedIssue` class.
- Events are stored in a custom in-memory list
- The LocalEventsForm uses this list to populate the event display, filter results, and generate recommendations dynamically.

## Notes
- Service Status will be implemented in Part 3/POE.
- Files are not uploaded, only the file path is stored.
