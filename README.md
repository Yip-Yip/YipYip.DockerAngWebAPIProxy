
# Docker & Angular 18 & .Net Core WebAPI with Seq using Nginx with Loading Balancing .NET 9 
- This example shows you how to create a basic **[.Net Core WebAPI](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.1)** with a Angular 18 Web frontend hosted in a **[Docker](https://www.docker.com/)** **[container](https://www.docker.com/what-container)** accessed via a seperate **[NGINX](https://www.nginx.com/)** docker container reverse proxy.  There is a third docker container also using nginx to host a client test web page used to query the API.
- This is all achieved using **[docker-compose](https://docs.docker.com/compose/)** which references the 3 **[Dockerfile's](https://docs.docker.com/engine/reference/builder/)** to build the **[images](https://docs.docker.com/v17.09/engine/userguide/storagedriver/imagesandcontainers/)** and create the containers.

## Building and Running
### Build the docker images
```sh
$ docker-compose build
```

### Run all three docker images
```sh
$ docker-compose up
```
## Diagnosis
### Running Containers
To check the docker containers running type the following:
```sh
$ docker ps
```

### Logs
To check the logs get the container id from the previous command 'docker ps' and type the following:
```sh
$ docker logs --details -f -t <container id>
```

### Terminal
To explore inside the container via a terminal type the following:
```sh
$ docker exec -it <container id>  /bin/bash
```

## Testing
To check it all works and hit the the .net core api use the sample web client as follows:
1. Open chrome using the following command
```sh
$ chrome.exe --user-data-dir="C:/Chrome dev session" --disable-web-security
```
2. Go to the following in your browser:
``` 
http://localhost/ 
```
3. Press 'Click Me'.  
4. The host name of the underlying API service should be returned.

## Configuration & How it works


### [Docker Compose - expose](https://docs.docker.com/compose/compose-file/#expose)
Inside docker-compose.yml each api uses 'expose' to make the service via the exposed port (8080) available to the linked services.  Note: this does not publish the port to the host machine.
```
    expose:
      - "8080"
```

### [Docker Compose - ports](https://docs.docker.com/compose/compose-file/#ports)
Inside docker-compose.yml each api the 'nginx proxy' service expose their internal port of 80 to the host port 80. 
```
    ports:
      - "80:80"
```

### [NGINX Load Balancing](http://nginx.org/en/docs/http/load_balancing.html)
Inside nginx.conf we have configured requests to 'round robin' (default when alternative not specified) between the API instances by the following configuration:
```
    links:
    upstream api_servers {
		server api1:8080;
		server api2:8080;

    }
```
Then in the server section we set the following:
```
   proxy_pass         http://api_servers;
```

Thanks to https://github.com/MikeyFriedChicken for the org

