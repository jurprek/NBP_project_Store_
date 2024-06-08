
delete  FROM [NBP_Project_Store].[NBP_project_Store].[Inventar]
delete  FROM [NBP_Project_Store].[NBP_project_Store].[Kupnja]
delete  FROM [NBP_Project_Store].[NBP_project_Store].[Poslovnica]
delete  FROM [NBP_Project_Store].[NBP_project_Store].[Kupac]
delete  FROM [NBP_Project_Store].[NBP_project_Store].[Predmet]
delete  FROM [NBP_Project_Store].[NBP_project_Store].[Trgovac]

insert into  [NBP_Project_Store].[NBP_project_Store].[Poslovnica] (ID,Naziv,Id_Poslovnica) values (NEWID(), 'Zagreb Centar', 'Pos_001')
insert into  [NBP_Project_Store].[NBP_project_Store].[Poslovnica] (ID,Naziv,Id_Poslovnica) values (NEWID(), 'Split Riva', 'Pos_002')
SELECT * FROM [NBP_Project_Store].[NBP_project_Store].[Poslovnica]

insert into  [NBP_Project_Store].[NBP_project_Store].[Trgovac] (ID,Ime,Prezime,Id_Trgovac) values (NEWID(), 'Ana', 'Aniæ','Trg_001')
insert into  [NBP_Project_Store].[NBP_project_Store].[Trgovac] (ID,Ime,Prezime,Id_Trgovac) values (NEWID(), 'Ena', 'Eniæ','Trg_002')
insert into  [NBP_Project_Store].[NBP_project_Store].[Trgovac] (ID,Ime,Prezime,Id_Trgovac) values (NEWID(), 'Ivo', 'Iviæ','Trg_003')
SELECT * FROM [NBP_Project_Store].[NBP_project_Store].[Trgovac]

insert into  [NBP_Project_Store].[NBP_project_Store].[Kupac] (ID,Ime,Prezime,Id_Kupac) values (NEWID(), 'Tena Albina', 'Kao','Kupac_001')
insert into  [NBP_Project_Store].[NBP_project_Store].[Kupac] (ID,Ime,Prezime,Id_Kupac) values (NEWID(), 'Magdalena', 'Potoènjak','Kupac_002')
insert into  [NBP_Project_Store].[NBP_project_Store].[Kupac] (ID,Ime,Prezime,Id_Kupac) values (NEWID(), 'Petar', 'Pavloviæ','Kupac_003')
insert into  [NBP_Project_Store].[NBP_project_Store].[Kupac] (ID,Ime,Prezime,Id_Kupac) values (NEWID(), 'Jurica', 'Preksavec','Kupac_004')
SELECT * FROM [NBP_Project_Store].[NBP_project_Store].[Kupac]

insert into  [NBP_Project_Store].[NBP_project_Store].[Predmet] (ID,Naziv,Id_Predmet) values (NEWID(), 'Acer Aspire 5 A515-55-56VK', 'Lap_001')
insert into  [NBP_Project_Store].[NBP_project_Store].[Predmet] (ID,Naziv,Id_Predmet) values (NEWID(), 'Dell XPS 13 9310', 'Lap_002')
insert into  [NBP_Project_Store].[NBP_project_Store].[Predmet] (ID,Naziv,Id_Predmet) values (NEWID(), 'HP Envy x360 15-eu0023dx', 'Lap_003')
insert into  [NBP_Project_Store].[NBP_project_Store].[Predmet] (ID,Naziv,Id_Predmet) values (NEWID(), 'Lenovo ThinkPad X1 Carbon Gen 9', 'Lap_004')
insert into  [NBP_Project_Store].[NBP_project_Store].[Predmet] (ID,Naziv,Id_Predmet) values (NEWID(), 'Asus ROG Zephyrus G14 GA402RK', 'Lap_005')
insert into  [NBP_Project_Store].[NBP_project_Store].[Predmet] (ID,Naziv,Id_Predmet) values (NEWID(), 'Microsoft Surface Laptop 5', 'Lap_006')
insert into  [NBP_Project_Store].[NBP_project_Store].[Predmet] (ID,Naziv,Id_Predmet) values (NEWID(), 'Apple MacBook Pro 14-inch M1 Pro', 'Lap_007')
insert into  [NBP_Project_Store].[NBP_project_Store].[Predmet] (ID,Naziv,Id_Predmet) values (NEWID(), 'Asus ZenBook Duo 14 UX482', 'Lap_008')
insert into  [NBP_Project_Store].[NBP_project_Store].[Predmet] (ID,Naziv,Id_Predmet) values (NEWID(), 'Razer Blade 15 Advanced Model', 'Lap_009')
insert into  [NBP_Project_Store].[NBP_project_Store].[Predmet] (ID,Naziv,Id_Predmet) values (NEWID(), 'HP Spectre x360 14-ea1013dx', 'Lap_010')
SELECT * FROM [NBP_Project_Store].[NBP_project_Store].[Predmet]


insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '699,00', 'Inv_001','Pos_001','Lap_001')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '699,00', 'Inv_002','Pos_002','Lap_001')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '1599,00', 'Inv_003','Pos_001','Lap_002')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '1599,00', 'Inv_004','Pos_002','Lap_002')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '1049,00', 'Inv_005','Pos_001','Lap_003')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '1049,00', 'Inv_006','Pos_002','Lap_003')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '1079,00', 'Inv_007','Pos_001','Lap_004')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '1079,00', 'Inv_008','Pos_002','Lap_004')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '2299,00', 'Inv_009','Pos_001','Lap_005')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '2299,00', 'Inv_010','Pos_002','Lap_005')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '1299,00', 'Inv_011','Pos_001','Lap_006')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '1299,00', 'Inv_012','Pos_002','Lap_006')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '2399,00', 'Inv_013','Pos_001','Lap_007')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '1499,00', 'Inv_014','Pos_002','Lap_008')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '2899,00', 'Inv_015','Pos_001','Lap_009')
insert into  [NBP_Project_Store].[NBP_project_Store].[Inventar] (ID,Cijena_Eur,Id_Inventar,Id_Poslovnica,Id_Predmet) values (NEWID(), '1549,00', 'Inv_016','Pos_002','Lap_010')
SELECT * FROM [NBP_Project_Store].[NBP_project_Store].[Inventar]

insert into  [NBP_Project_Store].[NBP_project_Store].[Kupnja] (ID,Id_Kupnja,Id_Kupac,Id_Predmet,Id_Trgovac,Datum_vrijeme,Id_Poslovnica) values (NEWID(),'Kupnja_001','Kupac_001','Lap_001','Trg_001',GETDATE(),'Pos_001')
insert into  [NBP_Project_Store].[NBP_project_Store].[Kupnja] (ID,Id_Kupnja,Id_Kupac,Id_Predmet,Id_Trgovac,Datum_vrijeme,Id_Poslovnica) values (NEWID(),'Kupnja_002','Kupac_001','Lap_005','Trg_001',GETDATE(),'Pos_001')
insert into  [NBP_Project_Store].[NBP_project_Store].[Kupnja] (ID,Id_Kupnja,Id_Kupac,Id_Predmet,Id_Trgovac,Datum_vrijeme,Id_Poslovnica) values (NEWID(),'Kupnja_003','Kupac_002','Lap_002','Trg_002',GETDATE(),'Pos_001')
insert into  [NBP_Project_Store].[NBP_project_Store].[Kupnja] (ID,Id_Kupnja,Id_Kupac,Id_Predmet,Id_Trgovac,Datum_vrijeme,Id_Poslovnica) values (NEWID(),'Kupnja_004','Kupac_003','Lap_003','Trg_002',GETDATE(),'Pos_001')
insert into  [NBP_Project_Store].[NBP_project_Store].[Kupnja] (ID,Id_Kupnja,Id_Kupac,Id_Predmet,Id_Trgovac,Datum_vrijeme,Id_Poslovnica) values (NEWID(),'Kupnja_005','Kupac_004','Lap_004','Trg_003',GETDATE(),'Pos_002')
SELECT * FROM [NBP_Project_Store].[NBP_project_Store].[Kupnja]