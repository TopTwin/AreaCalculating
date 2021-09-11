CREATE TABLE Products (
	Id INT,
	"Product" CHAR(50),
	PRIMARY KEY(Id)
);

INSERT INTO Products
VALUES
	(1, 'Green tea'),
	(2, 'Black tea'),
	(3, 'Potatos'),
	(4, 'Tomatos'),
	(5, 'Plate'),
	(6, 'Table');

CREATE TABLE Categories (	
	Id INT,
	"Category" CHAR(50),
	PRIMARY KEY(Id)
);

INSERT INTO Categories
VALUES
	(1, 'Tea'),
	(2, 'Food');

CREATE TABLE ProductCategories (
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	PRIMARY KEY (ProductId, CategoryId)
);

INSERT INTO ProductCategories
VALUES
	(1, 1),
	(1, 2),
	(2, 1),
	(2, 2),
	(3, 2),
	(4, 2);

SELECT P.Product, C.Category
FROM Products P
LEFT JOIN ProductCategories PC
	ON P.Id = PC.ProductId
LEFT JOIN Categories C
	ON C.Id = PC.CategoryId