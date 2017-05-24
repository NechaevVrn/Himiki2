CREATE TABLE [MeasureProfileData]
(
  [ID] [int] IDENTITY(1,1) NOT NULL,
  [SensorID] [int] NOT NULL,
  [Position] [int] NOT NULL,
  [MeasureProfileID] [int] NOT NULL,
  CONSTRAINT [PK_MeasureProfileData] PRIMARY KEY (ID)
)