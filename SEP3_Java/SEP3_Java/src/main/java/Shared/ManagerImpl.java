package Shared;

import Shared.Database.DAOInterface.DeliveryOptionDAOInterface;
import Shared.Database.DAOInterface.PaymentMethodDAOInterface;
import Shared.Database.DAOInterface.UserDAOInterface;
import Shared.Database.Implementation.DeliveryOptionDAO;
import Shared.Database.Implementation.PaymentMethodDAO;
import Shared.Database.Implementation.UserDAO;
import Shared.Entities.Order;
import Shared.Entities.User;
import Shared.Entities.Utlities.DeliveryOption;
import Shared.Entities.Utlities.PaymentMethod;
import proto.GetOrderRequest;

import java.sql.SQLException;
import java.util.ArrayList;

public class ManagerImpl implements ManagerInterface
{
  public static ManagerImpl instance;
  private GRPCFactory factory;
  private UserDAOInterface userDAO;
  private DeliveryOptionDAOInterface deliveryOptionDAO;
  private PaymentMethodDAOInterface paymentMethodDAO;

  private ManagerImpl()
  {
    factory = new GRPCFactory();
    userDAO = UserDAO.getInstance();
    deliveryOptionDAO = DeliveryOptionDAO.getInstance();
    paymentMethodDAO = PaymentMethodDAO.getInstance();
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
    PaymentMethod paymentMethod = null;


    ArrayList<DeliveryOption> deliveryOptions = deliveryOptionDAO.getAllDeliveryOptions();
    ArrayList<PaymentMethod> paymentMethods = paymentMethodDAO.getAllPaymentMethods();
    for (int i = 0; i < deliveryOptions.size(); i++)
    {
      if(deliveryOptions.get(i).getName().equals(order.getDeliveryOption().getName()))
      {
        deliveryOption = new DeliveryOption(deliveryOptions.get(i).getId(), deliveryOptions.get(i).getName());
        orderToSave.setDeliveryOption(deliveryOption);
      }
    }
    for (int i = 0; i < paymentMethods.size(); i++)
    {
      if(paymentMethods.get(i).getName().equals(order.getPaymentMethod().getName()))
      {
        paymentMethod = new PaymentMethod(paymentMethods.get(i).getId(), paymentMethods.get(i).getName());
        orderToSave.setPaymentMethod(paymentMethod);
      }
    }

    if(user == null || deliveryOption == null || paymentMethod == null)
    {
      return false;
    }


    return true;
  }
}
