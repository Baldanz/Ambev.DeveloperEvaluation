# Developer Evaluation Project

`READ CAREFULLY`

## Instructions
**The test consists in the backend .NET 8.0.**

- Select the docker-compose project to generate images in docker
- In Program.cs, line 90, uncomment the app.ApplyMigrations() to generate the tables based on Migrations
- Check if tables Carts, Products, ProductsInCart, ProductsInSales, Ratings, Sales, Users and __EFMigrationsHistory where created successfully
- The appsettings file contains the connection string to the postegree database
- "DefaultConnection": "Host=ambev.developerevaluation.database;Port=5432;Database=developer_evalutation;Database=developer_evalutation;Username=developer;Password=ev@luAt10n;TrustServerCertificate=True" 
- However, if no connection with connString above, uncomment the line above, and start the project Ambev.DeveloperEvaluation.Api in https mode
- Both startups projects retrives the swagger document, with all endpoints for the api

### Business Rules implemented

* Purchases above 4 identical items have a 10% discount
* Purchases between 10 and 20 identical items have a 20% discount
* It's not possible to sell above 20 identical items
* Purchases below 4 items cannot have a discount

These business rules define quantity-based discounting tiers and limitations:

1. Discount Tiers:
   - 4+ items: 10% discount
   - 10-20 items: 20% discount

2. Restrictions:
   - Maximum limit: 20 items per product
   - No discounts allowed for quantities below 4 items

## API Structure
This section includes links to the detailed documentation for the different API resources:
<!--
- [Users API]
- [Sales API]
- [Products API]
- [Carts API]
- [Auth API]
-->

## Execute the User Post to create a user
#### POST /users
- Description: Add a new user
- Request Body:
  ```json
{
  "userName": "string",
  "password": "string",
  "phone": "string",
  "email": "string",
  "status": 1,
  "role": 1
}
Response: 
  ```json
  {
  "data": {
    "id": "9eb4c7bb-a338-4674-b65a-c9514e9810d6",
    "userName": "string",
    "email": "string",
    "phone": "string",
    "role": 1 ( Customer = 1, Manager = 2, Admin = 3 ),
    "status": 1 ( Active = 1, Inactive = 2, Suspended = 3 )
  },
  "success": true,
  "message": "User created successfully",
  "errors": []
  }
  ```
## Endpoints execution with bearer token authentication and authorization
#### Auth 
- Description: generates a bearer token by user registered
- Request Body:
  ```json
{
  "email": "string",
  "password": "string"
}
Response: 
  ```json
{
  "data": {
    "data": {
      "token": "string" (get the token to authorize,
      "email": "string",
      "name": "string",
      "role": "Customer"
    },
    "success": true,
    "message": "User authenticated successfully",
    "errors": []
  },
  "success": true,
  "message": "",
  "errors": []
}
  ```
#### Authorization
- Bearer (apiKey)
JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')

Name: Authorization

In: header

Value: bearer "generated token"

#### POST /products
- Description: Add a new product
- Request Body:
  ```json
{
  "title": "string",
  "description": "string",
  "category": "string",
  "image": "string",
  "price": 0,
  "rate": {
    "rate": 0,
    "count": 0
  }
}
Response: 
  ```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "id": "string",
      "message": "string"
    }
  ],
  "data": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "title": "string",
    "description": "string",
    "category": "string",
    "image": "string",
    "price": 0,
    "rating": {
      "rate": 0,
      "count": 0
    }
  }
}
  ```
#### POST /cart
- Description: Add a new cart
- Request Body:
  ```json
{
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "products": [{
  "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "quantity": 0
}]
}
Response: 
  ```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "id": "string",
      "message": "string"
    }
  ],
  "data": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "createdAt": "2025-04-03T08:18:24.864Z",
    "products": [
      {
        "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "quantity": 0
      }
    ]
  }
}  
  ```
#### POST /sales
- Description: Add a new sale based on products in carts and user
- Request Body:
  ```json

  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "saleDate": "2025-04-03T08:20:25.902Z",
  "saleBranch": "string",
  "products": [
    {
      "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "quantity": 0
    }
  ]
}
Response: 
  ```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "id": "string",
      "message": "string"
    }
  ],
  "data": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "saleDate": "2025-04-03T08:20:25.903Z",
    "products": [
      {
        "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "quantity": 0
      }
    ]
  }
}
  ```
- the discounts for the products are validated in SalesController, line 121, method GetDiscountsOverProductQuantity();

## Paginated Lists (pageNumber = 1},{pageSize = 10} => default values
#### GET /carts
/api/Cart/{pageNumber},{pageSize}

#### GET /product
/api/Product/{pageNumber},{pageSize}
/api/Product/category/{pageNumber},{pageSize}
/api/Product/category/{category},{pageNumber},{pageSize}

#### GET /sales
/api/Sales/{pageNumber},{pageSize}

#### GET /user
/api/User/{pageNumber},{pageSize}

## Completed Crud

#### POST /user
/api/User

#### PUT /user
/api/User

#### GET /user
/api/User/{id}
/api/User/{pageNumber},{pageSize}

#### DELETE /user
/api/User/{id}

## Unit Tests
Ambev.DeveloperEvaluation.Unit
UserTests

## ProjectStructure
- Ambev.DeveloperEvaluation.Api --> WebApi
- Ambev.DeveloperEvaluation.Application --> Core Business
- Ambev.DeveloperEvaluation.Common --> Extension Services
- Ambev.DeveloperEvaluation.Entities --> Domain
- Ambev.DeveloperEvaluation.ORM --> Repository
- Ambev.DeveloperEvaluation.Unit --> XUnit Tests
- Ambev.DeveloperEvaluation.UoW --> Unit of Work
- Ambev.DeveloperEvaluation.IoC --> Dependency Injection
