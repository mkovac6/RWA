use AdventureWorksOBP

create table UserData(

IDUser int primary key identity,
Email nvarchar(50) not null,
Nickname nvarchar(50) not null,
Passwrd nvarchar(50) not null,

)

go

insert into UserData ([Email],[Nickname],[Passwrd])
values ('testmail@mail.com','Test1','Pa$$w0rd')


go

create proc GetLogins
as
select *
from UserData

go

create proc RegisterUser
@email nvarchar(50),@nickname nvarchar(50), @pwd nvarchar(50)
as

if(not exists (select * from UserData where Email = @email and Passwrd = @pwd))
	begin
		insert into UserData ([Email],[Nickname],[Passwrd])
		values(@email,@nickname,@pwd);
	end
go

create proc GetCountries
as
select * from Drzava

go

create proc GetCities
as
select * from Grad

go


create proc GetBuyers
as
select top 300 * from Kupac

go

create proc GetBuyerById
@ID int
as
select *
from Kupac
where IDKupac = @ID

go

create proc UpdateBuyer
@ID int, @Name nvarchar(50), @Lname nvarchar(50), @Email nvarchar(50), @Phone nvarchar(50), @CityID int
as
update Kupac
set Ime = @Name, Prezime = @Lname, Email = @Email, Telefon = @Phone, GradID = @CityID
where IDKupac = @ID

go

create proc GetBuyerBills
@kupacid int
as
select *
from Racun
where KupacID = @kupacid

go

create proc GetSellers
as
select *
from Komercijalist

go

create proc GetBillItems
@racunid int
as
select *
from Stavka where RacunID = @racunid

go

create proc GetProduct
@proizvodid int
as
select *
from Proizvod where IDProizvod = @proizvodid

go

create proc GetSubcategory
@subcatid int
as
select *
from Potkategorija where IDPotkategorija = @subcatid

go

create proc GetCategory
@kategorijaid int
as
select *
from Kategorija where IDKategorija = @kategorijaid

go

create proc GetBill
@racunid int
as
select *
from Racun where IDRacun = @racunid

go

create proc GetCategories
as
select * from Kategorija

go

create proc EditCategory
@id int, @name nvarchar(50)
as
update Kategorija set Naziv = @name
where IDKategorija = @id

go

create proc DeleteCategory
@id int
as

delete from Proizvod
where PotkategorijaID in (select IDPotkategorija from Potkategorija where KategorijaID = @id)

delete from Potkategorija
where KategorijaID = @id

delete from Kategorija
where IDKategorija = @id

go

create proc AddCategory
@naziv nvarchar(50)
as
insert into Kategorija ([Naziv])
values (@naziv)

go

create proc GetSubcategories
as
select * from Potkategorija

go

create proc EditSubcategory
@id int, @name nvarchar(50), @categ int
as
update Potkategorija
set Naziv = @name, KategorijaID = @categ
where IDPotkategorija = @id

go

create proc DeleteSubcategory
@id int
as

delete from Proizvod
where PotkategorijaID = @id

delete from Potkategorija
where IDPotkategorija = @id

go

create proc AddSubcategory
@naziv nvarchar(50), @kat int
as
insert into Potkategorija([Naziv],[KategorijaID])
values (@naziv,@kat)

go

create proc GetProducts
as
select * from Proizvod

go

create proc DeleteProduct
@id int
as
delete from Proizvod
where IDProizvod = @id

go

create proc AddProduct
@naziv nvarchar(50), @boja nvarchar(50), @broj nvarchar(50), @cijena money, @kolicina int, @idpot int
as
insert into Proizvod ([Naziv],[Boja],[BrojProizvoda],[CijenaBezPDV],[MinimalnaKolicinaNaSkladistu],[PotkategorijaID])
values (@naziv,@boja,@broj,@cijena,@kolicina,@idpot)

go

create proc EditProduct
@id int, @name nvarchar(50), @number nvarchar(50), @colour nvarchar(50), @amount int, @price money, @subcat int 
as
update Proizvod
set Naziv = @name, BrojProizvoda = @number, Boja = @colour, MinimalnaKolicinaNaSkladistu = @amount, CijenaBezPDV = @price, PotkategorijaID = @subcat
where IDProizvod = @id

go

create proc GetCreditCards
as
select * 
from KreditnaKartica

go

create proc GetCreditCard
@id int
as
select *
from KreditnaKartica
where IDKreditnaKartica = @id
