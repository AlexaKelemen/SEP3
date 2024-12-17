package Shared;

import Shared.Database.DAOInterface.*;
import Shared.Database.Implementation.*;
import Shared.Entities.Item;
import Shared.Entities.Order;
import Shared.Entities.User;
import Shared.Entities.Utlities.Category;
import Shared.Entities.Utlities.DeliveryOption;
import Shared.Entities.Utlities.PaymentMethod;

import proto.GetBooleanResponse;
import proto.GetAllOrdersRequest;
import proto.GetAllOrdersResponse;
import proto.GetOrderRequest;
import proto.GetOrderResponse;
import proto.GetRefundOrderRequest;

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
      DeliveryOption deliveryOption = deliveryOptionDAO.getDeliveryOption(orderToSave.getDeliveryOption().getId());
      PaymentMethod paymentMethod = paymentMethodDAO.getPaymentMethod(orderToSave.getPaymentMethod().getId());


      if (deliveryOption == null)
      {
        deliveryOption = deliveryOptionDAO.addDeliveryOption(orderToSave.getDeliveryOption());
      }
      if(paymentMethod == null)
      {
        paymentMethod = paymentMethodDAO.addPaymentMethod(orderToSave.getPaymentMethod());
      }
      orderToSave.setDeliveryOption(deliveryOption);
      orderToSave.setPaymentMethod(paymentMethod);

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
          itemAdded.setQuantity(itemsToSave.get(i).getQuantity());
          itemAdded.setColour(itemsToSave.get(i).getColour());
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
        itemsForOrder.add(getCompleteItem(items.get(i).getItemId(), ordersForUser.get(i).getOrderId()));
      }
      ordersForUser.get(i).setItems(itemsForOrder);
      ordersForUser.get(i).setDeliveryOption(deliveryOptionDAO.getDeliveryOption(ordersForUser.get(i).getDeliveryOption().getId()));
      ordersForUser.get(i).setPaymentMethod(paymentMethodDAO.getPaymentMethod(ordersForUser.get(i).getPaymentMethod().getId()));
    }
    return factory.fromOrder(ordersForUser);
  }

  @Override public GetBooleanResponse refundAnOrder(
      GetRefundOrderRequest refund)
  {
    try
    {
      Order orderToRefund = factory.fromGetRefundOrderRequest(refund);
      orderDAO.editOrder(orderToRefund);
      for (int i = 0; i < orderToRefund.getItems().size(); i++)
      {
        if (orderToRefund.getItems().get(i).getQuantity() <= 0)
        {
          itemsInOrderDAO.deleteItemFromOrder(orderToRefund.getItems().get(i).getItemId(), orderToRefund.getOrderId());
        }
        itemsInOrderDAO.editItemInOrder(orderToRefund.getItems().get(i), orderToRefund.getOrderId());
      }
      return factory.createBooleanResponse(true);
    }
    catch (Exception e)
    {
      return factory.createBooleanResponse(false);
    }
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
