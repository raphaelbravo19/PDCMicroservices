# PDC Microservices

This is a proof of concept of microservices using docker and docker compose to deploy services

## Usage

### Build a docker image
To build a docker image with specific params. Run it on the root project
```bash
docker build -t {{image-name}}:{{tag}} -f {{path-to-dockerfile}} .
```
Example:
```bash
docker build -t usersapi:v1 -f UsersApi/Dockerfile .
```

### Publish a docker image
To build a docker image with specific params. Run it on the root project
```bash
docker buildx create --name arch-builder --platform linux/arm64,linux/amd64 
docker buildx use arch-builder 
docker buildx build --platform linux/arm64,linux/amd64 --push -t raphaelbravo190813/usersapi:v1 -f UsersApi/Dockerfile .
```

### List all images
To list all docker images
```bash
docker images
```

### List all running containers
To list all running docker containers
```bash
docker ps
```

### Print logs of a specific container
To get the logs of a specifica container
```bash
docker logs {{container-id}}
```

### Stop a specific container
To stop a specific docker container
```bash
docker stop {{container-id}}
```

### Run Docker Compose
To run all the images inside docker compose. Containers that are already running will not be restarted
```bash
docker-compose up -d
```

### Stop Docker Compose
To stop all the containers running in a docker compose.
```bash
docker-compose down
```

## Execution

Run the following commands on the root folder

```bash
docker build -t usersapi:v1 -f UsersApi/Dockerfile .
docker build -t storesapi:v1 -f StoresApi/Dockerfile .
docker-compose up -d
```