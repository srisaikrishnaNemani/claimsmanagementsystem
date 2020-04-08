Create DATABASE Claims_Management;

USE Claims_management;
----------------------------------------------------------------------------------------------------------------------------
create TABLE tabMEMBER
	(MEMBERID INT IDENTITY(1,1) NOT NULL,
	 FIRSTNAME VARCHAR(50) NOT NULL, 
	 LASTNAME VARCHAR(50) NOT NULL, 
	 AGE INT NOT NULL, 
	 GENDER VARCHAR(10) NOT NULL, 
	 DOB DATE NOT NULL, 
	 CONTACTNUMBER BIGINT NOT NULL, 
	 ALTCONTACTNUMBER BIGINT NOT NULL, 
	 EMAILID VARCHAR(50) NOT NULL, 
	 PASSWORD VARCHAR(50) NOT NULL, 
	 ConfirmPassword Varchar(50) not null,
	 ADDRESSLINE1 VARCHAR(100) NOT NULL, 
	 ADDRESSLINE2 VARCHAR(100) NOT NULL, 
	 CITY VARCHAR(50) NOT NULL, 
	 STATE VARCHAR(50) NOT NULL, 
  	 ZIPCODE VARCHAR(10) NOT NULL,
	 ACTIVE VARCHAR(10) NOT NULL);

	 alter table tabMember 
	 add FavoritePerson varchar(50)
----------------------------------------------------------------------------------------------------------------------------
 CREATE TABLE ADMIN
	(ADMINID INT IDENTITY(1,1) NOT NULL, 
	FIRSTNAME VARCHAR(50) NOT NULL, 
	LASTNAME VARCHAR(50) NOT NULL, 
	AGE INT NOT NULL, 
	GENDER VARCHAR(10) NOT NULL, 
	DOB DATE NOT NULL, 
	CONTACTNUMBER BIGINT NOT NULL, 
	ALTCONTACTNUMBER BIGINT NOT NULL, 
	EMAILID VARCHAR(50) NOT NULL, 
	PASSWORD VARCHAR(50), 
	CONFIRMPASSWORD VARCHAR(50),
	ACTIVE VARCHAR(10) NOT NULL);

	alter Table Admin
	add FavoritePerson Varchar(50)
----------------------------------------------------------------------------------------------------------------------------
CREATE TABLE Claims(
	ClaimID INT IDENTITY(1,1) NOT NULL,
	MemberPlanId varchar(50) NOT NULL,
	ClaimServiceDate DATE NOT NULL,
	ClaimProcessingDate DATE NOT NULL,
	ClaimSubmissionDate DATE NOT NULL,
	ClaimStatus VARCHAR(500) NOT NULL, 
	ClaimAmount bigint NOT NULL, 
	ApprovedAmount bigint NOT NULL);

	alter table Claims
	add   ID int identity(1001,1)
----------------------------------------------------------------------------------------------------------------------------

CREATE TABLE PlanCode(
	PlanCodeId INT IDENTITY(1,1) NOT NULL,
	PlanName VARCHAR(50) NOT NULL,
	PlanDescription VARCHAR(1000) NOT NULL,
	Coverage1 DECIMAL(12,2) NOT NULL, 
	Coverage2 DECIMAL(12,2) NOT NULL,
	Coverage3 DECIMAL(12,2) NOT NULL,
	Coverage4 DECIMAL(12,2) NOT NULL, 
	Coverage5 DECIMAL(12,2) NOT NULL);

alter table PlanCode
	add  Coverage1 bigint,Coverage2 bigint,Coverage3 bigint,Coverage4 bigint,Coverage5 bigint

alter table PlanCode
	drop column Coverage1 ,Coverage2 ,Coverage3 ,Coverage4 ,Coverage5
----------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Member_Plan(
	MemberPlanId INT IDENTITY(1,1) NOT NULL, 
	MemberId VarChar(50) NOT NULL, 
	PlanCodeId INT NOT NULL, 
	StartDate DATE NOT NULL, 
	EndDate DATE NOT NULL, 
	CoverageAmount DECIMAL(12,2) NOT NULL, 
CoverageNumber INT NOT NULL);

alter table member_plan
	add  CoverageAmount bigint
