
CREATE database tienda;

USE tienda;

-- Tabla Categoria
CREATE TABLE Categoria (
    CodigoCategoria         INT             IDENTITY(1,1)       PRIMARY KEY,
    Nombre                  NVARCHAR(100)   NOT NULL UNIQUE
);

-- Tabla Producto
CREATE TABLE Producto (
    CodigoProducto          INT             PRIMARY KEY         IDENTITY(1,1),
    Nombre                  NVARCHAR(100)   NOT NULL UNIQUE,
    CodigoCategoria         INT             NOT NULL ,
    FOREIGN KEY (CodigoCategoria) 
    REFERENCES Categoria(CodigoCategoria)
);

-- Tabla Venta
CREATE TABLE Venta (
    CodigoVenta             INT             PRIMARY KEY IDENTITY(1,1),
    Fecha                   DATE            NOT NULL ,
    CodigoProducto          INT             NOT NULL ,
    FOREIGN KEY (CodigoProducto) 
    REFERENCES Producto(CodigoProducto)
);





INSERT INTO Categoria (Nombre) VALUES
('Electrónica'),
('Alimentos'),
('Cocina');


INSERT INTO Producto (Nombre, CodigoCategoria) VALUES
('Televisor Samsung 50"', 1),
('Auriculares Bluetooth', 1),
('Caja de cereal', 2);


INSERT INTO Venta (Fecha, CodigoProducto) VALUES
('2025-06-01', 1),
('2025-06-01', 2),
('2025-06-02', 1),
('2025-06-03', 3),
('2025-06-04', 2),
('2025-06-05', 1),
('2025-06-06', 3),
('2019-06-06', 1),
('2019-06-07', 3),
('2019-06-08', 2);

--consulta solicitada del item 1

SELECT TOP 1 Categoria.nombre 
FROM Categoria 
INNER JOIN Producto 
ON Producto.CodigoCategoria = Categoria.CodigoCategoria
INNER JOIN Venta 
ON Venta.CodigoProducto = Producto.CodigoProducto
ORDER BY Venta.Fecha DESC ;
