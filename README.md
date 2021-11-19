# Origin Take Home Assignment


### 1. Instructions to run the code

1.1. Download and install docker in your machine (if you dont have installed it already)

1.2. Open the terminal and set the terminal's root directory to the project's folder

1.3. Inside your terminal type the following code:

`docker build -t origin/take_home_assignment .`

`docker run -p $your_machine_port_available:80 --name TakeHomeAssignment origin/take_home_assignment`

*$your_machine_port_available: replace this variable with the port that you want run the container*

1.4. Open the url http://localhost:[$your_machine_port_available/swagger
