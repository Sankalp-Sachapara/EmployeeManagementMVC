# Employee Management System

An ASP.NET Core MVC application for managing employee data.

## Features

- View all employees in a table format
- Browse employees one by one
- Add, edit, and delete employee information
- Automatic database creation on first run
- Built on ASP.NET Core MVC with Entity Framework Core

## Requirements

- Visual Studio 2022 or newer
- .NET 8.0 SDK
- SQL Server (Local DB is sufficient for development)

## How to Run the Application

1. Clone the repository:
   ```
   git clone https://github.com/Sankalp-Sachapara/EmployeeManagementMVC.git
   ```

2. Open the solution file (`EmployeeManagement.sln`) in Visual Studio

3. Build the solution:
   - Press `Ctrl+Shift+B` or select `Build > Build Solution` from the menu

4. Run the application:
   - Press `F5` or click the `Start` button

5. The application will automatically create the database and seed initial data on first run

## Project Structure

- **Models**: Contains the Employee class and its properties
- **Controllers**: Contains the Home and Employees controllers
- **Views**: Contains all the views for the application
- **Data**: Contains the ApplicationDbContext for database operations

## Database

The application uses Entity Framework Core with SQL Server. The database and Employee table are created automatically when the application runs for the first time. Initial seed data is added to provide sample employees.

## Assignment Information

This project was created as part of CSD 3354 Assignment 3, building on Assignment 2.

## License

This project is for educational purposes only.
