# Origin Take Home Assignment


### 1. Instructions to run the code

1.1. Download and install docker in your machine (if you dont have installed it already)

1.2. Open the terminal and set the terminal's root directory to the project's folder

`> cd origin-take-home-assignment/`

1.3. Inside your terminal type the following codes:

`> docker build -t origin/take_home_assignment .`

`> docker run -p $your_machine_available_port:80 --name TakeHomeAssignment origin/take_home_assignment`

*$your_machine_available_port: replace this variable with the port that you want run the container*

1.4. Open the url http://localhost:$your_machine_port_available/swagger

*$your_machine_available_port: replace this variable with the port that you are running the container created previously*


### 2. Main technical decisions made

- A class for each insurance type

- Default rules and operations inside the base class that are used by all insurance type class that inherit from it

- Specific rules and operations inside of each insurance type class

- Life insurance status of all insurances is calculated in parallel


### 3. Comments about my code


  One comment about my code is related to the TotalScore property in Insurance.cs. I decided to define this property as int nullable, then, when TotalScore is null the LifeInsuranceStatus is ineligible, otherwise, the increment and decrement are performed based on the rules inside that insurance type.
  
  Also I decided to set the TotalScore property as “private set” and the methods that change this property are defined in Insurance.cs. I used this strategy in order to have more control about how this property is changed. 

