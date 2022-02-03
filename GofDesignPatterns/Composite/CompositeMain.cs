using Composite.Products;

namespace Composite
{
    public class CompositeMain
    {
        private SimpleProduct Ram4gb;
        private SimpleProduct Ram8gb;

        private CompositeProduct GammerPC;
        private CompositeProduct HomePC;
        private CompositeProduct Pc2x1;

        public void Action()
        {
            Ram4gb = new SimpleProduct("RAM 4GB", 750, "KingStone");
            Ram8gb = new SimpleProduct("RAM 8GB", 1000, "KingStone");

            GammerPC = new CompositeProduct("Gammer PC");
            GammerPC.AddProduct(Ram8gb);
            HomePC = new CompositeProduct("Home PC");
            HomePC.AddProduct(Ram4gb);

            Pc2x1 = new CompositeProduct("Pack PC Gammer + Home PC");
            Pc2x1.AddProduct(GammerPC);
            Pc2x1.AddProduct(HomePC);
        }
    }
}