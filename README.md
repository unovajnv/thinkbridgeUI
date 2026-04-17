# ThinkBridge Invoice Application

This is an ASP.NET Core web application that displays invoices using a REST API and SQLite database.

## Features
- Display invoices with items and prices
- REST API with Swagger/OpenAPI documentation
- SQLite database integration with Entity Framework Core
- Responsive invoice UI

## Building

```bash
dotnet build
```

## Running

```bash
dotnet run
```

The application will start on `https://localhost:5001` and `http://localhost:5000`

## API Documentation

Once running, visit: `http://localhost:5000/api/docs`

## Project Structure

- `/Controllers` - API controllers
- `/Data` - Database context and models
- `/wwwroot` - Static files (HTML, CSS, JS)
