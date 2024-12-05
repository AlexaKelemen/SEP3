package Database.Implementation;

import Database.DAOInterface.CardDAOInterface;
import Database.DatabaseFactory;
import Entities.Card;

import java.sql.*;
import java.time.LocalDate;
import java.time.YearMonth;
import java.util.ArrayList;
import java.util.List;

import Entities.User;
import org.springframework.stereotype.Service;



public class CardDAO extends DatabaseFactory implements CardDAOInterface{
    private static CardDAO instance;

    private CardDAO() throws SQLException {
        DriverManager.registerDriver(new org.postgresql.Driver()); // Register PostgreSQL driver
    }

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
    public synchronized Card addCard(Card card) {
        try (Connection connection = super.establishConnection()) {
            PreparedStatement statement = connection.prepareStatement(
                    "INSERT INTO card (card_number, expiration_date, cvc, f_name, l_name, username) VALUES (?, ?, ?, ?, ?, ?);", PreparedStatement.RETURN_GENERATED_KEYS
            );
            statement.setString(1, card.getCardNumber());
            statement.setDate(2, convertToSqlDate(card.getExpirationDate()));
            statement.setString(3, card.getCvc());
            statement.setString(4, card.getFName());
            statement.setString(5, card.getLName());
            statement.setString(6, card.getUsername());
            statement.executeUpdate();
            ResultSet generatedKeys = statement.getGeneratedKeys();
            if(generatedKeys.next())
            {
                card.setCardId(generatedKeys.getInt("cardId"));
            }
        } catch (SQLException e) {
            throw new RuntimeException("Why don't you try again, huh? Cause something went wrong during adding a card to the database: " + e.getMessage());
        }
        return getCard(card.getCardId());
    }
    @Override
    public synchronized Card editCard(Card card) {
        try (Connection connection = super.establishConnection()) {
            PreparedStatement statement = connection.prepareStatement(
                    "UPDATE card SET card_number = ?, expiration_date = ?, cvc = ?, f_name = ?, l_name = ?, username = ? WHERE card_id = ?;"
            );
            statement.setString(1, card.getCardNumber());
            statement.setDate(2, convertToSqlDate(card.getExpirationDate()));
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

    private Date convertToSqlDate(LocalDate date)
    {
        YearMonth helper = YearMonth.of(date.getYear()-1900, date.getMonthValue());
        Date returnDate = new Date(date.getYear() - 1900, date.getMonthValue()-1, helper.atEndOfMonth().getDayOfMonth());
        return returnDate;
    }


}
