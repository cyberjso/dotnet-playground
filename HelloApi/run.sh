#!/bin/bash

container_name=HelloApi

docker build -t dotnet-playground/hello-api .

docker stop $container_name
docker rm $container_name

docker run -d --name $container_name dotnet-playground/hello-api