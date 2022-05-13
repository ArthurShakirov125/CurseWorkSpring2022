
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/13/2022 15:13:00
-- Generated from EDMX file: C:\C#\Curswork\AdmissionsCommittee\DataBase\AdmissionsCommitteeDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AdmissionsCommittee];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ConsultationSubject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsultationSet] DROP CONSTRAINT [FK_ConsultationSubject];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentFlow]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FlowSet] DROP CONSTRAINT [FK_DepartmentFlow];
GO
IF OBJECT_ID(N'[dbo].[FK_EnrolleeExam_sheet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnrolleeSet] DROP CONSTRAINT [FK_EnrolleeExam_sheet];
GO
IF OBJECT_ID(N'[dbo].[FK_EnrolleeExam_statement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnrolleeSet] DROP CONSTRAINT [FK_EnrolleeExam_statement];
GO
IF OBJECT_ID(N'[dbo].[FK_Exam_scheduleSubject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exam_scheduleSet] DROP CONSTRAINT [FK_Exam_scheduleSubject];
GO
IF OBJECT_ID(N'[dbo].[FK_Exam_sheetGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exam_sheetSet] DROP CONSTRAINT [FK_Exam_sheetGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_Exam_statementSubject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubjectSet] DROP CONSTRAINT [FK_Exam_statementSubject];
GO
IF OBJECT_ID(N'[dbo].[FK_FacultyDepartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DepartmentSet] DROP CONSTRAINT [FK_FacultyDepartment];
GO
IF OBJECT_ID(N'[dbo].[FK_FlowConsultation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsultationSet] DROP CONSTRAINT [FK_FlowConsultation];
GO
IF OBJECT_ID(N'[dbo].[FK_FlowExam_schedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exam_scheduleSet] DROP CONSTRAINT [FK_FlowExam_schedule];
GO
IF OBJECT_ID(N'[dbo].[FK_FlowGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupSet] DROP CONSTRAINT [FK_FlowGroup];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ConsultationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConsultationSet];
GO
IF OBJECT_ID(N'[dbo].[DepartmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DepartmentSet];
GO
IF OBJECT_ID(N'[dbo].[EnrolleeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EnrolleeSet];
GO
IF OBJECT_ID(N'[dbo].[Exam_scheduleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exam_scheduleSet];
GO
IF OBJECT_ID(N'[dbo].[Exam_sheetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exam_sheetSet];
GO
IF OBJECT_ID(N'[dbo].[Exam_statementSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exam_statementSet];
GO
IF OBJECT_ID(N'[dbo].[FacultySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FacultySet];
GO
IF OBJECT_ID(N'[dbo].[FlowSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FlowSet];
GO
IF OBJECT_ID(N'[dbo].[GroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupSet];
GO
IF OBJECT_ID(N'[dbo].[SubjectSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubjectSet];
GO
IF OBJECT_ID(N'[dbo].[UniversitySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UniversitySet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UniversitySet'
CREATE TABLE [dbo].[UniversitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FacultySet'
CREATE TABLE [dbo].[FacultySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Competition] int  NOT NULL
);
GO

-- Creating table 'DepartmentSet'
CREATE TABLE [dbo].[DepartmentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Faculty_Id] int  NOT NULL
);
GO

-- Creating table 'FlowSet'
CREATE TABLE [dbo].[FlowSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Department_Id] int  NOT NULL
);
GO

-- Creating table 'GroupSet'
CREATE TABLE [dbo].[GroupSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Flow_Id] int  NOT NULL
);
GO

-- Creating table 'EnrolleeSet'
CREATE TABLE [dbo].[EnrolleeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Lastname] nvarchar(max)  NULL,
    [Passport] nvarchar(max)  NOT NULL,
    [Education] nvarchar(max)  NOT NULL,
    [Graduation] datetime  NOT NULL,
    [Golden_medal] bit  NOT NULL,
    [Silver_medal] bit  NOT NULL,
    [Exam_sheet_Exam_sheet_number] int  NOT NULL
);
GO

-- Creating table 'Exam_sheetSet'
CREATE TABLE [dbo].[Exam_sheetSet] (
    [Exam_sheet_number] int IDENTITY(1,1) NOT NULL,
    [Group_Id] int  NOT NULL
);
GO

-- Creating table 'Exam_statementSet'
CREATE TABLE [dbo].[Exam_statementSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mark] tinyint  NOT NULL,
    [Points] smallint  NOT NULL,
    [Enrollee_Id] int  NOT NULL,
    [Subject_Id] int  NOT NULL
);
GO

-- Creating table 'SubjectSet'
CREATE TABLE [dbo].[SubjectSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Pass_points] smallint  NOT NULL
);
GO

-- Creating table 'Exam_scheduleSet'
CREATE TABLE [dbo].[Exam_scheduleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Classroom] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Flow_Id] int  NOT NULL,
    [Subject_Id] int  NOT NULL
);
GO

-- Creating table 'ConsultationSet'
CREATE TABLE [dbo].[ConsultationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Classroom] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Flow_Id] int  NOT NULL,
    [Subject_Id] int  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UniversitySet'
ALTER TABLE [dbo].[UniversitySet]
ADD CONSTRAINT [PK_UniversitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FacultySet'
ALTER TABLE [dbo].[FacultySet]
ADD CONSTRAINT [PK_FacultySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DepartmentSet'
ALTER TABLE [dbo].[DepartmentSet]
ADD CONSTRAINT [PK_DepartmentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FlowSet'
ALTER TABLE [dbo].[FlowSet]
ADD CONSTRAINT [PK_FlowSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [PK_GroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EnrolleeSet'
ALTER TABLE [dbo].[EnrolleeSet]
ADD CONSTRAINT [PK_EnrolleeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Exam_sheet_number] in table 'Exam_sheetSet'
ALTER TABLE [dbo].[Exam_sheetSet]
ADD CONSTRAINT [PK_Exam_sheetSet]
    PRIMARY KEY CLUSTERED ([Exam_sheet_number] ASC);
GO

-- Creating primary key on [Id] in table 'Exam_statementSet'
ALTER TABLE [dbo].[Exam_statementSet]
ADD CONSTRAINT [PK_Exam_statementSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubjectSet'
ALTER TABLE [dbo].[SubjectSet]
ADD CONSTRAINT [PK_SubjectSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Exam_scheduleSet'
ALTER TABLE [dbo].[Exam_scheduleSet]
ADD CONSTRAINT [PK_Exam_scheduleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConsultationSet'
ALTER TABLE [dbo].[ConsultationSet]
ADD CONSTRAINT [PK_ConsultationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Faculty_Id] in table 'DepartmentSet'
ALTER TABLE [dbo].[DepartmentSet]
ADD CONSTRAINT [FK_FacultyDepartment]
    FOREIGN KEY ([Faculty_Id])
    REFERENCES [dbo].[FacultySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacultyDepartment'
CREATE INDEX [IX_FK_FacultyDepartment]
ON [dbo].[DepartmentSet]
    ([Faculty_Id]);
GO

-- Creating foreign key on [Department_Id] in table 'FlowSet'
ALTER TABLE [dbo].[FlowSet]
ADD CONSTRAINT [FK_DepartmentFlow]
    FOREIGN KEY ([Department_Id])
    REFERENCES [dbo].[DepartmentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentFlow'
CREATE INDEX [IX_FK_DepartmentFlow]
ON [dbo].[FlowSet]
    ([Department_Id]);
GO

-- Creating foreign key on [Flow_Id] in table 'GroupSet'
ALTER TABLE [dbo].[GroupSet]
ADD CONSTRAINT [FK_FlowGroup]
    FOREIGN KEY ([Flow_Id])
    REFERENCES [dbo].[FlowSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FlowGroup'
CREATE INDEX [IX_FK_FlowGroup]
ON [dbo].[GroupSet]
    ([Flow_Id]);
GO

-- Creating foreign key on [Exam_sheet_Exam_sheet_number] in table 'EnrolleeSet'
ALTER TABLE [dbo].[EnrolleeSet]
ADD CONSTRAINT [FK_EnrolleeExam_sheet]
    FOREIGN KEY ([Exam_sheet_Exam_sheet_number])
    REFERENCES [dbo].[Exam_sheetSet]
        ([Exam_sheet_number])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnrolleeExam_sheet'
CREATE INDEX [IX_FK_EnrolleeExam_sheet]
ON [dbo].[EnrolleeSet]
    ([Exam_sheet_Exam_sheet_number]);
GO

-- Creating foreign key on [Group_Id] in table 'Exam_sheetSet'
ALTER TABLE [dbo].[Exam_sheetSet]
ADD CONSTRAINT [FK_Exam_sheetGroup]
    FOREIGN KEY ([Group_Id])
    REFERENCES [dbo].[GroupSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Exam_sheetGroup'
CREATE INDEX [IX_FK_Exam_sheetGroup]
ON [dbo].[Exam_sheetSet]
    ([Group_Id]);
GO

-- Creating foreign key on [Enrollee_Id] in table 'Exam_statementSet'
ALTER TABLE [dbo].[Exam_statementSet]
ADD CONSTRAINT [FK_EnrolleeExam_statement]
    FOREIGN KEY ([Enrollee_Id])
    REFERENCES [dbo].[EnrolleeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnrolleeExam_statement'
CREATE INDEX [IX_FK_EnrolleeExam_statement]
ON [dbo].[Exam_statementSet]
    ([Enrollee_Id]);
GO

-- Creating foreign key on [Subject_Id] in table 'Exam_statementSet'
ALTER TABLE [dbo].[Exam_statementSet]
ADD CONSTRAINT [FK_Exam_statementSubject]
    FOREIGN KEY ([Subject_Id])
    REFERENCES [dbo].[SubjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Exam_statementSubject'
CREATE INDEX [IX_FK_Exam_statementSubject]
ON [dbo].[Exam_statementSet]
    ([Subject_Id]);
GO

-- Creating foreign key on [Flow_Id] in table 'Exam_scheduleSet'
ALTER TABLE [dbo].[Exam_scheduleSet]
ADD CONSTRAINT [FK_FlowExam_schedule]
    FOREIGN KEY ([Flow_Id])
    REFERENCES [dbo].[FlowSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FlowExam_schedule'
CREATE INDEX [IX_FK_FlowExam_schedule]
ON [dbo].[Exam_scheduleSet]
    ([Flow_Id]);
GO

-- Creating foreign key on [Flow_Id] in table 'ConsultationSet'
ALTER TABLE [dbo].[ConsultationSet]
ADD CONSTRAINT [FK_FlowConsultation]
    FOREIGN KEY ([Flow_Id])
    REFERENCES [dbo].[FlowSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FlowConsultation'
CREATE INDEX [IX_FK_FlowConsultation]
ON [dbo].[ConsultationSet]
    ([Flow_Id]);
GO

-- Creating foreign key on [Subject_Id] in table 'ConsultationSet'
ALTER TABLE [dbo].[ConsultationSet]
ADD CONSTRAINT [FK_ConsultationSubject]
    FOREIGN KEY ([Subject_Id])
    REFERENCES [dbo].[SubjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsultationSubject'
CREATE INDEX [IX_FK_ConsultationSubject]
ON [dbo].[ConsultationSet]
    ([Subject_Id]);
GO

-- Creating foreign key on [Subject_Id] in table 'Exam_scheduleSet'
ALTER TABLE [dbo].[Exam_scheduleSet]
ADD CONSTRAINT [FK_Exam_scheduleSubject]
    FOREIGN KEY ([Subject_Id])
    REFERENCES [dbo].[SubjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Exam_scheduleSubject'
CREATE INDEX [IX_FK_Exam_scheduleSubject]
ON [dbo].[Exam_scheduleSet]
    ([Subject_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------