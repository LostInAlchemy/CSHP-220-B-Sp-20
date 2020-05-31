--**********************************************************************************************--
-- Title: SQLDEV 100: SQL Server Essentials for Developers; 
-- Assignment 5
-- Author: Mark R Brown
-- Desc: This file demonstrates how to convert a 
-- Logical database design to a Physical database design
-- Including creating a database, tables, and views
-- Change Log: When,Who,What
-- 2018-Feb-10, Mark R Brown, Created File
-- 2018-Feb-18, Mark R Brown, Updated table constraints, Moved phone numbers from 
--														Phone_Numbers table and put them in the Employee table and Clients 
--														Table, Added data to all tables, Added examples of update and delete 
--														statements, Created a query to display Project data, Removed constraints
--														that served no purpose.
-- 2018-Feb-23, Mark R Brown, Renamed database, added Simple backup plan
-- 2018-Mar-03, Mark R Brown, Normalized database, adding tables, added schema(s)
-- 2018-Mar-07, Mark R Brown, added roles, logins and users
--***********************************************************************************************--


--ALTER AUTHORIZATION ON DATABASE::[mrbrown3_db_Essentials_for_Devsv2.0] TO sa
--GO



Begin Try
		Use Master;
		If Exists(Select Name From SysDatabases Where Name = 'ClientApplicationsDatabase')
		 Begin 
		  Alter Database [ClientApplicationsDatabase] set Single_user With Rollback Immediate;
		  Drop Database [ClientApplicationsDatabase]
				--DROP SCHEMA IF EXISTS Person
				--DROP SCHEMA IF EXISTS [Address]
				--DROP SCHEMA IF EXISTS Project;
		 End
		Create Database [ClientApplicationsDatabase];
	End Try
	Begin Catch
		Print Error_Number();
	End Catch
	go

	Use [ClientApplicationsDatabase];
	GO

	--------------------------------------------------------------- Create Tables & Add Data ---------------------------------------------------------------------------------------------

					--CREATE  -- Drop	
					--SCHEMA Person;
					--GO

				CREATE  -- Drop	
				TABLE Manufacturer                                                    -- Create Table
				(																																												  																															-- Adding Columns
					 MFG_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					,MFG_Name Varchar (50) NOT NULL
				);

				INSERT INTO Manufacturer																																																					-- Insert into Table											
								(
								 MFG_Name
								)
				VALUES																																																																							 -- Values to be inserted
								 ('Smartthings Classic')
								,('Smartthings Samsung')
								,('Nest')
								,('Wyze')
								,('GE')
								,('Philips')
								,('Ecobee')
								,('Sylvania')
								,('Amazon')
								,('ZemiSmart')
								,('Zooz')
								,('Samsung')
								;
GO																																																																																-- Execute

				CREATE  -- Drop	
				TABLE DeviceType                                              -- Create Table
				(																																												  																															-- Adding Columns
				 DeviceType_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
				,[Type_Name] VARCHAR (255) NOT NULL
				);

				INSERT INTO DeviceType																																														-- Insert into Table											
								(
								 [Type_Name]																																																													 -- Columns to insert into
								)
				VALUES																																																																							 -- Values to be inserted
								 ('Leak Sensor')
								,('Light Switch')
								,('Door Sensor')
								,('Light')
								,('Camera')
								,('Smart Assistant')
								,('Motion Sensor')
								,('Humidity Sensor')
								,('Thermostat')
								,('Smart Curtain')
								,('Smart Plug')
								,('Air Purifier')
								,('Smoke Dector')
								,('TV')
								,('3-Speed Fan Switch')
								,('Light Bulb')
								,('Temperature Sensor')
								,('Smart Button')
								,('Arrival Sensor')
								,('Multipurpose Sensor')
								;
GO																																																																																-- Execute

				CREATE  -- Drop	
				TABLE Ability				                                           -- Create Table
				(																																												  																															-- Adding Columns
				 Ability_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
				,Ability_Name VARCHAR (255) NOT NULL
				);

				INSERT INTO Ability																																										 					-- Insert into Table											
								(
								 Ability_Name																																											  																	  -- Columns to insert into
								)
				VALUES																																																																		 				 -- Values to be inserted
								 ('Temperature')
								,('Water')
								,('Motion')
								,('Humidity')
								,('Tilt')
								,('Light Level')
								,('Entry Sensor')
								,('Power Draw Measurement')
								,('Battery level')
								,('Position')
								,('Color')
								,('Color Temperature')
								,('Presence')
								;
GO																																																																																-- Execute

				CREATE  -- Drop	
				TABLE Battery_Type                                         -- Create Table
				(																																												  																															-- Adding Columns
				 battery_Type_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
				,Battery_Name VARCHAR (255) NOT NULL
				);

				INSERT INTO Battery_Type														 																					 					-- Insert into Table											
								(
								 Battery_Name																																  																											-- Columns to insert into
								)
				VALUES																																																																		 				 -- Values to be inserted
								 ('CR123')
								,('CR2032')
								,('CR2050')
								,('Double A')
								;
GO																																																																																-- Execute

				CREATE  -- Drop	
				TABLE Hardware                                              -- Create Table
				(																																												  																															-- Adding Columns
				 Hardware_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
				,Hardware_Name VARCHAR (255) NOT NULL 
				,Hardware_Desc VARCHAR (255) NOT NULL
				,Hardware_PartNumber VARCHAR (255) NOT NULL
				,Hardware_Cost VARCHAR (255) NOT NULL
				,Hardware_Electrical_Rating VARCHAR (255) NOT NULL
				);

				INSERT INTO Hardware 																																							 				 	-- Insert into Table											
								(
								 Hardware_Name, Hardware_Desc, Hardware_PartNumber, Hardware_Cost, Hardware_Electrical_Rating 	 												-- Columns to insert into
								)
				VALUES																																																																	 		 		 -- Values to be inserted
								 ('SmartThings Water Leak Sensor', 1, 'xyz', $123, )
								,(Motion Sensor)
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								,()
								;
GO																																																																																-- Execute













				CREATE  -- Drop	
				TABLE Person.Email                                                     -- Create Table
				(																																												  																															-- Adding Columns
				 Email_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
				,Email_Address VARCHAR (255)
				);

				INSERT INTO Person.Email																										 																					 					-- Insert into Table											
								(
								 Email_Address																																											  															-- Columns to insert into
								)
				VALUES																																																																		 				 -- Values to be inserted
								 ('John.Wick@TaylorSoft.com')
								,('Howard.The Duck@TaylorSoft.com')
								,('Dobby.Potter@TaylorSoft.com')
								,('Elmo.Playtime@TaylorSoft.com')
								,('Khaleesi.MacBride@TaylorSoft.com')
								;
GO 																																																																															-- Execute

				CREATE  -- Drop	
				TABLE Person.[Person_Type]                                             -- Create Table
				(																																												  																															-- Adding Columns
				 Person_Type_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
				,Person_Type VARCHAR (255) NOT NULL
				);

				INSERT INTO Person.[Person_Type]  																							 																				-- Insert into Table											
								(
								 Person_Type																																							  																					-- Columns to insert into
								)
				VALUES																																																																		 				 -- Values to be inserted
								 ('Software Engineering')
								,('Consulting Team')
								,('Administrator')
								,('Manager')
								,('Client')
								,('Other Staff')
								,('Employee')
								;
