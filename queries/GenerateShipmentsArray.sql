use SupPart
SELECT 'new Shipments { SN = "'+Shipments.SN+'", PN = "'+Shipments.PN+'", QTY = '+CONVERT(varchar(50),Shipments.QTY) +'},' from shipments;