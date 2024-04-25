using ShoppingModelLibrary.CustomerExceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary.ProductExceptions;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override Product Delete(int key)
        {
            Product product = GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override Product GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoProductWithGivenIDException();
            //-----------------------------------------
            //Predicate<Product> findProduct =(p)=>p.Id==key;
            //Product product = items.ToList().Find(findProduct);

            //Product product = items.ToList().Find((p) => p.Id == key);

            //Product product = items.FirstOrDefault(p => p.Id == key);
            //return product;
        }

        public override Product Update(Product item)
        {
            int index = items.FindIndex((element) => element.Id == item.Id);
            if (index != -1)
            {
                items[index] = item;
                return item;
            }
            throw new NoProductWithGivenIDException();
        }
    }
}
