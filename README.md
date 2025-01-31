# Motor Selection Backend

Motor Selection Backend is a .NET 8 Minimal API project designed to assist users in selecting the most suitable motorcycle based on various personal and technical criteria. The project leverages **MSSQL** with **Entity Framework Core (Code-First)**, ensuring a scalable and structured database. It is designed with **RESTful API principles** and provides a clear and interactive documentation via **Swagger**.

## 🚀 Project Purpose
This project serves multiple objectives:
- 📌 **Showcase Skills**: Demonstrates proficiency in **.NET 8**, **MSSQL**, **Minimal API**, **Entity Framework Core**, and **REST API design**.
- 🔍 **Active Development**: Highlights continuous development and contributions to real-world applications.
- 🏍️ **Motorcycle Recommendation**: Provides structured data and algorithms for intelligent motorcycle selection.

## ⚙️ Technologies & Tools
- **.NET 8 Minimal API**
- **MSSQL & Entity Framework Core (Code-First)**
- **Swagger for API Documentation**
- **Serilog for Logging**
- **Dependency Injection & Middleware Configuration**

## 📌 Features
- **User & Motorcycle Management**: CRUD operations for users and motorcycles.
- **Smart Selection Algorithm**: Recommends motorcycles based on user preferences.
- **Secure API**: Implements authentication & authorization mechanisms (to be added).
- **Logging & Monitoring**: Uses Serilog for structured logging.

## 🔧 Setup & Installation
1. **Clone the Repository**
```sh
git clone https://github.com/IbrahimOrdo/motor-selection-backend.git
cd motor-selection-backend
```
2. **Configure Database Connection**
- Update the `appsettings.json` file with your **MSSQL** connection string.

3. **Run the Application**
```sh
dotnet run
```

4. **Access Swagger API Docs**
- Navigate to: `http://localhost:5000/swagger/index.html`

## 📌 Roadmap
- ✅ Initial API Endpoints
- 🔄 Motorcycle Selection Algorithm Improvement
- 🔐 Authentication & Authorization
- 📊 Data Visualization for User Insights

## 📫 Contribution & Contact
This project is actively maintained by [Ibrahim Ordo](https://github.com/IbrahimOrdo). Contributions are welcome! Feel free to open issues or pull requests.

---

> **Note:** This project is part of a broader initiative to build a full-fledged motorcycle recommendation system, combining **ML models** and **real-world data** in future iterations.

