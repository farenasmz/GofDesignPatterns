using Prototype.Implementation;

namespace Prototype
{
    public class PrototypeMain
    {
        public void Action()
        {
            PriceList standardPriceList = new PriceList("Standard");

            for (int i = 1; i < 5; i++)
            {
                ProductItem productItem = new ProductItem("Product_" + i, i * 2);
                standardPriceList.AddProducts(productItem);
            }

            PrototypeFactory.AddPrototype(standardPriceList.GetListName(), standardPriceList);

            PriceList wholeSalePriceList = (PriceList)PrototypeFactory.GetPrototype("Standard Price List");
            wholeSalePriceList.SetListName("Wholesale Price List");

            foreach (var item in wholeSalePriceList.GetProducts())
            {
                item.Price *= 0.90;
            }

            PrototypeFactory.AddPrototype(wholeSalePriceList.GetListName(), wholeSalePriceList);

            PriceList vipPriceList = (PriceList)PrototypeFactory.GetPrototype("Wohlesale Price List");
            vipPriceList.SetListName("VIP Price List");

            foreach (var item in vipPriceList.GetProducts())
            {
                item.Price *= 0.90;
            }

            foreach (var item in standardPriceList.GetProducts())
            {
                Console.WriteLine(item.Name + " - " + item.Price);
            }

            foreach (var item in wholeSalePriceList.GetProducts())
            {
                Console.WriteLine(item.Name + " - " + item.Price);
            }

            foreach (var item in vipPriceList.GetProducts())
            {
                Console.WriteLine(item.Name + " - " + item.Price);
            }

        }
    }
}