GO 																																																																															-- Execute


---------------------------------------------------------------------------------------------------------------------------------


				CREATE  -- Drop	
				SCHEMA [Address];
				GO
				
				CREATE  -- Drop	
				TABLE [Address].[Address]                                              -- Create Table
				(																																																																											  -- Adding Columns
					 Address_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					,[Address] VARCHAR (255)
					,City_ID TINYINT NOT NULL
					,State_ID TINYINT NOT NULL
					,Zip_Code_ID TINYINT NOT NULL
					,Business_ID TINYINT NOT NULL
				);

				INSERT INTO [Address].[Address]																																															-- Insert into Table											
												(
												 [Address], City_ID, State_ID, Zip_Code_ID, Business_ID--Office_Type_ID																        	-- Columns to insert into
												)
								VALUES																																																																			 -- Values to be inserted
												 ('3300 S Las Vegas Blvd', 1, 1, 1, 6)
												,('275 Church St', 2, 2, 2, 6)
												,('3468-3696 Aurora Ave N', 3, 3, 3, 6)
												,('Pier 39, Building O-11', 4, 4, 4, 6)
												,('74-5588 Palani Rd', 5, 5, 5, 6)
												,('1255-1399 Conti St', 6, 6, 6, 1)
												,(NULL, 7, 7, 7, 2)
												,('222 S 7th St', 8, 8, 8, 3)
												,('1500 Shepardsville Hwy', 9, 9, 9, 4)
												,('10866 Cedar Lake Rd', 10, 10, 10, 5)
												;
				GO																																																																												-- Execute

				
				CREATE  -- Drop	
				TABLE [Address].City									                                          -- Create Table
				(																																																																											  -- Adding Columns
					City_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
				,City_Name VARCHAR (255) NOT NULL
				);

				INSERT INTO [Address].City																																																				-- Insert into Table											
												(
												 City_Name										 																																			 				        	-- Columns to insert into
												)
								VALUES																																																																			 -- Values to be inserted
												 ('Las Vegas')
												,('New York City')
												,('Seattle')
												,('San Francisco')
												,('Kailua-Kona')
												,('New Orleans')
												,('Crater Lake')
												,('St Maries')
												,('Nameless')
												,('Hell')
												;
				GO																																																																												-- Execute

				CREATE  -- Drop	
				TABLE [Address].[State]														                                  -- Create Table
				(																																																																											  -- Adding Columns
					 State_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					,State_Name VARCHAR (255) NOT NULL
					);

				INSERT INTO [Address].[State]																																																	-- Insert into Table											
												(
												 State_Name										  																											        	-- Columns to insert into
												)
								VALUES																																																																			 -- Values to be inserted
												 ('Nevada')
												,('New York')
												,('Washington')
												,('California')
												,('Hawaii')
												,('Louisiana')
												,('Oregon')
												,('Idaho')
												,('Tennessee')
												,('Michigan')
												;
				GO																																																																												-- Execute

			CREATE  -- Drop	
				TABLE [Address].[Zip_Code]														                                  -- Create Table
				(																																																																											  -- Adding Columns
					 Zip_Code_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					,Zip_Code VARCHAR (255) NOT NULL
					);

				INSERT INTO [Address].[Zip_Code]																																																	-- Insert into Table											
												(
												 Zip_Code											  																											        	-- Columns to insert into
												)
								VALUES																																																																			 -- Values to be inserted
												 ('89109')
												,('10013')
												,('98103')
												,('94133')
												,('96740')
												,('70112')
												,('97604')
												,('83861')
												,('38564')
												,('48169')
												;
				GO																																																																												-- Execute
	

				--------------------------------------------------------------------------------------------------------------------------


				CREATE  -- Drop	
				SCHEMA Project;
				GO
				
				CREATE  -- Drop	
				TABLE Project.Project																                                  -- Create Table
				(																																																																											  -- Adding Columns
					 Project_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					,Software_ID TINYINT
					,Business_ID TINYINT NOT NULL
					,Person_ID TINYINT
					,[Start_Date] DATE
					,[End_Date] DATE
					,Training_ID TINYINT
					);

				INSERT INTO Project.Project																																																			-- Insert into Table											
												(
												  Software_ID, Business_ID, Person_ID, [Start_Date]																	 	-- Columns to insert into
													,[End_Date], Training_ID
												)
								VALUES																																																																			 -- Values to be inserted
												 (1, 1, 1, '19390903', '19450508', 1)
												,(2, 2, 2, '20061110', '20070215', 2)
												,(3, 3, 3, '20140918', '20150102', 3)
												,(4, 4, 4, '19800527', '19801231', 4)
												,(5, 5, 5, '20150710', '20150810', 5)
												,(6, 4, 5, '20101102', '20170330', 6)
												,(7, 2, 1, '20171031', '20180228', 7)
												,(8, 2, 3, '20180120', NULL, 8)
												;
				GO																																																																												-- Execute

				CREATE  -- Drop	
				TABLE Project.Software																			                              -- Create Table
				(																																																																											  -- Adding Columns
					 Software_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					,SW_Package VARCHAR (255) NOT NULL
					);

				INSERT INTO Project.Software								  																																								-- Insert into Table											
												(
												 SW_Package																																													 				        	-- Columns to insert into
												)
								VALUES																																																																			 -- Values to be inserted
												 ('SW v.A')
												,('SW v.B')
												,('SW v.C')
												,('SW v.D')
												,('SW v.E')
												,('SW v.F')
												,('SW v.G')
												,('SW v.H')
												;
				GO																																																																												-- Execute


------------------------------------------------------------------------------------------------------------------------------------


				CREATE  -- Drop	
				SCHEMA Billing;
				GO

				CREATE  -- Drop	
				TABLE Billing.Billing																                                  -- Create Table
				(																																																																											  -- Adding Columns
					 Billing_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					,Project_ID TINYINT NOT NULL
					,Invoice_Number VARCHAR (255) NOT NULL
					,Invoice_Date DATE
					,Project_Cost Money
					,Training_Expense_ID TINYINT
					,Invoice_Amount Money
					);

				INSERT INTO Billing.Billing																																																	 	-- Insert into Table											
												(
												  Project_ID, Invoice_Number, Invoice_Date																										 	-- Columns to insert into
													,Project_Cost, Training_Expense_ID, Invoice_Amount
												)
								VALUES																																																																			 -- Values to be inserted
												 (1, 'Proj159628', '19450511', 48500, 1, 50000)
												,(2, 'Proj159629', '20070302', 204560, 2, 205560)
												,(3, 'Proj159630', '20150105', 72000, 3, 75000)
												,(4, 'Proj159631', '19810110', 117300, 4, 120000)
												,(5, 'Proj159632', '20150811', 38400, 5, 40500)
												,(6, 'Proj159633', '20170403', 95500, 6, 96000)
												,(7, 'Proj159634', NULL, NULL, NULL, NULL)
												,(8, 'Proj159635', NULL, NULL, NULL, NULL)
												;
				GO																																																																												-- Execute


