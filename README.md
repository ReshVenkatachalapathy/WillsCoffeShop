# Wills Coffe Shop  


This project demonstrates on basic functionalities for admin and employee to maintain the products, salary, employee info etc. 



Prerequisites:

-> Microsoft visual studio (any version - latest version recommended)

-> Java (any version - latest version recommended)

-> C# 

-> Install SQLClient 



Execution of the project:

-> Download the project from the github by cloning it.

-> Open the visual studio and select exsiting project

-> Select the downloaded project

-> Click on run which will initiate the execution. Execution will invoke the MainWindow.xaml which is the login page of the project and the consecutive pages gets called as per the user's request



Functionalities of the project:


Login: 
    
    is general page for both user type where the user has to mention the username and password to login into the application. If it is a new user, click on signup to create an account.

![image](https://github.com/user-attachments/assets/13012585-2063-4290-ae6a-69cc9abcd736)

![image](https://github.com/user-attachments/assets/63162776-42a2-4c01-9cb6-d040c65393e7)


-> Administrator user type:


Home Page:

    Displays the different features admin has access to.

![image](https://github.com/user-attachments/assets/070f6fc2-3bc0-4f6f-a887-c549b485d0ec)


Products Details: 

Admin can add/ update or delete products to the coffee store.

 	Add: User must assign item ID, name, prize and upload a sample picture of the product.
  
 	Update: User can make changes to the existing product.
  
 	Delete: User can delete an existing product.

![image](https://github.com/user-attachments/assets/f4ac4c35-d4bf-43ea-bc78-f5c4d380e4df)

  
Payroll Details:

Employee monthly payroll will be made record of here. 

 	Add: Admin must insert employee id, name, payment period, payment cost, number of hours worked.
  
 	Edit: Admin can make changes to the employee payroll.
  
 	Delete: Admin can delete an employee’s payroll.

![image](https://github.com/user-attachments/assets/9f650e2a-013b-46a6-94ef-f56df3759e75)

  
Employee Details:

 	Add: Insert the employee details like name, phone number, address, email address, gender, date of birth, date of joining, salary.
  
 	Update: Admin can make changes to the existing employee.
  
 	Delete: Admin can delete an existing employee.

![image](https://github.com/user-attachments/assets/c52cee93-e292-457f-9b33-71d2c4e55a0f)

  
Logout:

  User can securely log out of the system


-> Employee user type:


Homepage:

    Displays the dashboard with all the available options pertaining to the employee user

![image](https://github.com/user-attachments/assets/605a617b-29bc-4797-95c1-7a33879a7b86)

    

Profile Information:

 	Displays the employee personal and work details as per the saved records.

![image](https://github.com/user-attachments/assets/60e7e8dd-2822-4c93-b294-a8fa9e67dc8a)

    
Edit Profile:

    Edit the employee personal details

![image](https://github.com/user-attachments/assets/a3ebf49d-8bff-4845-993f-b19a158c01ec)


  
Payroll:

    View the payroll details like pay period, salary etc
  
 ![image](https://github.com/user-attachments/assets/9d4ef355-6d03-43c8-bc70-3d478dfabbd3)


    Raise a Ticket: Incase of any error or issue faced by the employee, a ticket can be raised to the admin team for resolution by mentioning the issue title,details and criticality of the issue
    
![image](https://github.com/user-attachments/assets/56dd5856-cdb9-40e1-bf74-9be43cbc44cf)


  
Logout:

    User can securely log out of the system



Object Oriented Programming Language Concepts in the Project:

Inheritance concept ->

        1) admin_HomePage.xaml.cs - Child of HomePage.xaml.cs

        2) employee_HomePage.xaml.cs - Child of HomePage.xaml.cs

Multilevel Inheritance -> 

        1) HomePage extends Window
   
        2) admin_HomePage, employee_HomePage extends HomePage
   
        3) Window methods and HomePage methods are implemented in child classes


Overriding concept ->

        1) admin_HomePage.xaml.cs - LogoutButton_Click method overridden from Parent class

        2) employee_HomePage.xaml.cs - LogoutButton_Click method overridden from Parent class




Group members details:

Person 1: Reshma Venkatachalapathy

Person 2: Mahesh Nimmakayala

Person 3:  Arfeena Jamal

Person 4:  Arundhathi Jayaprakash




Project Link: [https://github.com/your_username/repo_name](https://github.com/ReshVenkatachalapathy/WillsCoffeShop.git)


