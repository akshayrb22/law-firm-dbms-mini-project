﻿-- Script Date: 09-Nov-18 10:51 PM  - ErikEJ.SqlCeScripting version 3.5.2.75
CREATE TABLE [CASES] (
  [CASE_ID] INTEGER NOT NULL
, [STATUS ] TEXT NOT NULL
, [HOURS_BILLED] INTEGER NOT NULL
, [CL_ID] INTEGER NOT NULL
, [STAGE] TEXT NOT NULL
, [COURTROOM_NO] TEXT NOT NULL
, CONSTRAINT [PK_CASE] PRIMARY KEY ([CASE_ID])
, CONSTRAINT [FK_CASE] FOREIGN KEY ([CL_ID]) REFERENCES [CLIENT]([CLIENT_ID])

);
