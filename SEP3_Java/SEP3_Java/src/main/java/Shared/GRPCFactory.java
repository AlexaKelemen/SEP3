package Shared;

import Shared.Entities.Item;
import Shared.Entities.Order;
import Shared.Entities.Utlities.Category;
import Shared.Entities.Utlities.DeliveryOption;
import Shared.Entities.Utlities.PaymentMethod;
import proto.*;

import com.google.protobuf.Timestamp;

import java.sql.Time;
import java.time.*;
import java.util.ArrayList;
import java.util.List;

public class GRPCFactory
{
  public Order fromOrderRequest(GetOrderRequest request)
  {
    return new Order(fromItemDTOList(request.getItemsList()),
        request.getTotalAmount(), request.getOrderId(),
        fromTimestamp(request.getPlacedOn()),
        fromPaymentMethodDTO(request.getPaymentMethod()),
        fromDeliveryOptionDTO(request.getDeliveryOption()),
        request.getPlacedBy(), request.getToAddress());

  }

  public Order getOrderFromGetReturnRequest(GetReturnOrderRequest request)
  {
    return fromOrderDTO(request.getOrder());
  }

  public int getCreditFromGetReturnRequest(GetReturnOrderRequest request)
  {
    return request.getCredit();
  }

  public Order fromGetRefundOrderRequest(GetRefundOrderRequest request)
  {
    return fromOrderDTO(request.getOrder());
  }

  private Order fromOrderDTO(OrderDTO order)
  {
    return new Order(fromItemDTOList(order.getItemsList()),
        order.getTotalAmount(), order.getOrderId(),
        fromTimestamp(order.getPlacedOn()),
        fromPaymentMethodDTO(order.getPaymentMethod()),
        fromDeliveryOptionDTO(order.getDeliveryOption()),
        order.getPlacedBy(), order.getToAddress());
  }

  public String fromGetAllOrdersRequest(GetAllOrdersRequest request)
  {
    return request.getUser();
  }

  public GetAllOrdersResponse fromOrder(ArrayList<Order> order)
  {
    return proto.GetAllOrdersResponse.newBuilder().addAllOrders(createListOfOrderDTOs(order)).build();
  }

  private ArrayList<OrderDTO> createListOfOrderDTOs(ArrayList<Order> orders)
  {
    ArrayList<OrderDTO> response = new ArrayList<>();
    for (int i = 0; i < orders.size(); i++)
    {
      response.add(createOrderDTO(orders.get(i)));
    }
    return response;
  }

  private OrderDTO createOrderDTO(Order order)
  {
    return OrderDTO.newBuilder().setPlacedOn(createTimestamp(order.getDate()))
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

  private PaymentMethodDTO createPaymentMethodDTO(PaymentMethod paymentMethod)
  {
    return PaymentMethodDTO.newBuilder().setId(paymentMethod.getId())
        .setName(paymentMethod.getName()).build();
  }

  private DeliveryOptionDTO createDeliveryOptionDTO(
      DeliveryOption deliveryOption)
  {
    return proto.DeliveryOptionDTO.newBuilder().setId(deliveryOption.getId())
        .setName(deliveryOption.getName()).build();
  }

  private ArrayList<ItemDTO> createItemDTOList(ArrayList<Item> items)
  {
    ArrayList<ItemDTO> response = new ArrayList<>();
    for (int i = 0; i < items.size(); i++)
    {
      response.add(createItemDTO(items.get(i)));
    }
    return response;
  }

  private ItemDTO createItemDTO(Item item)
  {
    return ItemDTO.newBuilder().setItemId(item.getItemId())
        .setPrice(item.getPrice()).setDescription(item.getDescription())
        .setName(item.getName())
        .addAllCategory(createCategoryDTOList(item.getCategory()))
        .setQuantity(item.getQuantity()).setColour(item.getColour()).build();
  }

  private ArrayList<CategoryDTO> createCategoryDTOList(
      ArrayList<Category> categories)
  {
    ArrayList<CategoryDTO> response = new ArrayList<>();
    for (int i = 0; i < categories.size(); i++)
    {
      response.add(createCategoryDTO(categories.get(i)));
    }
    return response;
  }

  private CategoryDTO createCategoryDTO(Category category)
  {
    return CategoryDTO.newBuilder().setName(category.getName())
        .setDescription(category.getDescription())
        .setCategoryId(category.getCategoryId()).build();
  }

  private ArrayList<Item> fromItemDTOList(List<ItemDTO> items)
  {
    ArrayList<Item> response = new ArrayList<>();
    for (int i = 0; i < items.size(); i++)
    {
      response.add(fromItemDTO(items.get(i)));
    }
    return response;
  }

  private Item fromItemDTO(ItemDTO item)
  {
    return new Item(item.getName(), fromCategoryDTOList(item.getCategoryList()),
        item.getPrice(), item.getItemId(), item.getDescription(),
        item.getQuantity(), item.getColour());
  }

  private ArrayList<Category> fromCategoryDTOList(List<CategoryDTO> categories)
  {
    ArrayList<Category> response = new ArrayList<>();
    for (int i = 0; i < categories.size(); i++)
    {
      response.add(fromCategoryDTO(categories.get(i)));
    }
    return response;
  }

  private Category fromCategoryDTO(CategoryDTO category)
  {
    return new Category(category.getName(), category.getDescription(),
        category.getCategoryId());
  }

  private LocalDate fromTimestamp(Timestamp time)
  {
    return LocalDateTime.ofEpochSecond(time.getSeconds(), time.getNanos(),
        ZoneOffset.UTC).toLocalDate();
  }

  private PaymentMethod fromPaymentMethodDTO(PaymentMethodDTO paymentMethod)
  {
    return new PaymentMethod(paymentMethod.getId(), paymentMethod.getName());
  }

  private DeliveryOption fromDeliveryOptionDTO(DeliveryOptionDTO deliveryOption)
  {
    return new DeliveryOption(deliveryOption.getId(), deliveryOption.getName());
  }

  public GetOrderResponse fromBoolean(boolean deliveryMade)
  {
    return GetOrderResponse.newBuilder().setSuccess(deliveryMade).build();
  }

  public GetBooleanResponse createBooleanResponse(boolean refundMade)
  {
    return GetBooleanResponse.newBuilder().setSuccess(refundMade).build();
  }
}