-----------------------------------------------------------------------------------------------------------------------------------


				CREATE  -- Drop	
				SCHEMA Training;
				GO

				CREATE  -- Drop	
				TABLE Training.Training														                                  -- Create Table
				(																																																																											  -- Adding Columns
					 Training_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					,Software_ID TINYINT NOT NULL
					,Training_Type_ID TINYINT NOT NULL
					,Person_ID TINYINT NOT NULL
					,Training_Date DATE
					,Training_Expense_ID TINYINT
					);

				INSERT INTO Training.Training																																																	-- Insert into Table											
												(
												  Software_ID, Training_Type_ID, Person_ID																		 							 	-- Columns to insert into
													,Training_Date, Training_Expense_ID	
												)
								VALUES																																																																			 -- Values to be inserted
												 (1, 1, 1, '1945-05-10', 1)
												,(2, 2, 2, '2007-02-28', 2)
												,(3, 1, 3, '2015-01-03', 3)
												,(4, 1, 4, '1981-01-05', 4)
												,(5, 2, 5, '2015-08-10', 5)
												,(6, 2, 5, '2017-04-01', 6)
												,(7, 3, 1, NULL, NULL)
												,(8, 3, 3, NULL, NULL)
												;
				GO																																																																												-- Execute

				CREATE  -- Drop	
				TABLE Training.Training_Expense										                              -- Create Table
				(																																																																											  -- Adding Columns
					 Training_Expense_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					,Expense_Amount MONEY --NOT NULL
					);

				INSERT INTO Training.Training_Expense  																																							-- Insert into Table											
												(
												 Expense_Amount																					 																			 				        	-- Columns to insert into
												)
								VALUES																																																																			 -- Values to be inserted
												 (1500)
												,(1000)
												,(3000)
												,(2700)
												,(2100)
												,(500)
												,(NULL)
												,(NULL)
												;
				GO																																																																												-- Execute

				CREATE  -- Drop	
				TABLE Training.Training_Type										                                 -- Create Table
				(																																																																											  -- Adding Columns
					 Training_Type_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					,Training_Type VARCHAR (255) NOT NULL
					);

				INSERT INTO Training.Training_Type 																																			    				-- Insert into Table											
												(
												 Training_Type    																						 															 				        	-- Columns to insert into
												)
								VALUES																																																																			 -- Values to be inserted
												 ('On-site')
												,('Online')
												,('No Training')
												;
				GO																																																																												-- Execute
				

------------------------------------------------------------------------------------------------------------------------------------


				CREATE  -- Drop	
				SCHEMA Business;
				GO

				CREATE  -- Drop	
				TABLE Business.Business												                                    -- Create Table
				(																																																																											  -- Adding Columns
					 Business_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					,Business_Name_ID TINYINT NOT NULL
					,Business_Type_ID TINYINT NOT NULL
					,Office_Type_ID TINYINT NOT NULL
					,Address_ID TINYINT NOT NULL
					--,People_Type_ID TINYINT NOT NULL
					--,People_ID TINYINT NOT NULL
					--,Phone_ID_1 TINYINT NOT NULL
					--,Phone_ID_2 TINYINT NOT NULL
					--,Project_ID TINYINT NOT NULL
					);

				INSERT INTO Business.Business																																													 			-- Insert into Table											
												(
												  Business_Name_ID, Business_Type_ID, Office_Type_ID, [Address_ID]																				    										 	 	-- Columns to insert into
												)
								VALUES																																																																		  -- Values to be inserted
												 (1, 2, 2, 2)
												,(2, 2, 2, 4)
												,(3, 2, 2, 6)
												,(4, 2, 2, 7)
												,(5, 2, 2, 9)
												,(6, 1, 1, 1)
												,(6, 1, 1, 3)
												,(6, 1, 1, 5)
												,(6, 1, 1, 8)
												,(6, 1, 1, 10)
												;
				GO																																																																												-- Execute

				CREATE  -- Drop	
				TABLE Business.Business_Name                                            -- Create Table
				(																																																																											  -- Adding Columns
				 Business_Name_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
				,Business_Name VARCHAR (255) NOT NULL
				);

				INSERT INTO Business.Business_Name   																																										-- Insert into Table											
												(
												 Business_Name																  																										 				        	-- Columns to insert into
												)
								VALUES																																																																			 -- Values to be inserted
												 ('Etsy')
												,('Pandora')
												,('Meebo')
												,('Streetcar')
												,('Yipit')
												,('Taylorsoft')
												;
				GO																																																																												-- Execute

			CREATE  -- Drop	
				TABLE Business.Business_Type                                            -- Create Table
				(																																																																											  -- Adding Columns
				 Business_Type_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
				,Business_Type VARCHAR (255) NOT NULL
				);

				INSERT INTO Business.Business_Type   																																										-- Insert into Table											
												(
												 Business_Type															  																										 				        	-- Columns to insert into
												)
								VALUES																																																																			 -- Values to be inserted
												 ('Software')
												,('Construction')
												;
				GO																																																																												-- Execute

				CREATE  -- Drop	
				TABLE Business.Office_Type                                            -- Create Table
				(																																																																											  -- Adding Columns
				 Office_Type_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
				,Office_Type VARCHAR (255) NOT NULL
				);

				INSERT INTO Business.Office_Type   																																										-- Insert into Table											
												(
												 Office_Type																  																										 				        	-- Columns to insert into
												)
								VALUES																																																																			 -- Values to be inserted
												 ('TaylorSoft_Office')
												,('Client_Office')
												,('Vender_Office')
												,('Taylorsoft_Headquarters')
												;
				GO																																																																												-- Execute


