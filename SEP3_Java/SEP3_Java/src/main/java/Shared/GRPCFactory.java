package Shared;

import Shared.Entities.Item;
import Shared.Entities.Order;
import Shared.Entities.Utlities.Category;
import Shared.Entities.Utlities.DeliveryOption;
import Shared.Entities.Utlities.PaymentMethod;
import proto.GetOrderRequest;
import proto.ItemDTO;
import proto.CategoryDTO;
import proto.PaymentMethodDTO;
import proto.DeliveryOptionDTO;

import com.google.protobuf.Timestamp;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.ZoneOffset;
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

  public ArrayList<Item> fromItemDTOList(List<ItemDTO> items)
  {
    ArrayList<Item> response = new ArrayList<>();
    for (int i = 0; i < items.size(); i++)
    {
      response.add(fromItemDTO(items.get(i)));
    }
    return response;
  }

  public Item fromItemDTO(ItemDTO item)
  {
    return new Item(item.getName(), fromCategoryDTOList(item.getCategoryList()),
        item.getPrice(), item.getItemId(), item.getDescription(),
        item.getQuantity(), item.getColour());
  }

  public ArrayList<Category> fromCategoryDTOList(List<CategoryDTO> categories)
  {
    ArrayList<Category> response = new ArrayList<>();
    for (int i = 0; i < categories.size(); i++)
    {
      response.add(fromCategoryDTO(categories.get(i)));
    }
    return response;
  }

  public Category fromCategoryDTO(CategoryDTO category)
  {
    return new Category(category.getName(), category.getDescription(),
        category.getCategoryId());
  }

  public LocalDate fromTimestamp(Timestamp time)
  {
    return LocalDateTime.ofEpochSecond(time.getSeconds(), time.getNanos(),
        ZoneOffset.UTC).toLocalDate();
  }

  public PaymentMethod fromPaymentMethodDTO(PaymentMethodDTO paymentMethod)
  {
    return new PaymentMethod(paymentMethod.getId(), paymentMethod.getName());
  }

  public DeliveryOption fromDeliveryOptionDTO(DeliveryOptionDTO deliveryOption)
  {
    return new DeliveryOption(deliveryOption.getId(), deliveryOption.getName());
  }
}
