# RestWithASP-NET5
  
A restful api example using ASP-NET Core 5.  
The service was deployed on azure too. But for security reasons, it's available here through only Docker.
  
## 🚀 Starting
  
1. Clone the repository
2. Go to the project folder that contains the docker-compose file
3. You can start the api with the `docker-compose up -d --build` command, after this command the containers will be started (service and database - with data)
4. You can use the ASP-NET5.postman_collection.json file under the PostmanCollections Folder to make the requests to the api - The project requires authentication, that can be done throug Auth folder on postman, SignIn request

### 📋 Pre-requisites
  
1. Docker 
2. Docker-compose
3. Postman (Recommended)
4. Visual Studio (Optional - if you want run throug the IDE or study the code)