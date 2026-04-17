# Deploy to Render (Free PostgreSQL Database)

## ✅ Code is Ready for Deployment!

Your application is now configured for **Render** with a **free PostgreSQL database**.

---

## 🚀 Step-by-Step Deployment Instructions

### Step 1: Create Render Account
1. Go to https://render.com/
2. Sign up (you can use GitHub account)
3. Verify email

### Step 2: Create PostgreSQL Database
1. In Render dashboard, click **"New +"** → **"PostgreSQL"**
2. Fill in details:
   - **Name:** `invoices-db`
   - **Database:** `invoices`
   - **User:** `invoices_user`
   - **Plan:** Free
3. Click **Create Database**
4. **Copy the connection string** (you'll need it in Step 4)
   - It looks like: `postgresql://user:password@hostname:5432/database`

### Step 3: Create Web Service
1. Click **"New +"** → **"Web Service"**
2. Choose **"Deploy from a Git repository"**
3. Paste your GitHub repo: `https://github.com/unovajnv/thinkbridgeUI.git`
4. Click **Connect**

### Step 4: Configure Web Service
Fill in these fields:

- **Name:** `thinkbridge-invoice`
- **Environment:** `dotnet`
- **Build Command:** `dotnet build -c Release`
- **Start Command:** `dotnet run --no-build --configuration Release --urls http://0.0.0.0:10000`
- **Plan:** Free

### Step 5: Add Environment Variable
1. Scroll down to **Environment** section
2. Click **"Add Environment Variable"**
3. Add this variable:
   - **Key:** `DATABASE_URL`
   - **Value:** (paste the PostgreSQL connection string from Step 2)
4. Click **Save**

### Step 6: Deploy
1. Click **"Create Web Service"**
2. Render will automatically:
   - Build the application
   - Create the database
   - Deploy and start the service
3. Wait for deployment to complete (2-5 minutes)
4. You'll see a **green checkmark** when ready

---

## 📱 After Deployment - Your URLs

Once deployed, you'll have:

**UI URL:** `https://thinkbridge-invoice.onrender.com/`
- Shows the invoice display

**API/Swagger URL:** `https://thinkbridge-invoice.onrender.com/api/docs`
- Interactive Swagger documentation

**API Endpoint:** `https://thinkbridge-invoice.onrender.com/api/invoice/1`
- Returns JSON invoice data

---

## 🔄 Continuous Deployment

✅ Your GitHub repository is connected to Render, so:
- Every time you push to `main` branch, Render will automatically rebuild and redeploy
- No manual deployment needed for future updates

---

## 💡 Troubleshooting

### Application Not Starting?
- Check **Logs** tab in Render dashboard
- Verify `DATABASE_URL` environment variable is set correctly
- Make sure PostgreSQL database is created first

### Database Connection Error?
- Copy the full connection string from Render PostgreSQL dashboard
- Paste it exactly into `DATABASE_URL` environment variable
- Restart the web service

### Still Having Issues?
- Clear build cache: Settings → Clear build cache → Trigger deploy
- Redeploy manually from dashboard

---

## ✨ Features Deployed

- ✅ Full ASP.NET Core 10.0 application
- ✅ PostgreSQL database integration
- ✅ Swagger API documentation
- ✅ Professional invoice UI
- ✅ CORS enabled
- ✅ Automatic GitHub sync
- ✅ Free tier (no credit card needed after trial)

---

**Happy deploying!** 🎉
