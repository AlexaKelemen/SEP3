package Shared;

import Shared.Database.DAOInterface.UserDAOInterface;
import Shared.Database.Implementation.UserDAO;
import Shared.Entities.Order;
import proto.GetOrderRequest;

import java.sql.SQLException;

public class ManagerImpl implements ManagerInterface
{
  public static ManagerImpl instance;
  private GRPCFactory factory;
  private UserDAOInterface userDAO;

  private ManagerImpl()
  {
    factory = new GRPCFactory();
    userDAO = UserDAO.getInstance();
  }

  public static synchronized ManagerImpl getInstance()
  {
    if(instance == null)
    {
      instance = new ManagerImpl();
    }
    return instance;
  }
  @Override public boolean addOrder(GetOrderRequest order)
  {
    Order orderToSave = factory.fromOrderRequest(order);

    return false;
  }
}
