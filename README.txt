Blog Engine Project
===================
The goal of the project is to build an administrative interface to create blog posts and a REST API to consult them.

> Folder structure
  .
    ├── Angular                   # Frontend Project
    ├── BlogEngine                # Backend Project
    ├── Test                      # Unit Test Controller Backend Project
    ├── README.txt      

## Get started      

### Requirements
 - Backend
    - .NET 6.0 SDK
    - Visual Studio
 - Frontend 
    -  Visual Studio Code
    - `https://angular.io/guide/setup-local`

    - Angular v 15.1.x || 15.2.x (Actively supported versions)
        - `https://angular.io/guide/versions`
        - node.js v ^14.20.0 || ^16.13.0 || ^18.10.0	
        - npm pakage manager

### Backend
Asp.Net Core MVC

*Suggerstion: use Visual Studio as a IDE to open the project*

#### Open the repo
 - Open the Folder Angular using the IDE

```shell
cd BlogEngine
```

- Open the Solution -> `BlogEngine.sln`
- Run Project using the button or Press Ctrl+F5 to run without the debugger
   - if you don't have the certificate:
      - select Yes if you trust the IIS Express SSL certificate.
      - Select Yes if you agree to trust the development certificate.

 - Visual Studio launches the default browser and navigates to `https://localhost:7056/swagger/index.html` to access the APIs

### Tests
 - In Visual Studio follow these steps:
   - on the toolbar click on : Test ->  Run All Tests

### FrontEnd
This project was generated with Angular CLI version 15.2.7

*Suggerstion: use Visual Studio Code as a IDE to open Angular folder*

#### Open the repo
 Open the Folder Angular using the IDE

 ```shell
cd Angular
```

#### Install npm packages

Install the `npm` packages descrided in the `package.json` and  verify that ut works:

```shell
npm install
npm start
```
Suggerstion: if any error occurs, delete the /node_modules folder and repeat the installation

The `npm start` command builds , watches for changes to the source files, and runs `lite-server` on port `4200`.
Navigate to `http://localhost:4200/`.

Shut it down manually with `Ctrl-C`.

##### npm scripts

These are the most useful commands defined in `package.json`:

* `npm start` - runs the TypeScript compiler, asset copier, and a server at the same time, all three in "watch mode".
* `npm build` - to build the projec. The build artifacts will be stored in the `dist/` directory.
* `npm serve` - runs `lite-server`. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.


### Database
Azure SQL database
 - The database is stored in my personal azure account
 - All the data needed to access the database is in the .netcore project's connection string
