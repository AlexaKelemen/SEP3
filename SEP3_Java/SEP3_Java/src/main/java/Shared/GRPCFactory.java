package Shared;

import Shared.Entities.Item;
import Shared.Entities.Order;
import Shared.Entities.Utlities.Category;
import Shared.Entities.Utlities.DeliveryOption;
import Shared.Entities.Utlities.PaymentMethod;


import com.google.protobuf.Timestamp;

import java.sql.Time;
import java.time.*;
import java.util.ArrayList;
import java.util.List;
/**
 * Factory class for converting between gRPC protocol buffer objects and domain entities.
 * This class handles conversions to and from gRPC `proto` objects and the application's domain
 * objects such as {@link Order}, {@link Item}, {@link PaymentMethod}, {@link DeliveryOption}, and {@link Category}.
 * It is used for communication between server and client.
 *
 */
public class GRPCFactory
{
  /**
   * Converts a gRPC `GetOrderRequest` into an  Order object.
   *
   * @param request the gRPC `GetOrderRequest` object.
   * @return an  Order object populated with data from the request.
   */
  public Order fromOrderRequest(proto.GetOrderRequest request)
  {
    return new Order(fromItemDTOList(request.getItemsList()),
        request.getTotalAmount(), request.getOrderId(),
        fromTimestamp(request.getPlacedOn()),
        fromPaymentMethodDTO(request.getPaymentMethod()),
        fromDeliveryOptionDTO(request.getDeliveryOption()),
        request.getPlacedBy(), request.getToAddress());

  }
  /**
   * Converts a gRPC `GetReturnOrderRequest` into an  Order object.
   *
   * @param request the gRPC `GetReturnOrderRequest` object.
   * @return an {@link Order} object with data from the request.
   */
  public Order getOrderFromGetReturnRequest(proto.GetReturnOrderRequest request)
  {
    return fromOrderDTO(request.getOrder());
  }

  /**
   * Retrieves credit value from a gRPC `GetReturnOrderRequest`.
   *
   * @param request the gRPC `GetReturnOrderRequest` object.
   * @return the credit value from the request.
   */

  public int getCreditFromGetReturnRequest(proto.GetReturnOrderRequest request)
  {
    return request.getCredit();
  }

  /**
   * Converts a gRPC `GetCreditRequest` into a username string.
   *
   * @param request the gRPC `GetCreditRequest` object.
   * @return the username string from the request.
   */
  public String fromCreditRequest(proto.GetCreditRequest request)
  {
    return request.getUser();
  }

  /**
   * Converts a gRPC `SetCreditRequest` into a username string.
   *
   * @param request the gRPC `SetCreditRequest` object.
   * @return the username string from the request.
   */
  public String getUserFromSetCreditRequest(proto.SetCreditRequest request)
  {
    return request.getUser();
  }

  /**
   * Retrieves credit value from a gRPC `SetCreditRequest`.
   *
   * @param request the gRPC `SetCreditRequest` object.
   * @return the credit value from the request.
   */
  public int getCreditFromSetCreditRequest(proto.SetCreditRequest request)
  {
    return request.getCredit();
  }

  /**
   * Converts an integer credit value to a gRPC `GetCreditResponse`.
   *
   * @param credit the credit value to include in the response.
   * @return a gRPC `GetCreditResponse` object.
   */
  public proto.GetCreditResponse toCreditResponse(int credit)
  {
    return proto.GetCreditResponse.newBuilder().setCredit(credit).build();
  }
  /**
   * Converts a gRPC `GetRefundOrderRequest` into an Order object.
   *
   * @param request the gRPC `GetRefundOrderRequest` object.
   * @return an  Order object populated with data from the request.
   */
  public Order fromGetRefundOrderRequest(proto.GetRefundOrderRequest request)
  {
    return fromOrderDTO(request.getOrder());
  }

  /**
   * Converts a proto.OrderDTO object into an Order object.
   *
   * @param order the proto.OrderDTO object to be converted
   * @return a new  Order object with data derived from the input
   */
  private Order fromOrderDTO(proto.OrderDTO order)
  {
    return new Order(fromItemDTOList(order.getItemsList()),
        order.getTotalAmount(), order.getOrderId(),
        fromTimestamp(order.getPlacedOn()),
        fromPaymentMethodDTO(order.getPaymentMethod()),
        fromDeliveryOptionDTO(order.getDeliveryOption()),
        order.getPlacedBy(), order.getToAddress());
  }
  /**
   * Converts a gRPC `GetAllOrdersRequest` into a username string.
   *
   * @param request the gRPC `GetAllOrdersRequest` object.
   * @return the username string from the request.
   */
  public String fromGetAllOrdersRequest(proto.GetAllOrdersRequest request)
  {
    return request.getUser();
  }
  /**
   * Converts a list of orders into a gRPC `GetAllOrdersResponse`.
   *
   * @param order the list of Order objects to convert.
   * @return a gRPC `GetAllOrdersResponse` object containing the orders.
   */

