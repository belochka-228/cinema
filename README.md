# Практическая работа №6 (часть 3) – Unit-тесты авторизации и регистрации

## 1. Таблица Users
<img width="600" height="132" alt="image" src="https://github.com/user-attachments/assets/836b41e0-7e07-4928-8f6d-c93bc341d497" />

## 2. Результаты тестов
<img width="799" height="332" alt="image" src="https://github.com/user-attachments/assets/61706af9-ec8a-4e3c-a8ff-8b9b6fe045c6" />
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
