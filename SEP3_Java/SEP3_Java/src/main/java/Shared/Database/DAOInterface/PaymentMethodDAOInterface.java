package Shared.Database.DAOInterface;

import Shared.Entities.Utlities.PaymentMethod;

import java.util.ArrayList;

public interface PaymentMethodDAOInterface
{
  public PaymentMethod addPaymentMethod(PaymentMethod paymentMethod);
  public PaymentMethod editPaymentMethod(PaymentMethod paymentMethod);
  public void deletePaymentMethod(int paymentMethodId);
  public PaymentMethod getPaymentMethod(int paymentMethodId);
  public ArrayList<PaymentMethod> getAllPaymentMethods();
}