----------------------------------------------------------------------------------------------------------------------------
create table tabDocument
(
document_id int primary key identity(1001,1),
reason_claim varchar(100) null,
id_proof varchar(100) null,
required_document varchar(100) null,
bank_account_number bigint null,
bank_ifsc_code varchar(50) null,
bank_account_name varchar(50) null
);
----------------------------------------------------------------------------------------------------------------------------

create procedure sp_getAdminListForSuperUser
AS
BEGIN
	select ADMINID, FIRSTNAME,LASTNAME,AGE,GENDER from ADMIN
END

----------------------------------------------------------------------------------------------------------------------------

alter procedure sp_adminRegistration
	@FirstName VARCHAR(50), 
	@LastName VARCHAR(50) , 
	@Age INT , 
	@Gender VARCHAR(10), 
	@Dob DATE , 
	@Contact BIGINT , 
	@Altcontact BIGINT , 
	@EmailId VARCHAR(50) , 
	@Password VARCHAR(50), 
	@ConfirmPassword VARCHAR(50),
	@Active VARCHAR(10),
	@FavoritePerson varchar(50)
AS
BEGIN
	insert into ADMIN(FIRSTNAME,LASTNAME,AGE,GENDER,DOB,CONTACTNUMBER,ALTCONTACTNUMBER,EMAILID,PASSWORD,CONFIRMPASSWORD,ACTIVE,FavoritePerson) 
	values(@FirstName,@LastName,@Age,@Gender,@Dob,@Contact,@Altcontact,@EmailId,@Password,@ConfirmPassword,@Active,@FavoritePerson)
END
----------------------------------------------------------------------------------------------------------------------------

create procedure sp_loginAdmin
as
begin
	select EMAILID,PASSWORD,ACTIVE FROM ADMIN
end
----------------------------------------------------------------------------------------------------------------------------

create procedure sp_approveAdmin
	@AdminId int,
	@Active varchar(20)
as
begin
	update ADMIN set ACTIVE=@Active
	where ADMINID=@AdminId
END
----------------------------------------------------------------------------------------------------------------------------
alter procedure sp_memberRegistration
	@FirstName VARCHAR(50), 
	@LastName VARCHAR(50) , 
	@Age INT , 
	@Gender VARCHAR(10), 
	@Dob DATE , 
	@Contact BIGINT , 
	@Altcontact BIGINT , 
	@EmailId VARCHAR(50) , 
	@Password VARCHAR(50), 
	@ConfirmPassword VARCHAR(50),
	@AddressLine1 varchar(250),
	@AddressLine2 varchar(250),
	@City varchar(15),
	@State varchar(10),
	@ZipCode bigint,
	@Active VARCHAR(10),
	@FavoritePerson varchar(50)
AS
BEGIN
	insert into tabMEMBER (FIRSTNAME,LASTNAME,AGE,GENDER,DOB,CONTACTNUMBER,ALTCONTACTNUMBER,EMAILID,PASSWORD,CONFIRMPASSWORD,ADDRESSLINE1 ,ADDRESSLINE2 ,CITY ,STATE ,ZIPCODE ,ACTIVE,FavoritePerson) 
	values(@FirstName,@LastName,@Age,@Gender,@Dob,@Contact,@Altcontact,@EmailId,@Password,@ConfirmPassword,@AddressLine1,@AddressLine2,@City,@State,@ZipCode,@Active,@FavoritePerson)
END
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
alter procedure sp_getMemberListForAdmin
as
begin
	select MEMBERID,FIRSTNAME,GENDER,DOB,CONTACTNUMBER,EMAILID,CITY,ACTIVE FROM tabMEMBER  ;
End
---------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure sp_loginMember
as
begin
	select EMAILID,PASSWORD,ACTIVE FROM tabMEMBER
End
---------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure sp_approveMember
	@MemberId int,
	@Active varchar(20)
as
begin
	update tabMEMBER set ACTIVE=@Active
	where @MEMBERID=@MemberId
End
---------------------------------------------------------------------------------------------------------------------------------------------------------
alter procedure sp_MemberPlan
	@MemberId varchar(50),
	@PlanCode int,
	@StartDate date,
	@EndDate date,
	@CoverageAmount bigint,
	@CoverageNumber bigint
as
begin 
	insert into Member_Plan(MemberId,PlanCodeId,StartDate,EndDate,CoverageAmount,CoverageNumber) 
	values(@MemberId,@PlanCode,@StartDate,@EndDate,@CoverageAmount,@CoverageNumber)
