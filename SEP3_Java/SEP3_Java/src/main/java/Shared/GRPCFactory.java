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

public class GRPCFactory
{
  public Order fromOrderRequest(proto.GetOrderRequest request)
  {
    return new Order(fromItemDTOList(request.getItemsList()),
        request.getTotalAmount(), request.getOrderId(),
        fromTimestamp(request.getPlacedOn()),
        fromPaymentMethodDTO(request.getPaymentMethod()),
        fromDeliveryOptionDTO(request.getDeliveryOption()),
        request.getPlacedBy(), request.getToAddress());

  }

  public Order getOrderFromGetReturnRequest(proto.GetReturnOrderRequest request)
  {
    return fromOrderDTO(request.getOrder());
  }

  public int getCreditFromGetReturnRequest(proto.GetReturnOrderRequest request)
  {
    return request.getCredit();
  }

  public String fromCreditRequest(proto.GetCreditRequest request)
  {
    return request.getUser();
  }

  public String getUserFromSetCreditRequest(proto.SetCreditRequest request)
  {
    return request.getUser();
  }

  public int getCreditFromSetCreditRequest(proto.SetCreditRequest request)
  {
    return request.getCredit();
  }

  public proto.GetCreditResponse toCreditResponse(int credit)
  {
    return proto.GetCreditResponse.newBuilder().setCredit(credit).build();
  }

  public Order fromGetRefundOrderRequest(proto.GetRefundOrderRequest request)
  {
    return fromOrderDTO(request.getOrder());
  }

  private Order fromOrderDTO(proto.OrderDTO order)
  {
    return new Order(fromItemDTOList(order.getItemsList()),
        order.getTotalAmount(), order.getOrderId(),
        fromTimestamp(order.getPlacedOn()),
        fromPaymentMethodDTO(order.getPaymentMethod()),
        fromDeliveryOptionDTO(order.getDeliveryOption()),
        order.getPlacedBy(), order.getToAddress());
  }

  public String fromGetAllOrdersRequest(proto.GetAllOrdersRequest request)
  {
    return request.getUser();
  }

  public proto.GetAllOrdersResponse fromOrder(ArrayList<Order> order)
  {
    return proto.GetAllOrdersResponse.newBuilder().addAllOrders(createListOfOrderDTOs(order)).build();
  }

  private ArrayList<proto.OrderDTO> createListOfOrderDTOs(ArrayList<Order> orders)
  {
    ArrayList<proto.OrderDTO> response = new ArrayList<>();
    for (int i = 0; i < orders.size(); i++)
    {
      response.add(createOrderDTO(orders.get(i)));
    }
    return response;
  }

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

  private Timestamp createTimestamp(LocalDate date)
  {
    Instant instant = date.atStartOfDay(ZoneId.systemDefault()).toInstant();
    return Timestamp.newBuilder().setSeconds(instant.getEpochSecond())
        .setNanos(instant.getNano()).build();
  }

  private proto.PaymentMethodDTO createPaymentMethodDTO(PaymentMethod paymentMethod)
  {
    return proto.PaymentMethodDTO.newBuilder().setId(paymentMethod.getId())
        .setName(paymentMethod.getName()).build();
  }

  private proto.DeliveryOptionDTO createDeliveryOptionDTO(
      DeliveryOption deliveryOption)
  {
    return proto.DeliveryOptionDTO.newBuilder().setId(deliveryOption.getId())
        .setName(deliveryOption.getName()).build();
  }

  private ArrayList<proto.ItemDTO> createItemDTOList(ArrayList<Item> items)
  {
    ArrayList<proto.ItemDTO> response = new ArrayList<>();
    for (int i = 0; i < items.size(); i++)
    {
      response.add(createItemDTO(items.get(i)));
    }
    return response;
  }

  private proto.ItemDTO createItemDTO(Item item)
  {
    return proto.ItemDTO.newBuilder().setItemId(item.getItemId())
        .setPrice(item.getPrice()).setDescription(item.getDescription())
        .setName(item.getName())
        .addAllCategory(createCategoryDTOList(item.getCategory()))
        .setQuantity(item.getQuantity()).setColour(item.getColour()).setSize(
            item.getSize()).build();
  }

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

  private proto.CategoryDTO createCategoryDTO(Category category)
  {
    return proto.CategoryDTO.newBuilder().setName(category.getName())
        .setDescription(category.getDescription())
        .setCategoryId(category.getCategoryId()).build();
  }

  private ArrayList<Item> fromItemDTOList(List<proto.ItemDTO> items)
  {
    ArrayList<Item> response = new ArrayList<>();
    for (int i = 0; i < items.size(); i++)
    {
      response.add(fromItemDTO(items.get(i)));
    }
    return response;
  }

  private Item fromItemDTO(proto.ItemDTO item)
  {
    return new Item(item.getName(), fromCategoryDTOList(item.getCategoryList()),
        item.getPrice(), item.getItemId(), item.getDescription(),
        item.getQuantity(), item.getColour(), item.getSize());
  }

  private ArrayList<Category> fromCategoryDTOList(List<proto.CategoryDTO> categories)
  {
    ArrayList<Category> response = new ArrayList<>();
    for (int i = 0; i < categories.size(); i++)
    {
      response.add(fromCategoryDTO(categories.get(i)));
    }
    return response;
  }

  private Category fromCategoryDTO(proto.CategoryDTO category)
  {
    return new Category(category.getName(), category.getDescription(),
        category.getCategoryId());
  }

  private LocalDate fromTimestamp(Timestamp time)
  {
    return LocalDateTime.ofEpochSecond(time.getSeconds(), time.getNanos(),
        ZoneOffset.UTC).toLocalDate();
  }

  private PaymentMethod fromPaymentMethodDTO(
      proto.PaymentMethodDTO paymentMethod)
  {
    return new PaymentMethod(paymentMethod.getId(), paymentMethod.getName());
  }

  private DeliveryOption fromDeliveryOptionDTO(
      proto.DeliveryOptionDTO deliveryOption)
  {
    return new DeliveryOption(deliveryOption.getId(), deliveryOption.getName());
  }

  public proto.GetOrderResponse fromBoolean(boolean deliveryMade)
  {
    return proto.GetOrderResponse.newBuilder().setSuccess(deliveryMade).build();
  }

  public proto.GetBooleanResponse createBooleanResponse(boolean refundMade)
  {
    return proto.GetBooleanResponse.newBuilder().setSuccess(refundMade).build();
  }
}
