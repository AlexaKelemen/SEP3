package Shared.Database.DAOInterface;

import Shared.Entities.Utlities.DeliveryOption;

import java.util.ArrayList;
/**
 * Interface for managing delivery option-related database operations.
 * <p>
 * This interface defines methods to create, update, delete, and retrieve
 * delivery options in the database. It provides functionalities to manage
 * delivery option records efficiently.
 * </p>
 */
public interface DeliveryOptionDAOInterface
{
  /**
   * Adds a new delivery option to the database.
   *
   * @param deliveryOption the deliveryOption object to be added.
   * @return the added deliveryOption object
   */
  public DeliveryOption addDeliveryOption(DeliveryOption deliveryOption);

  /**
   * edits an existing delivery option in the database
   *
   * @param deliveryOption the @link DeliveryOption object containing updated information.
   * @return the @link deliveryOption object
   * */
  public DeliveryOption editDeliveryOption(DeliveryOption deliveryOption);

  /**
   * deletes a delivery option from the database
   * @param deliveryOptionId the identifier of the delivery option that is deleted
   */
  public void deleteDeliveryOption(int deliveryOptionId);

  /**
   *
   * @param deliveryOption  an identifier or criteria used to locate the delivery option
   * @return the {@link DeliveryOption} object corresponding to the given identifier or criteria.
   */
  public DeliveryOption getDeliveryOption(int deliveryOption);

  /**
   * gets all the delivery options available in the database
   *
   * @return an array list with all the delivery options
   */
  public ArrayList<DeliveryOption> getAllDeliveryOptions();
}
