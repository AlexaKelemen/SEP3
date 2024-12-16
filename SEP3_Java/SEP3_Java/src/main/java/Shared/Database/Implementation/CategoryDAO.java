package Shared.Database.Implementation;

import Shared.Database.DAOInterface.CategoryDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.Utlities.Category;

import java.sql.*;
import java.util.ArrayList;

public class CategoryDAO extends DatabaseFactory implements CategoryDAOInterface
{
  public static CategoryDAO instance;

  private CategoryDAO() throws SQLException
  {
    DriverManager.registerDriver(new org.postgresql.Driver());
  }

  public static synchronized CategoryDAO getInstance()
  {
    try
    {
      if (instance == null)
      {
        instance = new CategoryDAO();
      }
      return instance;
    }
    catch (SQLException e)
    {
      e.printStackTrace();
      return null;
    }
  }

  @Override public synchronized Category addCategory(Category category)
  {
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement(
          "insert into category(category_id, category_name, description) VALUES (?, ?, ?);");
      statement.setInt(1, category.getCategoryId());
      statement.setString(2, category.getName());
      statement.setString(3, category.getDescription());
      statement.executeUpdate();
      ResultSet generatedKeys = statement.getGeneratedKeys();
      if (generatedKeys.next())
      {
        category.setCategoryId(generatedKeys.getInt("category_id"));
      }
      else
      {
        throw new RuntimeException("No keys were generated.");
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while adding a category into the database: " + e.getMessage());
    }
    return getCategory(category.getCategoryId());
  }

  @Override public synchronized Category editCategory(Category category)
  {
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement(
          "UPDATE category\n" + "SET category_name = ?, description = ?\n"
              + "WHERE category_id = ?;");
      statement.setString(1, category.getName());
      statement.setString(2, category.getDescription());
      statement.setInt(3, category.getCategoryId());
      statement.executeUpdate();
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while updating a category in the database: " + e.getMessage());
    }
    return getCategory(category.getCategoryId());
  }

  @Override public synchronized void deleteCategory(int categoryId)
  {
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("DELETE FROM category\n"
          + "WHERE category_id = ?;");
      statement.setInt(1, categoryId);
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while deleting a category from a database: " + e.getMessage());
    }
  }

  @Override public Category getCategory(int categoryId)
  {
    Category response = null;
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT category_id, category_name, description\n"
          + "FROM category\n" + "WHERE category_id = ?;");
      statement.setInt(1, categoryId);
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        response = new Category();
        response.setCategoryId(rs.getInt("category_id"));
        response.setName(rs.getString("category_name"));
        response.setDescription(rs.getString("description"));
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting a category from the database: " + e.getMessage());
    }
    return response;
  }

  @Override public ArrayList<Category> getAllCategories()
  {
    ArrayList<Category> response = new ArrayList<>();
    try (Connection connection = super.establishConnection())
    {
      PreparedStatement statement = connection.prepareStatement("SELECT category_id, category_name, description\n"
          + "FROM category;");
      ResultSet rs = statement.executeQuery();
      while (rs.next())
      {
        Category element = new Category();
        element.setCategoryId(rs.getInt("category_id"));
        element.setName(rs.getString("category_name"));
        element.setDescription(rs.getString("description"));
        response.add(element);
      }
    }
    catch (SQLException e)
    {
      throw new RuntimeException("Something went wrong while getting all categories from the database: " + e.getMessage());
    }
    return response;
  }
}
