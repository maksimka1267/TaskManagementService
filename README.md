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

<img width="1095" height="274" alt="image" src="https://github.com/user-attachments/assets/7bca1262-dbce-4fb5-8f3a-7dc6ac17fa81" />


---
