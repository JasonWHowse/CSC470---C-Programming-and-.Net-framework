use SupPart
SELECT 'parts.Add(new Part{ PN = "'+PN+'", PName = "'+PNAME+'", Color = "'+COLOR+'", Weight = '+Convert(varchar(50),WEIGHT)+', City = "'+CITY+'"});' from Parts