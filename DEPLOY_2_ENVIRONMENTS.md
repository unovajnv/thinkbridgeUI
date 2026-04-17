# Deploy to 2 URLs - Staging & Production

Your code is now committed and pushed to GitHub. Here's how to deploy to **2 different URLs** (Staging and Production environments).

---

## 🎯 Architecture
```
GitHub Repository (Main Branch)
    ↓
    ├──→ Render Service #1: STAGING → https://thinkbridge-staging.onrender.com
    └──→ Render Service #2: PRODUCTION → https://thinkbridge-prod.onrender.com
```

---

## 📋 Prerequisites
- ✅ GitHub Account (with your code pushed)
- ✅ Render Account (free at https://render.com/)
- ✅ Code committed and pushed ✓ Done!

---

## 🚀 Step-by-Step: Deploy to 2 URLs

### **ENVIRONMENT 1: STAGING** (Testing)

#### Step 1.1: Login to Render
1. Go to https://render.com/
2. Sign in with GitHub
3. Click **"Dashboard"**

#### Step 1.2: Create Staging Web Service
1. Click **"New +"** → **"Web Service"**
2. Select **"Deploy from a Git repository"**
3. Paste your GitHub repo URL
4. Click **"Connect"**

#### Step 1.3: Configure Staging Service
Fill in the form:

| Field | Value |
|-------|-------|
| **Name** | `thinkbridge-staging` |
| **Environment** | `dotnet` |
| **Region** | Select closest to you |
| **Branch** | `main` |
| **Build Command** | `dotnet build -c Release` |
| **Start Command** | `dotnet run --no-build -c Release --urls http://0.0.0.0:10000` |
| **Plan** | **Free** |

#### Step 1.4: Environment Variables (Staging)
Since we're using dummy data now, you don't need DATABASE_URL!

Add these variables:
```
ASPNETCORE_ENVIRONMENT = Staging
ASPNETCORE_URLS = http://0.0.0.0:10000
```

#### Step 1.5: Deploy Staging
1. Click **"Create Web Service"**
2. Wait for deployment (2-5 minutes)
3. ✅ You'll get URL: `https://thinkbridge-staging.onrender.com`

---

### **ENVIRONMENT 2: PRODUCTION** (Live)

#### Step 2.1: Create Production Web Service
1. Go to Render Dashboard
2. Click **"New +"** → **"Web Service"**
3. Select **"Deploy from a Git repository"**
4. Paste your GitHub repo URL
5. Click **"Connect"**

#### Step 2.2: Configure Production Service
Fill in the form:

| Field | Value |
|-------|-------|
| **Name** | `thinkbridge-prod` |
| **Environment** | `dotnet` |
| **Region** | Select closest to you |
| **Branch** | `main` |
| **Build Command** | `dotnet build -c Release` |
| **Start Command** | `dotnet run --no-build -c Release --urls http://0.0.0.0:10000` |
| **Plan** | **Free** |

#### Step 2.3: Environment Variables (Production)
```
ASPNETCORE_ENVIRONMENT = Production
ASPNETCORE_URLS = http://0.0.0.0:10000
```

#### Step 2.4: Deploy Production
1. Click **"Create Web Service"**
2. Wait for deployment (2-5 minutes)
3. ✅ You'll get URL: `https://thinkbridge-prod.onrender.com`

---

## 🌐 Your 2 Public URLs

### **URL 1: STAGING** (For Testing)
```
🔗 https://thinkbridge-staging.onrender.com
📖 https://thinkbridge-staging.onrender.com/api/docs (Swagger)
📊 https://thinkbridge-staging.onrender.com/api/invoice (API)
```

### **URL 2: PRODUCTION** (Live/Public)
```
🔗 https://thinkbridge-prod.onrender.com
📖 https://thinkbridge-prod.onrender.com/api/docs (Swagger)
📊 https://thinkbridge-prod.onrender.com/api/invoice (API)
```

---

## 🔄 Automatic Updates

Both services are now connected to your GitHub repository:

✅ **How it works:**
1. You make changes locally
2. Commit and push to `main` branch
3. Render automatically:
   - Detects the push
   - Rebuilds the application
   - Deploys to BOTH staging AND production

**Example Workflow:**
```
git add .
git commit -m "Feature: Add new invoice types"
git push origin main
   ↓
   ├─ Staging rebuilds and deploys → https://thinkbridge-staging.onrender.com
   └─ Production rebuilds and deploys → https://thinkbridge-prod.onrender.com
```

---

## 📊 Testing Your Deployment

### Test Staging Environment
```
# Get all invoices
https://thinkbridge-staging.onrender.com/api/invoice

# Get specific invoice
https://thinkbridge-staging.onrender.com/api/invoice/1

# Swagger UI
https://thinkbridge-staging.onrender.com/api/docs
```

### Test Production Environment
```
# Get all invoices
https://thinkbridge-prod.onrender.com/api/invoice

# Get specific invoice
https://thinkbridge-prod.onrender.com/api/invoice/1

# Swagger UI
https://thinkbridge-prod.onrender.com/api/docs
```

---

## 🛠️ Troubleshooting

### Issue: Build fails
- Check Render logs in Dashboard → Service → Logs
- Ensure `dotnet build` runs locally: `cd ThinkBridge && dotnet build`

### Issue: Port errors
- The start command uses port `10000` (internal)
- Render automatically exposes on standard HTTPS/HTTP

### Issue: Service auto-sleeps
- Free tier sleeps after 15 min of inactivity
- First request will take longer to wake up (~30 sec)
- To avoid: Use Paid tier (start at $7/month)

---

## 🎯 Next Steps

1. ✅ Code committed and pushed
2. ➡️ Go to https://render.com/ and create BOTH services (steps above)
3. ➡️ Test both URLs
4. ➡️ Share staging URL for team testing
5. ➡️ Share production URL publicly

---

## 💡 Cost (100% FREE)

- ✅ 2 Render Web Services: Free
- ✅ Custom domains: Optional (paid extra)
- ✅ Automatic deployments: Free
- ✅ SSL/HTTPS: Free

---

## 🚀 Your Deployment Is Ready!

**Current Status:**
- ✅ Code committed: `Convert to dummy data - remove database dependency`
- ✅ Code pushed to GitHub
- ✅ Ready for deployment

**Next Action:** Go to Render dashboard and create the 2 services!

---

## 📞 Quick Reference

**Staging Service Details:**
- Name: `thinkbridge-staging`
- URL: `https://thinkbridge-staging.onrender.com`
- Branch: `main`
- Environment: `Staging`

**Production Service Details:**
- Name: `thinkbridge-prod`
- URL: `https://thinkbridge-prod.onrender.com`
- Branch: `main`
- Environment: `Production`

Both pull from the same GitHub repo and deploy automatically on every push!
