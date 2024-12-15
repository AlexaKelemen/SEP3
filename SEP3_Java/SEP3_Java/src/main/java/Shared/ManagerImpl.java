package Shared;

import Shared.Database.DAOInterface.*;
import Shared.Database.Implementation.*;
import Shared.Entities.Item;
import Shared.Entities.Order;
import Shared.Entities.User;
import Shared.Entities.Utlities.Category;
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
  private OrderDAOInterface orderDAO;
  private CategoryDAOInterface categoryDAO;
  private ItemDAOInterface itemDAO;
  private ItemCategoryDAOInterface itemCategoryDAO;

  private ManagerImpl()
  {
    factory = new GRPCFactory();
    userDAO = UserDAO.getInstance();
    deliveryOptionDAO = DeliveryOptionDAO.getInstance();
    paymentMethodDAO = PaymentMethodDAO.getInstance();
    orderDAO = OrderDAO.getInstance();
    categoryDAO = CategoryDAO.getInstance();
    itemDAO = ItemDAO.getInstance();
    itemCategoryDAO = ItemCategoryDAO.getInstance();
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
    orderDAO.addOrder(orderToSave);
    ArrayList<Item> itemsToSave = orderToSave.getItems();
    for (int i = 0; i < itemsToSave.size(); i++)
    {
      Item itemAdded = itemDAO.getItem(itemsToSave.get(i).getItemId());
      if(itemAdded == null)
      {
        itemAdded = itemDAO.addItem(itemsToSave.get(i));
      }
      ArrayList<Category> categories = itemsToSave.get(i).getCategory();
      for (int j = 0; j < categories.size(); j++)
      {
        Category categoryAdded = categoryDAO.getCategory(categories.get(j).getCategoryId());
        if(categoryAdded == null)
        {
          categoryAdded = categoryDAO.addCategory(categories.get(j));
        }
        itemCategoryDAO.addItemCategory(itemAdded.getItemId(), categoryAdded.getCategoryId());
      }


    }

    return true;
  }
}
