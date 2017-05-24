ALTER TABLE [MeasureProfileData]  
ADD CONSTRAINT [FK_MeasureProfileData_Sensors] 
  FOREIGN KEY([SensorID])
  REFERENCES [Sensors] ([ID])
        ON UPDATE CASCADE
    ON DELETE CASCADE