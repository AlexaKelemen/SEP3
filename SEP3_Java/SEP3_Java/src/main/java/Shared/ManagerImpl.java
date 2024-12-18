package Shared;

import Shared.Database.DAOInterface.*;
import Shared.Database.Implementation.*;
import Shared.Entities.Item;
import Shared.Entities.Order;
import Shared.Entities.User;
import Shared.Entities.Utlities.Category;
import Shared.Entities.Utlities.DeliveryOption;
import Shared.Entities.Utlities.PaymentMethod;



import java.sql.SQLException;
import java.util.ArrayList;
/**
 * Implements the {@code ManagerInterface} to provide functionalities for managing
 * orders, users, items, delivery options, payment methods, and user credits.
 *
 * <p>The {@code ManagerImpl} class serves as a singleton and includes methods for
 * processing orders, managing user data, and handling database interactions.
 */
public class ManagerImpl implements ManagerInterface
{
  /**
   * Singleton instance of the {@code ManagerImpl}.
   */
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
  private CreditDAOInterface creditDAO;
  /**
   * Private constructor to initialize DAOs and the factory.
   */
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
    creditDAO = CreditDAO.getInstance();
  }
  /**
   * Returns the singleton instance of {@code ManagerImpl}.
   *
   * @return the singleton instance of {@code ManagerImpl}
   */
  public static synchronized ManagerImpl getInstance()
  {
    if(instance == null)
    {
      instance = new ManagerImpl();
    }
    return instance;
  }
  /**
   * Adds a new order to the system.
   *
   * @param order the {@code proto.GetOrderRequest} containing order details
   * @return a {@code proto.GetOrderResponse} indicating success or failure
   */
  @Override public proto.GetOrderResponse addOrder(proto.GetOrderRequest order)
  {
    try
    {
      Order orderToSave = factory.fromOrderRequest(order);


      User user = userDAO.getUser(orderToSave.getPlacedBy());
      DeliveryOption deliveryOption = deliveryOptionDAO.getDeliveryOption(orderToSave.getDeliveryOption().getId());
      PaymentMethod paymentMethod = paymentMethodDAO.getPaymentMethod(orderToSave.getPaymentMethod().getId());


      if (deliveryOption == null || !deliveryOption.getName().equals(orderToSave.getDeliveryOption().getName()) )
      {
        deliveryOption = deliveryOptionDAO.addDeliveryOption(orderToSave.getDeliveryOption());
      }
      if(paymentMethod == null || !paymentMethod.getName().equals(orderToSave.getPaymentMethod().getName()))
      {
        paymentMethod = paymentMethodDAO.addPaymentMethod(orderToSave.getPaymentMethod());
      }
      orderToSave.setDeliveryOption(deliveryOption);
      orderToSave.setPaymentMethod(paymentMethod);

      if(user == null || deliveryOption == null || paymentMethod == null || orderToSave.getPaymentMethod().getName().isEmpty() || orderToSave.getDeliveryOption().getName().isEmpty() || order.getToAddress().isEmpty() )
      {
        return factory.fromBoolean(false);
      }
      ArrayList<Item> itemsToSave = orderToSave.getItems();
      for (int i = 0; i < itemsToSave.size(); i++)
      {
        Item itemAdded = itemDAO.getItem(itemsToSave.get(i).getItemId());
        if(itemAdded == null)
        {
          itemAdded = itemDAO.addItem(itemsToSave.get(i));
        }
        itemAdded.setQuantity(itemsToSave.get(i).getQuantity());
        itemAdded.setColour(itemsToSave.get(i).getColour());
        itemAdded.setSize(itemsToSave.get(i).getSize());
        ArrayList<Category> categories = itemsToSave.get(i).getCategory();
        for (int j = 0; j < categories.size(); j++)
        {
          Category categoryAdded = categoryDAO.getCategory(categories.get(j).getCategoryId());
          if(categoryAdded == null)
          {
            categoryAdded = categoryDAO.addCategory(categories.get(j));
          }
          if(itemCategoryDAO.getItemCategory(itemAdded.getItemId(), categoryAdded.getCategoryId()) == null)
          {
            itemCategoryDAO.addItemCategory(itemAdded.getItemId(), categoryAdded.getCategoryId());
          }
        }
        orderDAO.addOrder(orderToSave);
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
  /**
   * Retrieves all orders for a specific user.
   *
   * @param user the {@code proto.GetAllOrdersRequest} containing user details
   * @return a {@code proto.GetAllOrdersResponse} with the orders for the user
   */
  @Override public proto.GetAllOrdersResponse getAllOrdersForUser(
      proto.GetAllOrdersRequest user)
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
        itemsForOrder.add(getCompleteItem(items.get(j).getItemId(), ordersForUser.get(i).getOrderId()));
      }
      ordersForUser.get(i).setItems(itemsForOrder);
      ordersForUser.get(i).setDeliveryOption(deliveryOptionDAO.getDeliveryOption(ordersForUser.get(i).getDeliveryOption().getId()));
      ordersForUser.get(i).setPaymentMethod(paymentMethodDAO.getPaymentMethod(ordersForUser.get(i).getPaymentMethod().getId()));
    }
    return factory.fromOrder(ordersForUser);
  }
  /**
   * Processes a refund for a specific order.
   *
   * @param refund the {@code proto.GetRefundOrderRequest} containing refund details
   * @return a {@code proto.GetBooleanResponse} indicating success or failure
   */
  @Override public proto.GetBooleanResponse refundAnOrder(
      proto.GetRefundOrderRequest refund)
  {
    try
    {
      Order orderToRefund = factory.fromGetRefundOrderRequest(refund);
      orderDAO.editOrder(orderToRefund);
      ArrayList<Item> checkToDelete = itemsInOrderDAO.getAllItemsInOrder(orderToRefund.getOrderId());
      for (int i = 0; i < orderToRefund.getItems().size(); i++)
      {
        itemsInOrderDAO.editItemInOrder(orderToRefund.getItems().get(i), orderToRefund.getOrderId());
        for (int j = 0; j < checkToDelete.size(); j++)
        {
          if(checkToDelete.get(j).getItemId() == orderToRefund.getItems().get(i).getItemId())
          {
            checkToDelete.remove(j);
          }
        }
      }
      for (int i = 0; i < checkToDelete.size(); i++)
      {
        itemsInOrderDAO.deleteItemFromOrder(checkToDelete.get(i).getItemId(), orderToRefund.getOrderId());
      }
      return factory.createBooleanResponse(true);
    }
    catch (Exception e)
    {
      e.printStackTrace();
      return factory.createBooleanResponse(false);
    }
  }  /**
 * Processes a return for a specific order.
 *
 * @param request the {@code proto.GetReturnOrderRequest} containing return details
 * @return a {@code proto.GetBooleanResponse} indicating success or failure
 */

  @Override public proto.GetBooleanResponse returnAnOrder(
      proto.GetReturnOrderRequest request)
  {
    try
    {
      Order orderToReturn = factory.getOrderFromGetReturnRequest(request);
      ArrayList<Item> checkToDelete = itemsInOrderDAO.getAllItemsInOrder(orderToReturn.getOrderId());
      for (int i = 0; i < orderToReturn.getItems().size(); i++)
      {
        itemsInOrderDAO.editItemInOrder(orderToReturn.getItems().get(i), orderToReturn.getOrderId());
        for (int j = 0; j < checkToDelete.size(); j++)
        {
          if(checkToDelete.get(j).getItemId() == orderToReturn.getItems().get(i).getItemId())
          {
            checkToDelete.remove(j);
          }
        }
      }
      for (int i = 0; i < checkToDelete.size(); i++)
      {
        itemsInOrderDAO.deleteItemFromOrder(checkToDelete.get(i).getItemId(), orderToReturn.getOrderId());
      }
      int credit = creditDAO.getCredit(orderToReturn.getPlacedBy());
      if(credit < 0)
      {
        credit = factory.getCreditFromGetReturnRequest(request);
        creditDAO.addCredit(orderToReturn.getPlacedBy(), credit);

      }
      else
      {
        credit += factory.getCreditFromGetReturnRequest(request);
        creditDAO.editCredit(orderToReturn.getPlacedBy(), credit);
      }

      return factory.createBooleanResponse(true);
    }
    catch (Exception e)
    {
      e.printStackTrace();
      return factory.createBooleanResponse(false);
    }
  }
  /**
   * Retrieves the credit for a specific user.
   *
   * @param request the {@code proto.GetCreditRequest} containing user details
   * @return a {@code proto.GetCreditResponse} with the user's credit
   */
  @Override public proto.GetCreditResponse getCreditForUser(
      proto.GetCreditRequest request)
  {
    int credit = creditDAO.getCredit(factory.fromCreditRequest(request));
    if (credit <= 0)
    {
      return factory.toCreditResponse(0);
    }
    return factory.toCreditResponse(credit);
  }
  /**
   * Sets the credit for a specific user.
   *
   * @param request the {@code proto.SetCreditRequest} containing user and credit details
   * @return a {@code proto.GetBooleanResponse} indicating success or failure
   */
  @Override public proto.GetBooleanResponse setCreditForUser(
      proto.SetCreditRequest request)
  {
    int credit = creditDAO.getCredit(factory.getUserFromSetCreditRequest(request));
    if (credit < 0)
    {
      creditDAO.addCredit(factory.getUserFromSetCreditRequest(request),
          factory.getCreditFromSetCreditRequest(request));
    }
    creditDAO.editCredit(factory.getUserFromSetCreditRequest(request),
        factory.getCreditFromSetCreditRequest(request));
    return factory.createBooleanResponse(true);
  }
  /**
   * Retrieves the complete {@code Item} object, including its categories,
   * for a specific item and order.
   *
   * @param itemId the ID of the item
   * @param orderId the ID of the order
   * @return the complete {@code Item} object
   */
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
