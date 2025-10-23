# 🧩 Technical Challenge – In-Memory Customer CRUD API

## 📘 Overview
This project is part of a **technical assessment**.  
The goal is to build a simple **Customer CRUD API** in **.NET (C#)** that stores data **in memory** instead of using a database, while following a **layered architecture**.

---

## 🧱 Architecture
The solution must follow a **layered structure**, separating responsibilities into three main layers:

```
src/
 ├── Controllers/   # Handles HTTP requests/responses
 ├── Services/      # Contains business logic and validation
 └── Models/        # Contains entities and DTOs
```

Each layer should be independent and communicate only through well-defined contracts (interfaces or DTOs).

---

## ⚙️ Requirements
- .NET 8.0 SDK (or .NET 6.0+)
- No external database — all data should be stored in **memory**.
- Use **ConcurrentDictionary** or similar for in-memory storage.

---

## 🚀 How to Run

```bash
# Clone the repository
# Run the application
dotnet run
```

Once running, open your browser or use an API client like **Postman** or **curl** to access:

**Swagger UI:**  
```
http://localhost:5000/swagger
```

**Base URL:**  
```
http://localhost:5000/api/customers
```

---

## 🧩 Endpoints

| Method | Endpoint | Description |
|--------|-----------|-------------|
| `GET` | `/api/customers` | List all customers |
| `GET` | `/api/customers/{id}` | Get a specific customer by ID |
| `POST` | `/api/customers` | Create a new customer |
| `PUT` | `/api/customers/{id}` | Update an existing customer |
| `DELETE` | `/api/customers/{id}` | Delete a customer |

### Example JSON Payload

**POST /api/customers**
```json
{
  "name": "John Doe",
  "email": "john.doe@example.com"
}
```

**PUT /api/customers/1**
```json
{
  "name": "Johnathan Doe",
  "email": "john.doe@example.com"
}
```

---

## 🧠 Validations
- `Name` is **required** and must have at least **3 characters**.  
- `Email` is **required**, must be **valid**, and **unique** across customers.

---

## 🧰 Optional Bonus
- Implement **unit tests** for the Service layer using **xUnit** or **NUnit**.

---

## 🧾 Project Goals
- Demonstrate understanding of:
  - Layered architecture
  - Clean and maintainable code
  - RESTful API best practices
  - Basic validation and error handling

