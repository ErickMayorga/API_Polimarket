INSERT INTO Sucursal (direccion, idUsuario) VALUES
('El Recreo', 3),
('Quicentro Sur', 4),
('El Condado', 5)

INSERT INTO Sucursal_Producto (stock, idSucursal, idProducto) VALUES
-- El Recreo
(4, 1, 1),
(8, 1, 2),
(12, 1, 8),
--Quicentro Sur
(5, 2, 3),
(15, 2, 2),
(10, 2, 9),
-- El Condado
(20, 3, 3),
(15, 3, 1),
(11, 3, 7),
(19, 3, 6)