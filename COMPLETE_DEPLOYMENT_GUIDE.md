# Complete Deployment Guide for ThinkBridge

Your application is ready for deployment! Here's the complete guide for multiple platforms.

---

## 🎯 Current Status

✅ **Code committed and pushed to GitHub**
✅ **Vercel build in progress** (or completed)
✅ **Ready for 2 environment deployment** (Staging & Production)

---

## 📋 Deployment Options

### **Option 1: Vercel (Currently Building)** ⭐ RECOMMENDED

**Status:** Your build is already running!

#### What's Happening:
1. Vercel cloned your GitHub repo
2. Running: `dotnet restore`
3. Running: `dotnet build -c Release && dotnet publish -c Release -o out`
4. Deploying the `out` folder

#### Monitor Build:
- Go to: https://vercel.com/dashboard
- Select your project
- View logs in real-time

#### After Deployment:
You'll get URLs like:
```
https://thinkbridge-staging.vercel.app
https://thinkbridge-prod.vercel.app
```

**Pros:** Fast, easy, auto-deploys on git push
**Cons:** Free tier has limitations

---

### **Option 2: Render** ⭐ FREE TIER

Best for: Stable free hosting with no auto-sleep

#### Deploy Steps:

1. **Go to:** https://render.com/
2. **Click:** "New +" → "Web Service"
3. **Connect GitHub** and select your repo
4. **Fill in:**
   - Name: `thinkbridge-staging` (or `-prod`)
   - Environment: `dotnet`
   - Build Command: `dotnet build -c Release`
   - Start Command: `dotnet run --no-build -c Release --urls http://0.0.0.0:10000`
   - Plan: **Free**

5. **Add Environment Variables:**
   ```
   ASPNETCORE_ENVIRONMENT = Production
   ASPNETCORE_URLS = http://0.0.0.0:10000
   ```

6. **Click Deploy**

#### Your URLs:
```
https://thinkbridge-staging.onrender.com
https://thinkbridge-prod.onrender.com
```

**Pros:** Truly free, no auto-sleep, simple
**Cons:** Slower builds than Vercel

---

### **Option 3: Azure App Service**

Best for: Enterprise, powerful features, free tier available

#### Deploy Steps:

1. **Install Azure CLI:** https://docs.microsoft.com/en-us/cli/azure/install-azure-cli
2. **Login:**
   ```bash
   az login
   ```
3. **Create Resource Group:**
   ```bash
   az group create --name thinkbridge-rg --location eastus
   ```
4. **Create App Service Plan:**
   ```bash
   az appservice plan create --name thinkbridge-plan --resource-group thinkbridge-rg --sku F1 --is-linux
   ```
5. **Create Web App:**
   ```bash
   az webapp create --resource-group thinkbridge-rg --plan thinkbridge-plan --name thinkbridge-app --runtime "DOTNET|10.0"
   ```
6. **Deploy from GitHub:**
   ```bash
   az webapp deployment source config-zip --resource-group thinkbridge-rg --name thinkbridge-app --src ./publish.zip
   ```

#### Your URL:
```
https://thinkbridge-app.azurewebsites.net
```

**Pros:** Powerful, scalable, enterprise-ready
**Cons:** More complex setup

---

## 🚀 Quick Deployment Summary

### **If using Vercel (CURRENT):**

**Step 1: Wait for Build**
- Check: https://vercel.com/dashboard
- Status should change from "Building" to "Ready"
- Typically takes 5-10 minutes

**Step 2: Create Staging & Production**
In Vercel Dashboard:
1. Click "Add New" → "Project"
2. Select your GitHub repo
3. Name: `thinkbridge-staging`
4. Click "Deploy"
5. Repeat with name `thinkbridge-prod`

**Step 3: Access Your Apps**
```
Staging:     https://thinkbridge-staging.vercel.app
Production:  https://thinkbridge-prod.vercel.app
Swagger:     /api/docs
API:         /api/invoice
```

