# Практическая работа №6 (часть 3) – Unit-тесты авторизации и регистрации

## 1. Таблица Users
![Users](screenshots/users.png)

## 2. Результаты тестов
![Test Explorer](screenshots/test_explorer.png)

Все тесты пройдены успешно.

### Авторизация (`Cinema.AuthorizationTests`)
- `AuthTestSuccess` – вход всех пользователей из БД ✅  
- `AuthTestFail` – негативные сценарии (пустые поля, неверный пароль, несуществующий логин) ✅  

### Регистрация (`Cinema.RegistrationTests`)
- `RegisterTestSuccess` – создание нового пользователя ✅  
- `RegisterTestFail` – пустые поля, дублирование email ✅  

## 3. Вывод
Тесты успешно выполнены, так как:
- Методы `Auth` и `Register` корректно обрабатывают валидные/невалидные данные.
- Обработаны все негативные сценарии (пустые поля, дублирование email, неверный пароль).
- Подключение к БД настроено через `App.config`, тесты используют те же данные, что и приложение.

## 4. SQL-скрипт
[`CinemaDB.sql`](CinemaDB.sql)

## 5. Репозиторий
[https://github.com/ваш_логин/cinema](https://github.com/ваш_логин/cinema)
