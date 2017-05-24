ALTER TABLE [MeasureProfileData]  
ADD  CONSTRAINT [FK_MeasureProfileData_MeasureProfile] 
  FOREIGN KEY([MeasureProfileID])
  REFERENCES [MeasureProfile] ([ID])
      ON UPDATE CASCADE
    ON DELETE CASCADE