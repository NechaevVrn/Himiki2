ALTER TABLE [GroupTree]  
ADD CONSTRAINT [FK_GroupTreeIerarchy] 
  FOREIGN KEY([ParentID]) 
  REFERENCES [GroupTree] ([ID])