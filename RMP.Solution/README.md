## Run with Docker

Build the Docker image:
```bash
docker build -t rmp-api .
```

Run the application:
```bash
docker run -p 8080:8080 rmp-api
```

Open the Swagger UI in your browser:
```md
http://localhost:8080/swagger
```

## Run with Docker Compose

Instead of running the Docker image manually, we can use Docker Compose to build and run the application along with configuration for the database.

Build and start the containers:
```bash
docker compose up --build
```

Stop the containers:
```bash
docker compose down
```

Access the application

Swagger UI: http://localhost:8080/swagger

Health endpoint: http://localhost:8080/health

**Note:** The SQLite database is persisted in the ./data folder on your host machine. This ensures that your data is not lost when the container is stopped or removed.