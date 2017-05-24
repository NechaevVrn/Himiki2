CREATE TABLE [Data]
(
  [ID] [int] IDENTITY(1,1) NOT NULL,
  [MeasureID] [int] NOT NULL,
  [TimeValue] [float] NOT NULL,
  [FreqValue] [float] NOT NULL,
  [SensorID] [int] NOT NULL,
  CONSTRAINT [PK_Data] PRIMARY KEY ([ID])
)