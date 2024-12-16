package Shared;

import Shared.Database.DAOInterface.*;
import Shared.Database.Implementation.*;
import Shared.Entities.Item;
import Shared.Entities.Order;
import Shared.Entities.User;
import Shared.Entities.Utlities.Category;
import Shared.Entities.Utlities.DeliveryOption;
import Shared.Entities.Utlities.PaymentMethod;
import proto.GetAllOrdersRequest;
import proto.GetAllOrdersResponse;
import proto.GetOrderRequest;
import proto.GetOrderResponse;

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
  private ItemsInOrderDAOInterface itemsInOrderDAO;

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
    itemsInOrderDAO = ItemsInOrderDAO.getInstance();
  }

  public static synchronized ManagerImpl getInstance()
  {
    if(instance == null)
    {
      instance = new ManagerImpl();
    }
    return instance;
  }
  @Override public GetOrderResponse addOrder(GetOrderRequest order)
  {
    try
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
        return factory.fromBoolean(false);
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
        itemsInOrderDAO.addItemToOrder(itemAdded, orderToSave.getOrderId());
      }
      return factory.fromBoolean(true);
    }
    catch (Exception e)
    {
      e.printStackTrace();
      return factory.fromBoolean(false);
    }
  }

  @Override public GetAllOrdersResponse getAllOrdersForUser(
      GetAllOrdersRequest user)
  {
    ArrayList<Order> orders = orderDAO.getAllOrders();
    ArrayList<Order> ordersForUser = new ArrayList<>();
    for(int i = 0; i < orders.size(); i++)
    {
      if(orders.get(i).getPlacedBy().equals(factory.fromGetAllOrdersRequest(user)))
      {
        ordersForUser.add(orders.get(i));
      }
    }

    for (int i = 0; i < ordersForUser.size(); i++)
    {
      ArrayList<Item> items = itemsInOrderDAO.getAllItemsInOrder(ordersForUser.get(i).getOrderId());
      ArrayList<Item> itemsForOrder = new ArrayList<>();
      for (int j = 0; j < items.size(); j++)
      {
        itemsForOrder.add(getCompleteItem(itemsForOrder.get(i).getItemId(), ordersForUser.get(i).getOrderId()));
      }
      ordersForUser.get(i).setItems(itemsForOrder);
    }
    return factory.fromOrder(ordersForUser);
  }

  private Item getCompleteItem(int itemId, int orderId)
  {
    Item result = itemDAO.getItem(itemId);
    result = itemsInOrderDAO.getItemInOrder(result, orderId);
    ArrayList<int[]> categories = itemCategoryDAO.getCategoriesForItem(itemId);
    ArrayList<Category> categoryForItem = new ArrayList<>();
    for (int i = 0; i < categories.size(); i++)
    {
      categoryForItem.add(categoryDAO.getCategory(categories.get(i)[1]));
    }
    result.setCategory(categoryForItem);
    return result;
  }

}
