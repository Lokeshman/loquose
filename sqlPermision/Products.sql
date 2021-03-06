/*
   Saturday, April 7, 20189:23:36 AM
   User: 
   Server: .\SQL2008
   Database: LokeshSE
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Products
	(
	Id int NOT NULL IDENTITY (1, 1),
	ProductId varchar(16) NOT NULL,
	Name nvarchar(128) NOT NULL,
	Quantity numeric(18, 2) NOT NULL,
	Price numeric(18, 2) NOT NULL,
	timestamp timestamp NOT NULL,
	CreateDate datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Products ADD CONSTRAINT
	DF_Products_CreateDate DEFAULT getdate() FOR CreateDate
GO
ALTER TABLE dbo.Products SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Products', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Products', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Products', 'Object', 'CONTROL') as Contr_Per 