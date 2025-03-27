/*namespace WebAppDemo.Models
{
    public class MockICustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers;
        public MockICustomerRepository()
        {
            _customers = new List<Customer>()
            {
                new Customer(){ userName = "Subash",phoneNo="9892758421",address="Mumbai",email="Subash@gmail.com",password="Subash@123",rePassword="Subash@123",dp="gif.jpg"},
                new Customer(){ userName = "Ramya",phoneNo="9892758421",address="Mumbai",email="Ramya@gmail.com",password="Ramya@123",rePassword="Ramya@123",dp="dp.jpg"}
            };
        }

          
        public Customer Add(Customer customer)
        {
            _customers.Add(customer);
            return customer;
        }

        public Customer Delete(string userName)
        {
            Customer c=_customers.FirstOrDefault(c => c.userName == userName);
            if (c != null)
            {
                _customers.Remove(c);
            }
            return c;
        }

        public List<Customer> GetAllCustomer()
        {
            return _customers;
        }

        public Customer GetCustomerByUserName(string userName)
        {
            return _customers.FirstOrDefault(c => c.userName == userName);
        }

        public Customer Update(Customer customer)
        {
            Customer c = _customers.FirstOrDefault(c => c.userName == customer.userName);
            if (c != null)
            {
                c.email = customer.email;
                c.password = customer.password;
                c.rePassword = customer.rePassword;
                c.dp = customer.dp;
            }
            return c;
        }
    }
}*/