----------------------------------------------------------------------------------------------------------------------------------


				--Use mrbrown3_db_Essentials_for_Devsv2.0;
				--GO
				
				--SELECT * FROM Person.Person;																																																			-- Check Tables for data
				--SELECT * FROM Person.First_Name;
				--SELECT * FROM Person.Last_Name;
				--SELECT * FROM Person.Phone_Number_Type;
				--SELECT * FROM Person.Phone_Number;
				--SELECT * FROM Person.Email;
				--SELECT * FROM Person.Person_Type;

				--SELECT * FROM [Address].[Address]
				--SELECT * FROM [Address].City
				--SELECT * FROM [Address].[State]
				--SELECT * FROM [Address].Zip_Code

				--SELECT * FROM Project.Project;
				--SELECT * FROM Project.Software;
				
				--SELECT * FROM Billing.Billing;

				--SELECT * FROM Training.Training;
				--SELECT * FROM Training.Training_Expense;
				--SELECT * FROM Training.Training_Type;

				--SELECT * FROM Business.Business
				--SELECT * FROM Business.Business_Name
				--SELECT * FROM Business.Business_Type
				--SELECT * FROM Business.Office_Type
				--GO
				

	-------------------------------------------------------------------------------- Add Constraints --------------------------------------------------------------------------

				ALTER TABLE Person.Person
								ADD
												 CONSTRAINT FK_FN_Person FOREIGN KEY (First_Name_ID)			-- connect table "First_Name" and "Person" with FK on "First_Name_ID"
																REFERENCES Person.First_Name (First_Name_ID)
																ON UPDATE CASCADE
												,CONSTRAINT FK_LN_Person FOREIGN KEY (Last_Name_ID)			-- connect table "Last_Name" and "Person" with FK on "Last_Name_ID"
																REFERENCES Person.Last_Name (Last_Name_ID)
																ON UPDATE CASCADE
												,CONSTRAINT FK_PH1_Person FOREIGN KEY (Phone_ID_1)			-- connect table "Phone1" and "Person" with FK on "Phone_ID"
																REFERENCES Person.Phone_Number (Phone_ID)
																ON UPDATE CASCADE
												,CONSTRAINT FK_PH2_Person FOREIGN KEY (Phone_ID_2)			-- connect table "Phone2" and "Person" with FK on "Phone_ID"
																REFERENCES Person.Phone_Number (Phone_ID)
																--ON UPDATE CASCADE
												,CONSTRAINT FK_Email_Person FOREIGN KEY (Email_ID)			-- connect table "Email" and "Person" with FK on "Email_ID"
																REFERENCES Person.Email (Email_ID)
																ON UPDATE CASCADE
												,CONSTRAINT FK_Type_Person FOREIGN KEY (Person_Type_ID)			-- connect table "Person_Type" and "Person" with FK on "Person_Type_ID"
																REFERENCES Person.Person_Type (Person_Type_ID)
																ON UPDATE CASCADE
												,CONSTRAINT FK_Business_Person FOREIGN KEY (Business_ID)			-- connect table "Business" and "Person" with FK on "Business_ID"
																REFERENCES Business.Business (Business_ID)
																ON UPDATE CASCADE
				;
				GO

				ALTER TABLE Person.Phone_Number
								ADD
												 CONSTRAINT CK_PhoneNumberFormat1 CHECK (Phone_Number like '(%)%-%')	-- Check that the phone number follows phone number structure
												,CONSTRAINT FK_Phone#_Phone#Type FOREIGN KEY (Phone_Number_Type_ID)			-- connect table "PhoneType" and "Phone" with FK on "Phone_Number_Type_ID"
																REFERENCES Person.Phone_Number_Type (Phone_Number_Type_ID)
																ON UPDATE CASCADE
				;
				GO

				ALTER TABLE Person.Email
								ADD
												 CONSTRAINT U_Email UNIQUE NONCLUSTERED (Email_Address)-- make Email Name unique (no repeating names) 
												,CONSTRAINT CK_EmailAddressFormat CHECK (Email_Address like '%@%.%')	-- Check that the email address follows email structure
				;
				GO

				--------------------------------------------------------------------------------------------------------------------------------


			ALTER TABLE [Address].[Address]
								ADD
												 CONSTRAINT FK_City_Address FOREIGN KEY (City_ID)			-- connect table "City" and "Address" with FK on "City_ID"
																REFERENCES [Address].City (City_ID)
																ON UPDATE CASCADE
												,CONSTRAINT FK_State_Address FOREIGN KEY (State_ID)			-- connect table "State" and "Address" with FK on "State_ID"
																REFERENCES [Address].[State] (State_ID)
																ON UPDATE CASCADE
												,CONSTRAINT FK_Zip_Address FOREIGN KEY (Zip_Code_ID)			-- connect table "Zip_Code" and "Address" with FK on "Zip_Code_ID"
																REFERENCES [Address].Zip_Code (Zip_Code_ID)
																ON UPDATE CASCADE
				;
				GO

			ALTER TABLE [Address].City
								ADD
												 CONSTRAINT U_City UNIQUE NONCLUSTERED (City_Name)-- make City_Name unique (no repeating names) 
				;
				GO

			ALTER TABLE [Address].[State]
								ADD
												 CONSTRAINT U_State UNIQUE NONCLUSTERED (State_Name)-- make State_Name unique (no repeating names) 
				;
				GO


				----------------------------------------------------------------------------------------------------------------------------


			ALTER TABLE Project.Project
								ADD
												 CONSTRAINT FK_SW_Project FOREIGN KEY (Software_ID)			-- connect table "Software" and "Project" with FK on "Software_ID"
																REFERENCES Project.Software (Software_ID)
																ON UPDATE CASCADE
												,CONSTRAINT FK_Business_Project FOREIGN KEY (Business_ID)			-- connect table "Business" and "Project" with FK on "Business_ID"
																REFERENCES Business.Business (Business_ID)
																ON UPDATE CASCADE
												,CONSTRAINT FK_Person_Project FOREIGN KEY (Person_ID)			-- connect table "Office_Type" and "Project" with FK on "Person_ID"
																REFERENCES Person.Person (Person_ID)
																--ON UPDATE CASCADE
												,CONSTRAINT FK_Training_Project FOREIGN KEY (Training_ID)			-- connect table "Office_Type" and "Project" with FK on "Training_ID"
																REFERENCES Training.Training (Training_ID)
																ON UPDATE CASCADE
				;
				GO

			ALTER TABLE Project.Software
								ADD
												 CONSTRAINT U_SW_Package UNIQUE NONCLUSTERED (SW_Package)-- make SW_Package Name unique (no repeating names) 
				;
				GO


				------------------------------------------------------------------------------------------------------------------------------

				
				ALTER TABLE Billing.Billing
								ADD
												 CONSTRAINT FK_Project_Billing FOREIGN KEY (Project_ID)			-- connect table "Project" and "Billing" with FK on "Project_ID"
																REFERENCES Project.Project (Project_ID)
																ON UPDATE CASCADE
												,CONSTRAINT FK_Training_Billing FOREIGN KEY (Training_Expense_ID)			-- connect table "Training_Type" and "Billing" with FK on "Training_Expense_ID"
																REFERENCES Training.Training_Expense (Training_Expense_ID)
																ON UPDATE CASCADE
												,CONSTRAINT U_Invoice UNIQUE NONCLUSTERED (Invoice_Number)-- make SInvoice_Number Name unique (no repeating names) 
				;
				GO


