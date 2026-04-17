# Deploy to Render - Direct Cloud Deployment

## ✅ Ready for Production Deployment!

Your application is configured for **Render** with a **free PostgreSQL database** - NO local setup needed!

---

## 🚀 Deployment Steps (5 minutes)

### **Step 1:** Create Free Render Account
1. Go to https://render.com/
2. Sign up with GitHub account (recommended)
3. Verify email

### **Step 2:** Create PostgreSQL Database
1. Click **Dashboard** → **"New +"** → **"PostgreSQL"**
2. Fill in:
   - **Name:** `invoices-db`
   - **Database:** `invoices`
   - **User:** `invoices_user`
   - **Plan:** Free
3. Click **"Create Database"**
4. ⚠️ **IMPORTANT:** Copy the **External Database URL** (looks like `postgresql://user:pass@host:5432/db`)

### **Step 3:** Deploy Web Service
1. Click **Dashboard** → **"New +"** → **"Web Service"**
2. Select **"Deploy from a Git repository"**
3. Paste your GitHub URL: `https://github.com/unovajnv/thinkbridgeUI.git`
4. Click **"Connect"**

### **Step 4:** Configure Web Service
Fill in the form:

| Field | Value |
|-------|-------|
| **Name** | `thinkbridge-invoice` |
| **Environment** | `dotnet` |
| **Region** | `Ohio` (or closest to you) |
| **Branch** | `main` |
| **Build Command** | `dotnet build -c Release` |
| **Start Command** | `dotnet run --no-build --configuration Release --urls http://0.0.0.0:10000` |
| **Plan** | Free |

### **Step 5:** Add Database Connection Variable
1. Scroll to **Environment** section
2. Click **"Add Environment Variable"**
3. Create variable:
   - **Key:** `DATABASE_URL`
   - **Value:** (Paste the PostgreSQL URL from Step 2)
4. Click **"Save"**

### **Step 6:** Deploy!
1. Click **"Create Web Service"**
2. Render starts building automatically
3. ⏳ Wait 2-5 minutes for deployment
4. ✅ You'll see a **green checkmark** when ready
5. Your app URL appears at the top (like `thinkbridge-invoice.onrender.com`)

---

## 📱 Your Public URLs (After Deployment)

Once live, you'll have:

### **1️⃣ Invoice UI (Display)**
```
https://thinkbridge-invoice.onrender.com/
```
Shows the professional invoice display with items and total

### **2️⃣ Swagger API Documentation**
```
https://thinkbridge-invoice.onrender.com/api/docs
```
Interactive API documentation and testing interface

### **3️⃣ Direct API Endpoint**
```
https://thinkbridge-invoice.onrender.com/api/invoice/1
```
Returns JSON data

---

## ✨ What You Get (FREE Tier)

- ✅ Hosted .NET 10 application
- ✅ Free PostgreSQL database
- ✅ Free SSL/HTTPS certificate
- ✅ Automatic GitHub deployments
- ✅ Auto-sleep after 15 min inactivity (free tier)
- ✅ Professional production URLs
- ✅ Scalable infrastructure

---

## 🔄 Automatic GitHub Syncing

✅ **Setup Complete:** Your GitHub repo is linked to Render
- Every push to `main` branch = automatic redeploy
- No manual deployments needed
- See deployment logs in Render dashboard

---

## 💬 Common Questions

**Q: Do I need local PostgreSQL?**  
A: No! Everything runs in the cloud. DATABASE_URL is set by Render automatically.

**Q: Will the database persist?**  
A: Yes! Free PostgreSQL database persists your data.

**Q: How long does deployment take?**  
A: Usually 2-5 minutes depending on network.

**Q: Can I update my code?**  
A: Yes! Just push to GitHub and Render redeploys automatically.

**Q: What if deployment fails?**  
A: Check the **Logs** tab in Render dashboard for error messages.

---

## 🎯 Deployment Checklist

- [ ] Created Render account
- [ ] Created PostgreSQL database
- [ ] Copied DATABASE_URL
- [ ] Created Web Service
- [ ] Added DATABASE_URL environment variable
- [ ] Clicked "Create Web Service"
- [ ] Waited for deployment (green checkmark)
- [ ] Tested UI URL
- [ ] Tested Swagger URL

---

**Ready?** Deploy now and share your live URLs! 🚀

