# r0-core
Basic microservice starter template built in .Net Core

# Technologies Used
* Serilog is used as the logging provider

# Logging format
The application will log messages to the console in JSON format. This is not configurable, as it is the desired behavior of every service.

# Environment Variables
| Variable | Default Value | Valid Values |
| -------- |:-------------:| ------------ |
| `Serilog:MinimumLevel` | `Information` | `Verbose`, `Debug`, `Information`, `Warning`, `Error`, `Fatal` |
| `Serilog:Properties:Application` | `r0-core` | Name of your application |