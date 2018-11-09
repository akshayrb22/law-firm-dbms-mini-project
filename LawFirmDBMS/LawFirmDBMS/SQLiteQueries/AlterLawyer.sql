-- Script Date: 10-Nov-18 12:30 AM  - ErikEJ.SqlCeScripting version 3.5.2.75
-- Adding as column with NOT NULL is not allowed, set a default value or allow NULL
ALTER TABLE [LAWYER] ADD [PASSWORD] TEXT DEFAULT '' NOT NULL ;
