#!/bin/bash

container_name=HelloApi
version=2.0.0-SNAPSHOT

docker build -t dotnet-playground/hello-api:$version .

docker stop $container_name
docker rm $container_name

docker run -d --name $container_name dotnet-playground/hello-api:$version