end
---------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure sp_getMemberPlan
as
begin
	select MemberPlanId,MemberId,PlanCodeId,StartDate,EndDate,CoverageAmount,CoverageNumber from Member_Plan 
end
---------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure sp_getMemberPlanById
	@MemberId varchar(50),
	@PlanCode int
as
begin
	select MemberPlanId from Member_Plan where MemberId=@MemberId and PlanCodeId=@PlanCode 
end
---------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure sp_getMemberPlanIdNoclaim
	@memberId varchar(50)
as
begin
	select c.claimStatus, mp.MemberId,pc.PlanCodeId,mp.StartDate,mp.EndDate,mp.CoverageAmount,mp.CoverageNumber,pc.PlanName,pc.PlanDescription from Member_Plan mp join PlanCode pc on mp.PlanCodeId=pc.PlanCodeId  left join Claims c on c.MemberPlanId=mp.MemberPlanId    where MemberId=@memberId
End
---------------------------------------------------------------------------------------------------------------------------------------------------------
alter procedure sp_GetMemberPlanForId
	@memberId varchar(50)
as
begin
	select mp. MemberPlanId ,mp.MemberId ,p.PlanCodeId ,PlanName,PlanDescription,mp.StartDate ,mp.EndDate ,mp.CoverageAmount ,mp.CoverageNumber from [member_plan] mp join PlanCode p on p.PlanCodeId =mp.PlanCodeId  where memberid=@memberId 
end
	select mp. MemberPlanId ,mp.MemberId ,p.PlanCodeId ,PlanName,PlanDescription,mp.StartDate ,mp.EndDate ,mp.CoverageAmount ,mp.CoverageNumber from [member_plan] mp join PlanCode p on p.PlanCodeId =mp.PlanCodeId  where memberid='pavan@gmail.com'
---------------------------------------------------------------------------------------------------------------------------------------------------------
alter procedure sp_getmemberplanusingid
	@memid varchar(50)
as
begin
	select * from Member_Plan where MemberId=@memid
end
---------------------------------------------------------------------------------------------------------------------------------------------------------
alter procedure sp_ClaimStatus
	@Id varchar(50)
	
as
begin
	select ID,ClaimID , PlanName,ApprovedAmount,ClaimStatus from Claims where ClaimStatus='processing' or ClaimStatus='Approved'  and MemberPlanId  =@Id
end

select ClaimID , PlanName,ApprovedAmount,ClaimStatus from Claims where ClaimStatus='processing' or ClaimStatus='Approved'
---------------------------------------------------------------------------------------------------------------------------------------------------------
alter procedure sp_ClaimStatusRejected
	@Id varchar(50)
	
as
begin
	select ID, ClaimID, PlanName,ApprovedAmount,ClaimStatus from Claims where ClaimStatus ='Rejected' and MemberPlanId  =@Id
end
select ClaimID, PlanName,ApprovedAmount,ClaimStatus from Claims where ClaimStatus ='Rejected'
---------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure sp_AddPlans
	@planname varchar(50),
	@plandescription varchar(250),
	@coverage1 bigint,
	@coverage2 bigint,
	@coverage3 bigint,
	@coverage4 bigint,
	@coverage5 bigint
as
begin
	insert into PlanCode values(@planname,@plandescription,@coverage1,@coverage2,@coverage3,@coverage4,@coverage5)
end
---------------------------------------------------------------------------------------------------------------------------------------------------------

create procedure sp_EditPlan
	@plancodeid int,
	@planname varchar(50),
	@plandescription varchar(250),
	@coverage1 bigint,
	@coverage2 bigint,
	@coverage3 bigint,
	@coverage4 bigint,
	@coverage5 bigint
as
begin
	update PlanCode set PlanName=@planname,PlanDescription=@plandescription,Coverage1=@coverage1,Coverage2=@coverage2,Coverage3=@coverage3,Coverage4=@coverage4,Coverage5=@coverage5 where PlanCodeId=@plancodeid
end

---------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure sp_RemovePlan
	@plancodeid int
as
Begin
	delete from PlanCode where plancodeid=@plancodeid
End
---------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure sp_ViewPlan
as
begin
	select * from plancode 
end
---------------------------------------------------------------------------------------------------------------------------------------------------------

