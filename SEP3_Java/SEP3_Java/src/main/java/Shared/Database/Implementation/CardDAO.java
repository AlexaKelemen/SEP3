package Shared.Database.Implementation;

import Shared.Database.DAOInterface.CardDAOInterface;
import Shared.Database.DatabaseFactory;
import Shared.Entities.Card;

import java.sql.*;
import java.time.LocalDate;
import java.time.YearMonth;
import java.util.ArrayList;

/**
 * Handles database operations related to Card entities.
 */

public class CardDAO extends DatabaseFactory implements CardDAOInterface{
    /** Singleton instance of the CardDAO class. */
    private static CardDAO instance;
    /**
     * Private constructor to enforce singleton pattern.
     * Registers the PostgreSQL driver.
     *
     * @throws SQLException if an error occurs during driver registration.
     */
    private CardDAO() throws SQLException {
        DriverManager.registerDriver(new org.postgresql.Driver()); // Register PostgreSQL driver
    }
    /**
     * Returns the singleton instance of the CardDAO class.
     *
     * @return CardDAO instance.
     */
    public synchronized static CardDAO getInstance() {
        try {
            if (instance == null) {
                instance = new CardDAO();
            }
            return instance;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }
    /**
     * Adds a new card to the database.
     *
     * @param card the Card object to add.
     * @return the Card object with updated card ID.
     */
    public synchronized Card addCard(Card card) {
        try (Connection connection = super.establishConnection()) {
            PreparedStatement statement = connection.prepareStatement(
                    "INSERT INTO card (card_number, expiration_date, cvc, f_name, l_name, username) VALUES (?, ?, ?, ?, ?, ?);", PreparedStatement.RETURN_GENERATED_KEYS
            );
            statement.setString(1, card.getCardNumber());
            statement.setDate(2, convertToSqlCardDate(card.getExpirationDate()));
            statement.setString(3, card.getCvc());
            statement.setString(4, card.getFName());
            statement.setString(5, card.getLName());
            statement.setString(6, card.getUsername());
            statement.executeUpdate();
            ResultSet generatedKeys = statement.getGeneratedKeys();
            if(generatedKeys.next())
            {
                card.setCardId(generatedKeys.getInt("card_id"));
            }
            else
            {
                throw new RuntimeException("No keys were generated.");
            }
        } catch (SQLException e) {
            throw new RuntimeException("Why don't you try again, huh? Cause something went wrong during adding a card to the database: " + e.getMessage());
        }
        return getCard(card.getCardId());
    }
    /**
     * Updates an existing card in the database.
     *
     * @param card the Card object with updated details.
     * @return the updated Card object.
     */
    @Override
    public synchronized Card editCard(Card card) {
        try (Connection connection = super.establishConnection()) {
            PreparedStatement statement = connection.prepareStatement(
                    "UPDATE card SET card_number = ?, expiration_date = ?, cvc = ?, f_name = ?, l_name = ?, username = ? WHERE card_id = ?;"
            );
            statement.setString(1, card.getCardNumber());
            statement.setDate(2, convertToSqlCardDate(card.getExpirationDate()));
            statement.setString(3, card.getCvc());
            statement.setString(4, card.getFName());
            statement.setString(5, card.getLName());
            statement.setString(6, card.getUsername());
            statement.setInt(7, card.getCardId());
            statement.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException("Something went wrong during editing a card in the database: " + e.getMessage());
        }
        return getCard(card.getCardId());
    }
    /**
     * Deletes a card from the database.
     *
     * @param cardId the ID of the card to delete.
     */
    @Override
    public synchronized void deleteCard(int cardId) {
        try (Connection connection = super.establishConnection()) {
            String query = "DELETE FROM card WHERE card_id = ?";
            try (PreparedStatement statement = connection.prepareStatement(query)) {
                statement.setInt(1, cardId);
                statement.executeUpdate();
            }
        } catch (SQLException e) {
            throw new RuntimeException("Probably not your fault, but still your fault. So sorry but something went wrong during deleting a card from the database.", e);
        }
    }
    /**
     * Retrieves a specific card from the database by its ID.
     *
     * @param cardId the ID of the card to retrieve.
     * @return the Card object corresponding to the given ID, or null if not found.
     */
    @Override
    public Card getCard(int cardId) {
        Card response = null;
        String query = "SELECT card_id, card_number, expiration_date, cvc, f_name, l_name, username FROM card WHERE card_id = ?";

        try (Connection connection = super.establishConnection()) {
            PreparedStatement statement = connection.prepareStatement(query);
            statement.setInt(1, cardId);

            ResultSet rs = statement.executeQuery();
            while (rs.next()) {
                int id = rs.getInt("card_id");
                String cardNumber = rs.getString("card_number");
                Date expirationDate = rs.getDate("expiration_date");
                String cvc = rs.getString("cvc");
                String fName = rs.getString("f_name");
                String lName = rs.getString("l_name");
                String username = rs.getString("username");

                response = new Card(id, cardNumber, expirationDate.toLocalDate(), cvc, fName, lName, username);
            }
        } catch (SQLException e) {
            throw new RuntimeException("Something went wrong during getting a card from the database: " + e.getMessage(), e);
        }

        return response;
    }
    /**
     * Retrieves all cards from the database.
     *
     * @return a list of all Card objects.
     */
    @Override
    public ArrayList<Card> getAllCards()
    {
        ArrayList<Card> allCards = new ArrayList<>();
        try(Connection connection = super.establishConnection())
        {
            PreparedStatement statement = connection.prepareStatement("SELECT card_id, card_number, expiration_date, cvc, f_name, l_name, username FROM card;");
            ResultSet rs = statement.executeQuery();
            while (rs.next())
            {
                int id = rs.getInt("card_id");
                String cardNumber = rs.getString("card_number");
                Date expirationDate = rs.getDate("expiration_date");
                String cvc = rs.getString("cvc");
                String fName = rs.getString("f_name");
                String lName = rs.getString("l_name");
                String username = rs.getString("username");

                Card element = new Card(id, cardNumber, expirationDate.toLocalDate(), cvc, fName, lName, username);
                allCards.add(element);
            }
        }
        catch (SQLException e)
        {
            throw new RuntimeException("Something went wrong while fetching all cards from the database: " + e.getMessage());
        }
        return allCards;
    }


}
