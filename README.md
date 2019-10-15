# Repo001 Summary

Q5 - LispChecker.html and ParenthChecker.js
----------------------------------------
Simple **JavaScript function** that matches opening and closing parenths in a given LISP statement.
Input and output can be seen in console log in dev tools. No UI element used for simplicity.




Q6 - ProviderRegistrationASP.NETcoreMVC
------------------------------------

This is a simple **ASP.NET Core MVC app (.NET Core 3.0)** for registering providers. The app can easily be published/deployed to Azure.

The entered provider info is stored in a strongly typed static collection for simplicity.

#### Screenshot 1/5: Registration form

![Registration Form](temp/img1-empty.bmp "Regisration Form")

#### Screenshot 2/5: Data Input

![Data input](temp/img2-input.bmp "Data input")

#### Screenshot 3/5: Saved, thanks

![Thanks](temp/img3-thanks.bmp "Thanks")

#### Screenshot 4/5: Registrations list

![Registrations list](temp/img4-list.bmp "Regisrations list")

#### Screenshot 5/5: Validation

![Validation](temp/img5-validation.bmp "Validation")


Q7 - EnrolleeSplitter
-------------------------------
A simple **C# command line application (.NET Core 3.0)** that accepts an optional path parameter and splits CSV files based on insurance company at the given path to multiple files. If no path param is given, the current working directory is used.

### pseudo
0. create a Dictionary that has Insurance Company name as the key and Dictionary of Enrollees as the value
1. create a Dictionary that has User Id as the key and Enrollee object as the value
2. get files CSV files at the given path and do the following for each CSV 
3. read content and create Enrollee object for each line
4. if Enrollee Id exists for a given company in the dictionary, then compare version and use the higher version
5. else add to the dictionary
6. For each distinct Insurance Company create a CSV file that has all of the respective Enrollees listed by last name

temp
-------------
Temporary files / documentation files
