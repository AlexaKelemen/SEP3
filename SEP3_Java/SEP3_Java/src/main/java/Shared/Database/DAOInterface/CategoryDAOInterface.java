package Shared.Database.DAOInterface;

import Shared.Entities.Utlities.Category;

import java.util.ArrayList;
/**
 * Defines the operations that can be performed on category data in the database.
 */
public interface CategoryDAOInterface
{
  /**
   * Adds a new category to the database.
   *
   * @param category the category entity to be added.
   * @return the added category entity.
   */
  public Category addCategory(Category category);

  /**
   *  Edits an existing category in the database
   *
   * @param category the category entity with updated information
   * @return the updated category entity
   */
  public Category editCategory(Category category);

  /**
   * Deletes a category from the database
   *
   * @param categoryId the identifier of the category to be deleted from the database
   */
  public void deleteCategory(int categoryId);
  /**
   * Retrieves a category from the database by its unique identifier.
   *
   * @param categoryId the unique identifier of the category.
   * @return the category entity if found, or null if not found.
   */
  public Category getCategory(int categoryId);
  /**
   * Retrieves all categories from the database.
   *
   * @return a list of all category entities.
   */
  public ArrayList<Category> getAllCategories();
}
