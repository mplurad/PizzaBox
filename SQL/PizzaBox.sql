DROP TABLE PizzaTopping;
DROP TABLE Topping;
DROP TABLE Pizza;
DROP TABLE PizzaSize;
DROP TABLE Crust;
DROP TABLE [Order];
DROP TABLE Store;
DROP TABLE Customer;

CREATE TABLE Customer(
	CustomerID INT IDENTITY PRIMARY KEY,
	Username VARCHAR(50) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	CustomerFirstName VARCHAR(50) NOT NULL,
	CustomerLastName VARCHAR(50) NOT NULL,
	CustomerPhone CHAR(10),
	CustomerAddress VARCHAR(50),
	CustomerCardNumber CHAR(16),
	CustomerCardDate CHAR(4),
	CustomerCardCVV CHAR(3),
	CONSTRAINT CustomerPhoneCheck CHECK (CustomerPhone LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CONSTRAINT CustomerCardNumberCheck CHECK (CustomerCardNumber LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CONSTRAINT CustomerCardDateCheck CHECK (CustomerCardDate LIKE '[0-9][0-9][0-9][0-9]'),
	CONSTRAINT CustomerCardCVVCheck CHECK (CustomerCardCVV LIKE '[0-9][0-9][0-9]')
);

CREATE TABLE Store(
	StoreID TINYINT IDENTITY PRIMARY KEY,
	StoreLocation VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE [Order](
	OrderID INT IDENTITY PRIMARY KEY,
	CustomerID INT NOT NULL,
	StoreID TINYINT NOT NULL,
	Cost SMALLMONEY,
	OrderDate DateTime,
	FOREIGN KEY(CustomerID) REFERENCES Customer(CustomerID),
	FOREIGN KEY (StoreID) REFERENCES Store(StoreID)
);

CREATE TABLE Crust(
	CrustID TINYINT IDENTITY PRIMARY KEY,
	CrustName VARCHAR(50) UNIQUE,
	CrustPrice SMALLMONEY NOT NULL
);

CREATE TABLE PizzaSize(
	PizzaSizeID TINYINT IDENTITY PRIMARY KEY,
	PizzaSizeName VARCHAR(50) UNIQUE NOT NULL,
	PizzaSizeInches TINYINT NOT NULL,
	PizzaSizePrice SMALLMONEY NOT NULL
);

CREATE TABLE Pizza(
	PizzaID INT IDENTITY PRIMARY KEY,
	OrderID INT NOT NULL,
	CrustID TINYINT NOT NULL,
	PizzaSizeID TINYINT NOT NULL,
	PizzaPrice SMALLMONEY NOT NULL,
	FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
	FOREIGN KEY (CrustID) REFERENCES Crust(CrustID),
	FOREIGN KEY (PizzaSizeID) REFERENCES PizzaSize(PizzaSizeID)
);

CREATE TABLE Topping(
	ToppingID TINYINT IDENTITY PRIMARY KEY,
	ToppingName VARCHAR(50) UNIQUE NOT NULL,
	ToppingPrice SMALLMONEY NOT NULL
);

CREATE TABLE PizzaTopping(
	PizzaToppingID INT IDENTITY PRIMARY KEY,
	PizzaID INT NOT NULL,
	ToppingID TINYINT NOT NULL,
	ToppingCount TINYINT NOT NULL,
	CONSTRAINT PizzaID_ToppingID_Unique UNIQUE (PizzaID, ToppingID),
	FOREIGN KEY (PizzaID) REFERENCES Pizza(PizzaID),
	FOREIGN KEY (ToppingID) REFERENCES Topping(ToppingID)
);

-- Customer: ID, Username, Password, First Name, Last Name, Phone, Address, Card Number, Card Date, Card CVV
INSERT INTO Customer VALUES ('user1', 'pass1', 'Miles', 'Plurad', '7739512790', '7044 Plumlee Ave, Chicago IL', '7654321987654321', '1223', '853');
INSERT INTO Customer VALUES ('user2', 'pass2', 'John', 'Jacob', '8471234567', '1234 N Street Ave, NYC', '1234567891234567', '1224', '123');
INSERT INTO Customer VALUES ('user3', 'pass3', 'Jane', 'Doe', '7731234567', '830 S Mullbery Lane, Houston TX', '1234567891234567', '1124', '321');
INSERT INTO Customer VALUES ('aknox', 'password', 'Azhya', 'Knox', '2343333333', 'Azhya Lane Drive', '3444444444444444', '3453', '345');

-- Store: ID, Location
INSERT INTO Store VALUES ('New York City, New York');
INSERT INTO Store VALUES ('Los Angeles, California');
INSERT INTO Store VALUES ('Chicago, Illinois');
INSERT INTO Store VALUES ('Houston, Texas');

-- Crust: ID, Name, Price
INSERT INTO Crust VALUES ('Thin', 0);
INSERT INTO Crust VALUES ('Hand Tossed', 0);
INSERT INTO Crust VALUES ('Deep Dish', 0);
INSERT INTO Crust VALUES ('Gluten Free', 1);

-- PizzaSize: ID, Name, Inches, Price
INSERT INTO PizzaSize VALUES ('Small', 10, 5.99);
INSERT INTO PizzaSize VALUES ('Medium', 12, 7.99);
INSERT INTO PizzaSize VALUES ('Large', 14, 9.99);
INSERT INTO PizzaSize VALUES ('X-Large', 16, 11.99);

-- Topping: ID, Name, Price
INSERT INTO Topping VALUES ('Lobster', 2.25);
INSERT INTO Topping VALUES ('Shrimp', 1.50);
INSERT INTO Topping VALUES ('Chicken', 1);
INSERT INTO Topping VALUES ('Pepperoni', 0.75);
INSERT INTO Topping VALUES ('Bacon', 0.75);
INSERT INTO Topping VALUES ('Sausage', 0.75);
INSERT INTO Topping VALUES ('Salami', 0.75);
INSERT INTO Topping VALUES ('Ham', 0.75);
INSERT INTO Topping VALUES ('Mozzarella', 0.75);
INSERT INTO Topping VALUES ('Garlic', 0.75);
INSERT INTO Topping VALUES ('Onion', 0.75);
INSERT INTO Topping VALUES ('Olives', 0.75);
INSERT INTO Topping VALUES ('Basil', 0.75);
INSERT INTO Topping VALUES ('Arugula', 0.75);
INSERT INTO Topping VALUES ('Spinach', 0.75);
INSERT INTO Topping VALUES ('Green Bell Pepper', 0.75);
INSERT INTO Topping VALUES ('Red Bell Pepper', 0.75);
INSERT INTO Topping VALUES ('Tomato', 0.75);
INSERT INTO Topping VALUES ('Pineapple', 0.75);

SELECT * FROM Customer;
SELECT * FROM Store;
SELECT * FROM Crust;
SELECT * FROM PizzaSize;
SELECT * FROM Topping;

SELECT * FROM [Order];
SELECT * FROM Pizza;
SELECT * FROM PizzaTopping;