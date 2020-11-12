:: Stop the current compose if present
docker-compose down

:: Clear the screen and deploy pieces to our swarm
cls
@echo off

:: Init the swarm if need be
docker swarm init

:: Deploy Server
docker stack deploy -c ..\Docker.Demo.Client\docker-compose.yml dockerDemo

:: Deploy Client
docker stack deploy -c ..\Docker.Demo.Server\docker-compose.yml dockerDemo

echo You can now run the CurlExample.bat file
@echo on