------------------------------------------------------------------------------------------------------------------------------------


			ALTER TABLE Training.Training
								ADD
												 CONSTRAINT FK_Software_Training FOREIGN KEY (Software_ID)			-- connect table "Software" and "Training" with FK on "Software_ID"
																REFERENCES Project.Software (Software_ID)
																--ON UPDATE CASCADE
												,CONSTRAINT FK_TrainingType_Training FOREIGN KEY (Training_Type_ID)			-- connect table "Training_Type" and "Training" with FK on "Training_Type_ID"
																REFERENCES Training.Training_Type (Training_Type_ID)
																--ON UPDATE CASCADE
												,CONSTRAINT FK_Person_Training FOREIGN KEY (Person_ID)			-- connect table "Person" and "Training" with FK on "Person_ID"
																REFERENCES Person.Person (Person_ID)
																--ON UPDATE CASCADE
												,CONSTRAINT FK_Expense_Training FOREIGN KEY (Training_Expense_ID)			-- connect table "Person" and "Training" with FK on "Expense_ID"
																REFERENCES [Training].[Training_Expense] (Training_Expense_ID)
																--ON UPDATE CASCADE
				;
				GO


				------------------------------------------------------------------------------------------------------------------


			ALTER TABLE Business.Business
								ADD
												 CONSTRAINT FK_BusinessName_Business FOREIGN KEY (Business_Name_ID)			-- connect table "Office_Type" and "Address" with FK on "Office_Type_ID"
																REFERENCES Business.Business_Name (Business_Name_ID)
																ON UPDATE CASCADE			
												,CONSTRAINT FK_BusinessType_Business FOREIGN KEY (Business_Type_ID)			-- connect table "Address" and "Person" with FK on "Address_ID"
																REFERENCES Business.Business_Type (Business_Type_ID)
																ON UPDATE CASCADE															
												 ,CONSTRAINT FK_OfficeType_Business FOREIGN KEY (Office_Type_ID)			-- connect table "Office_Type" and "Address" with FK on "Office_Type_ID"
																REFERENCES Business.Office_Type (Office_Type_ID)
																ON UPDATE CASCADE			
												,CONSTRAINT FK_Address_Business FOREIGN KEY (Address_ID)			-- connect table "Address" and "Person" with FK on "Address_ID"
																REFERENCES [Address].[Address] (Address_ID)
																ON UPDATE CASCADE																									 
												
				;
				GO

					ALTER TABLE Business.Business_Name
								ADD
													 CONSTRAINT U_BusinessName UNIQUE NONCLUSTERED (Business_Name)-- make Business Name unique (no repeating names) 
				;
				GO


-------------------------------------------------------------------------------- Adding Views ------------------------------------------------------------------------------


					Use [mrbrown3_db_Essentials_for_Devsv2.0];
					GO

				CREATE -- Drop																																																-- Create View (Person.vPerson) of the entire Person table 				
				VIEW Person.vPerson AS
								SELECT * FROM Person.Person;
				GO

				CREATE -- Drop																																																-- Create View (Person.vFirst_Name) of the entire First_Name table 	
				VIEW Person.vFirst_Name AS
								SELECT * FROM Person.First_Name;
				GO

				CREATE -- Drop																																																-- Create View (Person.vLast_Name) of the entire Last_Name table 	
				VIEW Person.vLast_Name AS
								SELECT * FROM Person.Last_Name;
				GO

				CREATE -- Drop																																																-- Create View (Person.vPhone_Number_Type) of the entire Number_Type table 	
				VIEW Person.vPhone_Number_Type AS
								SELECT * FROM Person.Phone_Number_Type;
				GO

				CREATE -- Drop																																																-- Create View (Person.vPhone_Number) of the entire Phone_Number table 	
				VIEW Person.vPhone_Number AS
								SELECT * FROM Person.Phone_Number;
				GO

				CREATE -- Drop																																																-- Create View (Person.vEmail) of the entire Email table 				
				VIEW Person.vEmail AS
								SELECT * FROM Person.Email;
				GO

				CREATE -- Drop																																																-- Create View (Person.vPerson_Type) of the entire Person_Type table 	
				VIEW Person.vPerson_Type AS
								SELECT * FROM Person.Person_Type;
				GO

				CREATE -- Drop																																																-- Create View ([Address].[vAddress]) of the entire Address table 	
				VIEW [Address].[vAddress] AS
				SELECT * FROM [Address].[Address];
				GO

				CREATE -- Drop																																																-- Create View ([Address].vCity) of the entire City table 	
				VIEW [Address].vCity AS
				SELECT * FROM [Address].City;
				GO

				CREATE -- Drop																																																-- Create View ([Address].[vState]) of the entire State table 	
				VIEW [Address].[vState] AS
				SELECT * FROM [Address].[State];
				GO

				CREATE -- Drop																																																-- Create View ([Address].[vState]) of the entire State table 	
				VIEW [Address].[vZip_Code] AS
				SELECT * FROM [Address].Zip_Code;
				GO

				CREATE -- Drop																																																-- Create View (vProject) of the entire Project table 	
				VIEW Project.vProject AS
				SELECT * FROM Project.Project;
				GO

				CREATE -- Drop																																																-- Create View (vSoftware) of the entire Software table 	
				VIEW Project.vSoftware AS
				SELECT * FROM Project.Software;
				GO

				CREATE -- Drop																																																-- Create View (vBilling) of the entire Billing table 	
				VIEW Billing.vBilling AS
				SELECT * FROM Billing.Billing;
				GO

				CREATE -- Drop																																																-- Create View (vTraining) of the entire Training table 	
				VIEW Training.vTraining AS
				SELECT * FROM Training.Training;
				GO

				CREATE -- Drop																																																-- Create View (vTraining_Expense) of the entire Training_Expense table 	
				VIEW Training.vTraining_Expense AS
				SELECT * FROM Training.Training_Expense;
				GO

				CREATE -- Drop																																																-- Create View (vTraining_Type) of the entire Training_Type table 	
				VIEW Training.vTraining_Type AS
				SELECT * FROM Training.Training_Type;
				GO

				CREATE -- Drop																																																-- Create View (vBusiness) of the entire Business table 	
				VIEW Business.vBusiness AS
				SELECT * FROM Business.Business;
				GO

				CREATE -- Drop																																																-- Create View (vBusiness) of the entire Business table 	
				VIEW Business.vBusiness_Name AS
				SELECT * FROM Business.Business_Name;
				GO

				CREATE -- Drop																																																-- Create View (vBusiness) of the entire Business table 	
				VIEW Business.vBusiness_Type AS
				SELECT * FROM Business.Business_Type;
				GO

				CREATE -- Drop																																																-- Create View ([Address].vOffice_Type) of the entire Office_Type table 	
				VIEW Business.vOffice_Type AS
				SELECT * FROM Business.Office_Type;
				GO
	
				--Use mrbrown3_db_Essentials_for_Devsv2.0;
				--GO
				
				--SELECT * FROM Person.vPerson;																																																			-- Check Tables for data
				--SELECT * FROM Person.vFirst_Name;
				--SELECT * FROM Person.vLast_Name;
				--SELECT * FROM Person.vPhone_Number_Type;
				--SELECT * FROM Person.vPhone_Number;
				--SELECT * FROM Person.vEmail;
				--SELECT * FROM Person.vPerson_Type;

				--SELECT * FROM [Address].[vAddress]
				--SELECT * FROM [Address].vCity
				--SELECT * FROM [Address].[vState]
				--SELECT * FROM [Address].vZip_Code

				--SELECT * FROM Project.vProject;
				--SELECT * FROM Project.vSoftware;
				
				--SELECT * FROM Billing.vBilling;

				--SELECT * FROM Training.vTraining;
				--SELECT * FROM Training.vTraining_Expense;
				--SELECT * FROM Training.vTraining_Type;

				--SELECT * FROM Business.vBusiness
				--SELECT * FROM Business.vBusiness_Name
				--SELECT * FROM Business.vBusiness_Type
				--SELECT * FROM Business.vOffice_Type
				--GO


	------------------------------------------------------------------------- Set Permissions ---------------------------------------------------------------------------------


				--DENY Select ON Person.Person TO PUBLIC;																	-- Deny the public access to this table
				--DENY Select ON Person.First_Name TO PUBLIC;													-- Deny the public access to this table
				--DENY Select ON Person.Last_Name TO PUBLIC;														-- Deny the public access to this table
				--DENY Select ON Person.Phone_Number_Type TO PUBLIC;						-- Deny the public access to this table
				--DENY Select ON Person.Phone_Number TO PUBLIC;								 		-- Deny the public access to this table
				--DENY Select ON Person.Email TO PUBLIC;														  		-- Deny the public access to this table
				--DENY Select ON Person.Person_Type TO PUBLIC;												-- Deny the public access to this table
				--DENY Select ON [Address].[Address] TO PUBLIC;											-- Deny the public access to this table
				--DENY Select ON [Address].City TO PUBLIC;														  -- Deny the public access to this table
				--DENY Select ON [Address].[State] TO PUBLIC;									   	-- Deny the public access to this table
				--DENY Select ON [Address].Zip_Code TO PUBLIC;			   						-- Deny the public access to this table
				--DENY Select ON Project.Project TO PUBLIC;										   		-- Deny the public access to this table
				--DENY Select ON Project.Software TO PUBLIC;														-- Deny the public access to this table
				--DENY Select ON Billing.Billing TO PUBLIC;															-- Deny the public access to this table
				--DENY Select ON Training.Training TO PUBLIC;													-- Deny the public access to this table
				--DENY Select ON Training.Training_Expense TO PUBLIC;					-- Deny the public access to this table
				--DENY Select ON Training.Training_Type TO PUBLIC;						  -- Deny the public access to this table
				--DENY Select ON Business.Business TO PUBLIC;									    -- Deny the public access to this table
				--DENY Select ON Business.Business_Name TO PUBLIC;							 -- Deny the public access to this table
				--DENY Select ON Business.Business_Type TO PUBLIC;						  -- Deny the public access to this table
				--DENY Select ON Business.Office_Type TO PUBLIC;						    -- Deny the public access to this table

				--GRANT Select ON Person.vPerson TO PUBLIC;																	-- Give the public access to this table
				--GRANT Select ON Person.vFirst_Name TO PUBLIC;													-- Give the public access to this table
				--GRANT Select ON Person.vLast_Name TO PUBLIC;														-- Give the public access to this table
				--GRANT Select ON Person.vPhone_Number_Type TO PUBLIC;						-- Give the public access to this table
				--GRANT Select ON Person.vPhone_Number TO PUBLIC;								 		-- Give the public access to this table
				--GRANT Select ON Person.vEmail TO PUBLIC;														  		-- Give the public access to this table
				--GRANT Select ON Person.vPerson_Type TO PUBLIC;												-- Give the public access to this table
				--GRANT Select ON [Address].[vAddress] TO PUBLIC;											-- Give the public access to this table
				--GRANT Select ON [Address].vCity TO PUBLIC;														  -- Give the public access to this table
				--GRANT Select ON [Address].[vState] TO PUBLIC;									   	-- Give the public access to this table
				--GRANT Select ON [Address].vZip_Code TO PUBLIC;		   							-- Give the public access to this table
				--GRANT Select ON Project.vProject TO PUBLIC;										   		-- Give the public access to this table
				--GRANT Select ON Project.vSoftware TO PUBLIC;														-- Give the public access to this table
				--GRANT Select ON Billing.vBilling TO PUBLIC;															-- Give the public access to this table
				--GRANT Select ON Training.vTraining TO PUBLIC;													-- Give the public access to this table
				--GRANT Select ON Training.vTraining_Expense TO PUBLIC;					-- Give the public access to this table
				--GRANT Select ON Training.vTraining_Type TO PUBLIC;						  -- Give the public access to this table
				--GRANT Select ON Business.vBusiness TO PUBLIC;									    -- Give the public access to this table
				--GRANT Select ON Business.vBusiness_Name TO PUBLIC;							 -- Give the public access to this table
				--GRANT Select ON Business.vBusiness_Type TO PUBLIC;						  -- Give the public access to this table
				--GRANT Select ON Business.vOffice_Type TO PUBLIC;						    -- Give the public access to this table


