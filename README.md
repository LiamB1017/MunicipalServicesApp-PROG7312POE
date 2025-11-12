README.md – Municipal Services Application (Final POE)
# Overview

The Municipal Services Application is a comprehensive desktop system developed in C# (.NET Framework 4.7.2) that allows South African residents to:

Report local issues such as potholes, broken streetlights, or water leaks.

Access community events and announcements.

Track the status of submitted service requests using advanced data structures and algorithms.

This application demonstrates a strong integration of core software engineering principles with custom-built data structures such as Binary Search Trees (BSTs), Graphs, and algorithms like Breadth-First Search (BFS), Depth-First Search (DFS), and Prim’s Minimum Spanning Tree (MST).

# How to Compile and Run

Open MunicipalServicesApp.sln in Microsoft Visual Studio.

Ensure .NET Framework 4.7.2 or later is installed.

Build the project using Ctrl + Shift + B.

Press F5 or click Start to run the application.

# Features Implemented
Main Menu

Central navigation hub.

Provides access to:

Report Issues

Local Events & Announcements

Service Request Status

Report Issues

Users can submit reports that include:

Location

Category

Description

Optional file attachment path

Each report receives a unique Request ID.

Data is stored in memory using a custom static datastore (DataStore).

The ReportedIssue class represents each user report.

Provides a confirmation message and allows navigation back to the main menu.

Local Events & Announcements

Displays a list of community events stored in a SortedDictionary structure.

Users can:

Search events by keyword.

Filter events by category.

A Queue is used to store recent searches, and a HashSet stores unique event categories.

Recommendation feature uses recent search keywords to suggest events.

Service Request Status (Part 3)

This is the major enhancement introduced in Part 3.

Core functionality:

Displays all submitted service requests with their status.

Users can search by Request ID for detailed information.

Requests are stored in a Binary Search Tree (BST) for efficient lookup.

Relationships between requests are modeled using a Graph structure.

Algorithms implemented:

BFS (Breadth-First Search): Explores request nodes level by level.

DFS (Depth-First Search): Traverses connected nodes recursively.

Prim’s MST: Generates the minimal connection network among requests.

# Data Structures Implemented
Data Structure	Description	Application in Project
Binary Search Tree (BST)	Organizes and retrieves requests efficiently by ID.	Enables quick search, insertion, and sorted display of requests in the Service Request Status form.
Graph	Models relationships between service requests.	Used to demonstrate traversal algorithms (BFS, DFS) and Prim’s MST.
Queue	Follows FIFO (First-In-First-Out) principle.	Used to manage recent search history in Local Events.
HashSet	Ensures unique entries.	Stores unique categories of events to populate the dropdown filter.
SortedDictionary	Maintains key-value pairs in sorted order.	Used to store and display local events chronologically.
 
# Data Storage

Issues are stored temporarily in memory through the DataStore class.

Each issue instance (from ReportedIssue) is saved and retrieved across forms.

The ServiceRequestStatusForm dynamically loads all reports from this shared datastore into the BST and Graph.

# Improvements from Part 1 & 2
Area	Issue Identified	Fix Implemented
Navigation	Multiple instances of Main Menu opened after returning from other forms.	Modified navigation logic to show existing Main Menu form instead of creating new instances.
Event Recommendations	Recommendations were limited to exact search history.	Logic updated to suggest events containing related keywords or categories.
Display Issues	Lists were not updating correctly when data changed.	Implemented refresh methods to reload event and issue lists after submissions.
“Show” Button	Not displaying recommendations.	Fixed event handler and binding logic.
Missing Shared Data	Requests were not visible in Service Request Status.	Implemented centralized DataStore to hold reported issues across all forms.
Lookup Errors	“Request ID … has no associated data” appeared.	Fixed tree search to retrieve correct node payload.
Code Attribution	Improved comments and documentation in all classes.	Updated to ensure academic integrity compliance.
# Feedback and Fixes

# Feedback Received:

Built-in data structures were used. For example, the ContainsKey() method is a SortedDictionary operation. However, your code does not show where this method was implemented.
Also, the recommendation system only returns previously searched events instead of suggesting related ones.

Actions Taken:

Created custom implementations of the BST (ServiceRequestTree) and Graph (Graph), written from scratch.

Removed reliance on built-in data structures for Part 3, ensuring all required logic (insert, search, traversal) is manually implemented.

Enhanced recommendation logic to provide related event suggestions by matching partial titles, descriptions, and categories instead of direct search history.
