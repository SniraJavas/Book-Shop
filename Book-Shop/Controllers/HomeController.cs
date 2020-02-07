using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;
using BookShop.ViewModels;

namespace BookShop.Controllers
{

  
    public class HomeController : Controller
    {
        DemoContext dbObj = new DemoContext();
         public LinkedList<int> ll = new LinkedList<int>();

        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("login");
            }
            else
            {
                string getName = Session["username"].ToString();
                ViewBag.userName = getName;
                int Count = 0;

                var GetItemsId = dbObj.Cart.Where(s => s.UserName == getName).Select(u => u.ItemId).ToList();
                var GetCartItem = from itemList in dbObj.Item where GetItemsId.Contains(itemList.ItemId) select itemList;
               
               
                foreach (var ItemObj in GetCartItem)
                {
                    var quantity = dbObj.Cart.Single(i => i.ItemId == ItemObj.ItemId);
                    Count += quantity.Quantity;

                }

                ViewBag.cartCount = Count;

                /* NB: Update Count so that our count in cart  sums up the value of Quantity instead of counting rows.
                 * 
                 * 
                 * *
                 */

                return View("Index", getAllItems());
            }

        }

        [HttpGet]
        public ActionResult Register()
        {

            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(Users userObj)
        {
            if (ModelState.IsValid)
            {
                Session["username"] = userObj.UserName;
                dbObj.Users.Add(userObj);
                dbObj.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Register");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            Session["username"] = null;
            return View("login");
        }

        [HttpPost]
        public ActionResult Login(Login1 objLogin)
        {

            var getValidUser = dbObj.Login.FirstOrDefault((p) => p.UserName == objLogin.UserName && p.Password == objLogin.Password);

            if (getValidUser == dbObj.Login.FirstOrDefault((p) => p.UserName == "Admin" && p.Password == objLogin.Password))
            {
                Session["username"] = objLogin.UserName;

                return RedirectToAction("Index", "Items");
            }
            else
            {

                if (getValidUser != null)
                {
                    Session["username"] = objLogin.UserName;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.LoginFaild = "Invalid username or password";
                    return View("login");
                }

            }

        }

        public string GetUserByUsername(string uname)
        {
            var userExist = "";
            var user = dbObj.Users.FirstOrDefault((n) => n.UserName == uname);
            if (user == null)
            {
                userExist = "No";
            }
            else
            {
                userExist = "Yes";
            }
            return userExist;
        }

        public IList<Item> getAllItems()
        {
            IList<Item> items = new List<Item>();
            items = dbObj.Item.ToList(); 
            return items;
        }

        public int AddCart(int ItemId)
        {
            
            string username = Session["username"].ToString();
            int ItemdCount = dbObj.Cart.Where(s => s.ItemId == ItemId & s.UserName == username).Count();
            
           
            var SelectCartRow = dbObj.Cart.SingleOrDefault(s => s.ItemId == ItemId & s.UserName == username);

            
            

            if (SelectCartRow == null)
            {
                Carts objcart = new Carts()
                {
                    UserName = username,
                    ItemId = ItemId,
                    Quantity = 1
                };


                dbObj.Cart.Add(objcart);
                /*NB : After the code works then I will focus on using ViewModel to hide my Db connection for BP.
                 *     I will store data into ListA and ListB then later store bots List into a Mdthat involves both of them. 
                 *     
                 * 
                 */
               
                
            }
            else
            {                //Update the column quantity associated 

                SelectCartRow.Quantity++;
               
            }

            dbObj.SaveChanges();

            


            int count = dbObj.Cart.Where(s => s.UserName == username).Count(); // count number of rows where you can add Quntity intergers.
            

            return count;
        }



       
        public PartialViewResult GetCartItems()
        {
            string username = Session["username"].ToString();
            var sum = 0;
            
            var GetItemsId = dbObj.Cart.Where(s => s.UserName == username).Select(u => u.ItemId).ToList();
            var GetCartItem = from itemList in dbObj.Item where GetItemsId.Contains(itemList.ItemId) select itemList;
            //var CartItems = new List<ItemModel>();

            foreach (var ItemObj in GetCartItem)
            {
                  var quantity = dbObj.Cart.Single(i => i.ItemId == ItemObj.ItemId);
                  sum = sum + ItemObj.Price * quantity.Quantity;
                  

            //    /**
            //     * NB :  1.The foolowing code will be useful for best practice to prevent us from revealing data relationship to a view in a Web page.
            //     *       2. Then we will copy data into a List that will be passed into our PartialView. 
            //     *       3. And try to trace out and where we may be exposing our databse and use Lists instead.
            //     *       4. 
            //     */
            //    ll.AddFirst(quantity.Quantity);
            //    var CartItem = new ItemModel();
            //    CartItem.Category = ItemObj.Category;
            //    CartItem.ImagePath = ItemObj.ImagePath;
            //    CartItem.Name = ItemObj.Name;
            //    CartItem.Price = ItemObj.Price;
            //    CartItem.Description = ItemObj.Description;

            //    CartItems.Add(CartItem);
            //    //sum = sum - ((totalsum.Price * totalsum.Offer) / 100); /////// calculate using offer
               }

            List<Carts> List_Cart = new List<Carts>();
            List<Item> List_Item = new List<Item>();

            List_Cart = dbObj.Cart.Where(s => s.UserName == username).ToList();

            foreach(int itemId in List_Cart.Select(s => s.ItemId))
            {
                List_Item.Add(dbObj.Item.Where(item => item.ItemId == itemId).FirstOrDefault());
            }

            Model_1 myModel = new Model_1();

            myModel.CartSetGet = List_Cart;
            myModel.ItemSetGet = List_Item;

            ViewBag.Total = sum;

            return PartialView("_cartItem", myModel);

        }


        public PartialViewResult DeleteCart(int itemId)
        {
            string getName = Session["username"].ToString();
            Carts removeCart = dbObj.Cart.FirstOrDefault(s => s.UserName == getName && s.ItemId == itemId);
            if (removeCart.Quantity > 1)
            {
                removeCart.Quantity--;

            }
            else {
                dbObj.Cart.Remove(removeCart);

            }
            
            dbObj.SaveChanges();
            return GetCartItems();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item book = dbObj.Item.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


    }
}