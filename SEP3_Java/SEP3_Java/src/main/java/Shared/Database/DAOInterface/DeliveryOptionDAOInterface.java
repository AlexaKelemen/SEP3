package Shared.Database.DAOInterface;

import Shared.Entities.Utlities.DeliveryOption;

import java.util.ArrayList;

public interface DeliveryOptionDAOInterface
{
  public DeliveryOption addDeliveryOption(DeliveryOption deliveryOption);
  public DeliveryOption editDeliveryOption(DeliveryOption deliveryOption);
  public void deleteDeliveryOption(int deliveryOptionId);
  public DeliveryOption getDeliveryOption(int deliveryOption);
  public ArrayList<DeliveryOption> getAllDeliveryOptions();
}
