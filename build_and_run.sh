#!/bin/bash
docker build -t soccer-simulator .
docker run -d -p 8080:80 --name soccer-simulator soccer-simulator