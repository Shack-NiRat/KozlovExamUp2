create database [Trade]
go
use [Trade]
go
create table [User]
(
	UserID int primary key identity,
	UserSurname nvarchar(100) not null,
	UserName nvarchar(100) not null,
	UserPatronymic nvarchar(100) not null,
	UserLogin nvarchar(max) not null,
	UserPassword nvarchar(max) not null,
	UserRole nvarchar(max) not null
)

go 
create table PickupPoints
(
	PickupPointId int primary key identity,
	PickupPointIndex nvarchar(max),
	PickupPointSity nvarchar(max),
	PickupPointStreet nvarchar(max),
	PickupPointHouse nvarchar(max),

)
go
create table [Order]
(
	OrderID int primary key,
	OrderComposition nvarchar(MAX) not null,
	OrderDate datetime not null,
	OrderDeliveryDate datetime not null,
	OrderPickupPoint int foreign key references [PickupPoints](PickupPointId) not null,
	ClientName nvarchar(max) not null,
	ClientSurname nvarchar(max) not null,
	UserPatronymic nvarchar(max) not null,
	Client nvarchar(max) not null,
	CodeToGet int not null,
	OrderStatus nvarchar(max) not null,

)
go
create table Product
(
	ProductArticleNumber nvarchar(100) primary key,
	ProductName nvarchar(max) not null,
	ProductDescription nvarchar(max) not null,
	ProductCategory nvarchar(max) not null,
	ProductPhoto image,
	ProductProvider nvarchar(max),
	ProductManufacturer nvarchar(max) not null,
	ProductCost decimal(19,4) not null,
	ProductDiscountAmount tinyint,
	ProductMaxAmount int,
	ProductQuantityInStock int not null,
	ProductUnit nvarchar(max) not null,
)