  public proto.GetAllOrdersResponse fromOrder(ArrayList<Order> order)
  {
    return proto.GetAllOrdersResponse.newBuilder().addAllOrders(createListOfOrderDTOs(order)).build();
  }

  /**
   *Creates a list of proto.OrderDTO objects from a given list of Order objects.
   * @param orders the list of Order objects to be converted
   * @return a list of proto.OrderDTO objects corresponding to the input
   */

  private ArrayList<proto.OrderDTO> createListOfOrderDTOs(ArrayList<Order> orders)
  {
    ArrayList<proto.OrderDTO> response = new ArrayList<>();
    for (int i = 0; i < orders.size(); i++)
    {
      response.add(createOrderDTO(orders.get(i)));
    }
    return response;
  }
  /**
   * Converts an Order object to a gRPC `OrderDTO` object.
   *
   * @param order the Order object to convert.
   * @return a gRPC `OrderDTO` object.
   */
  private proto.OrderDTO createOrderDTO(Order order)
  {
    return proto.OrderDTO.newBuilder().setPlacedOn(createTimestamp(order.getDate()))
        .setPaymentMethod(createPaymentMethodDTO(order.getPaymentMethod()))
        .setTotalAmount(order.getTotalAmount())
        .setDeliveryOption(createDeliveryOptionDTO(order.getDeliveryOption()))
        .addAllItems(createItemDTOList(order.getItems()))
        .setOrderId(order.getOrderId()).setPlacedBy(order.getPlacedBy())
        .setToAddress(order.getToAddress()).build();
  }
  /**
   * Converts a LocalDate to a gRPC `Timestamp` object.
   *
   * @param date the LocalDate to convert.
   * @return a gRPC `Timestamp` object.
   */
  private Timestamp createTimestamp(LocalDate date)
  {
    Instant instant = date.atStartOfDay(ZoneId.systemDefault()).toInstant();
    return Timestamp.newBuilder().setSeconds(instant.getEpochSecond())
        .setNanos(instant.getNano()).build();
  }
  /**
   * Converts a PaymentMethod object to a gRPC `PaymentMethodDTO`.
   *
   * @param paymentMethod the PaymentMethod object to convert.
   * @return a gRPC `PaymentMethodDTO` object.
   */
  private proto.PaymentMethodDTO createPaymentMethodDTO(PaymentMethod paymentMethod)
  {
    return proto.PaymentMethodDTO.newBuilder().setId(paymentMethod.getId())
        .setName(paymentMethod.getName()).build();
  }
  /**
   * Converts a DeliveryOption object to a gRPC `DeliveryOptionDTO`.
   *
   * @param deliveryOption the DeliveryOption object to convert.
   * @return a gRPC `DeliveryOptionDTO` object.
   */
  private proto.DeliveryOptionDTO createDeliveryOptionDTO(
      DeliveryOption deliveryOption)
  {
    return proto.DeliveryOptionDTO.newBuilder().setId(deliveryOption.getId())
        .setName(deliveryOption.getName()).build();
  }
  /**
   * Converts a list of Item objects into a list of gRPC `ItemDTO` objects.
   *
   * @param items the list of Item objects to convert.
   * @return a list of gRPC `ItemDTO` objects.
   */

  private ArrayList<proto.ItemDTO> createItemDTOList(ArrayList<Item> items)
  {
    ArrayList<proto.ItemDTO> response = new ArrayList<>();
    for (int i = 0; i < items.size(); i++)
    {
      response.add(createItemDTO(items.get(i)));
    }
    return response;
  }

  /**
   * Converts an Item object to a gRPC `ItemDTO`.
   *
   * @param item the Item object to convert.
   * @return a gRPC `ItemDTO` object.
   */

