# Invoice Application - Deployment Guide

## ✅ Completed
- [x] Fixed HTML markup (title tag)
- [x] Created ASP.NET Core 10.0 application
- [x] Implemented Invoice API with Swagger documentation
- [x] Integrated SQLite database with Entity Framework Core
- [x] Enhanced UI with professional styling
- [x] Added CORS support
- [x] Pushed to GitHub: https://github.com/unovajnv/thinkbridgeUI.git

## Local Testing
The application is currently running locally on:
- **UI**: http://localhost:5000
- **API Docs (Swagger)**: http://localhost:5000/api/docs
- **API Endpoint**: http://localhost:5000/api/invoice/1

## Deployment Options

### Option 1: Azure App Service (Recommended)
1. Install Azure CLI
2. Run: `az login`
3. Create app: `az webapp up --name thinkbridge-invoice --runtime dotnet:10.0 --os-type linux`
4. Push code (already done)

### Option 2: Render (Simple & Free)
1. Push code to GitHub (✅ Already done)
2. Go to https://render.com/
3. Connect GitHub repository
4. Create new Web Service from GitHub
5. Set build command: `dotnet build`
6. Set start command: `dotnet run`

### Option 3: Railway (Free Credits)
1. Push code to GitHub (✅ Already done)
2. Go to https://railway.app/
3. Connect GitHub
4. Create new project from GitHub repository
5. Auto-detects .NET and configures deployment

### Option 4: GitHub Codespaces (For Testing)
The app can be tested on free Codespaces tier with port forwarding

## API Endpoints
- `GET /api/invoice` - Get all invoices
- `GET /api/invoice/{id}` - Get specific invoice
- `GET /api/docs` - Swagger UI
- `GET /swagger/v1/swagger.json` - OpenAPI spec

## Database
- SQLite database (invoices.db)
- Automatically initialized with sample data
- Two tables: Invoices and InvoiceItems

## Next Steps
1. Choose a deployment platform
2. Configure and deploy
3. Share the generated URLs