----------------------------------------------------------------------------- System Database Information ------------------------------------------------------------------
	
	
	--EXEC SP_HELPCONSTRAINT Employee;																												-- Shows only the constraints on the tables.
	--EXEC SP_HELPCONSTRAINT Employee_Group;
	--EXEC SP_HELPCONSTRAINT Locations;
	--EXEC SP_HELPCONSTRAINT Office_Type;
	--EXEC SP_HELPCONSTRAINT Projects;
	--EXEC SP_HELPCONSTRAINT Clients;
	--EXEC SP_HELPCONSTRAINT Training;
	--EXEC SP_HELPCONSTRAINT Billing;
	--EXEC SP_HELPCONSTRAINT People;
	--EXEC SP_HELPCONSTRAINT Phone_Numbers;

	--EXEC SP_HELP Employee;																								 -- General information about tables:
	--EXEC SP_HELP Employee_Group;
	--EXEC SP_HELP Locations;
	--EXEC SP_HELP Office_Type;
	--EXEC SP_HELP Projects;
	--EXEC SP_HELP Clients;
	--EXEC SP_HELP Training;
	--EXEC SP_HELP Billing;
	--EXEC SP_HELP People;
	--EXEC SP_HELP Phone_Numbers;
	--GO


	----------------------------------------------------------------------------- Assignment 6-1 ------------------------------------------------------------------------------


	----------------------------------------------------------------------------- Table Update --------------------------------------------------------------------------------

	-- 3.Updates at least 2 values in any table

				--Update Billing.Billing																																												-- Examples of an Update Statement
				--				SET  
				--								Invoice_Amount = 75000
				--				WHERE 
				--								Billing_ID = 4
				--				;
				--GO

				--Update [Address].[Address]
				--				SET  
				--								[Address] = 'Bradley',
				--								City_ID = 2,
				--								State_ID = 5,
				--								Business_ID = 4
				--				WHERE 
				--								[Address_ID] = 1
				--				;
				--GO

				--		Update Person.Email
				--				SET  
				--								Email_Address = 'Bradley.Bradley@TaylorSoft.com'
				--				WHERE 
				--								Email_ID = 1
				--				;
				--GO

				--Select * FROM Billing.Billing																																					-- Checking Data
				--Select * FROM [Address].[Address]
	 		--Select * FROM Person.Email
		
	----------------------------------------------------------------------------- Table Delete Data ---------------------------------------------------------------------------

	-- 4.Deletes at least 2 values in any table

				--DELETE FROM Person.Person_Type																																			 			-- Example of a Delete statement
				--				WHERE Person_Type_ID = 6;
				--GO

				--DELETE FROM Business.Office_Type																																										-- Example of a Delete statement
				--				WHERE Office_Type_ID = 4;
				--GO

				--Select * FROM Person.Person_Type																																			-- Checking Data
				--Select * FROM Business.Office_Type


	----------------------------------------------------------------------------- Table Data Queries --------------------------------------------------------------------------

	--			Use [mrbrown3_db_Essentials_for_Devsv2.0];
	--			GO

	--Select			
	
	--								First_Name, 
	--								Last_Name, 
	--								Person_Type, 
	--								Business_Name, 
	--								Business_Type, 
	--								[Address], 
	--								City_Name, 
	--								State_Name, 
	--								Zip_Code

	--From Business.Business
	--				Inner Join Business.Business_Name on	Business_Name.Business_Name_ID = Business.Business_Name_ID
	--				Inner Join Business.Business_Type on Business_Type.Business_Type_ID = Business.Business_Type_ID

	--				Inner Join [Address].[Address] on [Address].Business_ID = Business.Business_ID
	--				Inner Join [Address].City on City.City_ID = [Address].City_ID
	--				Inner Join [Address].[State] on [State].State_ID = [Address].State_ID
	--				Inner Join [Address].Zip_Code on Zip_Code.Zip_Code_ID = [Address].Zip_Code_ID

	--			--Inner Join Project.Project on Project.Business_ID = Business.Business_ID
	--			--Inner Join Project.Software on Project.Software_ID = Software.Software_ID

	--			Inner Join Person.Person on Person.Address_ID = [Address].[Address_ID]
	--			--		Inner Join Person.Person on Business.Business_ID = Person.[Business_ID]
	--				Inner Join Person.First_Name on Person.[First_Name_ID] = First_Name.[First_Name_ID]
	--				Inner Join Person.Last_Name on Person.Last_Name_ID = Last_Name.[Last_Name_ID]
	--				Inner Join Person.Person_Type on Person.Person_Type_ID = Person_Type.Person_Type_ID

	--where Business_Name = 'TaylorSoft'



	--	Select			
	--							 Business.Business_ID,
	--								Business.Business_Name_ID,
	--								Business_Name, 
	--								Business.Business_Type_ID,
	--								Business_Type, 
	--								Business.Office_Type_ID,
	--								Office_Type,
	--								Business.Address_ID,
	--								[Address],
	--								City_Name, 
	--								State_Name, 
	--								Zip_Code
	--From Business.Business
	--				Inner Join Business.Business_Name on	Business_Name.Business_Name_ID = Business.Business_Name_ID
	--				Inner Join Business.Business_Type on Business_Type.Business_Type_ID = Business.Business_Type_ID
	--				Inner Join Business.Office_Type	on Business.Office_Type_ID = Office_Type.Office_Type_ID
	--				Inner Join [Address].[Address] on [Address].Business_ID = Business.Business_ID
	--				Inner Join [Address].City on City.City_ID = [Address].City_ID
	--				Inner Join [Address].[State] on [State].State_ID = [Address].State_ID
	--				Inner Join [Address].Zip_Code on Zip_Code.Zip_Code_ID = [Address].Zip_Code_ID

	--Select			
	--							 [Address].Address_ID,
	--								[Address],
	--								City_Name, 
	--								State_Name, 
	--								Zip_Code,
	--								Business.Business_ID
	--From [Address].[Address]
	--				Inner Join Business.Business on Business.Business_ID =  [Address].Business_ID
	--				Inner Join [Address].City on City.City_ID = [Address].City_ID
	--				Inner Join [Address].[State] on [State].State_ID = [Address].State_ID
	--				Inner Join [Address].Zip_Code on Zip_Code.Zip_Code_ID = [Address].Zip_Code_ID


	--			Select			
	--											Person.Person_ID,
	--											First_Name.First_Name, 
	--											Last_name.Last_Name, 
	--											Person.[Address_ID], 
	--											person.Phone_ID_1 ,
	--											P1.Phone_Number ,
	--											Person.Phone_ID_2 ,
	--											P2.Phone_Number ,
	--											Email_Address,
	--											Person_Type, 
	--											Person.Business_ID

	--			From				Person.Person

	--			Inner Join Person.First_Name on Person.[First_Name_ID] = First_Name.[First_Name_ID]
	--			Inner Join Person.Last_Name on Person.Last_Name_ID = Last_Name.[Last_Name_ID]
	--			Inner Join Person.Person_Type on Person.Person_Type_ID = Person_Type.Person_Type_ID
	--			Inner Join Person.Phone_Number AS P1 on Person.Phone_ID_1 = P1.Phone_ID
	--			Left Join Person.Phone_Number AS P2 on Person.Phone_ID_2 = P2.Phone_ID
	--			Left Join Person.Email on Email.Email_ID = Person.Email_ID
	--			Inner Join [Address].[Address] on [Address].[Address_ID] = Person.Address_ID




