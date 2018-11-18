-- Script Date: 14-Nov-18 2:26 PM  - ErikEJ.SqlCeScripting version 3.5.2.75
-- Adding as column with NOT NULL is not allowed, set a default value or allow NULL
ALTER TABLE [LAWYER] ADD CONSTRAINT [PK_LAWYER] PRIMARY KEY ([L_ID], [PHONE]);
