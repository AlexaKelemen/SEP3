package Shared.Database.DAOInterface;

public interface CreditDAOInterface
{
  public int addCredit(String username, int credit);
  public int editCredit(String username, int credit);
  public void deleteCredit(String username);
  public int getCredit(String username);
}