----------------------------------------------------------- Save for Reference ------------------------------------------------------------------------
	
	----------------------------------------------------------- Simple Recovery Backup --------------------------------------------------------------------


--				USE [master];
--				GO

--				ALTER DATABASE [mrbrown3_db_Essentials_for_Devsv2.0] SET RECOVERY SIMPLE WITH NO_WAIT;
--				GO

--				BACKUP DATABASE [mrbrown3_db_Essentials_for_Devsv2.0] 
--				TO  DISK = N'C:\Temp\ServerName_mrbrown3_Simple_Backup_CurrentDate.bak'
--								WITH NOFORMAT
--								, NOINIT
--								, NAME = N'ServerName_db_BackupType_Date'
--								, SKIP
--								, NOREWIND
--								, NOUNLOAD
--								,  STATS = 10
--GO


----------------------------------------------------------- Assignment 8 ------------------------------------------------------------------------

				--1.Creates your latest database, with all database objects
				--2.Inserts data into your Tables
				--3.Creates at least two Views
				--4.Creates two Database Roles
				--5.Assigns SELECT permissions on the two Views to the two Roles - one Role should be able to SELECT from one View, and the other Role from the other View
				--6.Creates two SQL Server Logins
				--7.Creates two Database Users in your database, tied to the two Server Logins
				--8.Assigns the two Database Users to the Roles, one Database User per Role.

