-- Realizar una consulta que permita conocer cuál es el producto que más stock tiene.
SELECT * FROM Product
WHERE Stock = (SELECT MAX(Stock) FROM Product)

-- Realizar una consulta que permita conocer cuál es el producto más vendido
SELECT p.Nombre, s.Cantidad, p.Precio, s.Cantidad * p.Precio AS Total
FROM Sale s INNER JOIN Product p
ON s.ProductID = p.ID
WHERE Cantidad = (SELECT MAX(Cantidad) FROM Sale)