# README #

### Getting up and running ###

This project is setup to run as a local project in db mode but it relies upon two databases being setup.

You will need to publish both the security database and the pressford database projects to your local database server.  They were originally created using Microsoft SQL Server express.

If you have any difficulties, the original table scripts are available and seed data is included in the post deployment scripts.

You will then need to update the connection strings as found in the website project appsettings.json.

The default connection is the security database which is based on ASP.Net security.
The pressford connection is the database for storing and updating articles.

Once all this is setup you should just be able to hit debug and the website will run.


### What to expect ###

This is an example employee intranet task where some employees can publish articles and others can read them.

I've created a fairly straight forward .net core web app and most of the elements are out of the box, for example front end uses standard razor and bootstrap.

The first page you will find the ability to log in or register as a new user, articles are hidden to non-logged in users.  This uses the out of the box individual accounts and roles have been included to manage which pages different users can see.

On registration you will be able to set yourself up as a publisher or not.  All users can see all published articles, only publishers can manage articles and see article statistics.

The menu options for what you can do are available on the standard menu bar and fairly self explanatory.


### Code ###

In the back end, I have chosen to use some of my own conventions.  I appreciate this may not be the same standards as your business but I would of course adhere to your standards and conventions.

This is a standard .Net Core Web Application setup with the standard template.  I have used the out of the box dependency injection.


### Interfaces and Classes ###

I have chosen to name interfaces, not by copying the class name with an I in front, but with an IDoThis naming convention.  The reason for this is I believe it makes the SOLID Interface Segregation Principle easier to follow and it mentally decouples the interface contract from the implementation.


### Unit Testing ###

This project uses test wrappers and test classes with Microsoft Testing Framework.  Although it is possible to do setup of tests within the test class itself, I often find for practicality a test wrapper can be very useful as I can have the setup code in one window and the tests next to it in another window.

In the wrapper, I setup data for the test in the constructor, mocks in the GetTarget method and then if these properties are made available to the test I can adjust them as required.  The aim of the test wrapper is to create the ideal 'happy path' conditions for the implementation class, individual tests can adjust these to test specific circumstances.

In tests, by changing properties after calling the wrapper constructor, I can adjust what the mocks will respond with.  Although reference types don't require this, it is much simpler if your mock returns a primitive type.  Mock can also be adjusted by changing the setup after the GetClassUnderTest method is called.  This way of setting up tests has allowed me a great deal of flexibility in setting up different circumstances in a simple framework.

I haven't fully unit tested the project due to time constraints but I have given a demonstration of how I would approach unit testing in the elements I have tested.


### Database and Generic Repositories ###

I have used a Unit of Work design pattern for working with the database.  This is a design pattern we use in my current role and I would be perfectly happy to work with alternative design patterns that you employ.

I have also used this pattern because although I could work with the context directly, I find the abstraction of the repository makes unit testing simpler without the need to write mock/fake classes and enabling a mocking framework to do the heavy lifting, particularly when I want to change the setup.


### Javascript Libraries ###

I have chosen to use 3 main Javascript libraries to enable quick turnaround on some features

DataTables - https://datatables.net/
This is a plugin for creating sortable, filterable data tables.  I've used this for managing articles so that as the number grows it will enable simple management on the front end.  It is certainly true that if this system were used in the much longer term it would probably need much more management in the back end, but for proof of concept this would do.

TinyMCE - https://www.tinymce.com/
TinyMCE provides a simple way to add an HTML editor.  This is what enables the editing of the article body with html so that the article can be formatted well.

Chart.js - http://www.chartjs.org/
I have used this library for creating charts.  It takes away all of the work of creating charts and is a potentially very powerful tool, meaning that all I needed to do was provide the data from the database.  Unfortunately I ran out of time for creating more charts, but this gives an example of what could be done.
