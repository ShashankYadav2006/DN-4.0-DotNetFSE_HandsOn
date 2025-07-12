
# Week 4 ASP.NET Core 8.0 Web API – Hands-on Tasks

## Project Overview
This project includes all the implementation tasks assigned during **Week 4 of DN4.0 Skilling**, focusing on **ASP.NET Core 8.0 Web API**. It covers Swagger setup, filters, JWT authentication, and role-based authorization.

---

## Task Summary

### Task 1: Setup and Basic API
- Created a simple Web API project using ASP.NET Core 8.0.
- Implemented `EmployeeController` with:
  - `GET`: Retrieve employee list
  - `PUT`: Update employee by ID
- Used `[ApiController]`, `[HttpGet]`, `[HttpPut]`, and appropriate response annotations.

### Task 2: Swagger Integration
- Added `Swashbuckle.AspNetCore` for Swagger UI support.
- Configured metadata including:
  - API Title, Version, Description, Terms, Contact, License
- Used `[ProducesResponseType]` for clear documentation of responses.

### Task 3: Custom Filters
- Created:
  - `CustomAuthFilter` using `ActionFilterAttribute`
    - Validates `Authorization` header and bearer token presence.
  - `CustomExceptionFilter` implementing `IExceptionFilter`
    - Logs unhandled exceptions to a file and returns generic 500 message.
- Registered both globally and via `[ServiceFilter]`.

### Task 4: JWT Authentication & Role-Based Authorization
- Created `AuthController` to generate JWT tokens.
  - Added `Admin` and `POC` roles in claims.
  - Symmetric key used with HMAC SHA256 algorithm.
- Used `[Authorize(Roles = "Admin,POC")]` in `EmployeeController`.
- Tested token-based access via Postman:
  - Valid role token → 200 OK
  - Invalid/missing role → 401 Unauthorized

### Task 5: Final Integration and Testing
- Corrected token issues by using a 256-bit+ secret key.
- Verified middleware order: `UseAuthentication()` before `UseAuthorization()`.
- Successfully tested role-restricted endpoints in Postman using tokens.
- All tasks build and run successfully with Swagger and JWT features.

---

## Testing Instructions

1. **Build and Run**  
   ```bash
   dotnet build
   dotnet run
   ```

2. **Swagger Access**  
   Visit: `http://localhost:<port>/swagger`

3. **Generate JWT Token**
   ```
   GET /api/auth/get-token
   ```

4. **Use Postman to Authorize**
   - Add header:  
     ```
     Authorization: Bearer <your_token_here>
     ```

5. **Access Secure Endpoint**
   ```
   GET /api/employee
   ```

---

## Tech Stack
- ASP.NET Core 8.0
- C#
- Swagger (Swashbuckle)
- JWT Authentication
