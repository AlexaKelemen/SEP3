package Shared;

import proto.GetOrderRequest;

public class ManagerImpl implements ManagerInterface
{
  public static ManagerImpl instance;

  private ManagerImpl()
  {
  }

  public static synchronized ManagerImpl getInstance()
  {
    if(instance == null)
    {
      instance = new ManagerImpl();
    }
    return instance;
  }
  @Override public boolean addOrder(GetOrderRequest order)
  {
    return false;
  }
}
