use SupPart
SELECT 'suppliers.Add(new Shipments { SN = "'+Shipments.SN+'", PN = "'+Shipments.PN+'", QTY = '+CONVERT(varchar(50),Shipments.QTY) +'});' from shipments;