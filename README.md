# Project Setup

To set up this project, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/sashanazarchuk/First-App.git

2. Navigate to the root of the project:

   ```bash
   cd First-App/TaskBoard/
   ```
3. Build the project:

   ```bash
   docker-compose build
   ```
4. Run the project:

   ```bash
   docker-compose up
   ```
Access the ASP.NET Core Web API at http://localhost:2040/swagger/index.html

# PostgreSQL Configuration
To connect to PostgreSQL, use the following configuration:
   
   ```bash
POSTGRES_DB: taskdb
POSTGRES_USER: postgres
POSTGRES_PASSWORD: 12345
ports:
   - "5438:5432"
