# BookHub

BookHub is a console-based book management application built in C#. 
It provides a simple menu-driven interface for users and administrators to interact with a book catalog, 
with role-based access separating regular user actions from admin-level management.

## Features

- **Authentication** — Login and registration flow for new and existing users
- **Role-based access** — Separate experiences for `User` and `Admin` accounts
- **Book management** — Admins can manage the book catalog (add, update, remove, etc.)
- **User interactions** — Users can browse and interact with available books
- **Input validation** — Dedicated validators ensure clean, consistent data
- **Clean architecture** — Organized into Models, Services, Helpers, Validators, Enums, and Config layers for maintainability

## Usage

On launch, you'll be presented with a menu offering:

1. **Login** — Sign in with an existing account
2. **Register** — Create a new account
0. **Exit** — Close the application

Depending on whether you log in as a `User` or `Admin`, you'll be routed to the corresponding 
menu with role-specific actions.

## Architecture Overview

BookHub follows a layered design:

- **Models** define the core domain entities, split into `Base` (shared/abstract types like `Person`) and `Derived` (concrete types like `User` and `Admin`)
- **Services/Implementations** contain the business logic (e.g. `AuthorizationService` handles login/registration)
- **Helpers** provide reusable utilities for menus and role-specific flows (`MenuHelper`, `UserHelper`, `AdminHelper`)
- **Validators** enforce data integrity before it reaches the service layer
- **Enums** and **Config** centralize shared constants and settings