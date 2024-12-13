package Shared;

import Shared.Database.DAOInterface.DeliveryOptionDAOInterface;
import Shared.Database.DAOInterface.UserDAOInterface;
import Shared.Database.Implementation.DeliveryOptionDAO;
import Shared.Database.Implementation.UserDAO;
import Shared.Entities.Order;
import Shared.Entities.User;
import Shared.Entities.Utlities.DeliveryOption;
import proto.GetOrderRequest;

import java.sql.SQLException;
import java.util.ArrayList;

public class ManagerImpl implements ManagerInterface
{
  public static ManagerImpl instance;
  private GRPCFactory factory;
  private UserDAOInterface userDAO;
  private DeliveryOptionDAOInterface deliveryOptionDAO;

  private ManagerImpl()
  {
    factory = new GRPCFactory();
    userDAO = UserDAO.getInstance();
    deliveryOptionDAO = DeliveryOptionDAO.getInstance();
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

    User user = userDAO.getUser(orderToSave.getPlacedBy());
    DeliveryOption deliveryOption = null;

    ArrayList<DeliveryOption> deliveryOptions = deliveryOptionDAO.getAllDeliveryOptions();
    for (int i = 0; i < deliveryOptions.size(); i++)
    {
      if(deliveryOptions.get(i).getName().equals(order.getDeliveryOption().getName()))
      {
        deliveryOption = new DeliveryOption(deliveryOptions.get(i).getId(), deliveryOptions.get(i).getName());
      }
    }
    if(user == null || deliveryOption == null)
    {
      return false;
    }

    return true;
  }
}
