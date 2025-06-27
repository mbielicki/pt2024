# Bookshop Application

## Overview

This repository contains a modular Bookshop application built with C# 12 and .NET 8.0 for Windows. The solution follows a layered architecture, separating concerns into Data, Model, Logic, ViewModel, and View projects. It also includes comprehensive unit tests for each layer.

## Projects Structure

- **Data**: Handles data access, storage, and database interaction.
- **Model**: Defines core business entities and interfaces.
- **Logic**: Implements business logic and operations.
- **ViewModel**: Provides data binding and logic for the WPF UI.
- **View**: WPF application for the user interface.
- **DataTest, ModelTest, LogicTest, ViewModelTest**: MSTest-based unit test projects for each layer.

## Key Features

- **WPF UI**: Modern Windows desktop interface using MVVM.
- **Layered Architecture**: Clean separation of data, business logic, and presentation.
- **Test Coverage**: Automated tests using MSTest and Coverlet for code coverage.
- **Random Data Generation**: Utilities for generating test data (customers, suppliers, books).

## Getting Started

### Prerequisites

- Visual Studio 2022 or later
- .NET 8.0 SDK

### Build and Run

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Set `View` as the startup project.
4. Build the solution (`Ctrl+Shift+B`).
5. Run the application (`F5`).

### Running Tests

Each layer has its own test project. To run all tests:

1. Open the Test Explorer in Visual Studio.
2. Click "Run All".

## Project Dependencies

- All projects target `net8.0-windows`.
- WPF is enabled for UI projects.
- Test projects use MSTest and Coverlet for coverage.
- Data access uses LINQ to SQL.

## Notable Files

- `DataGenerator.cs`: Utilities for generating random test data.
- `Bookshop.dbml`: LINQ to SQL data model for the database.

## Contributing

Contributions are welcome. Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License.
