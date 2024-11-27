package Database.DAOInterface;
import java.util.ArrayList;
import Entities.Card;


public interface CardDAOInterface {

    public Card addCard(Card card);
    public Card editCard(Card card);
    public void deleteCard(int cardId);
    public Card getCard(int cardId);
    public ArrayList<Card> getAllCards();
}