---

### **If using Render (ALTERNATIVE):**

**Step 1: Create Staging**
- https://render.com → "New Web Service"
- Connect GitHub
- Name: `thinkbridge-staging`
- Build: `dotnet build -c Release`
- Start: `dotnet run --no-build -c Release --urls http://0.0.0.0:10000`
- Deploy

**Step 2: Create Production**
- Repeat with name `thinkbridge-prod`

**Step 3: Access Your Apps**
```
Staging:     https://thinkbridge-staging.onrender.com
Production:  https://thinkbridge-prod.onrender.com
```

---

## 🧪 Test Your Deployment

Once live, test these endpoints:

```bash
# Get all invoices
https://[your-url]/api/invoice

# Get invoice #1
https://[your-url]/api/invoice/1

# Swagger UI
https://[your-url]/api/docs

# Homepage
https://[your-url]/
```

**Expected Response:**
```json
[
  {
    "invoiceId": 1,
    "customerName": "Acme Corporation"
  },
  {
    "invoiceId": 2,
    "customerName": "Tech Solutions Inc"
  },
  {
    "invoiceId": 3,
    "customerName": "Digital Agency"
  }
]
```

---

## 🔄 Auto-Deployment Setup

Both Vercel and Render support **automatic deployment on git push**:

```bash
# Make a change
git add .
git commit -m "Update feature"
git push origin main

# Vercel/Render automatically:
# 1. Detects the push
# 2. Rebuilds your app
# 3. Deploys to BOTH staging and production
```

---

## 🐛 Troubleshooting

### **Build Fails on Vercel**

**Check Logs:**
1. Vercel Dashboard → Your Project → "Deployments" tab
2. Click the failed deployment
3. Scroll to "Build" section
4. Look for error messages

**Common Issues:**
- Missing `.csproj` file → Verify `ThinkBridge.csproj` exists
- Dependency errors → Run locally: `dotnet restore`
- Environment variables → Ensure `ASPNETCORE_URLS` is set

### **App Doesn't Start**

**Check:**
1. Port is correct (Vercel: 3000, Render: 10000)
2. `ASPNETCORE_ENVIRONMENT=Production`
3. `ASPNETCORE_URLS` is set
4. No database connection required (using dummy data ✓)

### **Getting 500 Errors**

**Test locally first:**
```bash
cd ThinkBridge
dotnet run
# Should start on http://localhost:5000
```

---

## 📊 Comparison: Vercel vs Render

| Feature | Vercel | Render |
|---------|--------|--------|
| **Setup** | Quick (5 min) | Medium (10 min) |
| **Build Time** | 3-5 min | 5-10 min |
| **Free Tier** | Yes (with limits) | Yes |
| **Auto-sleep** | 15 min | No |
| **Custom Domain** | Paid | Paid |
| **Auto-deploy** | Yes | Yes |
| **Cost** | From $5/mo | From $7/mo |

---

## ✅ Checklist

- ✅ Code committed and pushed
- ✅ `vercel.json` configured
- ✅ `.vercelignore` added
- ✅ Using dummy data (no database)
- ✅ `ThinkBridge.csproj` exists
- ✅ Environment variables ready
- ⏳ Build in progress on Vercel (or choose Render)

---

## 🎯 Next Steps

### **If Vercel is building:**
1. Wait for build to complete (5-10 min)
2. Check dashboard at https://vercel.com/dashboard
3. Once "Ready" → Click to view your app
4. Test the endpoints above

### **If starting fresh:**
1. Choose Vercel or Render
2. Follow the 3 steps in "Quick Deployment Summary"
3. Deploy takes 5-10 minutes
4. Test your URLs

---

## 📞 Get Help

**For Vercel issues:** https://vercel.com/docs/deployment-guides/deploying-dotnet
**For Render issues:** https://render.com/docs/deploy-dotnet

Your deployment is ready! 🚀