  private proto.ItemDTO createItemDTO(Item item)
  {
    return proto.ItemDTO.newBuilder().setItemId(item.getItemId())
        .setPrice(item.getPrice()).setDescription(item.getDescription())
        .setName(item.getName())
        .addAllCategory(createCategoryDTOList(item.getCategory()))
        .setQuantity(item.getQuantity()).setColour(item.getColour()).setSize(
            item.getSize()).build();
  }
  /**
   * Converts a list of Category objects into a list of gRPC `CategoryDTO` objects.
   *
   * @param categories the list of Category objects to convert.
   * @return a list of gRPC `CategoryDTO` objects.
   */
  private ArrayList<proto.CategoryDTO> createCategoryDTOList(
      ArrayList<Category> categories)
  {
    ArrayList<proto.CategoryDTO> response = new ArrayList<>();
    for (int i = 0; i < categories.size(); i++)
    {
      response.add(createCategoryDTO(categories.get(i)));
    }
    return response;
  }
  /**
   * Converts a Category object to a gRPC `CategoryDTO`.
   *
   * @param category the Category object to convert.
   * @return a gRPC `CategoryDTO` object.
   */
  private proto.CategoryDTO createCategoryDTO(Category category)
  {
    return proto.CategoryDTO.newBuilder().setName(category.getName())
        .setDescription(category.getDescription())
        .setCategoryId(category.getCategoryId()).build();
  }
  /**
   * Converts a list of gRPC `ItemDTO` objects into a list of Item objects.
   *
   * @param items the list of gRPC `ItemDTO` objects to convert.
   * @return a list of Item objects.
   */
  private ArrayList<Item> fromItemDTOList(List<proto.ItemDTO> items)
  {
    ArrayList<Item> response = new ArrayList<>();
    for (int i = 0; i < items.size(); i++)
    {
      response.add(fromItemDTO(items.get(i)));
    }
    return response;
  }
  /**
   * Converts a gRPC `ItemDTO` object to an Item object.
   *
   * @param item the gRPC `ItemDTO` object to convert.
   * @return an Item object.
   */
  private Item fromItemDTO(proto.ItemDTO item)
  {
    return new Item(item.getName(), fromCategoryDTOList(item.getCategoryList()),
        item.getPrice(), item.getItemId(), item.getDescription(),
        item.getQuantity(), item.getColour(), item.getSize());
  }
  /**
   * Converts a list of gRPC `CategoryDTO` objects into a list of Category objects.
   *
   * @param categories the list of gRPC `CategoryDTO` objects to convert.
   * @return a list of Category objects.
   */
  private ArrayList<Category> fromCategoryDTOList(List<proto.CategoryDTO> categories)
  {
    ArrayList<Category> response = new ArrayList<>();
    for (int i = 0; i < categories.size(); i++)
    {
      response.add(fromCategoryDTO(categories.get(i)));
    }
    return response;
  }
  /**
   * Converts a gRPC `CategoryDTO` object to a Category object.
   *
   * @param category the gRPC `CategoryDTO` object to convert.
   * @return a Category object.
   */
  private Category fromCategoryDTO(proto.CategoryDTO category)
  {
    return new Category(category.getName(), category.getDescription(),
        category.getCategoryId());
  }
  /**
   * Converts a gRPC `Timestamp` to a LocalDate object.
   *
   * @param time the gRPC `Timestamp` object to convert.
   * @return a LocalDate object.
   */
  private LocalDate fromTimestamp(Timestamp time)
  {
    return LocalDateTime.ofEpochSecond(time.getSeconds(), time.getNanos(),
        ZoneOffset.UTC).toLocalDate();
  }

  /**
   * Converts a gRPC `PaymentMethodDTO` object to a PaymentMethod object.
   *
   * @param paymentMethod the gRPC `PaymentMethodDTO` object to convert.
   * @return a PaymentMethod object.
   */
  private PaymentMethod fromPaymentMethodDTO(
      proto.PaymentMethodDTO paymentMethod)
  {
    return new PaymentMethod(paymentMethod.getId(), paymentMethod.getName());
  }
  /**
   * Converts a gRPC `DeliveryOptionDTO` object to a DeliveryOption object.
   *
   * @param deliveryOption the gRPC `DeliveryOptionDTO` object to convert.
   * @return a DeliveryOption object.
   */
  private DeliveryOption fromDeliveryOptionDTO(
      proto.DeliveryOptionDTO deliveryOption)
  {
    return new DeliveryOption(deliveryOption.getId(), deliveryOption.getName());
  }
  /**
   * Converts a boolean indicating delivery success to a gRPC `GetOrderResponse`.
   *
   * @param deliveryMade the boolean indicating delivery success.
   * @return a gRPC `GetOrderResponse` object.
   */
  public proto.GetOrderResponse fromBoolean(boolean deliveryMade)
  {
    return proto.GetOrderResponse.newBuilder().setSuccess(deliveryMade).build();
  }
  /**
   * Converts a boolean indicating refund success to a gRPC `GetBooleanResponse`.
   *
   * @param refundMade the boolean indicating refund success.
   * @return a gRPC `GetBooleanResponse` object.
   */
  public proto.GetBooleanResponse createBooleanResponse(boolean refundMade)
  {
    return proto.GetBooleanResponse.newBuilder().setSuccess(refundMade).build();
  }
}
