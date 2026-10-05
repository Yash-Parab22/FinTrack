# FinTrack — Personal Finance REST API

A backend REST API built with C# and ASP.NET Core for personal finance tracking.

## Tech Stack

- C# / ASP.NET Core
- Scalar / OpenAPI for API documentation

## Running the Project

```bash
dotnet run
```

API will be available at `http://localhost:5100`

## API Documentation

Once running, open Scalar UI:

```
http://localhost:5100/scalar/v1
```

All endpoints can be tested directly from Scalar.

## Endpoints

### Accounts

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/accounts | Get all accounts |
| GET | /api/accounts/{id} | Get account by ID |
| GET | /api/accounts/{id}/transactions | Get all transactions for an account |
| POST | /api/accounts | Create a new account |
| PUT | /api/accounts/{id} | Update an account |
| DELETE | /api/accounts/{id} | Delete an account |

### Transactions

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/transactions | Get all transactions |
| GET | /api/transactions/{id} | Get transaction by ID |
| POST | /api/transactions | Create a new transaction |
| DELETE | /api/transactions/{id} | Delete a transaction |

## Sample Requests

### Create an Account
```json
POST /api/accounts
{
  "name": "Savings",
  "type": "Savings",
  "balance": 5000
}
```

### Create a Transaction
```json
POST /api/transactions
{
  "accountId": 1,
  "amount": 100,
  "date": "2026-12-13T10:05:01",
  "description": "Salary",
  "category": "Income",
  "type": 0
}
```

Transaction types:
- `0` = Income
- `1` = Expense  
- `2` = Transfer

## Project Structure

```
Controllers/     — HTTP endpoints
Services/        — Business logic
Models/          — Domain entities
DTOs/            — Request/response objects
```