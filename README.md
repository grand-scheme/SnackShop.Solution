## _[ PIERRE'S SNACK SHOP ]_  

### _A C# MVC Application featuring RAZOR and Entity Frameworks Database_

### _January 15th, 2021_  
----------------------
Description:
----------------------
This product is an MVC application where you play the part of Pierre the baker. Pierre needs a way to keep track of &mdash; and show off! &mdash; the baked treats he has for sale.

Through this application, you-as-Pieere can add different "Treats" to your inventory, assign them with names, short descriptions, prices, and so forth. You can also categorize these treats by their "Flavors", describe what makes _sweet_ taste so _sweet_, and determine what time of day those treats can be sold. 

----------------------
Project Criteria:  
----------------------

As referenced from the [Epicodus](https://epicodus.com) program's curriculum:  


>    The application should have user authentication. A user should be able to log in and log out. Only logged in users should have create, update and delete functionality. All users should be able to have read functionality.
>
>    There should be a many-to-many relationship between `Treat`s and `Flavor`s. A `treat` can have many `flavor`s (such as sweet, savory, spicy, or creamy) and a `flavor` can have many `treat`s. For instance, the "sweet" `flavor` could include chocolate croissants, cheesecake, and so on.
>
>    A user should be able to navigate to a splash page that lists all treats and flavors. Users should be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.

-------------------------------
Known Issues / Bugs:
----------------------
Unable to disconnect a one-to-many relationship in one operation.

-------------------------------
Setup:
----------------------

 Prior to downloading:
> Each of the following programs and softwares will be listed with the version numbers used in making this application. While you may not need to have these _specific_ versions installed, compatibility cannot be guaranteed with earlier or later releases.
>
> You will need to have the following installed and set up on your local machine before you will be able to utilize this program:
- [.NET core](https://dotnet.microsoft.com/download/dotnet-core/2.2), `.NET Version: 2.2.203`.
- [MySql Server & Workbench](https://dev.mysql.com/downloads/), `MySQL Server Version: 8.0.19`; `MySQL Workbench Version: 8.0.19`

For more step-by-step instructions on installing these programs, please visit [these Epicodus tutorials](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c).

----------------------
To view locally on your machine:  
----------------------
1. Find the green **Code** button above the file list on this project's [main GitHub repository page](https://github.com/grand-scheme/SnackShop.Solution).

2. Select the button to open a drop-down menu. Select "Open with GitHub Desktop" or, if you do not have this program installed, download the compressed .zip file.

3. Extract the .zip file to your local machine.

4. Directions were accurate as of January 15th, 2021. If GitHub has since changed their protocol, please see [the GitHub help docs](https://docs.github.com/en) for up-to-date information.

----------------------
To clone this project to your machine: 
----------------------
> The following directions are based on Git Bash for a Windows machine; you may have to adjust terminology based on your local specs.
1. Launch your terminal of choice. 

2. Navigate to the containing directory into which you would like to clone this project.

3. Input:\
`$ git clone https://github.com/grand-scheme/SnackShop.Solution`

4. This will clone the project to a folder called "SnackShop.Solution." If you wish to clone it into a directory of a different name, append the new folder name to the end of the string, like so:\
`$ git clone https://github.com/grand-scheme/SnackShop.Solution NEW-FOLDER`\
where `NEW-FOLDER` is where you would type the name of the folder you would like to use.\
**Note:** It is highly recommended that your destination folder retains the name `SnackShop.Solution`.  

5. Directions were accurate as of Jan. 15th, 2021. If GitHub has since changed their protocol, please see [the GitHub help docs](https://docs.github.com/en) for up-to-date information.

----------------------
To run this project on your machine:
----------------------
1. Once you have the project locally stored, navigate to its main directory in your terminal of choice. By default, this is `SnackShop.Solution`.

2. Navigate to the subfolder `SnackShop`.

3. Open the file `appsettings.json`. Any plain-text editor should do. Once you have opened the file, you'll see a block of code that looks like this:
```csharp
{
	"ConnectionStrings": {
		"DefaultConnection": "Server=localhost;Port=3306;database=shannon_grantski;uid=root;pwd=PASSWORD;"
	}
}
```
You will need to replace `PASSWORD` with **your** MySql password. Depending on your local settings, you may also need to change the destinations for Server, Port, or uid. You can check what these settings should be in your local copy of MySql Workbench.

4. In your command line, input as separate commands:\
`$ dotnet restore`\
`$ dotnet build`\
`$ dotnet ef database update`\
`$ dotnet run`

5. If you run into any timeout errors, you may need to separately log in to your MySql server through Workbench or a terminal to establish the connection. Or, if you're like me, you'll need to restart your computer first, and _then_ log in.

6. If all goes well, the command terminal should inform you that a local host has been launched for this program at `http://localhost:5000`. Navigate to this url in your browser of choice. 
-------------------------------
Technologies Used:  
-------------------------------
- Visual Studio Code.
- Windows Powershell
- MySQL Workbench
- .NET Core SDK Version: 2.2.203
- Microsoft.AspNetCore.Razor.Design Version: 2.2.0
- Entity Framework Core .NET 2.2.4
-------------------------------
License
-------------------------------
- _GNU AGPLv3_  
- Project copyright (c) 2021 **_Shannon Grantski_**  
- Project criteria quoted text copyright (c) 2021 Epicodus, Inc.