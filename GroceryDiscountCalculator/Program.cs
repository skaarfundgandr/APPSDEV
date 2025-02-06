using System.Collections;
using System;

namespace GroceryDiscountCalculator
{
    class Item
    {
        string productName;
        double price;
        int quantity;

        public Item(string productName, double price, int quantity)
        {
            this.productName = productName;
            this.price = price;
            this.quantity = quantity;
        }

        public string ProductName { get { return productName; } }
        public double Price { get { return price; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const double BASE_DISCOUNT = 0.1;
            char input;
            double totalPrice;

            ArrayList items = new ArrayList();
            Console.Clear();
            try
            {
                do
                {
                    Console.WriteLine("\n 1. Add a product");
                    Console.WriteLine(" 2. Show products");
                    Console.WriteLine(" 3. Calculate total price");
                    Console.WriteLine(" x. Exit");
                    Console.Write("Enter your choice: ");

                    input = Console.ReadLine()[0];
                    Console.Clear();

                    switch (input)
                    {
                        case '1':
                            Console.WriteLine("---------------------");
                            Console.Write("Enter product name: ");
                            string pname = Console.ReadLine();

                            Console.Write("Enter price: ");
                            double price = double.Parse(Console.ReadLine());

                            Console.Write("Enter quantity: ");
                            int qtty = int.Parse(Console.ReadLine());
                            Console.Clear();

                            if (items.Count > 0)
                            {
                                Boolean itemfound = false;

                                foreach (Item item in items)
                                {
                                    if (item.ProductName == pname)
                                    {
                                        item.Quantity += qtty;
                                        itemfound = true;
                                        break;
                                    }
                                }
                                if (!itemfound)
                                {
                                    items.Add(new Item(pname, price, qtty));
                                }
                            }
                            else
                            {
                                items.Add(new Item(pname, price, qtty));
                            }
                            break;
                        case '2':
                            Console.WriteLine("\n{0,-15} {1,-10} {2,-10}", "Product Name", "Price", "Quantity");
                            Console.WriteLine(new string('-', 40));
                            foreach (Item item in items)
                            {
                                Console.WriteLine("{0,-15} {1,-10} {2,-10}", item.ProductName, item.Price, item.Quantity);
                            }
                            break;
                        case '3':
                            totalPrice = 0;

                            foreach (Item item in items)
                            {
                                totalPrice += item.Price * item.Quantity;
                            }

                            if (totalPrice > 100 && totalPrice <= 200)
                            {
                                totalPrice -= totalPrice * BASE_DISCOUNT;
                            }
                            if (totalPrice > 200 && totalPrice <= 500)
                            {
                                totalPrice -= totalPrice * (BASE_DISCOUNT + 0.5);
                            }
                            if (totalPrice > 500)
                            {
                                totalPrice -= totalPrice * (BASE_DISCOUNT + 0.1);
                            }

                            Console.WriteLine($"Total Price: ${totalPrice}");
                            break;
                        default:
                            Console.WriteLine("Invalid choice, Please try again.");
                            break;
                    }
                } while (input != 'x');
            } 
            catch(Exception ex) { Console.WriteLine(ex.ToString()); }
        }
    }
}
