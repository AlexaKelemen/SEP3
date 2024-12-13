package Shared.Entities.Utlities;

public class Category
{
  private String name;
  private String description;
  private int categoryId;

  public Category(String name)
  {
    this.name = name;
  }

  public Category(String name, String description, int categoryId)
  {
    this.name = name;
    this.description = description;
    this.categoryId = categoryId;
  }
  public String getName()
  {
    return name;
  }
}
