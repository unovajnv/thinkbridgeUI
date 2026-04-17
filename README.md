# ThinkBridge Invoice Application

A professional ASP.NET Core web application that displays invoices with a REST API and PostgreSQL database hosted on Render.

## ✨ Features
- Invoice display UI with professional styling
- REST API with Swagger/OpenAPI documentation
- PostgreSQL database integration
- Responsive design
- Free cloud hosting

## 🌐 Live Deployment (Render)

**Requires DATABASE_URL environment variable** - Set automatically by Render

See [RENDER_DEPLOYMENT.md](RENDER_DEPLOYMENT.md) for complete deployment instructions.

## 📱 After Deployment

Your public URLs will be:
- **UI:** `https://thinkbridge-invoice.onrender.com/`
- **Swagger API:** `https://thinkbridge-invoice.onrender.com/api/docs`

## 🏗️ Project Structure

```
├── Controllers/           # API controllers
├── Data/                 # Database context and models
├── wwwroot/             # Static files (HTML, CSS, JS)
├── Program.cs           # Application configuration
├── ThinkBridge.csproj   # Project file
└── RENDER_DEPLOYMENT.md # Deployment guide
```

## 🔧 Technology Stack

- **Framework:** ASP.NET Core 10.0
- **Database:** PostgreSQL
- **ORM:** Entity Framework Core
- **API Docs:** Swagger (Swashbuckle)
- **Hosting:** Render (Free)

## 📝 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/invoice` | Get all invoices |
| GET | `/api/invoice/{id}` | Get specific invoice |
| GET | `/api/docs` | Swagger UI |
| GET | `/` | Invoice display UI |

## 🚀 Quick Start

1. Deploy to Render following [RENDER_DEPLOYMENT.md](RENDER_DEPLOYMENT.md)
2. Get your public URLs
3. Share them!

---

**Ready to deploy?** → Read [RENDER_DEPLOYMENT.md](RENDER_DEPLOYMENT.md)

