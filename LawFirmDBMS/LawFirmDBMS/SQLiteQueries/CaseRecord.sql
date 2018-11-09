﻿-- Script Date: 09-Nov-18 11:06 PM  - ErikEJ.SqlCeScripting version 3.5.2.75
CREATE TABLE [CASE_RECORD] (
  [DOC_ID] INTEGER NOT NULL
, [CASE_ID] INTEGER NOT NULL
, [P_ID] INTEGER NOT NULL
, CONSTRAINT [PK_CASE_RECORD] PRIMARY KEY ([DOC_ID],[CASE_ID],[P_ID])
, CONSTRAINT [FK_CASE_RECORD] FOREIGN KEY ([CASE_ID]) REFERENCES [CASES]([CASE_ID])
, CONSTRAINT [FK_CASE_RECORD] FOREIGN KEY ([P_ID]) REFERENCES [PARALEGAL]([PARALEGAL_ID])
);
