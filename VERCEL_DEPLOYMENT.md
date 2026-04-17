# Vercel Deployment Configuration

## Build & Run Commands for Vercel

### Build Command
```bash
dotnet build -c Release
```

### Run/Start Command
```bash
dotnet run --no-build -c Release --urls http://0.0.0.0:3000
```

---

## Configuration Files

### 1. Create `vercel.json` (Root Directory)
```json
{
  "buildCommand": "dotnet build -c Release",
  "devCommand": "dotnet run",
  "outputDirectory": "bin/Release/net10.0/publish",
  "framework": "dotnet",
  "env": {
    "ASPNETCORE_ENVIRONMENT": "Production",
    "ASPNETCORE_URLS": "http://0.0.0.0:3000"
  }
}
```

### 2. Create `.vercelignore` (Root Directory)
```
# Ignore build artifacts
bin/
obj/
.git/
.gitignore
*.user
*.suo
.vs/
.vscode/
node_modules/
npm-debug.log
.DS_Store
```

---

## Deployment to 2 URLs (Staging & Production)

### **Option A: Using Vercel CLI**

```bash
# Install Vercel CLI
npm install -g vercel

# Login to Vercel
vercel login

# Deploy to Staging
vercel --name thinkbridge-staging --prod=false --env ASPNETCORE_ENVIRONMENT=Staging

# Deploy to Production
vercel --name thinkbridge-prod --prod --env ASPNETCORE_ENVIRONMENT=Production
```

### **Option B: Using Vercel Dashboard (Recommended)**

1. Go to https://vercel.com/
2. Sign in with GitHub
3. **Create Staging Service:**
   - Click "Add New" → "Project"
   - Select your GitHub repo
   - Name: `thinkbridge-staging`
   - Environment: Add `ASPNETCORE_ENVIRONMENT=Staging`
   - Deploy

4. **Create Production Service:**
   - Click "Add New" → "Project"
   - Select your GitHub repo
   - Name: `thinkbridge-prod`
   - Environment: Add `ASPNETCORE_ENVIRONMENT=Production`
   - Deploy

---

## Environment Variables for Vercel

### Staging Environment
```
ASPNETCORE_ENVIRONMENT = Staging
ASPNETCORE_URLS = http://0.0.0.0:3000
```

### Production Environment
```
ASPNETCORE_ENVIRONMENT = Production
ASPNETCORE_URLS = http://0.0.0.0:3000
```

---

## Your URLs on Vercel

### Staging
- 🔗 Main: `https://thinkbridge-staging.vercel.app`
- 📖 Swagger: `https://thinkbridge-staging.vercel.app/api/docs`
- 📊 API: `https://thinkbridge-staging.vercel.app/api/invoice`

### Production
- 🔗 Main: `https://thinkbridge-prod.vercel.app`
- 📖 Swagger: `https://thinkbridge-prod.vercel.app/api/docs`
- 📊 API: `https://thinkbridge-prod.vercel.app/api/invoice`

---

## Quick Deploy Steps

1. **Add configuration files to repo:**
   ```bash
   # vercel.json and .vercelignore created locally
   git add vercel.json .vercelignore
   git commit -m "Add Vercel configuration for 2 environments"
   git push
   ```

2. **Deploy via Vercel Dashboard:**
   - Go to https://vercel.com
   - Click "Add New" → "Project"
   - Select GitHub repo
   - Click "Deploy"

3. **Repeat for staging** (change project name)

---

## Alternative: Deploy via Git

If using Vercel's GitHub integration (recommended):

1. Push code to GitHub
2. Connect repo to Vercel
3. Create 2 deployments:
   - One for staging (from `main` branch)
   - One for production (from `main` branch with different project name)
4. Auto-deploys on every push!

---

## Testing After Deployment

```bash
# Test Staging
curl https://thinkbridge-staging.vercel.app/api/invoice

# Test Production
curl https://thinkbridge-prod.vercel.app/api/invoice
```

---

## Summary

| Command | Purpose |
|---------|---------|
| `dotnet build -c Release` | Build command |
| `dotnet run --no-build -c Release --urls http://0.0.0.0:3000` | Run command |
| `vercel login` | Login to Vercel CLI |
| `vercel --name thinkbridge-staging` | Deploy staging |
| `vercel --name thinkbridge-prod --prod` | Deploy production |

Your app is ready for Vercel deployment! 🚀
