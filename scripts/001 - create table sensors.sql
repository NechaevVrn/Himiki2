CREATE TABLE [Sensors] 
( 
   [SID] nvarchar(128) NOT NULL, 
   [Name] nvarchar(256)  NOT NULL,
   [Description] nvarchar(1024)  NULL, 
   [Settings] nvarchar(1024)  NOT NULL,
   [ID] [int] IDENTITY(1,1) NOT NULL, 

   CONSTRAINT [PK_Sensors] PRIMARY KEY ( [ID] ) 
)