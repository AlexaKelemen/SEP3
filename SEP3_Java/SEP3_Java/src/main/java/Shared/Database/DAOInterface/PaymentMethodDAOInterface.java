package Shared.Database.DAOInterface;

import Shared.Entities.Utlities.PaymentMethod;

import java.util.ArrayList;

/**
 * Interface for managing payment method-related database operations.
 * <p>
 * This interface defines methods for creating, updating, deleting, and retrieving
 * payment methods in the database, as well as retrieving all available payment methods.
 * </p>
 */
public interface PaymentMethodDAOInterface
{
  /**
   * Adds a new payment method to the database.
   *
   * @param paymentMethod the PaymentMethod object to be added.
   * @return the added PaymentMethod object
   */
  public PaymentMethod addPaymentMethod(PaymentMethod paymentMethod);

  /**
   * Deletes an existing payment method from the database
   *
   * @param paymentMethod the PaymentMethod object containing the updated information
   * @return the updated PaymentMethod object
   */
  public PaymentMethod editPaymentMethod(PaymentMethod paymentMethod);

  /**
   * Deletes an existing payment method from the database
   *
   * @param paymentMethodId the paymentMethod that gets deleted
   */
  public void deletePaymentMethod(int paymentMethodId);

  /**
   * Retrieves a specific payment method from the database using its ID.
   *
   * @param paymentMethodId the unique ID of the payment method to retrieve.
   * @return the  PaymentMethod object corresponding to the given ID, or null if no such payment method exists.
   */
  public PaymentMethod getPaymentMethod(int paymentMethodId);

  /**
   * Retrieves all the payment methods available from the database
   * @return a list containing all the payment methods available
   */
  public ArrayList<PaymentMethod> getAllPaymentMethods();
}
