﻿-- Script Date: 09-Nov-18 10:37 PM  - ErikEJ.SqlCeScripting version 3.5.2.75
CREATE TABLE [CLIENT] (
  [CL_ID] INTEGER NOT NULL
, [NAME] TEXT NOT NULL
, [CASE_ID] INTEGER NOT NULL
, [PHONE] TEXT NOT NULL
, CONSTRAINT [PK_CLIENT] PRIMARY KEY ([CL_ID])
, CONSTRAINT [FK_CLIENT] FOREIGN KEY ([CASE_ID]) REFERENCES [CASES]([CASE_ID]) 
);
