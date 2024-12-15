package Shared.Database.DAOInterface;

import Shared.Entities.Utlities.Category;

import java.util.ArrayList;

public interface CategoryDAOInterface
{
  public Category addCategory(Category category);
  public Category editCategory(Category category);
  public void deleteCategory(int categoryId);
  public Category getCategory(int categoryId);
  public ArrayList<Category> getAllCategories();
}
