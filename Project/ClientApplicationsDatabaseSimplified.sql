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
				TABLE Inventory                                                    -- Create Table
				(																																												  																															-- Adding Columns
					 Inventory_ID TINYINT NOT NULL IDENTITY(1,1) PRIMARY KEY
					 ,Part_Number Varchar (50) NOT NULL
					,MFG_Name Varchar (50) NOT NULL
					,[Device_Name] VARCHAR (255) NOT NULL
					,[Type] Varchar (50) NOT NULL
					,[Desc] VARCHAR(max)
					,Cost money
					,Attributes VARCHAR(255)
					,[AddedDate] [datetime] NOT NULL DEFAULT (getdate())
				);

				INSERT INTO Inventory																																																					-- Insert into Table											
								(
					 Part_Number
					,MFG_Name
					,[Device_Name]
					,[Type]
					,[Desc]
					,Cost
					,Attributes
								)
				VALUES																																																																							 -- Values to be inserted
								 ('XYZ123', 'Smartthings', 'Motion Sensor', 'Motion Dection'
								 ,'Keep your home under control with this Samsung SmartThings motion sensor. It sends an alert 
									to your smartphone via the SmartThings app when it detects unexpected movement, and the 
									thermostat trigger feature lets you program it to adjust the temperature based on occupancy. 
									The 131-foot range of this Samsung SmartThings motion sensor accommodates a wide variety of 
									floor plans.', $10.00, 'Detects motion from up to 15ft away,120° field of view,Motion alerts,Magnetic ball mount')

								;
GO																																																																																-- Execute

	