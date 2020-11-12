cls
@echo off
:: Make sure not in a swarm and remove existing stuff
docker stack rm dockerDemo
docker swarm leave --force

:: Remove the live environment if present and relaunch
docker-compose down
docker-compose up -d

echo You can now run the CurlExample.bat file
@echo on