alter procedure sp_ApproveClaim
	@ClaimId int,
	@ClaimStatus varchar(10),
	@ApproveAmount bigint
as
begin
	update Claims set ClaimStatus=@ClaimStatus, ApprovedAmount=@ApproveAmount where ID = @ClaimId
end
---------------------------------------------------------------------------------------------------------------------------------------------------------

alter procedure sp_RequestClaim
	@MemberPlanId varchar(50),
	@ClaimServiceDate date ,
	@ClaimSubmissionDate date,
	@ClaimProcessingDate date,
	@ClaimStatus varchar(50),
	@ClaimAmount bigint,
	@ApproveAmount bigint,
	@ClaimId int,
	@PlanName varchar(50)
as
begin
	insert into Claims (ClaimID,MemberPlanId,ClaimServiceDate,ClaimSubmissionDate,ClaimProcessingDate,ClaimStatus,ClaimAmount,ApprovedAmount,PlanName) values(@ClaimId,@MemberPlanId,@ClaimServiceDate,@ClaimSubmissionDate,@ClaimProcessingDate,@ClaimStatus,@ClaimAmount,@ApproveAmount,@PlanName)
end
---------------------------------------------------------------------------------------------------------------------------------------------------------
alter procedure sp_ResubmitClaim
	@claimId int
as
begin
	update Claims set ClaimStatus = 'Processing' where ID=@claimId
end
---------------------------------------------------------------------------------------------------------------------------------------------------------

alter procedure sp_ViewClaimForAdmin
as
begin
	select ID,ClaimId,MemberPlanId,ClaimServiceDate,ClaimSubmissionDate,ClaimProcessingDate,ClaimAmount,PlanName from Claims where ClaimStatus ='processing'  
	end

---------------------------------------------------------------------------------------------------------------------------------------------------------
create procedure sp_ViewClaimForCustomer
	@memberplanid varchar(50)
as
Begin
	select * from Claims where MemberPlanId=@memberplanid
end
---------------------------------------------------------------------------------------------------------------------------------------------------------
alter procedure sp_ViewClaimById
	@claimid int
as
begin
	select ID,ClaimId,PlanName,ClaimServiceDate,ClaimProcessingDate ,ClaimSubmissionDate ,ClaimAmount ,ApprovedAmount  from Claims where ID=@claimid 	
end
select ID,ClaimId,PlanName,ClaimServiceDate,ClaimProcessingDate ,ClaimSubmissionDate ,ClaimAmount ,ApprovedAmount  from Claims where ID=@claimid 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
select * from tabMEMBER  

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

alter procedure sp_SecurityAdmin
@EmailID varchar(50),
@FavoritePerson varchar(50),
@Password varchar(50),
@ConfirmPassword varchar(50)
as
Begin
select EMAILID ,FavoritePerson from ADMIN 
Update admin set
 Password=@Password,
 ConfirmPassword=@ConfirmPassword
 where 
 EmailId=@EmailID and FavoritePerson=@FavoritePerson
 end
 --------------------------------------------------------------------------------------------------------------------------------------------------------

 alter procedure sp_SecurityMember
@EmailID varchar(50),
@FavoritePerson varchar(50),
@Password varchar(50),
@ConfirmPassword varchar(50)
as
Begin
select EMAILID ,FavoritePerson from tabMEMBER 
Update tabMEMBER  set
 Password=@Password,
 ConfirmPassword=@ConfirmPassword
 where 
 EmailId=@EmailID and FavoritePerson=@FavoritePerson
 end
 --------------------------------------------------------------------------------------------------------------------------------------------------------
 create procedure sp_doc_upload
@reasonClaim varchar(100),
@idProof varchar(100),
@requiredDocument varchar(100),
@bankAccountNumber bigint,
@bankIfscCode varchar(50),
@banAccountName varchar(50)
as
begin
insert into tabDocument values(@reasonClaim,@idProof,@requiredDocument,@bankAccountNumber,@bankIfscCode,@banAccountName)
end
 --------------------------------------------------------------------------------------------------------------------------------------------------------

 Delete admin
 select * from PlanCode     
 Delete tabMEMBER 
 delete Member_Plan  
 delete tabDocument  
 delete PlanCode 
 select * from tabMEMBER
 select * from tabDocument 
 --------------------------------------------------------------------------------------------------------------------------------------------------------






