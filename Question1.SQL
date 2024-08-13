-- Table to store customer details
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100) UNIQUE,
    PhoneNumber VARCHAR(15),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Table to store merchant details
CREATE TABLE Merchants (
    MerchantID INT PRIMARY KEY AUTO_INCREMENT,
    MerchantName VARCHAR(100),
    Email VARCHAR(100) UNIQUE,
    PhoneNumber VARCHAR(15),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Table to store transaction details
CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY AUTO_INCREMENT,
    CustomerID INT,
    MerchantID INT,
    TransactionAmount DECIMAL(10, 2),
    TransactionDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PaymentMethod VARCHAR(50),
    Status VARCHAR(20),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (MerchantID) REFERENCES Merchants(MerchantID)
);

-- Indexes to optimize common queries
CREATE INDEX idx_customer_transaction ON Transactions (CustomerID);
CREATE INDEX idx_merchant_transaction ON Transactions (MerchantID);
CREATE INDEX idx_transaction_date ON Transactions (TransactionDate);

-- Get Transaction details
SELECT 
    t.TransactionID,
    c.FirstName AS CustomerFirstName,
    c.LastName AS CustomerLastName,
    c.Email AS CustomerEmail,
    m.MerchantName,
    m.Email AS MerchantEmail,
    t.TransactionAmount,
    t.TransactionDate,
    t.PaymentMethod,
    t.Status
FROM 
    Transactions t
INNER JOIN 
    Customers c ON t.CustomerID = c.CustomerID
INNER JOIN 
    Merchants m ON t.MerchantID = m.MerchantID
ORDER BY 
    t.TransactionDate DESC;
