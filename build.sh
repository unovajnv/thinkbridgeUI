#!/bin/bash
set -e

echo "Building application..."
dotnet build -c Release

echo "Publishing application..."
dotnet publish -c Release -o /app

echo "Build completed successfully!"
