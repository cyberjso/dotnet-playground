#!/bin/bash

export CONTAINER_NAME="db-server"
export DB_NAME="some_db"
export DB_USER="admin"
export DB_PASS="admin123"

docker stop $CONTAINER_NAME
docker rm $CONTAINER_NAME

docker build -t joliveira/mysql-db .

docker run --name $CONTAINER_NAME -e MYSQL_PASSWORD=admin123  -e MYSQL_USER=$DB_USER -e MYSQL_DATABASE=$DB_NAME -e MYSQL_ROOT_PASSWORD=$DB_PASS -d joliveira/mysql-db:latest

sleep 5

export DB_SERVER="$(docker inspect $CONTAINER_NAME -f '{{.NetworkSettings.IPAddress }}')"

dotnet run 