using E_Commerce_Try2.Dtos;

namespace E_Commerce_Try2.Repositorys.RepoOrder
{
    public interface IOrderRepo
    {
        public List<GetAllOrder> GetAllOrders();
        public void AddOrder(OrderDto dto);
        public void UpdateOrder(OrderDto dto,int id);
    }
}
