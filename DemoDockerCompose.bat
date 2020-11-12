cls
:: Make sure not in a swarm and remove existing stuff
docker swarm rm dockerDemo
docker swarm leave --force

:: Remove the live environment if present and relaunch
docker-compose down
docker-compose up