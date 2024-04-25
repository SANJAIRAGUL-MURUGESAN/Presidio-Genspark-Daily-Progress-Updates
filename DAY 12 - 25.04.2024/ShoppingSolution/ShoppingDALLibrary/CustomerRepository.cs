using ShoppingModelLibrary.CustomerExceptions;
using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override Customer Delete(int key)
        {
            Customer customer = GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
                return customer;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public override Customer GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoCustomerWithGiveIdException();
        }

        public override Customer Update(Customer item)
        {
            int index = items.FindIndex((element) => element.Id == item.Id);
            if (index != -1)
            {
                items[index] = item;
                return item;
            }
            throw new NoCustomerWithGiveIdException();
        }
    }
}