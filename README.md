# 🧩 Task Management Service

## Опис

Цей проєкт — простий REST API для управління завданнями.
Він дозволяє створювати завдання, переглядати їх і змінювати статуси лише за дозволеними правилами.

Мета — показати базові навички роботи з ASP.NET Core, InMemory сховищем і юніт-тестами.

---

## 🔧 Технології

* C# / .NET 9
* ASP.NET Core Web API
* InMemory repository
* xUnit (тестування)

---

## 📌 Статуси завдань

* **Backlog** → **InWork** → **Testing** → **Done**

Інші переходи заборонені.

---

## 🚀 Як запустити

### 1. Клонувати репозиторій

```bash
git clone https://github.com/maksimka1267/TaskManagementService.git
cd TaskManagementService
```

### 2. Запустити API (локально)

```bash
dotnet build
dotnet run --project src/TaskManagementService/TaskManagementService.csproj
```

### 3. Запустити тести

```bash
dotnet test
```

---

## 📸 Результати тестів

<img width="1090" height="268" alt="image" src="https://github.com/user-attachments/assets/f92ce92a-8889-4168-9382-86a0c840bf26" />



---
