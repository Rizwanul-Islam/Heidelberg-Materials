# REST API Integration - .NET and React

The objective of this task is to assess skills in REST API integration using .NET and React.

## Requirements:

1. Use the SpaceX API (https://docs.spacexdata.com/) to retrieve the details of all past and upcoming launches. You can use any programming language or framework of your choice, but we recommend using .NET and React.
2. Implement a React application that displays the details of all past and upcoming launches retrieved from the SpaceX API.
3. Add a feature to your React application that allows the user to click on a launch and view the details of that specific launch.
4. Implement an API endpoint using .NET that retrieves the details of a specific launch by its ID.
5. Add a button or link to your React application that, when clicked, calls your API endpoint and displays the details of the selected launch.
6. Implement automated tests to ensure that the API endpoint returns the expected results for valid inputs and handles invalid inputs gracefully.

## Deliverables:
1. The source code for your React application and API endpoint, and automated tests. You can send code to us or create a git repository on github and upload code there.
2. Documentation that explains how to build and run your React application and APIendpoint.

## Task Completion

1. All the functionalities has been completed.
2. After running the React client app, you will see a list of launches
3. Click on any launch and will generate the details

## Running the .NET Web API Endpoints

To run the minimal .NET web API application, follow these steps:

1. Install the .NET SDK 7 if you haven't already. You can download it from [Microsoft's official website](https://dotnet.microsoft.com/download).

2. Open a terminal or command prompt and navigate to the root directory of the .NET web API application.

3. Build the application by running the following command:
~~~csharp
     dotnet build
~~~      
4. Start the web API server by running the following command:
~~~csharp
     dotnet run
~~~ 
5. The server should now be running on `http://localhost:7124`. You can test the API endpoints using a tool like Postman or cURL.
~~~csharp
     https://localhost:7124/launches
     https://localhost:7124/launch/1   // 1 is the flight id  
~~~ 

## Running React client App

To run the React app, follow these steps:

1. Make sure you have Node.js installed on your machine. You can download it from [the official Node.js website](https://nodejs.org).

2. Open a terminal or command prompt and navigate to the root directory of the reactclient folder.

3. Install the required dependencies by running the following command:
~~~csharp
    npm install
~~~    
4. Start the development server by running the following command:
~~~csharp
    npm start
 ~~~    
6. The React app should now be running on `http://localhost:3000` in your browser. Any changes you make to the code will automatically trigger a hot reload.
     
