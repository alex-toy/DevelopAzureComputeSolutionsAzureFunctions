# Develop Azure Compute Solutions - Azure Functions


## Create Function App

### Demo Function App 1

- create function app
<img src="/pictures/create_fa.png" title="create function app"  width="600">

- add function. Choose *Develop in Portal* and *HTTP Trigger* and *Function* for authorization level
<img src="/pictures/create_fa2.png" title="create function app"  width="600">

- in the *Code + Test* section, modify the code :
<img src="/pictures/create_fa3.png" title="create function app"  width="900">

- you can test locally :
<img src="/pictures/create_fa4.png" title="create function app"  width="900">

### GET Function App

- create function app; choose the same options as previously
<img src="/pictures/create_fa5.png" title="create function app"  width="600">

- in the *Code + Test* section, modify the code and test locally :
<img src="/pictures/create_fa6.png" title="create function app"  width="900">
<img src="/pictures/create_fa7.png" title="create function app"  width="900">

### POST Function App

- create function app; choose the same options as previously
<img src="/pictures/create_fa8.png" title="create function app"  width="600">

- in the *Code + Test* section, modify the code and test locally :
<img src="/pictures/create_fa9.png" title="create function app"  width="900">

- same result with **Postman** :
<img src="/pictures/create_fa_postman.png" title="create function app"  width="900">


## Azure Functions using VSCode

- create **Azure Function** project
<img src="/pictures/vs_azure_function.png" title="create azure function project"  width="500">
<img src="/pictures/vs_azure_function2.png" title="create azure function project"  width="900">

- run the function locally
<img src="/pictures/vs_azure_function3.png" title="create azure function project"  width="900">

- publish the app to Azure
<img src="/pictures/publish_azure_function.png" title="publish azure function"  width="900">
<img src="/pictures/publish_azure_function2.png" title="publish azure function"  width="900">
<img src="/pictures/publish_azure_function3.png" title="publish azure function"  width="900">
<img src="/pictures/publish_azure_function4.png" title="publish azure function"  width="900">

- function app now available in postman
<img src="/pictures/publish_azure_function5.png" title="publish azure function"  width="900">


## Azure SQL Database

- create SQL database (alexeiadmin, Password.1234) and then run *scripts.sql*
- Nuget Package
```
System.Data.SqlClient
```

### GET Method

- test the function locally :
<img src="/pictures/sql_af.png" title="sql azure function"  width="900">

- get the function url :
<img src="/pictures/sql_af2.png" title="sql azure function"  width="900">

- you may get an error such as the following. In this case, set the *Firewall Settings* for the server to allow Azure services.
<img src="/pictures/sql_af3.png" title="sql azure function"  width="900">

- publish the app and test the function on azure :
<img src="/pictures/sql_af4.png" title="sql azure function"  width="900">

