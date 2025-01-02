using E_Commerce_Try2.Dtos;

namespace E_Commerce_Try2.Repositorys.RepoCustomer
{
    public interface ICustomerRepo
    {
        public List<GetAllCustomer> GetAllCustomers();
        public GetAllCustomer GetCustomerById(int id);
        public void AddCustomer(GetAllCustomer dto);
    }
}
