-To get project running, open command line on the project's root directory and run below command;
docker-compose up
-Once all containers are setup, check project's api port with docker-ps command and open it on a web browser by adding swagger/index.html to the link, the overview of api endpoints is supposed to appear, then it's ready to be tested.
Note: In case web browser doesn't allow http requests, it's also available to call endpoints with https over an incremented port of the one on api container.