CREATE TABLE Customer(
	CustomerId UNIQUEIDENTIFIER NOT NULL,
	CustomerName VARCHAR(60) NOT NULL,
	CustomerAddress VARCHAR(120) NOT NULL,
	Balance BIGINT NOT NULL,
	PRIMARY KEY(CustomerId)
);

CREATE TABLE Merchant(
	MerchantId UNIQUEIDENTIFIER NOT NULL,
	MerchantName VARCHAR(60) NOT NULL,
	MerchantAddress VARCHAR(120) NOT NULL,
	Balance BIGINT NOT NULL,
	PRIMARY KEY(MerchantId)
);

CREATE TABLE Transactions(
	CustomerId UNIQUEIDENTIFIER NOT NULL,
	MerchantId UNIQUEIDENTIFIER NOT NULL,
	TransactionDate DATETIME NOT NULL,
	TransactionAmount BIGINT NOT NULL,
	FOREIGN KEY(CustomerId) REFERENCES Customer(CustomerId),
	FOREIGN KEY(MerchantId) REFERENCES Merchant(MerchantId)
	);