----------------------------------------------------- Roles -------------------------------------------------------------------------
				
				--Use mrbrown3_db_Essentials_for_Devsv2.0;
				--GO

				----USE [master]
				--CREATE --DROP																																																							-- Create Role
				--ROLE [mrbrown3_SuperUser];
				--GO

				--Use mrbrown3_db_Essentials_for_Devsv2.0;
				--GO

			 --GRANT Select ON Person.vPerson TO mrbrown3_SuperUser;															-- Give the mrbrown3_SuperUser access to this table
				--GRANT Select ON Person.vFirst_Name TO mrbrown3_SuperUser;											-- Give the mrbrown3_SuperUser access to this table
				--GRANT Select ON Person.vLast_Name TO mrbrown3_SuperUser;												-- Give the mrbrown3_SuperUser access to this table
				--GRANT Select ON Person.vPhone_Number_Type TO mrbrown3_SuperUser;				-- Give the mrbrown3_SuperUser access to this table
				--GRANT Select ON Person.vPhone_Number TO mrbrown3_SuperUser;						 		-- Give the mrbrown3_SuperUser access to this table
				--GRANT Select ON Person.vEmail TO mrbrown3_SuperUser;												  		-- Give the mrbrown3_SuperUser access to this table
				--GRANT Select ON Person.vPerson_Type TO mrbrown3_SuperUser;										-- Give the mrbrown3_SuperUser access to this table
				--GRANT Select ON Billing.vBilling TO mrbrown3_SuperUser;													-- Give the mrbrown3_SuperUser access to this table

		 	--DENY Select ON [Address].[Address] TO mrbrown3_SuperUser;											-- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON [Address].City TO mrbrown3_SuperUser;														  -- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON [Address].[State] TO mrbrown3_SuperUser;									   	-- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON [Address].Zip_Code TO mrbrown3_SuperUser;			   						-- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON Project.Project TO mrbrown3_SuperUser;										   		-- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON Project.Software TO mrbrown3_SuperUser;														-- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON Training.Training TO mrbrown3_SuperUser;													-- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON Training.Training_Expense TO mrbrown3_SuperUser;					-- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON Training.Training_Type TO mrbrown3_SuperUser;						  -- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON Business.Business TO mrbrown3_SuperUser;									    -- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON Business.Business_Name TO mrbrown3_SuperUser;							 -- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON Business.Business_Type TO mrbrown3_SuperUser;						  -- Deny the mrbrown3_SuperUser access to this table
				--DENY Select ON Business.Office_Type TO mrbrown3_SuperUser;						    -- Deny the mrbrown3_SuperUser access to this table

				----USE [master]
				--CREATE --DROP																																																			-- Create Role
				--ROLE [mrbrown3_user];
				--GO

				--Use mrbrown3_db_Essentials_for_Devsv2.0;
				--GO
	 		--GRANT Select ON [Address].[vAddress] TO mrbrown3_user;											-- Give the mrbrown3_user access to this table
				--GRANT Select ON [Address].vCity TO mrbrown3_user;														  -- Give the mrbrown3_user access to this table
				--GRANT Select ON [Address].[vState] TO mrbrown3_user;									   	-- Give the mrbrown3_user access to this table
				--GRANT Select ON [Address].vZip_Code TO mrbrown3_user;		   							-- Give the mrbrown3_user access to this table
				--GRANT Select ON Project.vProject TO mrbrown3_user;										   		-- Give the mrbrown3_user access to this table
				--GRANT Select ON Project.vSoftware TO mrbrown3_user;														-- Give the mrbrown3_user access to this table
				--GRANT Select ON Training.vTraining TO mrbrown3_user;													-- Give the mrbrown3_user access to this table
				--GRANT Select ON Training.vTraining_Expense TO mrbrown3_user;					-- Give the mrbrown3_user access to this table
				--GRANT Select ON Training.vTraining_Type TO mrbrown3_user;						  -- Give the mrbrown3_user access to this table
				--GRANT Select ON Business.vBusiness TO mrbrown3_user;									    -- Give the mrbrown3_user access to this table
				--GRANT Select ON Business.vBusiness_Name TO mrbrown3_user;							 -- Give the mrbrown3_user access to this table
				--GRANT Select ON Business.vBusiness_Type TO mrbrown3_user;						  -- Give the mrbrown3_user access to this table
				--GRANT Select ON Business.vOffice_Type TO mrbrown3_user;						    -- Give the mrbrown3_user access to this table

				--DENY Select ON Person.Person TO mrbrown3_user;																	-- Deny the mrbrown3_user access to this table
				--DENY Select ON Person.First_Name TO mrbrown3_user;													-- Deny the mrbrown3_user access to this table
				--DENY Select ON Person.Last_Name TO mrbrown3_user;														-- Deny the mrbrown3_user access to this table
				--DENY Select ON Person.Phone_Number_Type TO mrbrown3_user;						-- Deny the mrbrown3_user access to this table
				--DENY Select ON Person.Phone_Number TO mrbrown3_user;								 		-- Deny the mrbrown3_user access to this table
				--DENY Select ON Person.Email TO mrbrown3_user;														  		-- Deny the mrbrown3_user access to this table
				--DENY Select ON Person.Person_Type TO mrbrown3_user;												-- Deny the mrbrown3_user access to this table
				--DENY Select ON Billing.Billing TO mrbrown3_user;															-- Deny the mrbrown3_user access to this table


				------------------------------------- SQL Server Logins -----------------------------------------------------------------------
			
				
				----USE [master]
				--CREATE --DROP
				--LOGIN																																																															-- Create Login w/ password
				--				mrbrown3_user 
				--								WITH PASSWORD = 'password', 
				--								DEFAULT_DATABASE = mrbrown3_db_Essentials_for_Devsv2.0 
				--								,DEFAULT_LANGUAGE = us_english
				--								,CHECK_POLICY= OFF;

				--CREATE --DROP
				--LOGIN																																																															-- Create Login w/ password 
				--				mrbrown3_Superuser 
				--								WITH PASSWORD = 'Passwart', 
				--								DEFAULT_DATABASE = mrbrown3_db_Essentials_for_Devsv2.0 
				--								,DEFAULT_LANGUAGE = us_english
				--								,CHECK_POLICY= OFF;


				-------------------------------------------------- Database Users ---------------------------------------------------------------

				--CREATE --DROP																																											 													-- Create user
				--USER mrbrown3_A FOR LOGIN mrbrown3_user;
				--GO

				--CREATE --DROP																																																										-- Create user
				--USER mrbrown3_B FOR LOGIN mrbrown3_Superuser;
				--GO


				------------------------------------------------------- Alter Roles -----------------------------------------------


				--ALTER ROLE mrbrown3_user ADD MEMBER mrbrown3_B;																									-- Add member to the Role
				--ALTER ROLE mrbrown3_Superuser ADD MEMBER mrbrown3_A;  


------------------------------------------------------------------------------------------------------------------------
	
	

				--Use [mrbrown3_db_Essentials_for_Devsv2.0];
				--GO

				---- I chose to create indexes on what I thought would be the most queried tables
				---- The first index, Names - I chose both the first and last name because is associated People/Training/Projects/Business Tables
				--Create INDEX Names on Person.Person (First_Name_ID, Last_Name_ID);																		-- Create an non-clustered index for the Person table on First_Name_ID and Last_Name_ID
				--Go

				---- BusinessNames index was created to speed up searches for Business and their address - which employees could be deployed to for training
				--Create INDEX BusinessNames on Business.Business (Business_Name_ID, Address_ID);					-- Create an non-clustered index for the Business table on Business_Name_ID and Address_ID
				--Go

				---- Index “Project”, was created as it will be queried constantly matching Projects to programmers and trainers to Businesses and the software package underdevelopment or deployed
				--Create INDEX Projects on Project.Project (Person_ID, Business_ID, Software_ID);					-- Create an non-clustered index for the Project table on Person_ID,  Business_ID, and Software_ID
				--Go

				---- The “Address” index, was created as it is associated with People and Businesses.  I figured that this would also be queried a lot
				--Create INDEX [Address] on [Address].[Address] ([Address], State_ID, Business_ID);			-- Create an non-clustered index for the Address table on Address, State_ID, and Business_ID
				--Go