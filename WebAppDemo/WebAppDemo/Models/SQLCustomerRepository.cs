/*namespace WebAppDemo.Models
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        public AppDbContext _db;
        public SQLCustomerRepository(AppDbContext _db)
        {
            this._db = _db;
        }
        public Customer Add(Customer customer)
        {
            _db.Customer.Add(customer);
            _db.SaveChanges();
            return customer;
        }

        public Customer Delete(string userName)
        {
            Customer c=_db.Customer.Find(userName);
            if (c != null)
            {
                _db.Customer.Remove(c);
                _db.SaveChanges();
            }
            return c;
        }

        public List<Customer> GetAllCustomer()
        {
            return _db.Customer.ToList();
        }

        public Customer GetCustomerByUserName(string userName)
        {
            return _db.Customer.Find(userName);
        }

        public Customer Update(Customer customer)
        {
            var c = _db.Customer.Attach(customer);
            c.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return customer;
        }
    }
}*/
