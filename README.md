# IMDB API

This repository contains a .NET Web API for managing CRUD operations related to the IMDB database. It provides endpoints for interacting with entities such as Movies, Actors, Producers, and Genres.

## Features
- Create, Read, Update, and Delete (CRUD) operations for:
  - Movies
  - Actors
  - Producers
  - Genres
- Relationships handling (e.g., linking actors to movies, genres to movies).
- RESTful architecture.
- Service - Repository Pattern
- Behaviour Driven Development using SpecFlow
- File upload support (e.g., movie posters via Firebase Storage).

## Prerequisites

- [.NET 8 or later](https://dotnet.microsoft.com/)
- A database management system (e.g., Microsoft SQL Server) with the IMDB database schema set up.
- A configured connection string to the database.

## Setup and Installation

### 1. Clone the Repository
```bash
git clone https://github.com/akumar-9/imdb-api.git
cd imdb-api
```

### 2. Configure the Database Connection
- Open the `appsettings.json` file.
- Update the `ConnectionStrings` section with your database details:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=IMDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
  }
  ```

### 3. Run the Application
- Restore dependencies:
  ```bash
  dotnet restore
  ```
- Build the application:
  ```bash
  dotnet build
  ```
- Run the API:
  ```bash
  dotnet run
  ```
- The API will be available at `http://localhost:5000` (default).

## Endpoints

### Actors
| Method | Endpoint               | Description                 |
|--------|------------------------|-----------------------------|
| GET    | `/actors`              | Retrieve all actors         |
| GET    | `/actors/{id}`         | Retrieve an actor by ID     |
| POST   | `/actors`              | Create a new actor          |
| PUT    | `/actors/{id}`         | Update an existing actor    |
| DELETE | `/actors/{id}`         | Delete an actor by ID       |

### Genres
| Method | Endpoint               | Description                 |
|--------|------------------------|-----------------------------|
| GET    | `/genres`              | Retrieve all genres         |
| GET    | `/genres/{id}`         | Retrieve a genre by ID      |
| POST   | `/genres`              | Create a new genre          |
| PUT    | `/genres/{id}`         | Update an existing genre    |
| DELETE | `/genres/{id}`         | Delete a genre by ID        |

### Movies
| Method | Endpoint               | Description                     |
|--------|------------------------|---------------------------------|
| GET    | `/movies`              | Retrieve all movies             |
| GET    | `/movies/{id}`         | Retrieve a movie by ID          |
| POST   | `/movies`              | Create a new movie              |
| PUT    | `/movies/{id}`         | Update an existing movie        |
| DELETE | `/movies/{id}`         | Delete a movie by ID            |
| POST   | `/movies/upload`       | Upload a movie poster (Firebase)|

### Producers
| Method | Endpoint                 | Description                   |
|--------|--------------------------|-------------------------------|
| GET    | `/producers`             | Retrieve all producers         |
| GET    | `/producers/{id}`        | Retrieve a producer by ID      |
| POST   | `/producers`             | Create a new producer          |
| PUT    | `/producers/{id}`        | Update an existing producer    |
| DELETE | `/producers/{id}`        | Delete a producer by ID        |

## Testing

Use tools like [Postman](https://www.postman.com/) or [cURL](https://curl.se/) to test the endpoints.

### Example cURL Command
To create a new actor:
```bash
curl -X POST http://localhost:5000/actors \
-H "Content-Type: application/json" \
-d '{"Name":"John Doe","DOB":"1980-01-01","Gender":"Male"}'
```

To upload a movie poster:
```bash
curl -X POST http://localhost:5000/movies/upload \
-F "poster=@path_to_poster.jpg"
```

## License

This project is licensed under the [MIT License](LICENSE).

