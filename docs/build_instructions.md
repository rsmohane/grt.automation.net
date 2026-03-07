# Build & Deployment Instructions

This page contains specific commands and tips for building and deploying each component of the GRT Global Cloud Platform.

## Local Development

### Prerequisites
- .NET 10 SDK
- Node.js/npm
- SQL Server/LocalDB
- Redis

### API & Web App

```bash
cd /workspaces/grt.automation.net/src
# restore and build

dotnet restore

dotnet build -c Debug

# start API and Web concurrently using dotnet-watch (optional)
dotnet watch --project GRTAssist.API run
dotnet watch --project GRTAssist.Web run
```

### MAUI Mobile/Desktop

Open `/src/GRTAssist.Mobile/GRTAssist.Mobile.sln` in Visual Studio and choose the target device/emulator. Use F5 to run.

### Azure Functions

Install the Azure Functions Core Tools (`npm i -g azure-functions-core-tools@4`).

```bash
cd src/GRTAssist.Functions
func start
```

## Containerization

```bash
docker build -t grtassist/nexus-api -f Dockerfile .
docker-compose up -d
```

## Azure Deployment (high level)

1. Create resource group: `az group create -n grt-nexus-rg -l eastus`
2. Provision App Service Plan & Web App(s).
3. Push Docker image to ACR and deploy.
4. Configure Azure SQL Database and connection strings.
5. Enable Azure Key Vault and set secrets.
6. Configure Azure API Management as gateway.

Refer to Microsoft docs for each step.

## Generating Slides / PDF

See `docs/complete_guide.md` section on Pandoc and Mermaid.

---

Keep this file updated as the architecture evolves.