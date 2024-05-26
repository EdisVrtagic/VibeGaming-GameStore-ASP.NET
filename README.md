# About the VibeGaming Project

The Vibe Gaming project is a student project created for a diploma thesis, with its main feature being the sale of physical copies of games on CDs, activation of digital game keys, and similar services. The project is built using ASP.NET MVC Core 6 technology and utilizes an MSSQL database. The project includes the following functionalities: user registration/login, browsing all available games by categories such as PC, PlayStation, Xbox, Nintendo, a cart for adding games, cash on delivery payment process, email notifications, order review, and more.

# Documentation of the used technologies
1. https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-8.0
2. https://learn.microsoft.com/en-us/sql/?view=sql-server-ver16

# Used script for the image gallery
1. https://www.lightgalleryjs.com/docs/attributes/

# Configuration of MSSQL
To create a database, or in this case to add an already defined database, SQL Server Management Studio (SSMS) will be used. SSMS is a program used for managing, configuring, and administering all components of the MSSQL Server. The main component of SSMS is the Object Explorer, which allows users to easily navigate and search for objects on the server. When SSMS is started, a pop-up window opens where you select the server and authenticate to the server where the pre-created database will be added, or an import will be performed. You can see the connection to the SQL Server in the following image (Image 1).
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/421d27a3-fe5e-422a-ad3f-209ac4a4fdcd" alt="fe">
  <p>Image 1: Connecting to the server using SSMS</p>
</div>

After successfully connecting to the server, on the left side, the Object Explorer is displayed, containing all the objects on the server that we can manage. In our case, we will not create a new database but rather add an existing one, or perform Import Data-tier Application, which we can access by right-clicking on Databases to open a dropdown menu with various options related to the database, as shown in the following image (Image 2.).
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/de4d14da-a55f-49ea-b294-33d45637ca47" alt="dr">
  <p>Image 2: Importing the database</p>
</div>

When we click on Import Data-tier Application, we get the following window (Image 3) where we can choose from which location on our computer we are adding the database to the server.
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/4bf1d81e-713a-4bdb-be95-3f89b82425c7" alt="rg">
  <p>Image 3: Selecting the location of the imported database</p>
</div>

After successfully selecting the database from our computer, we get a new window (Image 4) where we can adjust the name of our database as desired (it is recommended to leave it as the system has defined it).
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/eebb3e00-cedd-42ba-9a34-40b5e2ee5a45" alt="im">
  <p>Image 4: General options of the imported database</p>
</div>

At the very end, after successfully adding or importing the database to SQL Server and after all the successful tasks executed during the import, we receive a message about the successful import of our database (Image 5), and we can click the Close button, and our database is added and ready for use.
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/8de1ada7-cd46-49f6-98ef-9654419d3800" alt="fd">
  <p>Image 5: Message about the successful import of the database</p>
</div>

In the following images (Image 6 and Image 7), we can see how data is added to the tables. In Image 6, it is necessary to select the database where we want to add the data, and in the upper head section, we have the option New Query which we need to click to open a new empty file where we work on adding data.
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/2f1e0023-9e23-45a2-bdcd-0e92b9273d38" alt="adpo">
  <p>Image 6: Part I - Adding data</p>
</div>

After opening a new empty document, we need to paste the data that we will add to our tables (Image 7), and then in the head section, click on the Execute option, after which our data will be successfully added to the tables.
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/5a67e62b-fdc7-4e0f-ad63-876f905e454d" alt="expo">
  <p>Image 7: Part II – Executing data</p>
</div>

# Schema of the relational database for the project
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/d975e8ab-05f0-4518-b681-ad2125e7a591" alt="dbsh">
</div>

# Configuration of Visual Studio Community 2022
When you first install Visual Studio Community 2022, since the project is developed using ASP.NET technology, it is necessary to download the following add-ons and install them exactly as shown in (Image 8).
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/270f67ce-a98a-4acf-86e7-cdda9ec59ca1" alt="wlo">
  <p>Image 8: Workloads</p>
</div>

After successful modification, we can open our project's code by selecting 'Open a project or solution' in the window (Image 9) when opening Visual Studio. When a new window appears, find our project and open VibeGamingWeb.sln.
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/e0dfd482-f4f2-40a9-a24e-1156a43dc9fa" alt="tz">
  <p>Image 9: Opening the project</p>
</div>

When our project opens, we need to wait for a few moments (Image 10) for our project files to be successfully loaded. It is important to note that in this process, we do not need to install anything additionally, as Visual Studio will handle this for us, which is one of its great advantages.
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/61ab6f1b-a57a-4c8c-bdf7-b408c00af569" alt="mes">
  <p>Image 10: Loading project dependencies</p>
</div>

To launch our application, we first need to select 'IIS Express' from the dropdown menu (Image 11). This helps us simulate how our application will work when added to a real IIS Server on a hosting domain and assists us in identifying and resolving issues before the application is deployed to production. Additionally, the choice of web browser for testing our application depends on your preferences, but you can use the ones listed.
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/bbf0810f-3244-480e-b182-8aab0064c529" alt="run">
  <p>Image 11: Running the application</p>
</div>

# Email credentials
To send a successful order confirmation message to the user's email, you need to add your email address and password from which the message will be sent. You can find instructions on how to create an access password for web applications in the video link below.
This part of the code is located in the PaymentController.
<div align="center">
  <img src="https://github.com/EdisVrtagic/VibeGaming-GameStore-ASP.NET/assets/101829021/a784ebb7-d9d2-43a5-9109-5d6db14e645b" alt="emal">
</div>
YouTube video: https://www.youtube.com/watch?v=kTcmbZqNiGw
