# AIFormHelper (Frontend: React, Backend: .NET Core)

## Prerequisites

To run the project locally, you need to have the following tools installed:

- **.NET SDK 8.0** (or newer): Required to run the backend in .NET Core.
  - You can download it from: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
- **Node.js (version 16.0 or higher)**: Required to run the React frontend.
  - Download from: [https://nodejs.org/](https://nodejs.org/)
- **npm**: Package manager for installing React dependencies.
  - It is installed automatically with Node.js.

## Setup Instructions

### 1. Clone the repository

Clone the repository from GitHub or download the project to your local environment:

```powershell
git clone https://github.com/K0bi3l/AIFormHelper.git
cd AIFormHelper
```
### 2. Install Dependencies
Next, run following commands to install dependencies
```powershell
dotnet restore
```
for backend dependencies installation and:
```powershell
cd ClientApp
npm install
```
for frontend dependencies installation.
### 3. Add user-secret
```powershell
dotnet user-secrets init
dotnet user-secrets set "ApiKey" "Provided key"
```

### 4. Run the app
There are two ways to run the app, first one is to run it via IDE, like Visual Studio.
Second one is to write down following commands, in two different terminals.
In fist terminal, go to /AIFormHelper/AIFormHelper directory and type:
```powershell
dotnet run --project AIFormHelper/AIFormHelper.csproj
```
In second terminal, go to /AIFormHelper/AIFormHelper/ClientApp directory app and type:
```powershell
npm start
```
and web page is available at https://localhost:44402
### 5. Problems with Docker
The project contains Dockerfiles and docker-compose.yml and frontend is working in container, but backend doesn't want to work in container because of weird error, that main function as an entry point couldn't be found.
