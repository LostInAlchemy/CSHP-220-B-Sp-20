--**********************************************************************************************--
-- Title: SQLDEV Database for Client Applications UoW CSharp 220 
-- Class Project UoW CSharp 220
-- Author: Mark R Brown
-- Desc: This file demonstrates how to convert a 
--***********************************************************************************************--

--ALTER AUTHORIZATION ON DATABASE::[mrbrown3_db_Essentials_for_Devsv2.0] TO sa
--GO

BEGIN TRY
		USE MASTER;
		IF EXISTS(SELECT NAME FROM SYSDATABASES WHERE NAME = 'SmartHomeDevices')
		 BEGIN 
		  ALTER DATABASE SmartHomeDevices SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
		  DROP DATABASE SmartHomeDevices
		 END
		CREATE DATABASE SmartHomeDevices;
	END TRY
	BEGIN CATCH
		PRINT ERROR_NUMBER();
	END CATCH
	GO

	USE SmartHomeDevices;
	GO

	--------------------------------------------------------------- Create Tables & Add Data ---------------------------------------------------------------------------------------------

				CREATE  -- Drop	
				TABLE TypeInventory  -- Create Table
				(																																												  																															-- Adding Columns
					 [Type_InventoryID]		TINYINT			NOT NULL IDENTITY(1,1) PRIMARY KEY
					,[Type_Type]			VARCHAR (50)	NOT NULL
					,[Type_Desc]			VARCHAR(max)
					,[Type_AddedDate]		DATETIME		NOT NULL DEFAULT (getdate())
				);

				CREATE  -- Drop	
				TABLE DeviceInventory  -- Create Table
				(																																												  																															-- Adding Columns
					 [Device_InventoryID]	TINYINT			NOT NULL IDENTITY(1,1) PRIMARY KEY
					,[Device_MFGName]		VARCHAR (50)	NOT NULL
					,[Device_PartNumber]	VARCHAR (50)	NOT NULL
					,[Device_SerialNumber]	VARCHAR (50)	NOT NULL
					,[Device_DeviceName]	VARCHAR (255)	NOT NULL
					,[Device_Type]			VARCHAR (50)	NOT NULL
					,[Device_PowerType]		VARCHAR (50)
					,[Device_Attributes]	VARCHAR(255)
					,[Device_Protocol]		VARCHAR(50)		NOT NULL
					,[Device_Cost]			MONEY
					,[Device_MFGDesc]		VARCHAR(max)
					,[Device_Status]		VARCHAR(20)		NOT NULL
					,[Device_ControlledBy]	VARCHAR (50)
					,[Device_Location]		VARCHAR(50)
					,[Device_AddedDate]		DATETIME		NOT NULL DEFAULT (getdate())
				);
GO																																																																																-- Execute

	insert into TypeInventory ([Type_Type],[Type_Desc])
	values
	('Motion Sensor', 'Detects motion'),
	('Contact Sensor', 'Detects open/close'),
	('Light Switch', 'On/Off Dimmer'),
	('WiFi Camera', 'Web camera that can be viewed over the internet');


		insert into DeviceInventory ([Device_MFGName],[Device_PartNumber],[Device_SerialNumber],[Device_DeviceName]
									,[Device_Type],[Device_PowerType],[Device_Attributes],[Device_Protocol]
									,[Device_Cost],[Device_MFGDesc],[Device_Status],[Device_ControlledBy],[Device_Location])

values
	('Samsung', '123', '123', 'Multipurpose Sensor', 'Contact Sensor', '120V Hardwired', 'Temperature, Tilt', 'Zigbee', 20.99, 'Monitor doors and windows. Monitor temperature and vibration.', 'Active', 'Smartthings', 'Somewhere'),
	('Samsung', '123', '456', 'Multipurpose Sensor', 'Contact Sensor', 'Battery_CR-2450', 'Temperature, Tilt', 'Zigbee', 20.99, 'Monitor doors and windows. Monitor temperature and orientation.', 'Active', 'Smartthings', 'Somewhere'),
	('Samsung', '123', '123', 'Motion Sensor', 'Motion Sensor', 'Battery_AA', 'Motion, Temperature', 'Zigbee', 35.50, 'Monitor motion and temperature. Adjust the sensor angle with the quick tilt magnetic ball mount.', 'DeActive', 'Smartthings', 'Somewhere'),
	('Samsung', '123', '456', 'Motion Sensor', 'Motion Sensor', 'Battery_CR-2032', 'Motion, Temperature', 'Zigbee', 35.50, 'Monitor motion and temperature.', 'Active', 'Smartthings', 'Somewhere'),
	('GE', '123', '123', 'Light Switch', 'Light Switch', 'Battery_CR-123A', 'On/Off, Dimmer', 'Zwave', 49.99, 'YadaYadaYota', 'Active', 'Smartthings', 'Somewhere'),
	('Wyze', '123', '123', 'Wyze Cam V2', 'WiFi Camera', '120V Hardwired', 'Built-in speaker and microphone, Push notifications, Night vision', 'WiFi', 19.99, 'YadaYadaYota', 'Active', 'Smartthings', 'Somewhere');
