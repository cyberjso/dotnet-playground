#!/bin/bash

db_server_name="db-server"
db_name="some_db"

docker stop $db_server_name
docker rm $db_server_name

docker build -t jackson.oliveira/mysql-db .

docker run --name $db_server_name -e MYSQL_PASSWORD=admin123  -e MYSQL_USER=admin -e MYSQL_DATABASE=$db_name -e MYSQL_ROOT_PASSWORD=root123 -d jackson.oliveira/mysql-db:latest