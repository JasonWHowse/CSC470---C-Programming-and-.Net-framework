use SupPart
SELECT
    Shipments.PN
	, Shipments.SN
	, Shipments.QTY
	, Parts.PNAME as 'Parts Name'
	, Parts.Color
	, Parts.WEIGHT
	, Parts.CITY as 'Parts City'
	, Suppliers.SNAME as 'Supplier Name'
	, Suppliers.STATUS
	, Suppliers.CITY as 'Suppliers City'
FROM Shipments
FULL JOIN Parts ON Parts.PN = Shipments.PN
FULL JOIN Suppliers ON Suppliers.SN = Shipments.SN
WHERE QTY=QTY
ORDER BY Shipments.PN