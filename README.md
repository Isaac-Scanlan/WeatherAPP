# WeatherApp ☀️🌧️

<!-- ![Build Status](https://img.shields.io/github/workflow/status/username/WeatherApp/CI) -->
![License: AGPL v3](https://img.shields.io/badge/license-AGPLv3-blue.svg)

## Overview
**WeatherApp** is a real-time weather forecasting desktop application built using .NET Core and WPF. Designed with a clean, MVVM architecture, the app provides accurate weather data for various locations and integrates external APIs for real-time data retrieval. The app ensures a smooth and engaging user experience with a modern, intuitive UI, while XUnit test coverage guarantees its robustness.

## Table of Contents
- [Features](#features)
- [Screenshots](#screenshots)
- [Installation](#installation)
- [Installation on Windows](#installation-on-windows)
- [Usage](#usage)
- [Technologies Used](#technologies-used)
- [Testing](#testing)
- [License](#license)

## Features
- Real-time weather updates for multiple locations.
- Five-day weather forecast with temperature, humidity, wind speed, and more.
- Clean, responsive user interface built with WPF.
- Data sourced from external weather APIs.
- Fully implemented MVVM design pattern for clean separation of concerns.
- Comprehensive unit tests for key application components.

## Screenshots
![WeatherApp Main Screen](./assets/weatherapp_screenshot.png)

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/username/WeatherApp.git
    ```

2. Navigate to the project directory:
    ```bash
    cd WeatherApp
    ```

3. Install dependencies:
    ```bash
    dotnet restore
    ```

4. Build and run the project:
    ```bash
    dotnet run
    ```

## Installation on Windows
Follow these steps to set up and run **WeatherApp** on a Windows machine:

1. **Ensure .NET Core SDK is Installed**:
   - If you don’t have the .NET Core SDK installed, you can download it from [here](https://dotnet.microsoft.com/download/dotnet-core).
   - Once installed, verify by running the following command in your terminal (Command Prompt or PowerShell):
     ```bash
     dotnet --version
     ```

2. **Clone the Repository**:
   - Open Command Prompt or PowerShell and run:
     ```bash
     git clone https://github.com/username/WeatherApp.git
     cd WeatherApp
     ```

3. **Install Dependencies**:
   - In the project directory, restore the necessary packages:
     ```bash
     dotnet restore
     ```

4. **Build the Application**:
   - To compile the application, run:
     ```bash
     dotnet build
     ```

5. **Run the Application**:
   - After building, you can run the app with the following command:
     ```bash
     dotnet run
     ```

6. **Create an Executable** (Optional):
   - If you want to create a standalone executable for Windows, you can publish the project using:
     ```bash
     dotnet publish -c Release -r win10-x64 --self-contained
     ```
   - This will generate an executable in the `bin/Release/netcoreappX.X/win10-x64/publish/` directory (replace `X.X` with your .NET Core version).

7. **Run the Published Executable**:
   - Navigate to the `publish` folder and run the generated `.exe` file to start the application without needing to install .NET Core SDK.

## Usage
After the application starts, you can:
- **Search** for weather by entering a city name in the search bar.
- **View detailed forecasts** including temperature, humidity, and wind speed for the current day.

## Technologies Used
- **C#**: Core programming language for the application.
- **.NET Core**: For building the desktop application.
- **WPF**: Used to create the user interface and manage the UX.
- **MVVM**: Architectural pattern to ensure a clean separation of logic.
- **API Integration**: Uses external APIs to fetch real-time weather data.
- **XUnit**: For writing and running unit tests to ensure the app functions as expected.

## Testing
This project has comprehensive test coverage written in XUnit. To run the tests, use the following command:
```bash
dotnet test
