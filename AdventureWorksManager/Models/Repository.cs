using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AdventureWorksManager.Models
{
    public class Repository
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        private static List<Country> Countries = new List<Country>();
        private static List<City> Cities = new List<City>();
        private static List<Seller> Sellers = new List<Seller>();

        public static Login CheckLogin(string mail, string pwd) {

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetLogins");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["Email"].ToString() == mail && row["Passwrd"].ToString() == pwd)
                {
                    return new Login { Email = row["Email"].ToString(), Nickname = row["Nickname"].ToString() };
                }
            }
            throw new Exception("No such login!");
        
        }

        internal static List<BillItem> GetBillItems(int id)
        {
           

            List<BillItem> billItems = new List<BillItem>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetBillItems", id);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                BillItem b = new BillItem{};
                b.ID = (int)row["IDStavka"];
                b.BillId = (int)row["RacunID"];
                b.Amount = Convert.ToInt16(row["Kolicina"]);
                b.Price = (double)Convert.ToDecimal(row["CijenaPoKomadu"]);   
                b.Discount = (double)Convert.ToDecimal(row["PopustUPostocima"]);
                b.TotalPrice = (double)Convert.ToDecimal(row["UkupnaCijena"]);
                b.Product = GetProductById((int)row["ProizvodID"]);

                billItems.Add(b);

            }


            return billItems;
        }

        public static Product GetProductById(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetProduct", id);
            DataRow row = ds.Tables[0].Rows[0];

            var p = new Product();
            p.ID = (int)row["IDProizvod"];
            p.Colour = row["Boja"].ToString();
            p.Name = row["Naziv"].ToString();
            p.MinimalAmountStored = Convert.ToInt16(row["MinimalnaKolicinaNaSkladistu"]);
            p.Price = (double)Convert.ToDecimal(row["CijenaBezPDV"]);
            p.ProductNumber = row["BrojProizvoda"].ToString(); 
            if (row["PotkategorijaID"].ToString() == "")
            {
                p.Subcategory = new Subcategory { ID = 0, Category = new Category { ID = 0, Name = "" }, Name = "" };
            }
            else
            {
                p.Subcategory = GetSubcategory((int)row["PotkategorijaID"]);  
            }

            return p;
            
        }

        public static Subcategory GetSubcategory(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetSubcategory", id);
            DataRow row = ds.Tables[0].Rows[0];

            return new Subcategory() { ID = (int)row["IDPotkategorija"], Name = row["Naziv"].ToString(), Category = GetCategory((int)row["KategorijaID"]) };

        }

        public static Category GetCategory(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetCategory", id);
            DataRow row = ds.Tables[0].Rows[0];

            return new Category() { ID = (int)row["IDKategorija"], Name = row["Naziv"].ToString() };
        }
        public static void EditCategory(int id, string name)
        {
            SqlHelper.ExecuteNonQuery(cs, "EditCategory", id, name);

        }
        public static void EditSubcategory(int id, string name, int categoryId)
        {
            SqlHelper.ExecuteNonQuery(cs, "EditSubcategory", id, name, categoryId);

        }

        internal static Buyer GetBuyerById(int ID)
        {
           

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetBuyerById",ID);

            var row = ds.Tables[0].Rows[0];

            return new Buyer() {IDKupac = ID, FirstName = row["Ime"].ToString(),
                LastName = row["Prezime"].ToString(), Email = row["Email"].ToString(),
                Phone = row["Telefon"].ToString(),
                City = Cities.Find(c => c.IDGrad == (int)row["GradID"]) };
        }

        public static bool RegisterNewUser(string email, string nickname, string pwd) {


            try
            {
                SqlHelper.ExecuteDataset(cs, "RegisterUser", email, nickname, pwd);
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        
        }

        internal static void UpdateBuyer(Buyer buyer)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateBuyer", buyer.IDKupac, buyer.FirstName,
                buyer.LastName, buyer.Email, buyer.Phone, buyer.City.IDGrad);
        }
        public static void EditProduct(int id, string name, string prodNumber, string colour, string amount, string price, int subcatId)
        {
            SqlHelper.ExecuteNonQuery(cs, "EditProduct", id, name, prodNumber, colour, int.Parse(amount), Convert.ToDecimal(price), subcatId );
        }

        public static List<Country> GetCountries() {

            
                List<Country> countries = new List<Country>();

                DataSet ds = SqlHelper.ExecuteDataset(cs, "GetCountries");

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    countries.Add(new Country { IDDrzava = (int)row["IDDrzava"], Name = row["Naziv"].ToString() });
                }

            return countries;

        }
        public static List<City> GetCities() {

            
            
                List<City> cities = new List<City>();

                DataSet ds = SqlHelper.ExecuteDataset(cs, "GetCities");

                 if (Countries.Count == 0)
                 {
                        Countries = GetCountries();
                 }

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cities.Add(new City { IDGrad = (int)row["IDGrad"], Name = row["Naziv"].ToString(),
                        Country = Countries.Find(c => c.IDDrzava == (int)row["DrzavaID"]) });
                }

            return cities;

        }
        public static List<Buyer> GetBuyers() {

            
            
                List<Buyer> buyers = new List<Buyer>();

                DataSet ds = SqlHelper.ExecuteDataset(cs, "GetBuyers");

                 if (Cities.Count == 0)
                 {
                        Cities = GetCities();
                 }

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                buyers.Add(new Buyer {IDKupac = (int)row["IDKupac"], FirstName = row["Ime"].ToString(),
                LastName = row["Prezime"].ToString(), Email = row["Email"].ToString(), Phone = row["Telefon"].ToString(),
                City = Cities.Find(c => c.IDGrad == (int)row["GradID"]) });
                }

            return buyers;

        }
        public static List<Buyer> GetBuyersByCity(string id) {

            
            
                List<Buyer> buyers = new List<Buyer>();

                DataSet ds = SqlHelper.ExecuteDataset(cs, "GetBuyersByCity",id);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                buyers.Add(new Buyer {IDKupac = (int)row["IDKupac"], FirstName = row["Ime"].ToString(),
                LastName = row["Prezime"].ToString(), Email = row["Email"].ToString(), Phone = row["Telefon"].ToString(),
                City = Cities.Find(c => c.IDGrad == (int)row["GradID"]) });
                }

            return buyers;

        }

        public static List<Bill> GetBuyerRecords(string id) {

            Sellers = GetSellers();
            var CreditCards = GetCreditCards(); 

            List<Bill> bills = new List<Bill>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetBuyerBills", id);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Bill b = new Bill { ID = (int)row["IDRacun"], 
                IssueDate = DateTime.Parse(row["DatumIzdavanja"].ToString()), BillNumber = row["BrojRacuna"].ToString(),
                BuyerId = (int)row["KupacID"]
                };

                string CreditCardId = row["KreditnaKarticaID"].ToString();

                b.CreditCard = CreditCardId == "" ? CreditCards[0] : CreditCards.Find(card => card.ID == int.Parse(CreditCardId));

                string SellerId = row["KomercijalistID"].ToString() == "" ? "0" : row["KomercijalistID"].ToString();


                b.Seller = Sellers.Find(s => s.ID == int.Parse(SellerId));


                bills.Add(b);
            }


            return bills;
        }

        private static List<CreditCard> GetCreditCards()
        {
            List<CreditCard> cards = new List<CreditCard>();

            cards.Add( new CreditCard { ID = 0, CardNumber = "", Type = "Cash", ExpiryMonth = 0, ExpiryYear = 0 });

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetCreditCards");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                cards.Add(new CreditCard
                {
                    ID = (int)row["IDKreditnaKartica"],
                    Type = row["Tip"].ToString(),
                    CardNumber = row["Broj"].ToString(),
                    ExpiryMonth = Convert.ToInt16(row["IstekMjesec"]),
                    ExpiryYear = Convert.ToInt16(row["IstekGodina"])
                });

            }


            return cards;
        }
        private static CreditCard GetCreditCardById(int id)
        {

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetCreditCard", id);

            DataRow row =  ds.Tables[0].Rows[0];

            return new CreditCard
            {
                ID = (int)row["IDKreditnaKartica"],
                Type = row["Tip"].ToString(),
                CardNumber = row["Broj"].ToString(),
                ExpiryMonth = Convert.ToInt16(row["IstekMjesec"]),
                ExpiryYear = Convert.ToInt16(row["IstekGodina"])
            };

           
        }

        public static Bill GetBillById(int id)
        {

            if (Sellers == null)
            {
                Sellers = GetSellers(); 
            }

            

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetBill", id);

            DataRow row = ds.Tables[0].Rows[0];
            
                Bill b = new Bill
                {
                    ID = (int)row["IDRacun"],
                    IssueDate = DateTime.Parse(row["DatumIzdavanja"].ToString()),
                    BillNumber = row["BrojRacuna"].ToString(),
                    BuyerId = (int)row["KupacID"],
                    
                };

            string CreditCardId = row["KreditnaKarticaID"].ToString();

            b.CreditCard = CreditCardId == "" ?
                new CreditCard { ID = 0, CardNumber = "", Type = "Cash", ExpiryMonth = 0, ExpiryYear = 0 } :
                GetCreditCardById( int.Parse(CreditCardId));

            string SellerId = row["KomercijalistID"].ToString() == "" ? "0" : row["KomercijalistID"].ToString();


                b.Seller = Sellers.Find(s => s.ID == int.Parse(SellerId));

            return b;
        }

        private static List<Seller> GetSellers()
        {
            List<Seller> s = new List<Seller>();

            s.Add( new Seller { ID = 0, FirstName = "NULL", LastName = ""});

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetSellers");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                s.Add(new Seller { ID = (int)row["IDKomercijalist"], 
                    FirstName = row["Ime"].ToString(), LastName = row["Prezime"].ToString()
                });
            }


            return s;
        }

        public static List<Category> GetCategories() {

            List<Category> categories = new List<Category>();


            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetCategories");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                categories.Add( new Category { ID = (int)row["IDKategorija"], Name = row["Naziv"].ToString() });
            }


            return categories;

        }

        public static void DeleteCategory(string id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteCategory",int.Parse(id));
        }
        public static void AddCategory(string name)
        {
            SqlHelper.ExecuteNonQuery(cs, "AddCategory",name);
        }

        public static List<Subcategory> GetSubcategories()
        {

            List<Subcategory> subcategories = new List<Subcategory>();


            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetSubcategories");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                subcategories.Add(new Subcategory { ID = (int)row["IDPotkategorija"], Name = row["Naziv"].ToString(), Category = GetCategory((int)row["KategorijaID"]) });
            }


            return subcategories;

        }

        public static void DeleteSubcategory(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteSubcategory", id);
        }
        public static void AddSubcategory(int catId, string name)
        {
            SqlHelper.ExecuteNonQuery(cs, "AddSubcategory", name, catId);
        }

        public static List<Product> GetProducts()
        {
           

            List<Product> products = new List<Product>();


            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetProducts");

            Subcategory nullSubcategory = new Subcategory { ID = 0, Name = "-" };

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                Product p = new Product();

                p.ID = (int)row["IDProizvod"];
                p.Colour = row["Boja"].ToString();
                p.Name = row["Naziv"].ToString();
                p.MinimalAmountStored = Convert.ToInt16(row["MinimalnaKolicinaNaSkladistu"]);
                p.Price = (double)Convert.ToDecimal(row["CijenaBezPDV"]);
                p.ProductNumber = row["BrojProizvoda"].ToString();

                string id = row["PotkategorijaID"].ToString();


                    p.Subcategory = id == ""? nullSubcategory :   GetSubcategory(int.Parse(id)); 
                

                products.Add(p);
            }


            return products;

        }

        public static void DeleteProduct(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteProduct", id);
        }
        public static void AddProduct(string name, string colour, string number, string price, string amount, string subcatID)
        {
            SqlHelper.ExecuteNonQuery(cs, "AddProduct", name, colour, number, Convert.ToDecimal(price), Convert.ToInt16(amount), int.Parse(subcatID));
        }

    }
}