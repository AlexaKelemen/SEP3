package Shared.Database.DAOInterface;
import java.util.ArrayList;
import Shared.Entities.Card;

/**
 * Defines the operations that can be performed on card data in the database.
 */
public interface CardDAOInterface {
    /**
     *  Adds a new card to the database
     *
     * @param card the card entity to be added
     * @return the added card Entity
     */
    public Card addCard(Card card);

    /**
     * Edits an existing card in the database
     *
     * @param card the card entity with the updated information
     * @return the updated card Entity
     */
    public Card editCard(Card card);

    /**
     * Deletes a card from the database
     *
     * @param cardId the identifier of the card that has to be deleted
     *
     */
    public void deleteCard(int cardId);

    /**
     * gets a card from the database using its own identifier
     *
     * @param cardId the identifier of the card that has to be retrieved from the database
     * @return the card entity if found or null if not found
     */
    public Card getCard(int cardId);

    /**
     * retrieves all the cards from the database
     * @return a list of all the card entities
     */
    public ArrayList<Card> getAllCards();
}
