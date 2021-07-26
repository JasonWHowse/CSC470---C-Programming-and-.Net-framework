use SupPart
SELECT SN, 'Part Name: '+PName, 'Quantity: '+convert(varchar(50),QTY) from Shipments
full join Parts on Parts.PN = Shipments.PN
order by SN, PNAME;

Select COLOR, CITY from Parts
order by COLOR,CITY;