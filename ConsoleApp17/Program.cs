using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ShopContext())
            {
                var user = new User {
                    Id = Guid.NewGuid(),
                    login = "Amir",
                    Password = "dsdasdas",
            };
                var cart = new Cart {
                id=Guid.NewGuid()};
                user.Cart = cart;
                var item = new Item {

                    id = Guid.NewGuid(),
                    Name = "Burger",
                    Price = 345,
                    ProductOutOfDate = DateTime.Now.AddDays(3),
                    Carts=new List<Cart>
                    {
                        cart
                    }
                };
                cart.Items = new List<Item> {item };
                context.Carts.Add(cart);
                context.Users.Add(user);
                context.Items.Add(item);

                context.SaveChanges();

            }
        }
    }
}
